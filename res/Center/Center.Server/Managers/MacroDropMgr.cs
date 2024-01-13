using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Timers;
using Bussiness;
using Game.Base.Packets;
using log4net;
using SqlDataProvider.Data;

namespace Center.Server.Managers
{
	// Token: 0x02000016 RID: 22
	public class MacroDropMgr
	{
		// Token: 0x060000EA RID: 234 RVA: 0x000026FE File Offset: 0x000008FE
		public static bool Init()
		{
			MacroDropMgr.m_lock = new ReaderWriterLock();
			MacroDropMgr.FilePath = Directory.GetCurrentDirectory() + "\\macrodrop\\macroDrop.ini";
			return MacroDropMgr.Reload();
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000068AC File Offset: 0x00004AAC
		public static bool Reload()
		{
			try
			{
				Dictionary<int, DropInfo> dictionary = new Dictionary<int, DropInfo>();
				MacroDropMgr.m_DropInfo = new Dictionary<int, DropInfo>();
				dictionary = MacroDropMgr.LoadDropInfo();
				if (dictionary != null && dictionary.Count > 0)
				{
					Interlocked.Exchange<Dictionary<int, DropInfo>>(ref MacroDropMgr.m_DropInfo, dictionary);
				}
				return true;
			}
			catch (Exception exception)
			{
				if (MacroDropMgr.log.IsErrorEnabled)
				{
					MacroDropMgr.log.Error("DropInfoMgr", exception);
				}
			}
			return false;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00006920 File Offset: 0x00004B20
		private static void MacroDropReset()
		{
			MacroDropMgr.m_lock.AcquireWriterLock(-1);
			try
			{
				foreach (KeyValuePair<int, DropInfo> keyValuePair in MacroDropMgr.m_DropInfo)
				{
					int key = keyValuePair.Key;
					DropInfo value = keyValuePair.Value;
					if (MacroDropMgr.counter > value.Time && value.Time > 0 && MacroDropMgr.counter % value.Time == 0)
					{
						value.Count = value.MaxCount;
					}
				}
			}
			catch (Exception exception)
			{
				if (MacroDropMgr.log.IsErrorEnabled)
				{
					MacroDropMgr.log.Error("DropInfoMgr MacroDropReset", exception);
				}
			}
			finally
			{
				MacroDropMgr.m_lock.ReleaseWriterLock();
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000069FC File Offset: 0x00004BFC
		private static void MacroDropSync()
		{
			bool flag = true;
			ServerClient[] allClients = CenterServer.Instance.GetAllClients();
			ServerClient[] array = allClients;
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].NeedSyncMacroDrop)
				{
					flag = false;
					break;
				}
			}
			if (allClients.Length != 0 && flag)
			{
				GSPacketIn gspacketIn = new GSPacketIn(178);
				int count = MacroDropMgr.m_DropInfo.Count;
				gspacketIn.WriteInt(count);
				MacroDropMgr.m_lock.AcquireReaderLock(-1);
				try
				{
					foreach (KeyValuePair<int, DropInfo> keyValuePair in MacroDropMgr.m_DropInfo)
					{
						DropInfo value = keyValuePair.Value;
						gspacketIn.WriteInt(value.ID);
						gspacketIn.WriteInt(value.Count);
						gspacketIn.WriteInt(value.MaxCount);
					}
				}
				catch (Exception exception)
				{
					if (MacroDropMgr.log.IsErrorEnabled)
					{
						MacroDropMgr.log.Error("DropInfoMgr MacroDropReset", exception);
					}
				}
				finally
				{
					MacroDropMgr.m_lock.ReleaseReaderLock();
				}
				foreach (ServerClient serverClient in allClients)
				{
					serverClient.NeedSyncMacroDrop = false;
					serverClient.SendTCP(gspacketIn);
				}
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00002723 File Offset: 0x00000923
		private static void OnTimeEvent(object source, ElapsedEventArgs e)
		{
			MacroDropMgr.counter++;
			if (MacroDropMgr.counter % 12 == 0)
			{
				MacroDropMgr.MacroDropReset();
			}
			MacroDropMgr.MacroDropSync();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00002745 File Offset: 0x00000945
		public static void Start()
		{
			MacroDropMgr.counter = 0;
			System.Timers.Timer timer = new System.Timers.Timer();
			timer.Elapsed += MacroDropMgr.OnTimeEvent;
			timer.Interval = 300000.0;
			timer.Enabled = true;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00006B4C File Offset: 0x00004D4C
		private static Dictionary<int, DropInfo> LoadDropInfo()
		{
			Dictionary<int, DropInfo> dictionary = new Dictionary<int, DropInfo>();
			Dictionary<int, DropInfo> result;
			if (File.Exists(MacroDropMgr.FilePath))
			{
				IniReader iniReader = new IniReader(MacroDropMgr.FilePath);
				int num = 1;
				while (iniReader.GetIniString(num.ToString(), "TemplateId") != "")
				{
					string section = num.ToString();
					int id = Convert.ToInt32(iniReader.GetIniString(section, "TemplateId"));
					int time = Convert.ToInt32(iniReader.GetIniString(section, "Time"));
					int num2 = Convert.ToInt32(iniReader.GetIniString(section, "Count"));
					DropInfo dropInfo = new DropInfo(id, time, num2, num2);
					dictionary.Add(dropInfo.ID, dropInfo);
					num++;
				}
				result = dictionary;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00006C0C File Offset: 0x00004E0C
		public static void DropNotice(Dictionary<int, int> temp)
		{
			MacroDropMgr.m_lock.AcquireWriterLock(-1);
			try
			{
				foreach (KeyValuePair<int, int> keyValuePair in temp)
				{
					if (MacroDropMgr.m_DropInfo.ContainsKey(keyValuePair.Key))
					{
						DropInfo dropInfo = MacroDropMgr.m_DropInfo[keyValuePair.Key];
						if (dropInfo.Count > 0)
						{
							dropInfo.Count -= keyValuePair.Value;
						}
					}
				}
			}
			catch (Exception exception)
			{
				if (MacroDropMgr.log.IsErrorEnabled)
				{
					MacroDropMgr.log.Error("DropInfoMgr CanDrop", exception);
				}
			}
			finally
			{
				MacroDropMgr.m_lock.ReleaseWriterLock();
			}
		}

		// Token: 0x04000099 RID: 153
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x0400009A RID: 154
		private static ReaderWriterLock m_lock;

		// Token: 0x0400009B RID: 155
		private static Dictionary<int, DropInfo> m_DropInfo;

		// Token: 0x0400009C RID: 156
		private static string FilePath;

		// Token: 0x0400009D RID: 157
		private static int counter;
	}
}
