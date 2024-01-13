using System;
using System.Threading;
using Game.Base;

namespace Center.Server.Commands
{
	// Token: 0x0200001B RID: 27
	[Cmd("&shutdown", ePrivLevel.Admin, "停止并退出服务器", new string[] { "eg:    /shutdown", "       /shutdown n" })]
	public class ShutDownCommand : AbstractCommandHandler, ICommandHandler
	{
		// Token: 0x060000FC RID: 252 RVA: 0x00007154 File Offset: 0x00005354
		public bool OnCommand(BaseClient client, string[] args)
		{
			if (this.m_timer == null)
			{
				this.m_timer = new Timer(new TimerCallback(this.CheckServer), null, 0, 1000);
				this.DisplayMessage(client, "All server begin shutdown!");
			}
			if (args.Length > 1)
			{
				CenterServer.Instance.ClientsExecuteCmd("/shutdown " + args[1]);
			}
			else
			{
				CenterServer.Instance.ClientsExecuteCmd("/shutdown");
			}
			return true;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000071C4 File Offset: 0x000053C4
		private void CheckServer(object state)
		{
			ServerClient[] allClients = CenterServer.Instance.GetAllClients();
			if (allClients == null || allClients.Length == 0)
			{
				this.m_timer.Dispose();
				Environment.Exit(0);
			}
		}

		// Token: 0x0400009E RID: 158
		private Timer m_timer;
	}
}
