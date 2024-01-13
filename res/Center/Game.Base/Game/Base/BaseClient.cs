using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using Game.Base.Packets;
using log4net;

namespace Game.Base
{
	// Token: 0x02000006 RID: 6
	public class BaseClient
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600001B RID: 27 RVA: 0x00002910 File Offset: 0x00000B10
		// (remove) Token: 0x0600001C RID: 28 RVA: 0x00002948 File Offset: 0x00000B48
		public event ClientEventHandle Connected;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600001D RID: 29 RVA: 0x00002980 File Offset: 0x00000B80
		// (remove) Token: 0x0600001E RID: 30 RVA: 0x000029B8 File Offset: 0x00000BB8
		public event ClientEventHandle Disconnected;

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000029ED File Offset: 0x00000BED
		// (set) Token: 0x06000020 RID: 32 RVA: 0x000029F5 File Offset: 0x00000BF5
		public bool AsyncPostSend { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000029FE File Offset: 0x00000BFE
		// (set) Token: 0x06000022 RID: 34 RVA: 0x00002A06 File Offset: 0x00000C06
		public bool Encryted { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002A0F File Offset: 0x00000C0F
		public bool IsConnected
		{
			get
			{
				return this.m_isConnected == 1;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002A1A File Offset: 0x00000C1A
		public byte[] PacketBuf
		{
			get
			{
				return this.m_readBuffer;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002A22 File Offset: 0x00000C22
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00002A2A File Offset: 0x00000C2A
		public int PacketBufSize
		{
			get
			{
				return this.m_readBufEnd;
			}
			set
			{
				this.m_readBufEnd = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002A33 File Offset: 0x00000C33
		public byte[] SendBuffer
		{
			get
			{
				return this.m_sendBuffer;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002A3B File Offset: 0x00000C3B
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00002A43 File Offset: 0x00000C43
		public Socket Socket
		{
			get
			{
				return this.m_sock;
			}
			set
			{
				this.m_sock = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002A4C File Offset: 0x00000C4C
		// (set) Token: 0x0600002B RID: 43 RVA: 0x00002A54 File Offset: 0x00000C54
		public bool Strict { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002A60 File Offset: 0x00000C60
		public string TcpEndpoint
		{
			get
			{
				Socket sock = this.m_sock;
				string result;
				if (sock != null && sock.Connected && sock.RemoteEndPoint != null)
				{
					result = sock.RemoteEndPoint.ToString();
				}
				else
				{
					result = "not connected";
				}
				return result;
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002AB4 File Offset: 0x00000CB4
		public BaseClient(byte[] readBuffer, byte[] sendBuffer)
		{
			this.IsClientPacketSended = true;
			this.m_readBuffer = readBuffer;
			this.m_sendBuffer = sendBuffer;
			this.m_readBufEnd = 0;
			this.rc_event = new SocketAsyncEventArgs();
			this.rc_event.Completed += this.RecvEventCallback;
			this.m_processor = new StreamProcessor(this);
			this.Encryted = false;
			this.Strict = true;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002B20 File Offset: 0x00000D20
		protected void CloseConnections()
		{
			if (this.m_sock != null)
			{
				try
				{
					this.m_sock.Shutdown(SocketShutdown.Both);
				}
				catch (Exception e)
				{
					if (BaseClient.log.IsErrorEnabled)
					{
						BaseClient.log.Error("CloseConnections", e);
					}
				}
				try
				{
					this.m_sock.Close();
				}
				catch (Exception e2)
				{
					if (BaseClient.log.IsErrorEnabled)
					{
						BaseClient.log.Error("CloseConnections", e2);
					}
				}
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002BAC File Offset: 0x00000DAC
		public virtual bool Connect(Socket connectedSocket)
		{
			this.m_sock = connectedSocket;
			bool result;
			if (!this.m_sock.Connected)
			{
				result = false;
			}
			else
			{
				if (Interlocked.Exchange(ref this.m_isConnected, 1) == 0)
				{
					this.OnConnect();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002BE8 File Offset: 0x00000DE8
		public virtual void Disconnect()
		{
			BaseClient.log.Debug(new StackTrace().ToString());
			try
			{
				if (Interlocked.Exchange(ref this.m_isConnected, 0) == 1)
				{
					this.CloseConnections();
					this.OnDisconnect();
					this.rc_event.Dispose();
					this.m_processor.Dispose();
				}
			}
			catch (Exception exception)
			{
				if (BaseClient.log.IsErrorEnabled)
				{
					BaseClient.log.Error("Exception", exception);
				}
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002C6C File Offset: 0x00000E6C
		public virtual void DisplayMessage(string msg)
		{
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002C6E File Offset: 0x00000E6E
		protected virtual void OnConnect()
		{
			if (Interlocked.Exchange(ref this.m_isConnected, 1) == 0 && this.Connected != null)
			{
				this.Connected(this);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002C92 File Offset: 0x00000E92
		protected virtual void OnDisconnect()
		{
			if (this.Disconnected != null)
			{
				this.Disconnected(this);
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002CA8 File Offset: 0x00000EA8
		public virtual void OnRecv(int num_bytes)
		{
			this.m_processor.ReceiveBytes(num_bytes);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002CB6 File Offset: 0x00000EB6
		public virtual void OnRecvPacket(GSPacketIn pkg)
		{
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002CB8 File Offset: 0x00000EB8
		public void ReceiveAsync()
		{
			this.ReceiveAsyncImp(this.rc_event);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002CC8 File Offset: 0x00000EC8
		private void ReceiveAsyncImp(SocketAsyncEventArgs e)
		{
			if (this.m_sock != null && this.m_sock.Connected)
			{
				int length = this.m_readBuffer.Length;
				if (this.m_readBufEnd >= length)
				{
					if (BaseClient.log.IsErrorEnabled)
					{
						BaseClient.log.Error(this.TcpEndpoint + " disconnected because of buffer overflow!");
						BaseClient.log.Error(string.Concat(new object[] { "m_pBufEnd=", this.m_readBufEnd, "; buf size=", length }));
						BaseClient.log.Error(this.m_readBuffer);
					}
					this.Disconnect();
					return;
				}
				e.SetBuffer(this.m_readBuffer, this.m_readBufEnd, length - this.m_readBufEnd);
				if (!this.m_sock.ReceiveAsync(e))
				{
					this.RecvEventCallback(this.m_sock, e);
					return;
				}
			}
			else
			{
				this.Disconnect();
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002DB8 File Offset: 0x00000FB8
		private void RecvEventCallback(object sender, SocketAsyncEventArgs e)
		{
			try
			{
				int bytesTransferred = e.BytesTransferred;
				if (bytesTransferred > 0)
				{
					this.OnRecv(bytesTransferred);
					this.ReceiveAsyncImp(e);
				}
				else
				{
					BaseClient.log.InfoFormat("Disconnecting client ({0}), received bytes={1}", this.TcpEndpoint, bytesTransferred);
					this.Disconnect();
				}
			}
			catch (Exception exception)
			{
				BaseClient.log.ErrorFormat("{0} RecvCallback:{1}", this.TcpEndpoint, exception);
				this.Disconnect();
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002E34 File Offset: 0x00001034
		public virtual void resetKey()
		{
			this.RECEIVE_KEY = StreamProcessor.cloneArrary(StreamProcessor.KEY, 8);
			this.SEND_KEY = StreamProcessor.cloneArrary(StreamProcessor.KEY, 8);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002E58 File Offset: 0x00001058
		public bool SendAsync(SocketAsyncEventArgs e)
		{
			int tickCount = Environment.TickCount;
			bool flag = true;
			if (this.m_sock.Connected)
			{
				flag = this.m_sock.SendAsync(e);
			}
			int num2 = Environment.TickCount - tickCount;
			if (num2 > 1500)
			{
				BaseClient.log.WarnFormat("AsyncTcpSendCallback.BeginSend took {0}ms! (TCP to client: {1})", num2, this.TcpEndpoint);
			}
			return flag;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002EB3 File Offset: 0x000010B3
		public virtual void SendTCP(GSPacketIn pkg)
		{
			this.m_processor.SendTCP(pkg);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002EC1 File Offset: 0x000010C1
		public void SetFsm(int adder, int muliter)
		{
			this.m_processor.SetFsm(adder, muliter);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002ED0 File Offset: 0x000010D0
		public virtual void setKey(byte[] data)
		{
			for (int i = 0; i < 8; i++)
			{
				this.RECEIVE_KEY[i] = data[i];
				this.SEND_KEY[i] = data[i];
			}
		}

		// Token: 0x0400000E RID: 14
		public bool IsClientPacketSended;

		// Token: 0x0400000F RID: 15
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000010 RID: 16
		private int m_isConnected;

		// Token: 0x04000011 RID: 17
		public StreamProcessor m_processor;

		// Token: 0x04000012 RID: 18
		protected int m_readBufEnd;

		// Token: 0x04000013 RID: 19
		protected byte[] m_readBuffer;

		// Token: 0x04000014 RID: 20
		protected byte[] m_sendBuffer;

		// Token: 0x04000015 RID: 21
		protected Socket m_sock;

		// Token: 0x04000016 RID: 22
		public int numPacketProcces;

		// Token: 0x04000017 RID: 23
		private SocketAsyncEventArgs rc_event;

		// Token: 0x04000018 RID: 24
		public byte[] RECEIVE_KEY;

		// Token: 0x04000019 RID: 25
		public byte[] SEND_KEY;

		// Token: 0x0400001C RID: 28
		public ePrivLevel m_privLevel;
	}
}
