using System;

namespace Game.Base.Commands
{
	// Token: 0x0200002C RID: 44
	[Cmd("&cmd", ePrivLevel.Admin, "eg:    /cmd -reload           :重新加载命令行系统.", new string[] { })]
	public class CommandMgrSetupCommand : AbstractCommandHandler, ICommandHandler
	{
		// Token: 0x06000153 RID: 339 RVA: 0x0000723C File Offset: 0x0000543C
		public bool OnCommand(BaseClient client, string[] args)
		{
			if (args.Length > 1)
			{
				string text = args[1];
				if (text != null && text == "-reload")
				{
					CommandMgr.LoadCommands();
				}
				else
				{
					this.DisplaySyntax(client);
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
