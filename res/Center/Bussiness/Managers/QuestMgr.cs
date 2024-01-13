using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using log4net;
using SqlDataProvider.Data;

namespace Bussiness.Managers
{
	// Token: 0x02000025 RID: 37
	public class QuestMgr
	{
		// Token: 0x060001E3 RID: 483 RVA: 0x000203BD File Offset: 0x0001E5BD
		public static bool Init()
		{
			return QuestMgr.ReLoad();
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x000203C4 File Offset: 0x0001E5C4
		public static bool ReLoad()
		{
			try
			{
				Dictionary<int, QuestInfo> tempQuestInfo = QuestMgr.LoadQuestInfoDb();
				Dictionary<int, List<QuestConditionInfo>> tempQuestCondiction = QuestMgr.LoadQuestCondictionDb(tempQuestInfo);
				Dictionary<int, List<QuestAwardInfo>> tempQuestGoods = QuestMgr.LoadQuestGoodDb(tempQuestInfo);
				if (tempQuestInfo.Count > 0)
				{
					Interlocked.Exchange<Dictionary<int, QuestInfo>>(ref QuestMgr.m_questinfo, tempQuestInfo);
					Interlocked.Exchange<Dictionary<int, List<QuestConditionInfo>>>(ref QuestMgr.m_questcondiction, tempQuestCondiction);
					Interlocked.Exchange<Dictionary<int, List<QuestAwardInfo>>>(ref QuestMgr.m_questgoods, tempQuestGoods);
				}
				return true;
			}
			catch (Exception e)
			{
				QuestMgr.log.Error("QuestMgr", e);
			}
			return false;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00020440 File Offset: 0x0001E640
		public static Dictionary<int, QuestInfo> LoadQuestInfoDb()
		{
			Dictionary<int, QuestInfo> list = new Dictionary<int, QuestInfo>();
			using (ProduceBussiness db = new ProduceBussiness())
			{
				foreach (QuestInfo info in db.GetALlQuest())
				{
					if (!list.ContainsKey(info.ID))
					{
						list.Add(info.ID, info);
					}
				}
			}
			return list;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x000204B0 File Offset: 0x0001E6B0
		public static Dictionary<int, List<QuestConditionInfo>> LoadQuestCondictionDb(Dictionary<int, QuestInfo> quests)
		{
			Dictionary<int, List<QuestConditionInfo>> list = new Dictionary<int, List<QuestConditionInfo>>();
			using (ProduceBussiness db = new ProduceBussiness())
			{
				QuestConditionInfo[] infos = db.GetAllQuestCondiction();
				using (Dictionary<int, QuestInfo>.ValueCollection.Enumerator enumerator = quests.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						QuestInfo quest = enumerator.Current;
						IEnumerable<QuestConditionInfo> temp = from s in infos
							where s.QuestID == quest.ID
							select s;
						list.Add(quest.ID, temp.ToList<QuestConditionInfo>());
					}
				}
			}
			return list;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00020564 File Offset: 0x0001E764
		public static Dictionary<int, List<QuestAwardInfo>> LoadQuestGoodDb(Dictionary<int, QuestInfo> quests)
		{
			Dictionary<int, List<QuestAwardInfo>> list = new Dictionary<int, List<QuestAwardInfo>>();
			using (ProduceBussiness db = new ProduceBussiness())
			{
				QuestAwardInfo[] infos = db.GetAllQuestGoods();
				using (Dictionary<int, QuestInfo>.ValueCollection.Enumerator enumerator = quests.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						QuestInfo quest = enumerator.Current;
						IEnumerable<QuestAwardInfo> temp = from s in infos
							where s.QuestID == quest.ID
							select s;
						list.Add(quest.ID, temp.ToList<QuestAwardInfo>());
					}
				}
			}
			return list;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00020618 File Offset: 0x0001E818
		public static QuestInfo GetSingleQuest(int id)
		{
			QuestInfo result;
			if (QuestMgr.m_questinfo.ContainsKey(id))
			{
				result = QuestMgr.m_questinfo[id];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00020644 File Offset: 0x0001E844
		public static List<QuestAwardInfo> GetQuestGoods(QuestInfo info)
		{
			List<QuestAwardInfo> result;
			if (QuestMgr.m_questgoods.ContainsKey(info.ID))
			{
				result = QuestMgr.m_questgoods[info.ID];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0002067C File Offset: 0x0001E87C
		public static List<QuestConditionInfo> GetQuestCondiction(QuestInfo info)
		{
			List<QuestConditionInfo> result;
			if (QuestMgr.m_questcondiction.ContainsKey(info.ID))
			{
				result = QuestMgr.m_questcondiction[info.ID];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x040000DD RID: 221
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x040000DE RID: 222
		private static Dictionary<int, QuestInfo> m_questinfo = new Dictionary<int, QuestInfo>();

		// Token: 0x040000DF RID: 223
		private static Dictionary<int, List<QuestConditionInfo>> m_questcondiction = new Dictionary<int, List<QuestConditionInfo>>();

		// Token: 0x040000E0 RID: 224
		private static Dictionary<int, List<QuestAwardInfo>> m_questgoods = new Dictionary<int, List<QuestAwardInfo>>();
	}
}
