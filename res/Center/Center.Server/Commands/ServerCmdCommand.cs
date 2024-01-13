using System;
using System.Text;
using Game.Base;

namespace Center.Server.Commands
{
	// Token: 0x0200001A RID: 26
	[Cmd("&sc", ePrivLevel.Admin, "Manage server properties at runtime(include CenterServer and GameServer).", new string[] { "   /sc <option> [para1][para2] ..." })]
	public class ServerCmdCommand : AbstractCommandHandler, ICommandHandler
	{
		// Token: 0x060000FA RID: 250 RVA: 0x000070D8 File Offset: 0x000052D8
		public bool OnCommand(BaseClient client, string[] args)
		{
			if (args.Length > 1)
			{
				StringBuilder stringBuilder = new StringBuilder(args[1]);
				for (int i = 2; i < args.Length; i++)
				{
					stringBuilder.Append(" ");
					stringBuilder.Append(args[i]);
				}
				ServerClient[] allClients = CenterServer.Instance.GetAllClients();
				if (allClients != null)
				{
					ServerClient[] array = allClients;
					for (int j = 0; j < array.Length; j++)
					{
						array[j].SendCmd(client, stringBuilder.ToString());
					}
				}
			}
			else
			{
				this.DisplaySyntax(client);
			}
			return true;
		}
	}
}
