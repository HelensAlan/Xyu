using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Bussiness;
using Game.Base.Packets;
using log4net;
using SqlDataProvider.Data;

namespace Center.Server
{
	// Token: 0x02000014 RID: 20
	public class SystemConsortiaMrg
	{
		// Token: 0x060000D3 RID: 211 RVA: 0x00005EBC File Offset: 0x000040BC
		public static bool Init()
		{
			bool result;
			try
			{
				SystemConsortiaMrg.m_lock = new ReaderWriterLock();
				SystemConsortiaMrg.allSystemConsortia = new Dictionary<int, ConsortiaInfo>();
				SystemConsortiaMrg.autoAcceptTimer = new Timer(new TimerCallback(SystemConsortiaMrg.autoAcceptHandler), null, SystemConsortiaMrg.autoAcceptInterval, SystemConsortiaMrg.autoAcceptInterval);
				SystemConsortiaMrg.autoUpdateTimer = new Timer(new TimerCallback(SystemConsortiaMrg.autoUpdateHandler), null, SystemConsortiaMrg.autoUpdateInterval, SystemConsortiaMrg.autoUpdateInterval);
				SystemConsortiaMrg.autoActiveTimer = new Timer(new TimerCallback(SystemConsortiaMrg.autoActiveHandler), null, SystemConsortiaMrg.autoActiveInterval, SystemConsortiaMrg.autoActiveInterval);
				result = SystemConsortiaMrg.Load(SystemConsortiaMrg.allSystemConsortia);
			}
			catch (Exception exception)
			{
				if (SystemConsortiaMrg.log.IsErrorEnabled)
				{
					SystemConsortiaMrg.log.Error("SystemConsortiaMrg", exception);
				}
				result = false;
			}
			return result;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00005F80 File Offset: 0x00004180
		private static bool Load(Dictionary<int, ConsortiaInfo> consortia)
		{
			using (ConsortiaBussiness consortiaBussiness = new ConsortiaBussiness())
			{
				foreach (ConsortiaInfo consortiaInfo in consortiaBussiness.GetAllSystemConsortia())
				{
					if (consortiaInfo.IsExist && !consortia.ContainsKey(consortiaInfo.ConsortiaID))
					{
						consortia.Add(consortiaInfo.ConsortiaID, consortiaInfo);
					}
				}
			}
			return true;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00005FEC File Offset: 0x000041EC
		public static bool ReLoad()
		{
			try
			{
				Dictionary<int, ConsortiaInfo> consortia = new Dictionary<int, ConsortiaInfo>();
				if (SystemConsortiaMrg.Load(consortia))
				{
					SystemConsortiaMrg.m_lock.AcquireWriterLock(-1);
					try
					{
						SystemConsortiaMrg.allSystemConsortia = consortia;
						SystemConsortiaMrg.autoUpdateHandler(null);
						return true;
					}
					catch
					{
					}
					finally
					{
						SystemConsortiaMrg.m_lock.ReleaseWriterLock();
					}
				}
			}
			catch (Exception exception)
			{
				if (SystemConsortiaMrg.log.IsErrorEnabled)
				{
					SystemConsortiaMrg.log.Error("SystemConsortiaMrg", exception);
				}
			}
			return false;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00006080 File Offset: 0x00004280
		public static ConsortiaInfo[] GatAllSystemConsortia()
		{
			ConsortiaInfo[] result;
			try
			{
				SystemConsortiaMrg.m_lock.AcquireReaderLock(-1);
				result = SystemConsortiaMrg.allSystemConsortia.Values.ToArray<ConsortiaInfo>();
			}
			catch
			{
				result = null;
			}
			finally
			{
				SystemConsortiaMrg.m_lock.ReleaseReaderLock();
			}
			return result;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000025E7 File Offset: 0x000007E7
		public static bool Stop()
		{
			SystemConsortiaMrg.autoAcceptTimer.Change(-1, -1);
			SystemConsortiaMrg.autoAcceptTimer.Dispose();
			SystemConsortiaMrg.autoUpdateTimer.Change(-1, -1);
			SystemConsortiaMrg.autoUpdateTimer.Dispose();
			return true;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000060D8 File Offset: 0x000042D8
		private static void autoActiveHandler(object state)
		{
			try
			{
				using (ConsortiaBussiness consortiaBussiness = new ConsortiaBussiness())
				{
					consortiaBussiness.ActiveConsortia();
				}
			}
			catch (Exception exception)
			{
				if (SystemConsortiaMrg.log.IsErrorEnabled)
				{
					SystemConsortiaMrg.log.Error("SystemConsortiaMrg", exception);
				}
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000613C File Offset: 0x0000433C
		private static void autoUpdateHandler(object state)
		{
			try
			{
				using (ConsortiaBussiness consortiaBussiness = new ConsortiaBussiness())
				{
					consortiaBussiness.UpdateRobotChairman();
				}
			}
			catch (Exception exception)
			{
				if (SystemConsortiaMrg.log.IsErrorEnabled)
				{
					SystemConsortiaMrg.log.Error("SystemConsortiaMrg", exception);
				}
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000061A0 File Offset: 0x000043A0
		private static void autoAcceptHandler(object state)
		{
			int num = 0;
			int page = 0;
			int num2 = 100;
			int num3 = 0;
			bool flag = true;
			string text = "";
			int val = 0;
			ConsortiaApplyUserInfo[] array = null;
			SystemConsortiaMrg.m_lock.AcquireReaderLock(-1);
			ConsortiaInfo[] array2 = SystemConsortiaMrg.allSystemConsortia.Values.ToArray<ConsortiaInfo>();
			SystemConsortiaMrg.m_lock.ReleaseReaderLock();
			try
			{
				foreach (ConsortiaInfo consortiaInfo in array2)
				{
					using (ConsortiaBussiness consortiaBussiness = new ConsortiaBussiness())
					{
						page = 1;
						num = 0;
						array = consortiaBussiness.GetConsortiaApplyUserPage(page, num2, ref num, 2, consortiaInfo.ConsortiaID, -1, -1);
					}
					if (array != null)
					{
						num3 = (num + num2 - 1) / num2;
						while (page++ <= num3)
						{
							foreach (ConsortiaApplyUserInfo consortiaApplyUserInfo in array)
							{
								if (DateTime.Compare(consortiaApplyUserInfo.ApplyDate.AddMinutes((double)SystemConsortiaMrg.minAcceptInterval), DateTime.Now) > 0)
								{
									flag = false;
									break;
								}
								using (ConsortiaBussiness consortiaBussiness2 = new ConsortiaBussiness())
								{
									ConsortiaUserInfo consortiaUserInfo = new ConsortiaUserInfo();
									if (consortiaBussiness2.PassConsortiaApplyUsers(consortiaApplyUserInfo.ID, consortiaInfo.ChairmanID, consortiaInfo.ChairmanName, consortiaInfo.ConsortiaID, ref text, consortiaUserInfo, ref val))
									{
										consortiaUserInfo.ConsortiaID = consortiaInfo.ConsortiaID;
										consortiaUserInfo.ConsortiaName = consortiaInfo.ConsortiaName;
										GSPacketIn gspacketIn = new GSPacketIn(128, consortiaInfo.ChairmanID);
										gspacketIn.WriteByte(1);
										gspacketIn.WriteInt(consortiaUserInfo.ID);
										gspacketIn.WriteBoolean(false);
										gspacketIn.WriteInt(consortiaUserInfo.ConsortiaID);
										gspacketIn.WriteString(consortiaUserInfo.ConsortiaName);
										gspacketIn.WriteInt(consortiaUserInfo.UserID);
										gspacketIn.WriteString(consortiaUserInfo.UserName);
										gspacketIn.WriteInt(consortiaInfo.ChairmanID);
										gspacketIn.WriteString(consortiaInfo.ChairmanName);
										gspacketIn.WriteInt(consortiaUserInfo.DutyID);
										gspacketIn.WriteString(consortiaUserInfo.DutyName);
										gspacketIn.WriteInt(consortiaUserInfo.Offer);
										gspacketIn.WriteInt(consortiaUserInfo.RichesOffer);
										gspacketIn.WriteInt(consortiaUserInfo.RichesRob);
										gspacketIn.WriteDateTime(consortiaUserInfo.LastDate);
										gspacketIn.WriteInt(consortiaUserInfo.Grade);
										gspacketIn.WriteInt(consortiaUserInfo.Level);
										gspacketIn.WriteInt(consortiaUserInfo.State);
										gspacketIn.WriteBoolean(consortiaUserInfo.Sex);
										gspacketIn.WriteInt(consortiaUserInfo.Right);
										gspacketIn.WriteInt(consortiaUserInfo.Win);
										gspacketIn.WriteInt(consortiaUserInfo.Total);
										gspacketIn.WriteInt(consortiaUserInfo.Escape);
										gspacketIn.WriteInt(val);
										gspacketIn.WriteString(consortiaUserInfo.LoginName);
										gspacketIn.WriteInt(consortiaUserInfo.FightPower);
										gspacketIn.WriteInt(consortiaUserInfo.AchievementPoint);
										gspacketIn.WriteString(consortiaUserInfo.Honor);
										gspacketIn.WriteInt(consortiaUserInfo.RichesOffer);
										CenterServer.Instance.SendToALL(gspacketIn, null);
									}
								}
							}
							if (!flag)
							{
								break;
							}
						}
					}
				}
			}
			catch (Exception exception)
			{
				if (SystemConsortiaMrg.log.IsErrorEnabled)
				{
					SystemConsortiaMrg.log.Error("SystemConsortiaMrg.autoAcceptHandler", exception);
				}
			}
		}

		// Token: 0x04000086 RID: 134
		private static Dictionary<int, ConsortiaInfo> allSystemConsortia;

		// Token: 0x04000087 RID: 135
		private static Timer autoAcceptTimer;

		// Token: 0x04000088 RID: 136
		private static Timer autoUpdateTimer;

		// Token: 0x04000089 RID: 137
		private static Timer autoActiveTimer;

		// Token: 0x0400008A RID: 138
		private static int autoAcceptInterval = 60000;

		// Token: 0x0400008B RID: 139
		private static int autoUpdateInterval = 3600000;

		// Token: 0x0400008C RID: 140
		private static int autoActiveInterval = 60000;

		// Token: 0x0400008D RID: 141
		private static int minAcceptInterval = 10;

		// Token: 0x0400008E RID: 142
		private static ReaderWriterLock m_lock;

		// Token: 0x0400008F RID: 143
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
	}
}
