using System;
using Center.Server;
using Game.Base;
using Game.Base.Packets;

namespace Center.Service.actions
{
	// Token: 0x02000006 RID: 6
	public class ClientConnetor : BaseConnector
	{
		// Token: 0x0600001A RID: 26 RVA: 0x0000245B File Offset: 0x0000065B
		public ClientConnetor(string ip, int port)
			: base(ip, port, false, new byte[8192], new byte[8192])
		{
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000247C File Offset: 0x0000067C
		public void Login()
		{
			GSPacketIn pkg = new GSPacketIn(252);
			pkg.WriteString(ServerClient.MANAGER_KEY);
			this.SendTCP(pkg);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000024A6 File Offset: 0x000006A6
		public override void Disconnect()
		{
			Console.WriteLine("Disconnect from sever.");
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000024B4 File Offset: 0x000006B4
		public void SendCmd(string cmd)
		{
			GSPacketIn pkg = new GSPacketIn(254);
			pkg.WriteString(cmd);
			this.SendTCP(pkg);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000024DA File Offset: 0x000006DA
		public override void OnRecvPacket(GSPacketIn pkg)
		{
			if (pkg.Code == 255)
			{
				Console.WriteLine(pkg.ReadString());
				Console.Write(">");
			}
		}
	}
}
