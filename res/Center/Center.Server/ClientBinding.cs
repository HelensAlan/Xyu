using System;
using System.ServiceModel;

namespace Center.Server
{
	// Token: 0x02000006 RID: 6
	public class ClientBinding
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000021BD File Offset: 0x000003BD
		// (set) Token: 0x06000045 RID: 69 RVA: 0x000021C5 File Offset: 0x000003C5
		public NetTcpBinding Binding { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000046 RID: 70 RVA: 0x000021CE File Offset: 0x000003CE
		// (set) Token: 0x06000047 RID: 71 RVA: 0x000021D6 File Offset: 0x000003D6
		public EndpointAddress Uri { get; private set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000021DF File Offset: 0x000003DF
		// (set) Token: 0x06000049 RID: 73 RVA: 0x000021E7 File Offset: 0x000003E7
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				this.Uri = new EndpointAddress(string.Format("net.tcp://{0}:9230/service", value));
				this._Address = value;
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000443C File Offset: 0x0000263C
		public ClientBinding()
		{
			this.Binding = new NetTcpBinding
			{
				MaxReceivedMessageSize = 65536L
			};
			this.Binding.ReaderQuotas.MaxArrayLength = 16384;
			this.Binding.CloseTimeout = new TimeSpan(0, 1, 0);
			this.Binding.OpenTimeout = new TimeSpan(0, 1, 0);
			this.Binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
			this.Binding.SendTimeout = new TimeSpan(0, 1, 0);
			this.Binding.Security.Mode = SecurityMode.None;
		}

		// Token: 0x04000022 RID: 34
		public const string URI_STRING = "net.tcp://{0}:9230/service";

		// Token: 0x04000023 RID: 35
		private string _Address;
	}
}
