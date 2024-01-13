using System;

namespace Game.Base.Commands
{
	// Token: 0x0200002D RID: 45
	[Cmd("&?", ePrivLevel.Admin, "/?     List all commands", new string[] { })]
	public class ListAllCommand : AbstractCommandHandler, ICommandHandler
	{
		// Token: 0x06000155 RID: 341 RVA: 0x00007284 File Offset: 0x00005484
		public bool OnCommand(BaseClient client, string[] args)
		{
			CommandMgr.DisplaySyntax(client);
			return true;
		}
	}
}
