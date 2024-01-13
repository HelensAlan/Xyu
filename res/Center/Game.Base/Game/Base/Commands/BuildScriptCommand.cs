using System;
using Game.Server.Managers;

namespace Game.Base.Commands
{
	// Token: 0x0200002B RID: 43
	[Cmd("&cs", ePrivLevel.Player, "Compile the C# scripts.", new string[] { "/cs  <source file> <target> <importlib>", "eg: /cs ./scripts temp.dll game.base.dll,game.logic.dll" })]
	public class BuildScriptCommand : AbstractCommandHandler, ICommandHandler
	{
		// Token: 0x06000151 RID: 337 RVA: 0x000071F0 File Offset: 0x000053F0
		public bool OnCommand(BaseClient client, string[] args)
		{
			if (args.Length >= 4)
			{
				string path = args[1];
				string target = args[2];
				string libs = args[3];
				ScriptMgr.CompileScripts(false, path, target, libs.Split(new char[] { ',' }));
			}
			else
			{
				this.DisplaySyntax(client);
			}
			return true;
		}
	}
}
