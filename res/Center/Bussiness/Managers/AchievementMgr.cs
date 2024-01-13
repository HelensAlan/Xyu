using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using log4net;
using SqlDataProvider.Data;

namespace Bussiness.Managers
{
	// Token: 0x0200001E RID: 30
	public class AchievementMgr
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x0001E9E4 File Offset: 0x0001CBE4
		public static Hashtable ItemRecordType
		{
			get
			{
				return AchievementMgr.m_ItemRecordTypeInfo;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x0001E9EB File Offset: 0x0001CBEB
		public static Dictionary<int, AchievementInfo> Achievement
		{
			get
			{
				return AchievementMgr.m_achievement;
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0001E9F2 File Offset: 0x0001CBF2
		public static bool Init()
		{
			return AchievementMgr.Reload();
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0001E9FC File Offset: 0x0001CBFC
		public static bool Reload()
		{
			try
			{
				AchievementMgr.LoadItemRecordTypeInfoDB();
				Dictionary<int, AchievementInfo> tempAchievementInfo = AchievementMgr.LoadAchievementInfoDB();
				Dictionary<int, List<AchievementConditionInfo>> tempAchievementConditionInfo = AchievementMgr.LoadAchievementConditionInfoDB(tempAchievementInfo);
				Dictionary<int, List<AchievementRewardInfo>> tempAchievementRewardInfo = AchievementMgr.LoadAchievementRewardInfoDB(tempAchievementInfo);
				if (tempAchievementInfo.Count > 0)
				{
					Interlocked.Exchange<Dictionary<int, AchievementInfo>>(ref AchievementMgr.m_achievement, tempAchievementInfo);
					Interlocked.Exchange<Dictionary<int, List<AchievementConditionInfo>>>(ref AchievementMgr.m_achievementCondition, tempAchievementConditionInfo);
					Interlocked.Exchange<Dictionary<int, List<AchievementRewardInfo>>>(ref AchievementMgr.m_achievementReward, tempAchievementRewardInfo);
				}
				return true;
			}
			catch (Exception ex)
			{
				AchievementMgr.log.Error("AchievementMgr", ex);
			}
			return false;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0001EA7C File Offset: 0x0001CC7C
		public static void LoadItemRecordTypeInfoDB()
		{
			using (ProduceBussiness db = new ProduceBussiness())
			{
				foreach (ItemRecordTypeInfo info in db.GetAllItemRecordType())
				{
					if (!AchievementMgr.m_ItemRecordTypeInfo.Contains(info.RecordID))
					{
						AchievementMgr.m_ItemRecordTypeInfo.Add(info.RecordID, info.Name);
					}
				}
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0001EAF8 File Offset: 0x0001CCF8
		public static Dictionary<int, AchievementInfo> LoadAchievementInfoDB()
		{
			Dictionary<int, AchievementInfo> list = new Dictionary<int, AchievementInfo>();
			using (ProduceBussiness db = new ProduceBussiness())
			{
				foreach (AchievementInfo info in db.GetALlAchievement())
				{
					if (!list.ContainsKey(info.ID))
					{
						list.Add(info.ID, info);
					}
				}
			}
			return list;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0001EB68 File Offset: 0x0001CD68
		public static Dictionary<int, List<AchievementConditionInfo>> LoadAchievementConditionInfoDB(Dictionary<int, AchievementInfo> achievementInfos)
		{
			Dictionary<int, List<AchievementConditionInfo>> list = new Dictionary<int, List<AchievementConditionInfo>>();
			using (ProduceBussiness db = new ProduceBussiness())
			{
				AchievementConditionInfo[] infos = db.GetALlAchievementCondition();
				using (Dictionary<int, AchievementInfo>.ValueCollection.Enumerator enumerator = achievementInfos.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						AchievementInfo achievementInfo = enumerator.Current;
						IEnumerable<AchievementConditionInfo> temp = from s in infos
							where s.AchievementID == achievementInfo.ID
							select s;
						list.Add(achievementInfo.ID, temp.ToList<AchievementConditionInfo>());
						if (temp != null)
						{
							foreach (AchievementConditionInfo info in temp)
							{
								if (!AchievementMgr.m_distinctCondition.Contains(info.CondictionType))
								{
									AchievementMgr.m_distinctCondition.Add(info.CondictionType, info.CondictionType);
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0001EC94 File Offset: 0x0001CE94
		public static Dictionary<int, List<AchievementRewardInfo>> LoadAchievementRewardInfoDB(Dictionary<int, AchievementInfo> achievementInfos)
		{
			Dictionary<int, List<AchievementRewardInfo>> list = new Dictionary<int, List<AchievementRewardInfo>>();
			using (ProduceBussiness db = new ProduceBussiness())
			{
				AchievementRewardInfo[] infos = db.GetALlAchievementReward();
				using (Dictionary<int, AchievementInfo>.ValueCollection.Enumerator enumerator = achievementInfos.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						AchievementInfo achievementInfo = enumerator.Current;
						IEnumerable<AchievementRewardInfo> temp = from s in infos
							where s.AchievementID == achievementInfo.ID
							select s;
						list.Add(achievementInfo.ID, temp.ToList<AchievementRewardInfo>());
					}
				}
			}
			return list;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0001ED48 File Offset: 0x0001CF48
		public static AchievementInfo GetSingleAchievement(int id)
		{
			AchievementInfo result;
			if (AchievementMgr.m_achievement.ContainsKey(id))
			{
				result = AchievementMgr.m_achievement[id];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0001ED74 File Offset: 0x0001CF74
		public static List<AchievementConditionInfo> GetAchievementCondition(AchievementInfo info)
		{
			List<AchievementConditionInfo> result;
			if (AchievementMgr.m_achievementCondition.ContainsKey(info.ID))
			{
				result = AchievementMgr.m_achievementCondition[info.ID];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0001EDAC File Offset: 0x0001CFAC
		public static List<AchievementRewardInfo> GetAchievementReward(AchievementInfo info)
		{
			List<AchievementRewardInfo> result;
			if (AchievementMgr.m_achievementReward.ContainsKey(info.ID))
			{
				result = AchievementMgr.m_achievementReward[info.ID];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x040000C1 RID: 193
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x040000C2 RID: 194
		private static Dictionary<int, AchievementInfo> m_achievement = new Dictionary<int, AchievementInfo>();

		// Token: 0x040000C3 RID: 195
		private static Dictionary<int, List<AchievementConditionInfo>> m_achievementCondition = new Dictionary<int, List<AchievementConditionInfo>>();

		// Token: 0x040000C4 RID: 196
		private static Dictionary<int, List<AchievementRewardInfo>> m_achievementReward = new Dictionary<int, List<AchievementRewardInfo>>();

		// Token: 0x040000C5 RID: 197
		private static Dictionary<int, List<ItemRecordTypeInfo>> m_itemRecordType = new Dictionary<int, List<ItemRecordTypeInfo>>();

		// Token: 0x040000C6 RID: 198
		private static Hashtable m_distinctCondition = new Hashtable();

		// Token: 0x040000C7 RID: 199
		private static Hashtable m_ItemRecordTypeInfo = new Hashtable();
	}
}
