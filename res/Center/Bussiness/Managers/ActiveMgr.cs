using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using log4net;
using SqlDataProvider.Data;

namespace Bussiness.Managers
{
	// Token: 0x0200001F RID: 31
	public class ActiveMgr
	{
		// Token: 0x060001AF RID: 431 RVA: 0x0001EE49 File Offset: 0x0001D049
		public static bool Init()
		{
			return ActiveMgr.ReLoad();
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0001EE50 File Offset: 0x0001D050
		public static bool ReLoad()
		{
			try
			{
				Dictionary<int, List<ActiveConditionInfo>> tempActiveConditionInfo = ActiveMgr.LoadActiveConditionDb();
				Dictionary<int, ActiveAwardInfo> tempActiveAwardInfo = ActiveMgr.LoadActiveAwardDb(tempActiveConditionInfo);
				if (tempActiveConditionInfo.Count > 0)
				{
					Interlocked.Exchange<Dictionary<int, List<ActiveConditionInfo>>>(ref ActiveMgr.m_ActiveConditionInfo, tempActiveConditionInfo);
					Interlocked.Exchange<Dictionary<int, ActiveAwardInfo>>(ref ActiveMgr.m_ActiveAwardInfo, tempActiveAwardInfo);
				}
				return true;
			}
			catch (Exception e)
			{
				ActiveMgr.log.Error("QuestMgr", e);
			}
			return false;
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0001EEB8 File Offset: 0x0001D0B8
		public static Dictionary<int, List<ActiveConditionInfo>> LoadActiveConditionDb()
		{
			Dictionary<int, List<ActiveConditionInfo>> list = new Dictionary<int, List<ActiveConditionInfo>>();
			using (ProduceBussiness db = new ProduceBussiness())
			{
				foreach (ActiveConditionInfo info in db.GetAllActiveConditionInfo())
				{
					List<ActiveConditionInfo> temp = new List<ActiveConditionInfo>();
					if (!list.ContainsKey(info.ActiveID))
					{
						temp.Add(info);
						list.Add(info.ActiveID, temp);
					}
					else
					{
						list[info.ActiveID].Add(info);
					}
				}
			}
			return list;
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0001EF4C File Offset: 0x0001D14C
		public static Dictionary<int, ActiveAwardInfo> LoadActiveAwardDb(Dictionary<int, List<ActiveConditionInfo>> conditions)
		{
			Dictionary<int, ActiveAwardInfo> list = new Dictionary<int, ActiveAwardInfo>();
			using (ProduceBussiness db = new ProduceBussiness())
			{
				ActiveAwardInfo[] infos = db.GetAllActiveAwardInfo();
				foreach (int key in conditions.Keys)
				{
					foreach (ActiveAwardInfo info in infos)
					{
						if (key == info.ActiveID && !list.ContainsKey(info.ID))
						{
							list.Add(info.ID, info);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0001F00C File Offset: 0x0001D20C
		public static bool IsValid(ActiveConditionInfo info)
		{
			DateTime startTime = info.StartTime;
			DateTime endTime = info.EndTime;
			return info.StartTime.Ticks <= DateTime.Now.Ticks && info.EndTime.Ticks >= DateTime.Now.Ticks;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0001F068 File Offset: 0x0001D268
		public static List<ActiveAwardInfo> GetAwardInfo(DateTime lastDate, int playerGrade)
		{
			string itemIds = null;
			int days = (DateTime.Now - lastDate).Days;
			if (DateTime.Now.DayOfYear > lastDate.DayOfYear)
			{
				days++;
			}
			List<ActiveAwardInfo> list = new List<ActiveAwardInfo>();
			foreach (List<ActiveConditionInfo> list2 in ActiveMgr.m_ActiveConditionInfo.Values)
			{
				foreach (ActiveConditionInfo info in list2)
				{
					if (ActiveMgr.IsValid(info) && ActiveMgr.IsInGrade(info.LimitGrade, playerGrade) && info.Condition <= days)
					{
						itemIds = info.AwardId;
						int activeID = info.ActiveID;
					}
				}
			}
			if (!string.IsNullOrEmpty(itemIds))
			{
				foreach (string item in itemIds.Split(new char[] { ',' }))
				{
					if (!string.IsNullOrEmpty(item))
					{
						list.Add(ActiveMgr.m_ActiveAwardInfo[Convert.ToInt32(item)]);
					}
				}
			}
			return list;
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0001F1B0 File Offset: 0x0001D3B0
		private static bool IsInGrade(string limitGrade, int playerGrade)
		{
			bool result = false;
			int minGrad = 0;
			int maxGrad = 0;
			if (limitGrade != null)
			{
				string[] strs = limitGrade.Split(new char[] { '-' });
				if (strs.Length == 2)
				{
					minGrad = Convert.ToInt32(strs[0]);
					maxGrad = Convert.ToInt32(strs[1]);
				}
				if (minGrad <= playerGrade && maxGrad >= playerGrade)
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x040000C8 RID: 200
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x040000C9 RID: 201
		public static Dictionary<int, List<ActiveConditionInfo>> m_ActiveConditionInfo = new Dictionary<int, List<ActiveConditionInfo>>();

		// Token: 0x040000CA RID: 202
		public static Dictionary<int, ActiveAwardInfo> m_ActiveAwardInfo = new Dictionary<int, ActiveAwardInfo>();
	}
}
