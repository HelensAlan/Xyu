using System;
using System.Collections.Generic;
using System.Reflection;
using DAL;
using log4net;

namespace Bussiness
{
	// Token: 0x0200000A RID: 10
	public class CountBussiness
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000079 RID: 121 RVA: 0x0000A8EC File Offset: 0x00008AEC
		public static string ConnectionString
		{
			get
			{
				return CountBussiness._connectionString;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600007A RID: 122 RVA: 0x0000A8F3 File Offset: 0x00008AF3
		public static int AppID
		{
			get
			{
				return CountBussiness._appID;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600007B RID: 123 RVA: 0x0000A8FA File Offset: 0x00008AFA
		public static int SubID
		{
			get
			{
				return CountBussiness._subID;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600007C RID: 124 RVA: 0x0000A901 File Offset: 0x00008B01
		public static int ServerID
		{
			get
			{
				return CountBussiness._serverID;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600007D RID: 125 RVA: 0x0000A908 File Offset: 0x00008B08
		public static bool CountRecord
		{
			get
			{
				return CountBussiness._conutRecord;
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000A90F File Offset: 0x00008B0F
		public static void SetConfig(string connectionString, int appID, int subID, int serverID, bool countRecord)
		{
			CountBussiness._connectionString = connectionString;
			CountBussiness._appID = appID;
			CountBussiness._subID = subID;
			CountBussiness._serverID = serverID;
			CountBussiness._conutRecord = countRecord;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000A930 File Offset: 0x00008B30
		public static void InsertGameInfo(DateTime begin, int mapID, int money, int gold, string users)
		{
			CountBussiness.InsertGameInfo(CountBussiness.AppID, CountBussiness.SubID, CountBussiness.ServerID, begin, DateTime.Now, users.Split(new char[] { ',' }).Length, mapID, money, gold, users);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000A970 File Offset: 0x00008B70
		public static void InsertGameInfo(int appid, int subid, int serverid, DateTime begin, DateTime end, int usercount, int mapID, int money, int gold, string users)
		{
			try
			{
				if (CountBussiness.CountRecord)
				{
					SqlHelper.BeginExecuteNonQuery(CountBussiness.ConnectionString, "SP_Insert_Count_FightInfo", new object[] { appid, subid, serverid, begin, end, usercount, mapID, money, gold, users });
				}
			}
			catch (Exception ex)
			{
				CountBussiness.log.Error("Insert Log Error!", ex);
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000AA1C File Offset: 0x00008C1C
		public static void InsertServerInfo(int usercount, int gamecount)
		{
			CountBussiness.InsertServerInfo(CountBussiness.AppID, CountBussiness.SubID, CountBussiness.ServerID, usercount, gamecount, DateTime.Now);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000AA3C File Offset: 0x00008C3C
		public static void InsertServerInfo(int appid, int subid, int serverid, int usercount, int gamecount, DateTime time)
		{
			try
			{
				if (CountBussiness.CountRecord)
				{
					SqlHelper.BeginExecuteNonQuery(CountBussiness.ConnectionString, "SP_Insert_Count_Server", new object[] { appid, subid, serverid, usercount, gamecount, time });
				}
			}
			catch (Exception ex)
			{
				CountBussiness.log.Error("Insert Log Error!!", ex);
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000AAC4 File Offset: 0x00008CC4
		public static void InsertSystemPayCount(int consumerid, int money, int gold, int consumertype, int subconsumertype)
		{
			CountBussiness.InsertSystemPayCount(CountBussiness.AppID, CountBussiness.SubID, consumerid, money, gold, consumertype, subconsumertype, DateTime.Now);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000AAE0 File Offset: 0x00008CE0
		public static void InsertSystemPayCount(int appid, int subid, int consumerid, int money, int gold, int consumertype, int subconsumertype, DateTime datime)
		{
			try
			{
				if (CountBussiness.CountRecord)
				{
					SqlHelper.BeginExecuteNonQuery(CountBussiness.ConnectionString, "SP_Insert_Count_SystemPay", new object[] { appid, subid, consumerid, money, gold, consumertype, subconsumertype, datime });
				}
			}
			catch (Exception ex)
			{
				CountBussiness.log.Error("InsertSystemPayCount Log Error!!!", ex);
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000AB7C File Offset: 0x00008D7C
		public static void InsertContentCount(Dictionary<string, string> clientInfos)
		{
			try
			{
				if (CountBussiness.CountRecord)
				{
					SqlHelper.BeginExecuteNonQuery(CountBussiness.ConnectionString, "Modify_Count_Content", new object[]
					{
						clientInfos["Application_Id"],
						clientInfos["Cpu"],
						clientInfos["OperSystem"],
						clientInfos["IP"],
						clientInfos["IPAddress"],
						clientInfos["NETCLR"],
						clientInfos["Browser"],
						clientInfos["ActiveX"],
						clientInfos["Cookies"],
						clientInfos["CSS"],
						clientInfos["Language"],
						clientInfos["Computer"],
						clientInfos["Platform"],
						clientInfos["Win16"],
						clientInfos["Win32"],
						clientInfos["Referry"],
						clientInfos["Redirect"],
						clientInfos["TimeSpan"],
						clientInfos["ScreenWidth"] + clientInfos["ScreenHeight"],
						clientInfos["Color"],
						clientInfos["Flash"],
						"Insert"
					});
				}
			}
			catch (Exception ex)
			{
				CountBussiness.log.Error("Insert Log Error!!!!", ex);
			}
		}

		// Token: 0x0400001C RID: 28
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x0400001D RID: 29
		private static string _connectionString;

		// Token: 0x0400001E RID: 30
		private static int _appID;

		// Token: 0x0400001F RID: 31
		private static int _subID;

		// Token: 0x04000020 RID: 32
		private static int _serverID;

		// Token: 0x04000021 RID: 33
		private static bool _conutRecord;
	}
}
