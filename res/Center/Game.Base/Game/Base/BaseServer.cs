using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using log4net;

namespace Game.Base
{
	// Token: 0x02000008 RID: 8
	public class BaseServer
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000030A9 File Offset: 0x000012A9
		public int ClientCount
		{
			get
			{
				return this._clients.Count;
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000030B6 File Offset: 0x000012B6
		public BaseServer()
		{
			this.ac_event = new SocketAsyncEventArgs();
			this.ac_event.Completed += this.AcceptAsyncCompleted;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000030EC File Offset: 0x000012EC
		private void AcceptAsync()
		{
			try
			{
				if (this._linstener != null)
				{
					SocketAsyncEventArgs e = new SocketAsyncEventArgs();
					e.Completed += this.AcceptAsyncCompleted;
					this._linstener.AcceptAsync(e);
				}
			}
			catch (Exception ex)
			{
				BaseServer.log.Error("AcceptAsync is error!", ex);
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000314C File Offset: 0x0000134C
		private void AcceptAsyncCompleted(object sender, SocketAsyncEventArgs e)
		{
			Socket sock = null;
			try
			{
				sock = e.AcceptSocket;
				sock.SendBufferSize = BaseServer.SEND_BUFF_SIZE;
				BaseClient client = this.GetNewClient();
				try
				{
					if (BaseServer.log.IsInfoEnabled)
					{
						string ip = (sock.Connected ? sock.RemoteEndPoint.ToString() : "socket disconnected");
						BaseServer.log.Debug("Incoming connection from " + ip);
					}
					object syncRoot = this._clients.SyncRoot;
					lock (syncRoot)
					{
						this._clients.Add(client, client);
						client.Disconnected += this.client_Disconnected;
					}
					client.Connect(sock);
					client.ReceiveAsync();
				}
				catch (Exception ex)
				{
					BaseServer.log.ErrorFormat("create client failed:{0}", ex);
					client.Disconnect();
				}
			}
			catch
			{
				if (sock != null)
				{
					try
					{
						sock.Close();
					}
					catch
					{
					}
				}
			}
			finally
			{
				e.Dispose();
				this.AcceptAsync();
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003280 File Offset: 0x00001480
		private void client_Disconnected(BaseClient client)
		{
			client.Disconnected -= this.client_Disconnected;
			this.RemoveClient(client);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000329B File Offset: 0x0000149B
		protected virtual BaseClient GetNewClient()
		{
			return new BaseClient(new byte[8192], new byte[8192]);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000032B8 File Offset: 0x000014B8
		public virtual bool InitSocket(IPAddress ip, int port)
		{
			try
			{
				this._linstener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				this._linstener.Bind(new IPEndPoint(ip, port));
			}
			catch (Exception e)
			{
				BaseServer.log.Error("InitSocket", e);
				return false;
			}
			return true;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003310 File Offset: 0x00001510
		public virtual bool Start()
		{
			if (this._linstener != null)
			{
				try
				{
					this._linstener.Listen(100);
					this.AcceptAsync();
					if (BaseServer.log.IsDebugEnabled)
					{
						BaseServer.log.Debug("Server is now listening to incoming connections!");
					}
				}
				catch (Exception e)
				{
					if (BaseServer.log.IsErrorEnabled)
					{
						BaseServer.log.Error("Start", e);
					}
					if (this._linstener != null)
					{
						this._linstener.Close();
					}
					return false;
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000033A8 File Offset: 0x000015A8
		public virtual void Stop()
		{
			BaseServer.log.Debug("Stopping server! - Entering method");
			try
			{
				if (this._linstener != null)
				{
					Socket linstener = this._linstener;
					this._linstener = null;
					linstener.Close();
					BaseServer.log.Debug("Server is no longer listening for incoming connections!");
				}
			}
			catch (Exception e)
			{
				BaseServer.log.Error("Stop", e);
			}
			if (this._clients != null)
			{
				object syncRoot = this._clients.SyncRoot;
				lock (syncRoot)
				{
					try
					{
						BaseClient[] list = new BaseClient[this._clients.Keys.Count];
						this._clients.Keys.CopyTo(list, 0);
						BaseClient[] array = list;
						for (int i = 0; i < array.Length; i++)
						{
							array[i].Disconnect();
						}
						BaseServer.log.Debug("Stopping server! - Cleaning up client list!");
					}
					catch (Exception e2)
					{
						BaseServer.log.Error("Stop", e2);
					}
				}
			}
			BaseServer.log.Debug("Stopping server! - End of method!");
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000034D4 File Offset: 0x000016D4
		public virtual void RemoveClient(BaseClient client)
		{
			object syncRoot = this._clients.SyncRoot;
			lock (syncRoot)
			{
				this._clients.Remove(client);
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003520 File Offset: 0x00001720
		public BaseClient[] GetAllClients()
		{
			object syncRoot = this._clients.SyncRoot;
			BaseClient[] result;
			lock (syncRoot)
			{
				BaseClient[] temp = new BaseClient[this._clients.Count];
				this._clients.Keys.CopyTo(temp, 0);
				result = temp;
			}
			return result;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003588 File Offset: 0x00001788
		public void Dispose()
		{
			this.ac_event.Dispose();
		}

		// Token: 0x04000026 RID: 38
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000027 RID: 39
		private static readonly int SEND_BUFF_SIZE = 16384;

		// Token: 0x04000028 RID: 40
		protected readonly HybridDictionary _clients = new HybridDictionary();

		// Token: 0x04000029 RID: 41
		protected Socket _linstener;

		// Token: 0x0400002A RID: 42
		protected SocketAsyncEventArgs ac_event;
	}
}
