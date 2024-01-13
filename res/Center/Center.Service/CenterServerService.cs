using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;
using Center.GMService;
using Center.Server;
using log4net;

namespace Center.Service
{
	// Token: 0x02000002 RID: 2
	internal class CenterServerService : ServiceBase
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000206F File Offset: 0x0000026F
		private void InitializeComponent()
		{
			this.components = new Container();
			base.ServiceName = "CenterServerService";
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002088 File Offset: 0x00000288
		public CenterServerService()
		{
			base.ServiceName = "Center Service";
			this.EventLog.Log = "DDT";
			base.AutoLog = true;
			base.CanHandlePowerEvent = false;
			base.CanPauseAndContinue = false;
			base.CanShutdown = false;
			base.CanStop = true;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020D9 File Offset: 0x000002D9
		protected override void OnStart(string[] args)
		{
			if (!CenterServerService.StartServer())
			{
				CenterServerService.log.Error("Start ceter service failed!");
				base.Stop();
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020F8 File Offset: 0x000002F8
		private static bool StartServer()
		{
			Directory.SetCurrentDirectory(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName);
			CenterServer.CreateInstance(new CenterServerConfig());
			bool start = CenterServer.Instance.Start();
			if (start)
			{
				start = GMService.Start();
			}
			return start;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002140 File Offset: 0x00000340
		private void StopServer()
		{
			if (CenterServer.Instance != null)
			{
				if (CenterServer.Instance.GetAllClients().Length != 0)
				{
					CenterServer.Instance.ClientsExecuteCmd("/shutdown 5");
					Thread.Sleep(360000);
				}
				CenterServer.Instance.Stop();
			}
			GMService.Stop();
			LogManager.Shutdown();
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000218F File Offset: 0x0000038F
		protected override void OnStop()
		{
			this.StopServer();
		}

		// Token: 0x04000001 RID: 1
		private IContainer components;

		// Token: 0x04000002 RID: 2
		public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
	}
}
