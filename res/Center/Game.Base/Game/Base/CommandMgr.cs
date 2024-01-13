using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Game.Base.Events;
using Game.Server.Managers;
using log4net;

namespace Game.Base
{
	// Token: 0x0200000C RID: 12
	public class CommandMgr
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00003774 File Offset: 0x00001974
		// (set) Token: 0x06000067 RID: 103 RVA: 0x0000377B File Offset: 0x0000197B
		public static string[] DisableCommands
		{
			get
			{
				return CommandMgr.m_disabledarray;
			}
			set
			{
				CommandMgr.m_disabledarray = ((value == null) ? new string[0] : value);
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000378E File Offset: 0x0000198E
		public static GameCommand GetCommand(string cmd)
		{
			return CommandMgr.m_cmds[cmd] as GameCommand;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000037A0 File Offset: 0x000019A0
		public static GameCommand GuessCommand(string cmd)
		{
			GameCommand myCommand = CommandMgr.GetCommand(cmd);
			GameCommand result;
			if (myCommand != null)
			{
				result = myCommand;
			}
			else
			{
				string compareCmdStr = cmd.ToLower();
				IDictionaryEnumerator iter = CommandMgr.m_cmds.GetEnumerator();
				while (iter.MoveNext())
				{
					GameCommand currentCommand = iter.Value as GameCommand;
					string currentCommandStr = iter.Key as string;
					if (currentCommand != null && currentCommandStr.ToLower().StartsWith(compareCmdStr))
					{
						myCommand = currentCommand;
						break;
					}
				}
				result = myCommand;
			}
			return result;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000380C File Offset: 0x00001A0C
		public static string[] GetCommandList(ePrivLevel plvl, bool addDesc)
		{
			IDictionaryEnumerator iter = CommandMgr.m_cmds.GetEnumerator();
			ArrayList list = new ArrayList();
			while (iter.MoveNext())
			{
				GameCommand cmd = iter.Value as GameCommand;
				string cmdString = iter.Key as string;
				if (cmd != null && cmdString != null)
				{
					if (cmdString[0] == '&')
					{
						cmdString = "/" + cmdString.Remove(0, 1);
					}
					if (plvl >= (ePrivLevel)cmd.m_lvl)
					{
						if (addDesc)
						{
							list.Add(cmdString + " - " + cmd.m_desc);
						}
						else
						{
							list.Add(cmd.m_cmd);
						}
					}
				}
			}
			return (string[])list.ToArray(typeof(string));
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000038B8 File Offset: 0x00001AB8
		[ScriptLoadedEvent]
		public static void OnScriptCompiled(RoadEvent ev, object sender, EventArgs args)
		{
			CommandMgr.LoadCommands();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000038C0 File Offset: 0x00001AC0
		public static bool LoadCommands()
		{
			CommandMgr.m_cmds.Clear();
			foreach (object obj in new ArrayList(ScriptMgr.Scripts))
			{
				Assembly script = (Assembly)obj;
				if (CommandMgr.log.IsDebugEnabled)
				{
					ILog log = CommandMgr.log;
					string str2 = "ScriptMgr: Searching for commands in ";
					AssemblyName name = script.GetName();
					log.Debug(str2 + ((name != null) ? name.ToString() : null));
				}
				foreach (Type type in script.GetTypes())
				{
					if (type.IsClass && type.GetInterface("Game.Base.ICommandHandler") != null)
					{
						try
						{
							foreach (CmdAttribute attrib in type.GetCustomAttributes(typeof(CmdAttribute), false))
							{
								bool disabled = false;
								foreach (string str in CommandMgr.m_disabledarray)
								{
									if (attrib.Cmd.Replace('&', '/') == str)
									{
										disabled = true;
										CommandMgr.log.Info("Will not load command " + attrib.Cmd + " as it is disabled in game properties");
										break;
									}
								}
								if (!disabled)
								{
									if (CommandMgr.m_cmds.ContainsKey(attrib.Cmd))
									{
										CommandMgr.log.Info(string.Concat(new object[]
										{
											attrib.Cmd,
											" from ",
											script.GetName(),
											" has been suppressed, a command of that type already exists!"
										}));
									}
									else
									{
										if (CommandMgr.log.IsDebugEnabled)
										{
											CommandMgr.log.Debug("Load: " + attrib.Cmd + "," + attrib.Description);
										}
										GameCommand cmd = new GameCommand();
										cmd.m_usage = attrib.Usage;
										cmd.m_cmd = attrib.Cmd;
										cmd.m_lvl = attrib.Level;
										cmd.m_desc = attrib.Description;
										cmd.m_cmdHandler = (ICommandHandler)Activator.CreateInstance(type);
										CommandMgr.m_cmds.Add(attrib.Cmd, cmd);
										if (attrib.Aliases != null)
										{
											foreach (string alias in attrib.Aliases)
											{
												CommandMgr.m_cmds.Add(alias, cmd);
											}
										}
									}
								}
							}
						}
						catch (Exception e)
						{
							CommandMgr.log.Error("LoadCommands", e);
						}
					}
				}
			}
			CommandMgr.log.Info("CommandMger:Loaded " + CommandMgr.m_cmds.Count.ToString() + " commands!");
			return true;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003BCC File Offset: 0x00001DCC
		public static void DisplaySyntax(BaseClient client)
		{
			client.DisplayMessage("Commands list:");
			foreach (string str in CommandMgr.GetCommandList(ePrivLevel.Admin, true))
			{
				client.DisplayMessage(" " + str);
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003C10 File Offset: 0x00001E10
		public static bool HandleCommandNoPlvl(BaseClient client, string cmdLine)
		{
			try
			{
				string[] pars = CommandMgr.ParseCmdLine(cmdLine);
				GameCommand myCommand = CommandMgr.GuessCommand(pars[0]);
				if (myCommand == null)
				{
					return false;
				}
				CommandMgr.ExecuteCommand(client, myCommand, pars);
			}
			catch (Exception e)
			{
				if (CommandMgr.log.IsErrorEnabled)
				{
					CommandMgr.log.Error("HandleCommandNoPlvl", e);
				}
			}
			return true;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003C74 File Offset: 0x00001E74
		private static bool ExecuteCommand(BaseClient client, GameCommand myCommand, string[] pars)
		{
			pars[0] = myCommand.m_cmd;
			return myCommand.m_cmdHandler.OnCommand(client, pars);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003C8C File Offset: 0x00001E8C
		private static string[] ParseCmdLine(string cmdLine)
		{
			if (cmdLine == null)
			{
				throw new ArgumentNullException("cmdLine");
			}
			List<string> args = new List<string>();
			int state = 0;
			StringBuilder arg = new StringBuilder(cmdLine.Length >> 1);
			for (int i = 0; i < cmdLine.Length; i++)
			{
				char c = cmdLine[i];
				switch (state)
				{
				case 0:
					if (c != ' ')
					{
						arg.Length = 0;
						if (c == '"')
						{
							state = 2;
						}
						else
						{
							state = 1;
							i--;
						}
					}
					break;
				case 1:
					if (c == ' ')
					{
						args.Add(arg.ToString());
						state = 0;
					}
					arg.Append(c);
					break;
				case 2:
					if (c == '"')
					{
						args.Add(arg.ToString());
						state = 0;
					}
					arg.Append(c);
					break;
				}
			}
			if (state != 0)
			{
				args.Add(arg.ToString());
			}
			string[] pars = new string[args.Count];
			args.CopyTo(pars);
			return pars;
		}

		// Token: 0x04000032 RID: 50
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000033 RID: 51
		private static Hashtable m_cmds = new Hashtable(StringComparer.InvariantCultureIgnoreCase);

		// Token: 0x04000034 RID: 52
		private static string[] m_disabledarray = new string[0];
	}
}
