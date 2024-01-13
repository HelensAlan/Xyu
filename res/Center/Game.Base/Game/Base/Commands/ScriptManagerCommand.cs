using System;
using System.IO;
using System.Reflection;
using Game.Server.Managers;

namespace Game.Base.Commands
{
	// Token: 0x0200002E RID: 46
	[Cmd("&sm", ePrivLevel.Player, "eg:    /sm -list              : List all assemblies in scripts array.", new string[] { "       /sm -add <assembly>    : Add assembly into the scripts array.", "       /sm -remove <assembly> : Remove assembly from the scripts array." })]
	public class ScriptManagerCommand : AbstractCommandHandler, ICommandHandler
	{
		// Token: 0x06000157 RID: 343 RVA: 0x00007298 File Offset: 0x00005498
		public bool OnCommand(BaseClient client, string[] args)
		{
			bool result;
			if (args.Length > 1)
			{
				string text = args[1];
				if (text != null)
				{
					if (text == "-list")
					{
						foreach (Assembly ass in ScriptMgr.Scripts)
						{
							this.DisplayMessage(client, ass.FullName);
						}
						return true;
					}
					if (text == "-add")
					{
						if (args.Length > 2 && args[2] != null && File.Exists(args[2]))
						{
							try
							{
								if (ScriptMgr.InsertAssembly(Assembly.LoadFile(args[2])))
								{
									this.DisplayMessage(client, "Add assembly success!");
									return true;
								}
								this.DisplayMessage(client, "Assembly already exists in the scripts array!");
								return false;
							}
							catch (Exception ex)
							{
								this.DisplayMessage(client, "Add assembly error:", new object[] { ex.Message });
								return false;
							}
						}
						this.DisplayMessage(client, "Can't find add assembly!");
						return false;
					}
					if (text == "-remove")
					{
						if (args.Length > 2 && args[2] != null && File.Exists(args[2]))
						{
							try
							{
								if (ScriptMgr.RemoveAssembly(Assembly.LoadFile(args[2])))
								{
									this.DisplayMessage(client, "Remove assembly success!");
									return true;
								}
								this.DisplayMessage(client, "Assembly didn't exist in the scripts array!");
								return false;
							}
							catch (Exception ex2)
							{
								this.DisplayMessage(client, "Remove assembly error:", new object[] { ex2.Message });
								return false;
							}
						}
						this.DisplayMessage(client, "Can't find remove assembly!");
						return false;
					}
				}
				this.DisplayMessage(client, "Can't fine option:{0}", new object[] { args[1] });
				result = true;
			}
			else
			{
				this.DisplaySyntax(client);
				result = true;
			}
			return result;
		}
	}
}
