using System;
using System.Collections;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using log4net;
using Road.Base.Packets;

namespace Game.Base.Packets
{
	// Token: 0x0200001C RID: 28
	public class StreamProcessor : IStreamProcessor
	{
		// Token: 0x060000F8 RID: 248 RVA: 0x00005870 File Offset: 0x00003A70
		public StreamProcessor(BaseClient client)
		{
			this.m_client = client;
			this.m_client.resetKey();
			this.m_tcpSendBuffer = client.SendBuffer;
			this.m_tcpQueue = new Queue(256);
			this.send_event = new SocketAsyncEventArgs
			{
				UserToken = this
			};
			this.send_event.Completed += StreamProcessor.AsyncTcpSendCallback;
			this.send_event.SetBuffer(this.m_tcpSendBuffer, 0, 0);
			this.send_fsm = new FSM(2059198199, 1501, "send_fsm");
			this.receive_fsm = new FSM(2059198199, 1501, "receive_fsm");
			this.SetKey(StreamProcessor.KEY);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000592C File Offset: 0x00003B2C
		public void SetKey(byte[] temp)
		{
			this.SEND_KEY = new byte[8];
			this.RECEIVE_KEY = new byte[8];
			Buffer.BlockCopy(temp, 0, this.SEND_KEY, 0, 8);
			Buffer.BlockCopy(temp, 0, this.RECEIVE_KEY, 0, 8);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00005964 File Offset: 0x00003B64
		public void SetFsm(int adder, int muliter)
		{
			this.send_fsm.Setup(adder, muliter);
			this.receive_fsm.Setup(adder, muliter);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00005980 File Offset: 0x00003B80
		public void SendTCP(GSPacketIn packet)
		{
			packet.WriteHeader();
			packet.Offset = 0;
			if (this.m_client.Socket.Connected)
			{
				try
				{
					Statistics.BytesOut += (long)packet.Length;
					Statistics.PacketsOut += 1L;
					lock (this.m_tcpQueue.SyncRoot)
					{
						this.m_tcpQueue.Enqueue(packet);
						if (this.m_sendingTcp)
						{
							return;
						}
						this.m_sendingTcp = true;
					}
					if (this.m_client.AsyncPostSend)
					{
						ThreadPool.QueueUserWorkItem(new WaitCallback(StreamProcessor.AsyncSendTcpImp), this);
					}
					else
					{
						StreamProcessor.AsyncTcpSendCallback(this, this.send_event);
					}
				}
				catch (Exception ex)
				{
					StreamProcessor.log.Error("SendTCP", ex);
					StreamProcessor.log.WarnFormat("It seems <{0}> went linkdead. Closing connection. (SendTCP, {1}: {2})", this.m_client, ex.GetType(), ex.Message);
					this.m_client.Disconnect();
				}
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00005A94 File Offset: 0x00003C94
		private static void AsyncSendTcpImp(object state)
		{
			StreamProcessor streamProcessor = state as StreamProcessor;
			if (streamProcessor != null)
			{
				BaseClient client = streamProcessor.m_client;
				try
				{
					StreamProcessor.AsyncTcpSendCallback(streamProcessor, streamProcessor.send_event);
				}
				catch (Exception exception)
				{
					StreamProcessor.log.Error("AsyncSendTcpImp", exception);
					client.Disconnect();
				}
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00005AEC File Offset: 0x00003CEC
		private static void AsyncTcpSendCallback(object sender, SocketAsyncEventArgs e)
		{
			StreamProcessor streamProcessor = (StreamProcessor)e.UserToken;
			BaseClient client = streamProcessor.m_client;
			try
			{
				Queue tcpQueue = streamProcessor.m_tcpQueue;
				if (tcpQueue != null && client.Socket.Connected)
				{
					int bytesTransferred = e.BytesTransferred;
					byte[] tcpSendBuffer = streamProcessor.m_tcpSendBuffer;
					int num = 0;
					if (bytesTransferred != e.Count && streamProcessor.m_sendBufferLength > bytesTransferred)
					{
						num = streamProcessor.m_sendBufferLength - bytesTransferred;
						Array.Copy(tcpSendBuffer, bytesTransferred, tcpSendBuffer, 0, num);
					}
					e.SetBuffer(0, 0);
					int num2 = streamProcessor.m_firstPkgOffset;
					lock (tcpQueue.SyncRoot)
					{
						int num3 = 0;
						if (tcpQueue.Count > 0)
						{
							PacketIn packetIn;
							do
							{
								packetIn = (PacketIn)tcpQueue.Peek();
								int num4 = (client.Encryted ? packetIn.CopyTo3(tcpSendBuffer, num, num2, client.SEND_KEY, ref client.numPacketProcces) : packetIn.CopyTo(tcpSendBuffer, num, num2));
								if (num4 == 0)
								{
									num3++;
								}
								else
								{
									num3 = 0;
								}
								num2 += num4;
								num += num4;
								if (packetIn.Length <= num2)
								{
									tcpQueue.Dequeue();
									num2 = 0;
									if (client.Encryted)
									{
										streamProcessor.send_fsm.UpdateState();
										packetIn.isSended = true;
									}
								}
								if (tcpSendBuffer.Length == num)
								{
									break;
								}
								if (num3 > 5)
								{
									goto IL_142;
								}
							}
							while (tcpQueue.Count > 0);
							goto IL_14C;
							IL_142:
							packetIn.isSended = true;
						}
						IL_14C:
						streamProcessor.m_firstPkgOffset = num2;
						if (num <= 0)
						{
							streamProcessor.m_sendingTcp = false;
							return;
						}
					}
					streamProcessor.m_sendBufferLength = num;
					e.SetBuffer(0, num);
					if (!client.SendAsync(e))
					{
						StreamProcessor.AsyncTcpSendCallback(sender, e);
					}
				}
			}
			catch (Exception ex)
			{
				StreamProcessor.log.Error("AsyncTcpSendCallback", ex);
				StreamProcessor.log.WarnFormat("It seems <{0}> went linkdead. Closing connection. (SendTCP, {1}: {2})", client, ex.GetType(), ex.Message);
				client.Disconnect();
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00005CF8 File Offset: 0x00003EF8
		public void ReceiveBytes(int numBytes)
		{
			lock (this)
			{
				byte[] packetBuf = this.m_client.PacketBuf;
				int num = this.m_client.PacketBufSize + numBytes;
				if (num < 20)
				{
					this.m_client.PacketBufSize = num;
				}
				else
				{
					this.m_client.PacketBufSize = 0;
					int num2 = 0;
					int num4;
					do
					{
						int num3 = 0;
						if (this.m_client.Encryted)
						{
							byte[] param = StreamProcessor.cloneArrary(this.m_client.RECEIVE_KEY, 8);
							while (num2 + 4 < num)
							{
								byte[] array = StreamProcessor.decryptBytes(packetBuf, num2, 8, param);
								if (((int)array[0] << 8) + (int)array[1] == 29099)
								{
									num3 = ((int)array[2] << 8) + (int)array[3];
									break;
								}
								num2++;
							}
						}
						else
						{
							while (num2 + 4 < num)
							{
								if (((int)packetBuf[num2] << 8) + (int)packetBuf[num2 + 1] == 29099)
								{
									num3 = ((int)packetBuf[num2 + 2] << 8) + (int)packetBuf[num2 + 3];
									break;
								}
								num2++;
							}
						}
						if ((num3 != 0 && num3 < 20) || num3 > 8192)
						{
							goto IL_19A;
						}
						num4 = num - num2;
						if (num4 < num3 || num3 == 0)
						{
							goto IL_1C0;
						}
						GSPacketIn gSPacketIn = new GSPacketIn(new byte[8192], 8192);
						if (this.m_client.Encryted)
						{
							gSPacketIn.CopyFrom3(packetBuf, num2, 0, num3, this.m_client.RECEIVE_KEY);
						}
						else
						{
							gSPacketIn.CopyFrom(packetBuf, num2, 0, num3);
						}
						gSPacketIn.ReadHeader();
						try
						{
							this.m_client.OnRecvPacket(gSPacketIn);
						}
						catch (Exception exception)
						{
							if (StreamProcessor.log.IsErrorEnabled)
							{
								StreamProcessor.log.Error("HandlePacket(pak)", exception);
							}
						}
						num2 += num3;
					}
					while (num - 1 > num2);
					goto IL_1D6;
					IL_19A:
					this.m_client.PacketBufSize = 0;
					if (this.m_client.Strict)
					{
						this.m_client.Disconnect();
					}
					return;
					IL_1C0:
					Array.Copy(packetBuf, num2, packetBuf, 0, num4);
					this.m_client.PacketBufSize = num4;
					IL_1D6:
					if (num - 1 == num2)
					{
						packetBuf[0] = packetBuf[num2];
						this.m_client.PacketBufSize = 1;
					}
				}
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00005F30 File Offset: 0x00004130
		public static byte[] cloneArrary(byte[] arr, int length = 8)
		{
			byte[] array = new byte[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = arr[i];
			}
			return array;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00005F58 File Offset: 0x00004158
		public static string PrintArray(byte[] arr, int length = 8)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[");
			for (int i = 0; i < length; i++)
			{
				stringBuilder.AppendFormat("{0} ", arr[i]);
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00005FAC File Offset: 0x000041AC
		public static string PrintArray(byte[] arr, int first, int length)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[");
			for (int i = first; i < first + length; i++)
			{
				stringBuilder.AppendFormat("{0} ", arr[i]);
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00006000 File Offset: 0x00004200
		public static byte[] decryptBytes(byte[] param1, int curOffset, int param2, byte[] param3)
		{
			byte[] array = new byte[param2];
			for (int i = 0; i < param2; i++)
			{
				array[i] = param1[i];
			}
			for (int j = 0; j < param2; j++)
			{
				if (j > 0)
				{
					param3[j % 8] = (byte)((int)(param3[j % 8] + param1[curOffset + j - 1]) ^ j);
					array[j] = (param1[curOffset + j] - param1[curOffset + j - 1]) ^ param3[j % 8];
				}
				else
				{
					array[0] = param1[curOffset] ^ param3[0];
				}
			}
			return array;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00006070 File Offset: 0x00004270
		public void Dispose()
		{
			this.send_event.Dispose();
			this.m_tcpQueue.Clear();
		}

		// Token: 0x04000060 RID: 96
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000061 RID: 97
		protected readonly BaseClient m_client;

		// Token: 0x04000062 RID: 98
		private FSM send_fsm;

		// Token: 0x04000063 RID: 99
		private FSM receive_fsm;

		// Token: 0x04000064 RID: 100
		private SocketAsyncEventArgs send_event;

		// Token: 0x04000065 RID: 101
		protected byte[] m_tcpSendBuffer;

		// Token: 0x04000066 RID: 102
		protected Queue m_tcpQueue;

		// Token: 0x04000067 RID: 103
		protected bool m_sendingTcp;

		// Token: 0x04000068 RID: 104
		protected int m_firstPkgOffset;

		// Token: 0x04000069 RID: 105
		protected int m_sendBufferLength;

		// Token: 0x0400006A RID: 106
		private byte[] SEND_KEY;

		// Token: 0x0400006B RID: 107
		private byte[] RECEIVE_KEY;

		// Token: 0x0400006C RID: 108
		public static byte[] KEY = new byte[] { 174, 191, 86, 120, 171, 205, 239, 241 };
	}
}
