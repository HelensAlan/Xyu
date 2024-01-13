using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using log4net;

namespace Game.Base
{
	// Token: 0x02000007 RID: 7
	public class BaseConnector : BaseClient
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002EFF File Offset: 0x000010FF
		public IPEndPoint RemoteEP
		{
			get
			{
				return this._remoteEP;
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002F08 File Offset: 0x00001108
		public bool Connect()
		{
			try
			{
				this.m_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				this.m_readBufEnd = 0;
				this.m_sock.Connect(this._remoteEP);
				BaseConnector.log.InfoFormat("Connected to {0}", this._remoteEP);
			}
			catch
			{
				BaseConnector.log.ErrorFormat("Connect {0} failed!", this._remoteEP);
				this.m_sock = null;
				return false;
			}
			this.OnConnect();
			base.ReceiveAsync();
			return true;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002F94 File Offset: 0x00001194
		private void TryReconnect()
		{
			if (this.Connect())
			{
				if (this.timer != null)
				{
					this.timer.Dispose();
					this.timer = null;
				}
				base.ReceiveAsync();
				return;
			}
			BaseConnector.log.ErrorFormat("Reconnect {0} failed:", this._remoteEP);
			BaseConnector.log.ErrorFormat("Retry after {0} ms!", BaseConnector.RECONNECT_INTERVAL);
			if (this.timer == null)
			{
				this.timer = new Timer(new TimerCallback(BaseConnector.RetryTimerCallBack), this, -1, -1);
			}
			this.timer.Change(BaseConnector.RECONNECT_INTERVAL, -1);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000302C File Offset: 0x0000122C
		private static void RetryTimerCallBack(object target)
		{
			BaseConnector connector = target as BaseConnector;
			if (connector != null)
			{
				connector.TryReconnect();
				return;
			}
			BaseConnector.log.Error("BaseConnector retryconnect timer return NULL!");
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003059 File Offset: 0x00001259
		public BaseConnector(string ip, int port, bool autoReconnect, byte[] readBuffer, byte[] sendBuffer)
			: base(readBuffer, sendBuffer)
		{
			this._remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
			this._autoReconnect = autoReconnect;
			this.e = new SocketAsyncEventArgs();
		}

		// Token: 0x04000020 RID: 32
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000021 RID: 33
		private static readonly int RECONNECT_INTERVAL = 10000;

		// Token: 0x04000022 RID: 34
		private SocketAsyncEventArgs e;

		// Token: 0x04000023 RID: 35
		private IPEndPoint _remoteEP;

		// Token: 0x04000024 RID: 36
		private bool _autoReconnect;

		// Token: 0x04000025 RID: 37
		private Timer timer;
	}
}
