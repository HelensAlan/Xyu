using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using Bussiness;
using Bussiness.Bussiness;
using Center.Server.Managers;
using Center.Server.Statics;
using Game.Base;
using Game.Base.Events;
using Game.Base.Packets;
using Game.Server.Managers;
using log4net;
using log4net.Config;
using SqlDataProvider.Data;
using SqlDataProvider.SqlDataProvider.Data;

namespace Center.Server
{
	// Token: 0x02000002 RID: 2
	public class CenterServer : BaseServer
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public CenterServerConfig Config
		{
			get
			{
				return this.m_config;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public static CenterServer Instance
		{
			get
			{
				return CenterServer.m_instance;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000003 RID: 3 RVA: 0x0000205F File Offset: 0x0000025F
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002066 File Offset: 0x00000266
		public static CrossServerConnector CrossServer { get; private set; }

		// Token: 0x06000005 RID: 5 RVA: 0x0000206E File Offset: 0x0000026E
		private CenterServer(CenterServerConfig config)
		{
			this.m_config = config;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000207D File Offset: 0x0000027D
		protected override BaseClient GetNewClient()
		{
			return new ServerClient(this);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000027C0 File Offset: 0x000009C0
		public override bool Start()
		{
			bool result;
			try
			{
				Thread.CurrentThread.Priority = ThreadPriority.Normal;
				AppDomain.CurrentDomain.UnhandledException += this.CurrentDomain_UnhandledException;
				GameProperties.Refresh();
				if (!this.InitComponent(this.RecompileScripts(), "Recompile Scripts"))
				{
					result = false;
				}
				else if (!this.InitComponent(this.StartScriptComponents(), "Script components"))
				{
					result = false;
				}
				else if (!this.InitComponent(GameProperties.EDITION == CenterServer.Edition, "Check Server Edition:" + CenterServer.Edition))
				{
					result = false;
				}
				else if (!this.InitComponent(this.InitSocket(IPAddress.Parse(this.m_config.Ip), this.m_config.Port), "InitSocket Port:" + this.m_config.Port.ToString()))
				{
					result = false;
				}
				else if (!this.InitComponent(CenterService.Start(), "Center Service"))
				{
					result = false;
				}
				else if (!this.InitComponent(this.ConnectCrossServer(), "Cross Server"))
				{
					result = false;
				}
				else if (!this.InitComponent(ServerMgr.Start(), "Load serverlist"))
				{
					result = false;
				}
				else if (!this.InitComponent(ConsortiaLevelMgr.Init(), "Init ConsortiaLevelMgr"))
				{
					result = false;
				}
				else if (!this.InitComponent(SystemConsortiaMrg.Init(), "Init SystemConsortiaMrg"))
				{
					result = false;
				}
				else if (!this.InitComponent(MacroDropMgr.Init(), "Init MacroDropMgr"))
				{
					result = false;
				}
				else if (!this.InitComponent(LanguageMgr.Setup(""), "LanguageMgr Init"))
				{
					result = false;
				}
				else if (!this.InitComponent(this.InitGlobalTimers(), "Init Global Timers"))
				{
					result = false;
				}
				else
				{
					GameEventMgr.Notify(ScriptEvent.Loaded);
					MacroDropMgr.Start();
					if (!this.InitComponent(base.Start(), "base.Start()"))
					{
						result = false;
					}
					else
					{
						GameEventMgr.Notify(GameServerEvent.Started, this);
						GC.Collect(GC.MaxGeneration);
						CenterServer.log.Warn("GameServer is now open for connections!");
						GameProperties.Save();
						result = true;
					}
				}
			}
			catch (Exception exception)
			{
				CenterServer.log.Error("Failed to start the server", exception);
				result = false;
			}
			return result;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000029EC File Offset: 0x00000BEC
		private bool ConnectCrossServer()
		{
			CenterServer.CrossServer = new CrossServerConnector(this.Config.CrossServerIP, this.Config.CrossServerPort, this.Config.CrossServerKey, new byte[2048], new byte[2048]);
			CenterServer.CrossServer.Disconnected += delegate(BaseClient _)
			{
				while (!this.ConnectCrossServer())
				{
					Thread.Sleep(1000);
				}
			};
			return CenterServer.CrossServer.Connect();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002085 File Offset: 0x00000285
		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			CenterServer.log.Fatal("Unhandled exception!\n" + e.ExceptionObject.ToString());
			if (e.IsTerminating)
			{
				LogManager.Shutdown();
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020B3 File Offset: 0x000002B3
		protected bool InitComponent(bool componentInitState, string text)
		{
			CenterServer.log.Info(text + ": " + componentInitState.ToString());
			if (!componentInitState)
			{
				this.Stop();
			}
			return componentInitState;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002A58 File Offset: 0x00000C58
		public bool RecompileScripts()
		{
			string path = this.m_config.RootDirectory + Path.DirectorySeparatorChar.ToString() + "scripts";
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			string[] asm_names = this.m_config.ScriptAssemblies.Split(new char[] { ',' });
			return ScriptMgr.CompileScripts(false, path, this.m_config.ScriptCompilationTarget, asm_names);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002AC8 File Offset: 0x00000CC8
		protected bool StartScriptComponents()
		{
			bool result;
			try
			{
				ScriptMgr.InsertAssembly(typeof(CenterServer).Assembly);
				ScriptMgr.InsertAssembly(typeof(BaseServer).Assembly);
				foreach (Assembly asm in ScriptMgr.Scripts)
				{
					GameEventMgr.RegisterGlobalEvents(asm, typeof(GameServerStartedEventAttribute), GameServerEvent.Started);
					GameEventMgr.RegisterGlobalEvents(asm, typeof(GameServerStoppedEventAttribute), GameServerEvent.Stopped);
					GameEventMgr.RegisterGlobalEvents(asm, typeof(ScriptLoadedEventAttribute), ScriptEvent.Loaded);
					GameEventMgr.RegisterGlobalEvents(asm, typeof(ScriptUnloadedEventAttribute), ScriptEvent.Unloaded);
				}
				CenterServer.log.Debug("Registering global event handlers: true");
				result = true;
			}
			catch (Exception exception)
			{
				CenterServer.log.Error("StartScriptComponents", exception);
				result = false;
			}
			return result;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002BA4 File Offset: 0x00000DA4
		public bool InitGlobalTimers()
		{
			int num = this.m_config.SaveIntervalInterval * 60 * 1000;
			if (this.m_saveDBTimer == null)
			{
				this.m_saveDBTimer = new Timer(new TimerCallback(this.SaveTimerProc), null, num, num);
			}
			else
			{
				this.m_saveDBTimer.Change(num, num);
			}
			num = 60000;
			if (this.m_loginLapseTimer == null)
			{
				this.m_loginLapseTimer = new Timer(new TimerCallback(this.LoginLapseTimerProc), null, num, num);
			}
			else
			{
				this.m_loginLapseTimer.Change(num, num);
			}
			num = this.m_config.SaveRecordInterval * 60 * 1000;
			if (this.m_saveRecordTimer == null)
			{
				this.m_saveRecordTimer = new Timer(new TimerCallback(this.SaveRecordProc), null, num, num);
			}
			else
			{
				this.m_saveRecordTimer.Change(num, num);
			}
			num = this.m_config.ScanAuctionInterval * 60 * 1000;
			if (this.m_scanAuction == null)
			{
				this.m_scanAuction = new Timer(new TimerCallback(this.ScanAuctionProc), null, num, num);
			}
			else
			{
				this.m_scanAuction.Change(num, num);
			}
			num = this.m_config.ScanMailInterval * 60 * 1000;
			if (this.m_scanMail == null)
			{
				this.m_scanMail = new Timer(new TimerCallback(this.ScanMailProc), null, num, num);
			}
			else
			{
				this.m_scanMail.Change(num, num);
			}
			num = this.m_config.ScanConsortiaInterval * 60 * 1000;
			if (this.m_scanConsortia == null)
			{
				this.m_scanConsortia = new Timer(new TimerCallback(this.ScanConsortiaProc), null, num, num);
			}
			else
			{
				this.m_scanConsortia.Change(num, num);
			}
			num = 10000;
			if (this.m_scanCharge == null)
			{
				this.m_scanCharge = new Timer(new TimerCallback(this.ScanChargeProc), null, num, num);
			}
			else
			{
				this.m_scanCharge.Change(num, num);
			}
			return true;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002D88 File Offset: 0x00000F88
		public void DisposeGlobalTimers()
		{
			if (this.m_saveDBTimer != null)
			{
				this.m_saveDBTimer.Dispose();
			}
			if (this.m_loginLapseTimer != null)
			{
				this.m_loginLapseTimer.Dispose();
			}
			if (this.m_saveRecordTimer != null)
			{
				this.m_saveRecordTimer.Dispose();
			}
			if (this.m_scanAuction != null)
			{
				this.m_scanAuction.Dispose();
			}
			if (this.m_scanMail != null)
			{
				this.m_scanMail.Dispose();
			}
			if (this.m_scanConsortia != null)
			{
				this.m_scanConsortia.Dispose();
			}
			if (this.m_scanBigBugle != null)
			{
				this.m_scanBigBugle.Dispose();
			}
			if (this.m_scanCharge != null)
			{
				this.m_scanCharge.Dispose();
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002E30 File Offset: 0x00001030
		protected void SaveTimerProc(object state)
		{
			try
			{
				int num = Environment.TickCount;
				CenterServer.log.Debug("Saving database...");
				CenterServer.log.Debug("Save ThreadId=" + Thread.CurrentThread.ManagedThreadId.ToString());
				ThreadPriority priority = Thread.CurrentThread.Priority;
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				ServerMgr.SaveToDatabase();
				Thread.CurrentThread.Priority = priority;
				num = Environment.TickCount - num;
				CenterServer.log.Debug("Saving database complete!");
				CenterServer.log.Debug("Saved all databases " + num.ToString() + "ms");
			}
			catch (Exception exception)
			{
				if (CenterServer.log.IsErrorEnabled)
				{
					CenterServer.log.Error("SaveTimerProc", exception);
				}
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002F08 File Offset: 0x00001108
		protected void LoginLapseTimerProc(object sender)
		{
			try
			{
				Player[] allPlayer = LoginMgr.GetAllPlayer();
				long ticks = DateTime.Now.Ticks;
				long num = (long)this.m_config.LoginLapseInterval * 60L * 1000L * 10L * 1000L;
				foreach (Player player in allPlayer)
				{
					if (player.State == ePlayerState.NotLogin)
					{
						if (player.LastTime + num < ticks)
						{
							LoginMgr.RemovePlayer(player.Id);
						}
					}
					else
					{
						player.LastTime = DateTime.Now.Ticks;
					}
				}
			}
			catch (Exception exception)
			{
				if (CenterServer.log.IsErrorEnabled)
				{
					CenterServer.log.Error("LoginLapseTimer callback", exception);
				}
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002FD0 File Offset: 0x000011D0
		protected void SaveRecordProc(object sender)
		{
			try
			{
				int num = Environment.TickCount;
				CenterServer.log.Debug("Saving Record...");
				ThreadPriority priority = Thread.CurrentThread.Priority;
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				LogMgr.Save();
				Thread.CurrentThread.Priority = priority;
				CenterServer.log.Debug("Saving Record completed!");
				num = Environment.TickCount - num;
				if (num > 120000)
				{
					CenterServer.log.WarnFormat("Saved all Record  in {0} ms!", num);
				}
			}
			catch (Exception exception)
			{
				CenterServer.log.Error("SaveRecordProc", exception);
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003074 File Offset: 0x00001274
		protected void ScanAuctionProc(object sender)
		{
			try
			{
				int num = Environment.TickCount;
				CenterServer.log.Debug("Saving Record...");
				CenterServer.log.Debug("Save ThreadId=" + Thread.CurrentThread.ManagedThreadId.ToString());
				ThreadPriority priority = Thread.CurrentThread.Priority;
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				string text = "";
				using (PlayerBussiness playerBussiness = new PlayerBussiness())
				{
					playerBussiness.ScanAuction(ref text);
				}
				foreach (string text2 in text.Split(new char[] { ',' }))
				{
					if (!string.IsNullOrEmpty(text2))
					{
						GSPacketIn gspacketIn = new GSPacketIn(117);
						gspacketIn.WriteInt(int.Parse(text2));
						gspacketIn.WriteInt(1);
						this.SendToALL(gspacketIn);
					}
				}
				Thread.CurrentThread.Priority = priority;
				num = Environment.TickCount - num;
				CenterServer.log.Debug("Scan Auction complete!");
				if (num > 120000)
				{
					CenterServer.log.WarnFormat("Scan all Auction  in {0} ms", num);
				}
			}
			catch (Exception exception)
			{
				if (CenterServer.log.IsErrorEnabled)
				{
					CenterServer.log.Error("ScanAuctionProc", exception);
				}
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000031E8 File Offset: 0x000013E8
		protected void ScanMailProc(object sender)
		{
			try
			{
				int num = Environment.TickCount;
				CenterServer.log.Debug("Saving Record...");
				CenterServer.log.Debug("Save ThreadId=" + Thread.CurrentThread.ManagedThreadId.ToString());
				ThreadPriority priority = Thread.CurrentThread.Priority;
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				string text = "";
				using (PlayerBussiness playerBussiness = new PlayerBussiness())
				{
					playerBussiness.ScanMail(ref text);
				}
				foreach (string text2 in text.Split(new char[] { ',' }))
				{
					if (!string.IsNullOrEmpty(text2))
					{
						GSPacketIn gspacketIn = new GSPacketIn(117);
						gspacketIn.WriteInt(int.Parse(text2));
						gspacketIn.WriteInt(1);
						this.SendToALL(gspacketIn);
					}
				}
				Thread.CurrentThread.Priority = priority;
				num = Environment.TickCount - num;
				CenterServer.log.Debug("Scan Mail complete!");
				if (num > 120000)
				{
					CenterServer.log.WarnFormat("Scan all Mail in {0} ms", num);
				}
			}
			catch (Exception exception)
			{
				if (CenterServer.log.IsErrorEnabled)
				{
					CenterServer.log.Error("ScanMailProc", exception);
				}
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000335C File Offset: 0x0000155C
		protected void ScanConsortiaProc(object sender)
		{
			try
			{
				int num = Environment.TickCount;
				CenterServer.log.Debug("Saving Record...");
				CenterServer.log.Debug("Save ThreadId=" + Thread.CurrentThread.ManagedThreadId.ToString());
				ThreadPriority priority = Thread.CurrentThread.Priority;
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				string text = "";
				using (ConsortiaBussiness consortiaBussiness = new ConsortiaBussiness())
				{
					consortiaBussiness.ScanConsortia(ref text);
				}
				foreach (string text2 in text.Split(new char[] { ',' }))
				{
					if (!string.IsNullOrEmpty(text2))
					{
						GSPacketIn gspacketIn = new GSPacketIn(128);
						gspacketIn.WriteByte(2);
						gspacketIn.WriteInt(int.Parse(text2));
						this.SendToALL(gspacketIn);
					}
				}
				Thread.CurrentThread.Priority = priority;
				num = Environment.TickCount - num;
				CenterServer.log.Debug("Scan Consortia complete!");
				if (num > 120000)
				{
					CenterServer.log.WarnFormat("Scan all Consortia in {0} ms", num);
				}
			}
			catch (Exception exception)
			{
				if (CenterServer.log.IsErrorEnabled)
				{
					CenterServer.log.Error("ScanConsortiaProc", exception);
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000034D4 File Offset: 0x000016D4
		protected void ScanChargeProc(object sender)
		{
			try
			{
				int num = Environment.TickCount;
				CenterServer.log.Debug("Scan Charge...");
				CenterServer.log.Debug("Scan Charge ThreadId=" + Thread.CurrentThread.ManagedThreadId.ToString());
				ThreadPriority priority = Thread.CurrentThread.Priority;
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				using (UserChargeBussiness userChargeBussiness = new UserChargeBussiness())
				{
					foreach (UserChargeMoneyInfo userChargeMoneyInfo in userChargeBussiness.GetAllUserChargeMoneyInfoNotCharge())
					{
						this.Charge(userChargeMoneyInfo.UserName, userChargeMoneyInfo.Money, true);
						userChargeBussiness.UpdateUserChargeMoneyInfo(userChargeMoneyInfo.ID);
					}
				}
				Thread.CurrentThread.Priority = priority;
				num = Environment.TickCount - num;
				CenterServer.log.Debug("Scan Charge complete!");
				if (num > 120000)
				{
					CenterServer.log.WarnFormat("Scan all Charge in {0} ms", num);
				}
			}
			catch (Exception exception)
			{
				if (CenterServer.log.IsErrorEnabled)
				{
					CenterServer.log.Error("ScanChargeProc", exception);
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003624 File Offset: 0x00001824
		public override void Stop()
		{
			try
			{
				SystemConsortiaMrg.Stop();
				this.DisposeGlobalTimers();
				this.SaveTimerProc(null);
				this.SaveRecordProc(null);
				CenterService.Stop();
				base.Stop();
			}
			catch (Exception exception)
			{
				CenterServer.log.Error("Center service stopp error:", exception);
			}
			CenterServer.log.Warn("Center Server Stopped!");
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000368C File Offset: 0x0000188C
		public new ServerClient[] GetAllClients()
		{
			ServerClient[] array = null;
			object syncRoot = this._clients.SyncRoot;
			lock (syncRoot)
			{
				array = new ServerClient[this._clients.Count];
				this._clients.Keys.CopyTo(array, 0);
			}
			return array;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000020DB File Offset: 0x000002DB
		public void SendToALL(GSPacketIn pkg)
		{
			this.SendToALL(pkg, null);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000036F4 File Offset: 0x000018F4
		public void SendToALL(GSPacketIn pkg, ServerClient except)
		{
			ServerClient[] allClients = this.GetAllClients();
			if (allClients != null)
			{
				foreach (ServerClient serverClient in allClients)
				{
					if (serverClient != except)
					{
						serverClient.SendTCP(pkg);
					}
				}
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000372C File Offset: 0x0000192C
		public void SendConsortiaDelete(int consortiaID)
		{
			GSPacketIn gspacketIn = new GSPacketIn(128);
			gspacketIn.WriteByte(5);
			gspacketIn.WriteInt(consortiaID);
			this.SendToALL(gspacketIn);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000375C File Offset: 0x0000195C
		public void SendSystemNotice(string msg)
		{
			GSPacketIn gspacketIn = new GSPacketIn(10);
			gspacketIn.WriteInt(0);
			gspacketIn.WriteString(msg);
			this.SendToALL(gspacketIn, null);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003788 File Offset: 0x00001988
		public int RateUpdate(int serverId)
		{
			ServerClient[] allClients = this.GetAllClients();
			if (allClients != null)
			{
				foreach (ServerClient serverClient in allClients)
				{
					if (serverClient.Info.ID == serverId)
					{
						GSPacketIn gspacketIn = new GSPacketIn(177);
						gspacketIn.WriteInt(serverId);
						serverClient.SendTCP(gspacketIn);
						return 0;
					}
				}
			}
			return 1;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000037E0 File Offset: 0x000019E0
		public int NoticeServerUpdate(int serverId, int type)
		{
			ServerClient[] allClients = this.GetAllClients();
			if (allClients != null)
			{
				foreach (ServerClient serverClient in allClients)
				{
					if (serverClient.Info.ID == serverId)
					{
						GSPacketIn gspacketIn = new GSPacketIn(11);
						gspacketIn.WriteInt(type);
						serverClient.SendTCP(gspacketIn);
						return 0;
					}
				}
			}
			return 1;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003838 File Offset: 0x00001A38
		public bool ClientsExecuteCmd(string cmdLine)
		{
			try
			{
				LogClient cmdclient = new LogClient();
				ServerClient[] allClients = CenterServer.Instance.GetAllClients();
				if (allClients != null)
				{
					ServerClient[] array = allClients;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].SendCmd(cmdclient, cmdLine);
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				CenterServer.log.Error(ex.Message, ex);
			}
			return false;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000038A4 File Offset: 0x00001AA4
		public static void CreateInstance(CenterServerConfig config)
		{
			if (CenterServer.m_instance != null)
			{
				throw new Exception("Can't create more than one CenterServer!");
			}
			FileInfo fileInfo = new FileInfo(config.LogConfigFile);
			if (!fileInfo.Exists)
			{
				ResourceUtil.ExtractResource(fileInfo.Name, fileInfo.FullName, Assembly.GetAssembly(typeof(CenterServer)));
			}
			XmlConfigurator.ConfigureAndWatch(fileInfo);
			CenterServer.m_instance = new CenterServer(config);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000390C File Offset: 0x00001B0C
		public bool Charge(string username, int money, bool isDirect)
		{
			try
			{
				using (PlayerBussiness playerBussiness = new PlayerBussiness())
				{
					PlayerInfo userSingleByUserName = playerBussiness.GetUserSingleByUserName(username);
					if (userSingleByUserName != null)
					{
						playerBussiness.SendMailAndItem("充值成功", "", userSingleByUserName.ID, 0, money * 1000, 0, string.Format("11408,{0},0,0,0,0,0,0,true", money * 2), false);
						this.MailNotice(userSingleByUserName.ID);
						CenterServer.log.WarnFormat("[{0}][{1}]充值{2}元已发货！", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), userSingleByUserName.NickName, money);
					}
					if (isDirect)
					{
						CenterServer.CrossServer.SendChargeReward(userSingleByUserName.UserName, money);
					}
					return true;
				}
			}
			catch (Exception message)
			{
				CenterServer.log.Error(message);
			}
			return false;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000039E8 File Offset: 0x00001BE8
		public bool MailNotice(int playerID)
		{
			try
			{
				ServerClient serverClient = LoginMgr.GetServerClient(playerID);
				if (serverClient != null)
				{
					GSPacketIn gspacketIn = new GSPacketIn(117);
					gspacketIn.WriteInt(playerID);
					gspacketIn.WriteInt(1);
					serverClient.SendTCP(gspacketIn);
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x04000001 RID: 1
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000002 RID: 2
		public static readonly string Edition = "5498628";

		// Token: 0x04000003 RID: 3
		private CenterServerConfig m_config;

		// Token: 0x04000004 RID: 4
		private Timer m_loginLapseTimer;

		// Token: 0x04000005 RID: 5
		private Timer m_saveDBTimer;

		// Token: 0x04000006 RID: 6
		private Timer m_saveRecordTimer;

		// Token: 0x04000007 RID: 7
		private Timer m_scanAuction;

		// Token: 0x04000008 RID: 8
		private Timer m_scanMail;

		// Token: 0x04000009 RID: 9
		private Timer m_scanConsortia;

		// Token: 0x0400000A RID: 10
		private Timer m_scanBigBugle;

		// Token: 0x0400000B RID: 11
		private Timer m_scanCharge;

		// Token: 0x0400000C RID: 12
		private static CenterServer m_instance;
	}
}
