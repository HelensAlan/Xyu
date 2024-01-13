using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Bussiness;
using log4net;
using SqlDataProvider.Data;

namespace Center.Server
{
	// Token: 0x02000007 RID: 7
	public class ConsortiaLevelMgr
	{
		// Token: 0x0600004B RID: 75 RVA: 0x000044DC File Offset: 0x000026DC
		public static bool ReLoad()
		{
			try
			{
				Dictionary<int, ConsortiaLevelInfo> consortiaLevel = new Dictionary<int, ConsortiaLevelInfo>();
				if (ConsortiaLevelMgr.Load(consortiaLevel))
				{
					ConsortiaLevelMgr.m_lock.AcquireWriterLock(-1);
					try
					{
						ConsortiaLevelMgr._consortiaLevel = consortiaLevel;
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
			catch (Exception exception)
			{
				if (ConsortiaLevelMgr.log.IsErrorEnabled)
				{
					ConsortiaLevelMgr.log.Error("ConsortiaLevelMgr", exception);
				}
			}
			return false;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004568 File Offset: 0x00002768
		public static bool Init()
		{
			bool result;
			try
			{
				ConsortiaLevelMgr.m_lock = new ReaderWriterLock();
				ConsortiaLevelMgr._consortiaLevel = new Dictionary<int, ConsortiaLevelInfo>();
				result = ConsortiaLevelMgr.Load(ConsortiaLevelMgr._consortiaLevel);
			}
			catch (Exception exception)
			{
				if (ConsortiaLevelMgr.log.IsErrorEnabled)
				{
					ConsortiaLevelMgr.log.Error("ConsortiaLevelMgr", exception);
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000045C8 File Offset: 0x000027C8
		private static bool Load(Dictionary<int, ConsortiaLevelInfo> consortiaLevel)
		{
			using (ConsortiaBussiness consortiaBussiness = new ConsortiaBussiness())
			{
				foreach (ConsortiaLevelInfo consortiaLevelInfo in consortiaBussiness.GetAllConsortiaLevel())
				{
					if (!consortiaLevel.ContainsKey(consortiaLevelInfo.Level))
					{
						consortiaLevel.Add(consortiaLevelInfo.Level, consortiaLevelInfo);
					}
				}
			}
			return true;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000462C File Offset: 0x0000282C
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

		// Token: 0x04000026 RID: 38
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000027 RID: 39
		private static Dictionary<int, ConsortiaLevelInfo> _consortiaLevel;

		// Token: 0x04000028 RID: 40
		private static ReaderWriterLock m_lock;
	}
}
