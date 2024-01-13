using System;
using System.Collections;
using Center.Server;

namespace Center.Service.actions
{
	// Token: 0x02000008 RID: 8
	public class ManagerClient : IAction
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000026F7 File Offset: 0x000008F7
		public string Name
		{
			get
			{
				return "--client";
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000026FE File Offset: 0x000008FE
		public string Syntax
		{
			get
			{
				return "--client";
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002705 File Offset: 0x00000905
		public string Description
		{
			get
			{
				return "Connect to the exist server,managed it through console.";
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000270C File Offset: 0x0000090C
		public void OnAction(Hashtable parameters)
		{
			Console.WriteLine("Center Server Manager Client");
			CenterServerConfig config = new CenterServerConfig();
			ClientConnetor connector = new ClientConnetor((config.Ip == "0.0.0.0") ? "127.0.0.1" : config.Ip, config.Port);
			if (connector.Connect())
			{
				Console.WriteLine("Connected to {0}:{1}", config.Ip, config.Port);
				connector.Login();
			}
			else
			{
				Console.WriteLine("Can't connect to {0}:{1}", config.Ip, config.Port);
			}
			bool run = true;
			while (run)
			{
				try
				{
					Console.Write("> ");
					string line = Console.ReadLine();
					if (line.Length <= 0)
					{
						break;
					}
					if (line[0] == '/')
					{
						line = line.Remove(0, 1);
						line = line.Insert(0, "&");
					}
					if (line == "quit")
					{
						break;
					}
					if (connector.IsConnected)
					{
						connector.SendCmd(line);
					}
					else
					{
						Console.WriteLine("didn't connect to andy server!");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error:" + ex.ToString());
				}
			}
		}
	}
}
