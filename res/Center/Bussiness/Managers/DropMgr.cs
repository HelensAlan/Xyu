using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Bussiness.Protocol;
using log4net;
using SqlDataProvider.Data;

namespace Bussiness.Managers
{
	// Token: 0x02000021 RID: 33
	public class DropMgr
	{
		// Token: 0x060001BE RID: 446 RVA: 0x0001F3EB File Offset: 0x0001D5EB
		public static bool Init()
		{
			return DropMgr.ReLoad();
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0001F3F4 File Offset: 0x0001D5F4
		public static bool ReLoad()
		{
			bool result = false;
			try
			{
				List<DropCondiction> tempDropCondiction = DropMgr.LoadDropConditionDb();
				Interlocked.Exchange<List<DropCondiction>>(ref DropMgr.m_dropcondiction, tempDropCondiction);
				Dictionary<int, List<DropItem>> tempDropItem = DropMgr.LoadDropItemDb();
				Interlocked.Exchange<Dictionary<int, List<DropItem>>>(ref DropMgr.m_dropitem, tempDropItem);
				if (tempDropCondiction.Count > 0 && tempDropItem.Count > 0)
				{
					result = true;
				}
				else
				{
					DropMgr.log.Warn("DropMgr didn't load any data!");
				}
			}
			catch (Exception e)
			{
				DropMgr.log.Error("DropMgr", e);
			}
			return result;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0001F474 File Offset: 0x0001D674
		public static List<DropCondiction> LoadDropConditionDb()
		{
			List<DropCondiction> result;
			using (ProduceBussiness db = new ProduceBussiness())
			{
				DropCondiction[] infos = db.GetAllDropCondictions();
				result = ((infos != null) ? infos.ToList<DropCondiction>() : null);
			}
			return result;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0001F4B8 File Offset: 0x0001D6B8
		public static Dictionary<int, List<DropItem>> LoadDropItemDb()
		{
			Dictionary<int, List<DropItem>> list = new Dictionary<int, List<DropItem>>();
			using (ProduceBussiness db = new ProduceBussiness())
			{
				DropItem[] infos = db.GetAllDropItems();
				using (List<DropCondiction>.Enumerator enumerator = DropMgr.m_dropcondiction.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DropCondiction info = enumerator.Current;
						IEnumerable<DropItem> temp = from s in infos
							where s.DropId == info.DropId
							select s;
						list.Add(info.DropId, temp.ToList<DropItem>());
					}
				}
			}
			return list;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0001F568 File Offset: 0x0001D768
		public static int FindCondiction(eDropType type, string para1, string para2)
		{
			string temppara = "," + para1 + ",";
			string temppara2 = "," + para2 + ",";
			foreach (DropCondiction drop in DropMgr.m_dropcondiction)
			{
				if (drop.CondictionType == (int)type && drop.Para1.IndexOf(temppara) != -1 && drop.Para2.IndexOf(temppara2) != -1)
				{
					return drop.DropId;
				}
			}
			return 0;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0001F60C File Offset: 0x0001D80C
		public static List<DropItem> FindDropItem(int dropId)
		{
			List<DropItem> result;
			if (DropMgr.m_dropitem.ContainsKey(dropId))
			{
				result = DropMgr.m_dropitem[dropId];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x040000CF RID: 207
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x040000D0 RID: 208
		private static string[] m_DropTypes = Enum.GetNames(typeof(eDropType));

		// Token: 0x040000D1 RID: 209
		private static List<DropCondiction> m_dropcondiction = new List<DropCondiction>();

		// Token: 0x040000D2 RID: 210
		private static Dictionary<int, List<DropItem>> m_dropitem = new Dictionary<int, List<DropItem>>();
	}
}
