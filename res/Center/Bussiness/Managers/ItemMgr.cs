using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using log4net;
using SqlDataProvider.Data;

namespace Bussiness.Managers
{
	// Token: 0x02000024 RID: 36
	public class ItemMgr
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00020032 File Offset: 0x0001E232
		public static List<ItemTemplateInfo> Items
		{
			get
			{
				return ItemMgr._items.Values.ToList<ItemTemplateInfo>();
			}
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00020044 File Offset: 0x0001E244
		public static bool ReLoad()
		{
			try
			{
				Dictionary<int, ItemTemplateInfo> tempItems = new Dictionary<int, ItemTemplateInfo>();
				if (ItemMgr.LoadItem(tempItems))
				{
					ItemMgr.m_lock.AcquireWriterLock(-1);
					try
					{
						ItemMgr._items = tempItems;
						return true;
					}
					catch
					{
					}
					finally
					{
						ItemMgr.m_lock.ReleaseWriterLock();
					}
				}
			}
			catch (Exception e)
			{
				if (ItemMgr.log.IsErrorEnabled)
				{
					ItemMgr.log.Error("ReLoad", e);
				}
			}
			return false;
		}

		// Token: 0x060001DB RID: 475 RVA: 0x000200D0 File Offset: 0x0001E2D0
		public static bool Init()
		{
			bool result;
			try
			{
				ItemMgr.m_lock = new ReaderWriterLock();
				ItemMgr._items = new Dictionary<int, ItemTemplateInfo>();
				result = ItemMgr.LoadItem(ItemMgr._items);
			}
			catch (Exception e)
			{
				if (ItemMgr.log.IsErrorEnabled)
				{
					ItemMgr.log.Error("Init", e);
				}
				result = false;
			}
			return result;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00020130 File Offset: 0x0001E330
		public static bool LoadItem(Dictionary<int, ItemTemplateInfo> infos)
		{
			using (ProduceBussiness db = new ProduceBussiness())
			{
				foreach (ItemTemplateInfo item in db.GetAllGoods())
				{
					if (!infos.Keys.Contains(item.TemplateID))
					{
						infos.Add(item.TemplateID, item);
					}
				}
			}
			return true;
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0002019C File Offset: 0x0001E39C
		public static ItemTemplateInfo FindItemTemplate(int templateId)
		{
			if (ItemMgr._items == null)
			{
				ItemMgr.Init();
			}
			ItemMgr.m_lock.AcquireReaderLock(-1);
			try
			{
				if (ItemMgr._items.Keys.Contains(templateId))
				{
					return ItemMgr._items[templateId];
				}
			}
			finally
			{
				ItemMgr.m_lock.ReleaseReaderLock();
			}
			return null;
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00020204 File Offset: 0x0001E404
		public static ItemTemplateInfo GetGoodsbyFusionTypeandQuality(int fusionType, int quality)
		{
			if (ItemMgr._items == null)
			{
				ItemMgr.Init();
			}
			ItemMgr.m_lock.AcquireReaderLock(-1);
			try
			{
				foreach (ItemTemplateInfo p in ItemMgr._items.Values)
				{
					if (p.FusionType == fusionType && p.Quality == quality)
					{
						return p;
					}
				}
			}
			finally
			{
				ItemMgr.m_lock.ReleaseReaderLock();
			}
			return null;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0002029C File Offset: 0x0001E49C
		public static ItemTemplateInfo GetGoodsbyFusionTypeandLevel(int fusionType, int level)
		{
			if (ItemMgr._items == null)
			{
				ItemMgr.Init();
			}
			ItemMgr.m_lock.AcquireReaderLock(-1);
			try
			{
				foreach (ItemTemplateInfo p in ItemMgr._items.Values)
				{
					if (p.FusionType == fusionType && p.Level == level)
					{
						return p;
					}
				}
			}
			finally
			{
				ItemMgr.m_lock.ReleaseReaderLock();
			}
			return null;
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00020334 File Offset: 0x0001E534
		public static List<ItemInfo> SpiltGoodsMaxCount(ItemInfo itemInfo)
		{
			List<ItemInfo> Infos = new List<ItemInfo>();
			for (int maxItem = 0; maxItem < itemInfo.Count; maxItem += itemInfo.Template.MaxCount)
			{
				int tempCount = ((itemInfo.Count < itemInfo.Template.MaxCount) ? itemInfo.Count : itemInfo.Template.MaxCount);
				ItemInfo item = itemInfo.Clone();
				item.Count = tempCount;
				Infos.Add(item);
			}
			return Infos;
		}

		// Token: 0x040000DA RID: 218
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x040000DB RID: 219
		private static Dictionary<int, ItemTemplateInfo> _items;

		// Token: 0x040000DC RID: 220
		private static ReaderWriterLock m_lock;
	}
}
