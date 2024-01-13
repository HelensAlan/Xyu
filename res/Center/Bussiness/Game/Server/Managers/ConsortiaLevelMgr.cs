using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Bussiness;
using log4net;
using SqlDataProvider.Data;

namespace Game.Server.Managers
{
	// Token: 0x02000003 RID: 3
	public class ConsortiaLevelMgr
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00003070 File Offset: 0x00001270
		public static bool ReLoad()
		{
			try
			{
				Dictionary<int, ConsortiaLevelInfo> tempConsortiaLevel = new Dictionary<int, ConsortiaLevelInfo>();
				if (ConsortiaLevelMgr.Load(tempConsortiaLevel))
				{
					ConsortiaLevelMgr.m_lock.AcquireWriterLock(-1);
					try
					{
						ConsortiaLevelMgr._consortiaLevel = tempConsortiaLevel;
						return true;
					}
					catch
					{
					}
					finally
					{
						ConsortiaLevelMgr.m_lock.ReleaseWriterLock();
					}
				}
			}
			catch (Exception e)
			{
				if (ConsortiaLevelMgr.log.IsErrorEnabled)
				{
					ConsortiaLevelMgr.log.Error("ConsortiaLevelMgr", e);
				}
			}
			return false;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000030FC File Offset: 0x000012FC
		public static bool Init()
		{
			bool result;
			try
			{
				ConsortiaLevelMgr.m_lock = new ReaderWriterLock();
				ConsortiaLevelMgr._consortiaLevel = new Dictionary<int, ConsortiaLevelInfo>();
				result = ConsortiaLevelMgr.Load(ConsortiaLevelMgr._consortiaLevel);
			}
			catch (Exception e)
			{
				if (ConsortiaLevelMgr.log.IsErrorEnabled)
				{
					ConsortiaLevelMgr.log.Error("ConsortiaLevelMgr", e);
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000315C File Offset: 0x0000135C
		private static bool Load(Dictionary<int, ConsortiaLevelInfo> consortiaLevel)
		{
			using (ConsortiaBussiness db = new ConsortiaBussiness())
			{
				foreach (ConsortiaLevelInfo info in db.GetAllConsortiaLevel())
				{
					if (!consortiaLevel.ContainsKey(info.Level))
					{
						consortiaLevel.Add(info.Level, info);
					}
				}
			}
			return true;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000031C0 File Offset: 0x000013C0
		public static ConsortiaLevelInfo FindConsortiaLevelInfo(int level)
		{
			ConsortiaLevelMgr.m_lock.AcquireReaderLock(-1);
			try
			{
				if (ConsortiaLevelMgr._consortiaLevel.ContainsKey(level))
				{
					return ConsortiaLevelMgr._consortiaLevel[level];
				}
			}
			catch
			{
			}
			finally
			{
				ConsortiaLevelMgr.m_lock.ReleaseReaderLock();
			}
			return null;
		}

		// Token: 0x0400000D RID: 13
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x0400000E RID: 14
		private static Dictionary<int, ConsortiaLevelInfo> _consortiaLevel;

		// Token: 0x0400000F RID: 15
		private static ReaderWriterLock m_lock;
	}
}
