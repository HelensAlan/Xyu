using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bussiness;
using log4net;
using SqlDataProvider.Data;

namespace Center.Server
{
	// Token: 0x02000013 RID: 19
	public class ServerMgr
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000CB RID: 203 RVA: 0x000025A4 File Offset: 0x000007A4
		public static ServerInfo[] Servers
		{
			get
			{
				return ServerMgr._list.Values.ToArray<ServerInfo>();
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00005ABC File Offset: 0x00003CBC
		public static bool Start()
		{
			bool result;
			try
			{
				using (ServiceBussiness serviceBussiness = new ServiceBussiness())
				{
					foreach (ServerInfo serverInfo in serviceBussiness.GetServerList())
					{
						serverInfo.State = 1;
						serverInfo.Online = 0;
						ServerMgr._list.Add(serverInfo.ID, serverInfo);
					}
				}
				ServerMgr.log.Info("Load server list from db.");
				result = true;
			}
			catch (Exception arg)
			{
				ServerMgr.log.ErrorFormat("Load server list from db failed:{0}", arg);
				result = false;
			}
			return result;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00005B60 File Offset: 0x00003D60
		public static bool ReLoadServerList()
		{
			bool result;
			try
			{
				using (ServiceBussiness serviceBussiness = new ServiceBussiness())
				{
					object syncStop = ServerMgr._syncStop;
					lock (syncStop)
					{
						foreach (ServerInfo serverInfo in serviceBussiness.GetServerList())
						{
							if (ServerMgr._list.ContainsKey(serverInfo.ID))
							{
								ServerMgr._list[serverInfo.ID].IP = serverInfo.IP;
								ServerMgr._list[serverInfo.ID].Name = serverInfo.Name;
								ServerMgr._list[serverInfo.ID].Port = serverInfo.Port;
								ServerMgr._list[serverInfo.ID].Room = serverInfo.Room;
								ServerMgr._list[serverInfo.ID].Total = serverInfo.Total;
								ServerMgr._list[serverInfo.ID].MustLevel = serverInfo.MustLevel;
								ServerMgr._list[serverInfo.ID].LowestLevel = serverInfo.LowestLevel;
								ServerMgr._list[serverInfo.ID].Online = serverInfo.Online;
								ServerMgr._list[serverInfo.ID].State = serverInfo.State;
							}
							else
							{
								serverInfo.State = 1;
								serverInfo.Online = 0;
								ServerMgr._list.Add(serverInfo.ID, serverInfo);
							}
							ServerMgr.log.InfoFormat("Load server [{0}]  {1}   {2} {3}", new object[] { serverInfo.Name, serverInfo.ID, serverInfo.Port, serverInfo.State });
						}
					}
				}
				ServerMgr.log.InfoFormat("Load server list completed!", new object[0]);
				result = true;
			}
			catch (Exception arg)
			{
				ServerMgr.log.ErrorFormat("ReLoad server list from db failed:{0}", arg);
				result = false;
			}
			return result;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00005DCC File Offset: 0x00003FCC
		public static ServerInfo GetServerInfo(int id)
		{
			ServerInfo result;
			if (ServerMgr._list.ContainsKey(id))
			{
				result = ServerMgr._list[id];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00005DF8 File Offset: 0x00003FF8
		public static int GetState(int count, int total)
		{
			int result;
			if (count >= total)
			{
				result = 5;
			}
			else if ((double)count > (double)total * 0.5)
			{
				result = 4;
			}
			else
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00005E24 File Offset: 0x00004024
		public static void SaveToDatabase()
		{
			try
			{
				using (ServiceBussiness serviceBussiness = new ServiceBussiness())
				{
					foreach (ServerInfo info in ServerMgr._list.Values)
					{
						serviceBussiness.UpdateService(info);
					}
				}
			}
			catch (Exception exception)
			{
				ServerMgr.log.Error("Save server state", exception);
			}
		}

		// Token: 0x04000083 RID: 131
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000084 RID: 132
		private static Dictionary<int, ServerInfo> _list = new Dictionary<int, ServerInfo>();

		// Token: 0x04000085 RID: 133
		private static object _syncStop = new object();
	}
}
