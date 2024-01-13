using System;
using Game.Base;

namespace Center.Server.Commands
{
	// Token: 0x02000017 RID: 23
	[Cmd("&time", ePrivLevel.Admin, "   显示当前系统时间", new string[] { "       /time :  显示当前系统时间", "                   " })]
	public class DataTimeCommand : AbstractCommandHandler, ICommandHandler
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x00006CE4 File Offset: 0x00004EE4
		public bool OnCommand(BaseClient client, string[] args)
		{
			this.DisplayMessage(client, "data time:");
			this.DisplayMessage(client, "-------------------------------");
			this.DisplayMessage(client, DateTime.Now.ToString());
			return true;
		}
	}
}
