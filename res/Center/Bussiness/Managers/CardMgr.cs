using System;
using System.Reflection;
using System.Threading;
using log4net;
using SqlDataProvider.Data;

namespace Bussiness.Managers
{
	// Token: 0x02000020 RID: 32
	public class CardMgr
	{
		// Token: 0x060001B8 RID: 440 RVA: 0x0001F230 File Offset: 0x0001D430
		public static bool ReLoad()
		{
			try
			{
				CardMgr.m_lock.AcquireWriterLock(-1);
				try
				{
					using (ProduceBussiness db = new ProduceBussiness())
					{
						CardMgr._cardUpdateInfo = db.GetCardUpdateInfo();
						CardMgr._cardUpdateConditionInfo = db.GetCardUpdateConditionInfo();
					}
					return true;
				}
				catch
				{
				}
				finally
				{
					CardMgr.m_lock.ReleaseWriterLock();
				}
			}
			catch (Exception e)
			{
				if (CardMgr.log.IsErrorEnabled)
				{
					CardMgr.log.Error("ReLoad", e);
				}
			}
			return false;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0001F2DC File Offset: 0x0001D4DC
		public static bool Init()
		{
			bool result;
			try
			{
				CardMgr.m_lock = new ReaderWriterLock();
				using (ProduceBussiness db = new ProduceBussiness())
				{
					CardMgr._cardUpdateInfo = db.GetCardUpdateInfo();
					CardMgr._cardUpdateConditionInfo = db.GetCardUpdateConditionInfo();
				}
				result = true;
			}
			catch (Exception e)
			{
				if (CardMgr.log.IsErrorEnabled)
				{
					CardMgr.log.Error("Init", e);
				}
				result = false;
			}
			return result;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0001F360 File Offset: 0x0001D560
		public static CardUpdateInfo GetUpdateInfo(int templateID, int level)
		{
			foreach (CardUpdateInfo info in CardMgr._cardUpdateInfo)
			{
				if (info.Id == templateID && info.Level == level)
				{
					return info;
				}
			}
			return null;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0001F39C File Offset: 0x0001D59C
		public static CardUpdateConditionInfo GetCardUpdateConditionInfo(int level)
		{
			foreach (CardUpdateConditionInfo info in CardMgr._cardUpdateConditionInfo)
			{
				if (info.Level == level)
				{
					return info;
				}
			}
			return null;
		}

		// Token: 0x040000CB RID: 203
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x040000CC RID: 204
		private static CardUpdateInfo[] _cardUpdateInfo;

		// Token: 0x040000CD RID: 205
		private static CardUpdateConditionInfo[] _cardUpdateConditionInfo;

		// Token: 0x040000CE RID: 206
		private static ReaderWriterLock m_lock;
	}
}
