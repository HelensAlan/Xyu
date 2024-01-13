using System;
using System.Configuration;
using System.Data;
using System.Reflection;
using log4net;
using SqlDataProvider.Data;

namespace Center.Server.Statics
{
	// Token: 0x02000015 RID: 21
	public class LogMgr
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000DD RID: 221 RVA: 0x0000265B File Offset: 0x0000085B
		public static int GameType
		{
			get
			{
				return int.Parse(ConfigurationManager.AppSettings["GameType"]);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00002671 File Offset: 0x00000871
		public static int ServerID
		{
			get
			{
				return int.Parse(ConfigurationManager.AppSettings["ServerID"]);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00002687 File Offset: 0x00000887
		public static int AreaID
		{
			get
			{
				return int.Parse(ConfigurationManager.AppSettings["AreaID"]);
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x0000269D File Offset: 0x0000089D
		public static int SaveRecordSecond
		{
			get
			{
				return int.Parse(ConfigurationManager.AppSettings["SaveRecordInterval"]) * 60;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x0000652C File Offset: 0x0000472C
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x0000656C File Offset: 0x0000476C
		public static int RegCount
		{
			get
			{
				object sysObj = LogMgr._sysObj;
				int result;
				lock (sysObj)
				{
					result = LogMgr.regCount;
				}
				return result;
			}
			set
			{
				object sysObj = LogMgr._sysObj;
				lock (sysObj)
				{
					LogMgr.regCount = value;
				}
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000026B6 File Offset: 0x000008B6
		public static bool Setup()
		{
			return LogMgr.Setup(LogMgr.GameType, LogMgr.AreaID, LogMgr.ServerID);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000065AC File Offset: 0x000047AC
		public static bool Setup(int gametype, int areaid, int serverid)
		{
			LogMgr._gameType = gametype;
			LogMgr._serverId = serverid;
			LogMgr._areaId = areaid;
			LogMgr.m_LogServer = new DataTable("Log_Server");
			LogMgr.m_LogServer.Columns.Add("ApplicationId", typeof(int));
			LogMgr.m_LogServer.Columns.Add("SubId", typeof(int));
			LogMgr.m_LogServer.Columns.Add("EnterTime", typeof(DateTime));
			LogMgr.m_LogServer.Columns.Add("Online", typeof(int));
			LogMgr.m_LogServer.Columns.Add("Reg", typeof(int));
			LogMgr.m_LogServerOnline = new DataTable("LogServerOnline");
			LogMgr.m_LogServerOnline.Columns.Add("ServerID", typeof(int));
			LogMgr.m_LogServerOnline.Columns.Add("EnterTime", typeof(DateTime));
			LogMgr.m_LogServerOnline.Columns.Add("Online", typeof(int));
			return true;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000066E4 File Offset: 0x000048E4
		public static void Reset()
		{
			DataTable logServer = LogMgr.m_LogServer;
			lock (logServer)
			{
				LogMgr.m_LogServer.Clear();
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00006728 File Offset: 0x00004928
		public static void Save()
		{
			if (LogMgr.m_LogServer == null)
			{
				LogMgr.Setup();
			}
			int onlineCount = LoginMgr.GetOnlineCount();
			object[] values = new object[]
			{
				LogMgr._gameType,
				LogMgr._serverId,
				DateTime.Now,
				onlineCount,
				LogMgr.RegCount
			};
			DataTable obj = LogMgr.m_LogServer;
			lock (obj)
			{
				LogMgr.m_LogServer.Rows.Add(values);
			}
			LogMgr.RegCount = 0;
			int saveRecordSecond = LogMgr.SaveRecordSecond;
			foreach (ServerInfo serverInfo in ServerMgr.Servers)
			{
				object[] values2 = new object[]
				{
					serverInfo.ID,
					DateTime.Now,
					serverInfo.Online
				};
				obj = LogMgr.m_LogServerOnline;
				lock (obj)
				{
					LogMgr.m_LogServerOnline.Rows.Add(values2);
				}
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00006864 File Offset: 0x00004A64
		public static void AddRegCount()
		{
			object sysObj = LogMgr._sysObj;
			lock (sysObj)
			{
				LogMgr.regCount++;
			}
		}

		// Token: 0x04000090 RID: 144
		public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000091 RID: 145
		private static object _syncStop = new object();

		// Token: 0x04000092 RID: 146
		private static int _gameType;

		// Token: 0x04000093 RID: 147
		private static int _serverId;

		// Token: 0x04000094 RID: 148
		private static int _areaId;

		// Token: 0x04000095 RID: 149
		public static DataTable m_LogServer;

		// Token: 0x04000096 RID: 150
		public static DataTable m_LogServerOnline;

		// Token: 0x04000097 RID: 151
		private static int regCount;

		// Token: 0x04000098 RID: 152
		public static object _sysObj = new object();
	}
}
