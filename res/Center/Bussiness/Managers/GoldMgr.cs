using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using log4net;
using SqlDataProvider.Data;

namespace Bussiness.Managers
{
	// Token: 0x02000022 RID: 34
	public class GoldMgr
	{
		// Token: 0x060001C6 RID: 454 RVA: 0x0001F680 File Offset: 0x0001D880
		public static bool ReLoad()
		{
			try
			{
				Dictionary<int, GoldEquipInfo> tempInfos = new Dictionary<int, GoldEquipInfo>();
				if (GoldMgr.LoadInfo(tempInfos))
				{
					GoldMgr.m_lock.AcquireWriterLock(-1);
					try
					{
						GoldMgr._infos = tempInfos;
						return true;
					}
					catch
					{
					}
					finally
					{
						GoldMgr.m_lock.ReleaseWriterLock();
					}
				}
			}
			catch (Exception e)
			{
				if (GoldMgr.log.IsErrorEnabled)
				{
					GoldMgr.log.Error("ReLoad", e);
				}
			}
			return false;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0001F70C File Offset: 0x0001D90C
		public static bool Init()
		{
			bool result;
			try
			{
				GoldMgr.m_lock = new ReaderWriterLock();
				GoldMgr._infos = new Dictionary<int, GoldEquipInfo>();
				result = GoldMgr.LoadInfo(GoldMgr._infos);
			}
			catch (Exception e)
			{
				if (GoldMgr.log.IsErrorEnabled)
				{
					GoldMgr.log.Error("Init", e);
				}
				result = false;
			}
			return result;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0001F76C File Offset: 0x0001D96C
		public static bool LoadInfo(Dictionary<int, GoldEquipInfo> infos)
		{
			using (ProduceBussiness db = new ProduceBussiness())
			{
				foreach (GoldEquipInfo info in db.GetGoldEquipInfo())
				{
					if (!infos.Keys.Contains(info.ID))
					{
						infos.Add(info.ID, info);
					}
				}
			}
			return true;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0001F7D8 File Offset: 0x0001D9D8
		public static GoldEquipInfo FindOldTemplate(int templateId)
		{
			if (GoldMgr._infos == null)
			{
				GoldMgr.Init();
			}
			GoldMgr.m_lock.AcquireReaderLock(-1);
			try
			{
				foreach (KeyValuePair<int, GoldEquipInfo> i in GoldMgr._infos)
				{
					if (i.Value.NewTemplateId == templateId)
					{
						return i.Value;
					}
				}
			}
			finally
			{
				GoldMgr.m_lock.ReleaseReaderLock();
			}
			return null;
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0001F870 File Offset: 0x0001DA70
		public static GoldEquipInfo FindNewTemplate(int templateId)
		{
			if (GoldMgr._infos == null)
			{
				GoldMgr.Init();
			}
			GoldMgr.m_lock.AcquireReaderLock(-1);
			try
			{
				foreach (KeyValuePair<int, GoldEquipInfo> i in GoldMgr._infos)
				{
					if (i.Value.OldTemplateId == templateId)
					{
						return i.Value;
					}
				}
			}
			finally
			{
				GoldMgr.m_lock.ReleaseReaderLock();
			}
			return null;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0001F908 File Offset: 0x0001DB08
		public static GoldEquipInfo FindTemplateByCategoryID(int categoryId)
		{
			if (GoldMgr._infos == null)
			{
				GoldMgr.Init();
			}
			GoldMgr.m_lock.AcquireReaderLock(-1);
			try
			{
				foreach (KeyValuePair<int, GoldEquipInfo> i in GoldMgr._infos)
				{
					if (i.Value.CategoryID == categoryId)
					{
						return i.Value;
					}
				}
			}
			finally
			{
				GoldMgr.m_lock.ReleaseReaderLock();
			}
			return null;
		}

		// Token: 0x040000D3 RID: 211
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x040000D4 RID: 212
		private static Dictionary<int, GoldEquipInfo> _infos;

		// Token: 0x040000D5 RID: 213
		private static ReaderWriterLock m_lock;
	}
}
