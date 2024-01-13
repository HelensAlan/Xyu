using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Center.GMService;
using Center.Server;
using Game.Base;
using log4net;

namespace Center.Service.actions
{
	// Token: 0x02000007 RID: 7
	public class ConsoleStart : IAction
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000024FE File Offset: 0x000006FE
		public string Name
		{
			get
			{
				return "--start";
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002505 File Offset: 0x00000705
		public string Syntax
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002508 File Offset: 0x00000708
		public string Description
		{
			get
			{
				return "Start the Center Server in console mode";
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002510 File Offset: 0x00000710
		private static bool StartServer()
		{
			Console.WriteLine("Starting the server");
			bool start = CenterServer.Instance.Start();
			if (start)
			{
				Console.WriteLine("Starting the GM Service");
				start = GMService.Start();
			}
			return start;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002548 File Offset: 0x00000748
		public void OnAction(Hashtable parameters)
		{
			Console.WriteLine("Starting GameServer ... please wait a moment!");
			CenterServer.CreateInstance(new CenterServerConfig());
			ConsoleStart.StartServer();
			ConsoleStart.handler = new ConsoleStart.ConsoleCtrlDelegate(ConsoleStart.ConsoleCtrHandler);
			ConsoleStart.SetConsoleCtrlHandler(ConsoleStart.handler, true);
			ConsoleClient client = new ConsoleClient();
			bool run = true;
			while (run)
			{
				try
				{
					Console.Write("> ");
					string line = Console.ReadLine();
					if (line.Length > 0)
					{
						if (line[0] == '/')
						{
							line = line.Remove(0, 1);
							line = line.Insert(0, "&");
						}
						if (line == "quit")
						{
							break;
						}
						try
						{
							if (!CommandMgr.HandleCommandNoPlvl(client, line))
							{
								Console.WriteLine("Unknown command: " + line);
							}
						}
						catch (Exception ex2)
						{
							Console.WriteLine(ex2.ToString());
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error:" + ex.ToString());
				}
			}
			if (CenterServer.Instance != null)
			{
				ServerClient[] list = CenterServer.Instance.GetAllClients();
				ConsoleStart.log.Warn("list.count = " + list.Length.ToString());
				if (list.Length != 0)
				{
					CenterServer.Instance.ClientsExecuteCmd("/shutdown 5");
					Thread.Sleep(360000);
				}
				CenterServer.Instance.Stop();
			}
			GMService.Stop();
			if (CenterServer.Instance != null)
			{
				CenterServer.Instance.Stop();
			}
			LogManager.Shutdown();
		}

		// Token: 0x06000024 RID: 36
		[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
		private static extern int SetConsoleCtrlHandler(ConsoleStart.ConsoleCtrlDelegate HandlerRoutine, bool add);

		// Token: 0x06000025 RID: 37 RVA: 0x000026C0 File Offset: 0x000008C0
		private static int ConsoleCtrHandler(ConsoleStart.ConsoleEvent e)
		{
			GMService.Stop();
			if (CenterServer.Instance != null)
			{
				CenterServer.Instance.Stop();
			}
			return 0;
		}

		// Token: 0x04000004 RID: 4
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000005 RID: 5
		private static ConsoleStart.ConsoleCtrlDelegate handler;

		// Token: 0x02000009 RID: 9
		// (Invoke) Token: 0x0600002E RID: 46
		private delegate int ConsoleCtrlDelegate(ConsoleStart.ConsoleEvent ctrlType);

		// Token: 0x0200000A RID: 10
		private enum ConsoleEvent
		{
			// Token: 0x04000007 RID: 7
			Ctrl_C,
			// Token: 0x04000008 RID: 8
			Ctrl_Break,
			// Token: 0x04000009 RID: 9
			Close,
			// Token: 0x0400000A RID: 10
			Logoff,
			// Token: 0x0400000B RID: 11
			Shutdown
		}
	}
}
