using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using log4net;
using SqlDataProvider.Data;

namespace Bussiness.Managers
{
	// Token: 0x02000023 RID: 35
	public class ItemBoxMgr
	{
		// Token: 0x060001CE RID: 462 RVA: 0x0001F9C0 File Offset: 0x0001DBC0
		public static bool ReLoad()
		{
			try
			{
				ItemBoxInfo[] tempItemBox = ItemBoxMgr.LoadItemBoxDb();
				Dictionary<int, List<ItemBoxInfo>> tempItemBoxs = ItemBoxMgr.LoadItemBoxs(tempItemBox);
				if (tempItemBox != null)
				{
					Interlocked.Exchange<ItemBoxInfo[]>(ref ItemBoxMgr.m_itemBox, tempItemBox);
					Interlocked.Exchange<Dictionary<int, List<ItemBoxInfo>>>(ref ItemBoxMgr.m_itemBoxs, tempItemBoxs);
				}
			}
			catch (Exception e)
			{
				if (ItemBoxMgr.log.IsErrorEnabled)
				{
					ItemBoxMgr.log.Error("ReLoad", e);
				}
				return false;
			}
			return true;
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0001FA2C File Offset: 0x0001DC2C
		public static bool Init()
		{
			return ItemBoxMgr.ReLoad();
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0001FA34 File Offset: 0x0001DC34
		public static ItemBoxInfo[] LoadItemBoxDb()
		{
			new Dictionary<int, ItemBoxInfo>();
			ItemBoxInfo[] result;
			using (ProduceBussiness db = new ProduceBussiness())
			{
				result = db.GetItemBoxInfos();
			}
			return result;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0001FA74 File Offset: 0x0001DC74
		public static Dictionary<int, List<ItemBoxInfo>> LoadItemBoxs(ItemBoxInfo[] itemBoxs)
		{
			Dictionary<int, List<ItemBoxInfo>> infos = new Dictionary<int, List<ItemBoxInfo>>();
			Func<ItemBoxInfo, bool> <>9__0;
			foreach (ItemBoxInfo info in itemBoxs)
			{
				if (!infos.Keys.Contains(info.DataId))
				{
					Func<ItemBoxInfo, bool> predicate;
					if ((predicate = <>9__0) == null)
					{
						predicate = (<>9__0 = (ItemBoxInfo s) => s.DataId == info.DataId);
					}
					IEnumerable<ItemBoxInfo> temp = itemBoxs.Where(predicate);
					infos.Add(info.DataId, temp.ToList<ItemBoxInfo>());
				}
			}
			return infos;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0001FAFC File Offset: 0x0001DCFC
		public static bool LoadItemBoxs(Dictionary<int, List<ItemBoxInfo>> infos)
		{
			bool result;
			using (ProduceBussiness db = new ProduceBussiness())
			{
				ItemBoxInfo[] items = db.GetItemBoxInfos();
				Func<ItemBoxInfo, bool> <>9__0;
				foreach (ItemBoxInfo item in items)
				{
					if (!infos.Keys.Contains(item.DataId))
					{
						IEnumerable<ItemBoxInfo> source = items;
						Func<ItemBoxInfo, bool> predicate;
						if ((predicate = <>9__0) == null)
						{
							predicate = (<>9__0 = (ItemBoxInfo s) => s.DataId == item.DataId);
						}
						IEnumerable<ItemBoxInfo> temp = source.Where(predicate);
						infos.Add(item.DataId, temp.ToList<ItemBoxInfo>());
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0001FBB8 File Offset: 0x0001DDB8
		public static List<ItemBoxInfo> FindItemBox(int DataId)
		{
			List<ItemBoxInfo> result;
			if (ItemBoxMgr.m_itemBoxs.ContainsKey(DataId))
			{
				result = ItemBoxMgr.m_itemBoxs[DataId];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0001FBE4 File Offset: 0x0001DDE4
		public static List<ItemBoxInfo> GetRouletteGoods(int dataId)
		{
			List<ItemBoxInfo> result = new List<ItemBoxInfo>();
			List<ItemBoxInfo> unFiltInfos = (from x in ItemBoxMgr.FindItemBox(dataId)
				orderby x.Random descending
				select x).ToList<ItemBoxInfo>();
			if (unFiltInfos == null || unFiltInfos.Count < 18)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < 18; i++)
				{
					int total = unFiltInfos.Sum((ItemBoxInfo x) => x.Random);
					int random = ItemBoxMgr.random.Next(total);
					int current = 0;
					for (int j = 0; j < unFiltInfos.Count; j++)
					{
						ItemBoxInfo item = unFiltInfos[j];
						current += item.Random;
						if (current >= random)
						{
							result.Add(item);
							unFiltInfos.RemoveAt(j);
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0001FCC8 File Offset: 0x0001DEC8
		public static bool CreateItemBox(int DateId, List<ItemInfo> itemInfos, ref int gold, ref int point, ref int giftToken, ref int gp)
		{
			List<ItemBoxInfo> FiltInfos = new List<ItemBoxInfo>();
			List<ItemBoxInfo> unFiltInfos = ItemBoxMgr.FindItemBox(DateId);
			if (unFiltInfos != null)
			{
				FiltInfos = (from s in unFiltInfos
					where s.IsSelect
					select s).ToList<ItemBoxInfo>();
				int dropItemCount = 1;
				int maxRound = 0;
				foreach (ItemBoxInfo boxInfo in unFiltInfos)
				{
					if (!boxInfo.IsSelect && maxRound < boxInfo.Random)
					{
						maxRound = boxInfo.Random;
					}
				}
				maxRound = ItemBoxMgr.random.Next(maxRound);
				List<ItemBoxInfo> RoundInfos = (from s in unFiltInfos
					where !s.IsSelect && s.Random >= maxRound
					select s).ToList<ItemBoxInfo>();
				int maxItems = RoundInfos.Count<ItemBoxInfo>();
				if (maxItems > 0)
				{
					dropItemCount = ((dropItemCount > maxItems) ? maxItems : dropItemCount);
					foreach (int j in ItemBoxMgr.GetRandomUnrepeatArray(0, maxItems - 1, dropItemCount))
					{
						ItemBoxInfo item = RoundInfos[j];
						if (FiltInfos == null)
						{
							FiltInfos = new List<ItemBoxInfo>();
						}
						FiltInfos.Add(item);
					}
				}
				foreach (ItemBoxInfo info in FiltInfos)
				{
					if (info == null)
					{
						return false;
					}
					int templateId = info.TemplateId;
					if (templateId <= -200)
					{
						if (templateId == -300)
						{
							giftToken += info.ItemCount;
							continue;
						}
						if (templateId == -200)
						{
							point += info.ItemCount;
							continue;
						}
					}
					else
					{
						if (templateId == -100)
						{
							gold += info.ItemCount;
							continue;
						}
						if (templateId == 11107)
						{
							gp += info.ItemCount;
							continue;
						}
					}
					ItemInfo item2 = ItemInfo.CreateFromTemplate(ItemMgr.FindItemTemplate(info.TemplateId), info.ItemCount, 101);
					if (item2 != null)
					{
						item2.IsBinds = info.IsBind;
						item2.ValidDate = info.ItemValid;
						item2.StrengthenLevel = info.StrengthenLevel;
						item2.AttackCompose = info.AttackCompose;
						item2.DefendCompose = info.DefendCompose;
						item2.AgilityCompose = info.AgilityCompose;
						item2.LuckCompose = info.LuckCompose;
						item2.IsTips = info.IsTips;
						item2.IsLogs = info.IsLogs;
						if (itemInfos == null)
						{
							itemInfos = new List<ItemInfo>();
						}
						itemInfos.Add(item2);
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0001FFB0 File Offset: 0x0001E1B0
		public static int[] GetRandomUnrepeatArray(int minValue, int maxValue, int count)
		{
			int[] resultRound = new int[count];
			for (int i = 0; i < count; i++)
			{
				int j = ItemBoxMgr.random.Next(minValue, maxValue + 1);
				int num = 0;
				for (int k = 0; k < i; k++)
				{
					if (resultRound[k] == j)
					{
						num++;
					}
				}
				if (num == 0)
				{
					resultRound[i] = j;
				}
				else
				{
					i--;
				}
			}
			return resultRound;
		}

		// Token: 0x040000D6 RID: 214
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x040000D7 RID: 215
		private static ItemBoxInfo[] m_itemBox;

		// Token: 0x040000D8 RID: 216
		private static Dictionary<int, List<ItemBoxInfo>> m_itemBoxs;

		// Token: 0x040000D9 RID: 217
		private static ThreadSafeRandom random = new ThreadSafeRandom();
	}
}
