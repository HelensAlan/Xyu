using System;
using System.IO;
using System.Reflection;
using Game.Base.Config;
using log4net;

namespace Center.Server
{
	// Token: 0x02000003 RID: 3
	public class CenterServerConfig : BaseAppConfig
	{
		// Token: 0x06000024 RID: 36 RVA: 0x0000211B File Offset: 0x0000031B
		public CenterServerConfig()
		{
			this.Load(typeof(CenterServerConfig));
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002133 File Offset: 0x00000333
		public void Refresh()
		{
			this.Load(typeof(CenterServerConfig));
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003A38 File Offset: 0x00001C38
		protected override void Load(Type type)
		{
			if (Assembly.GetEntryAssembly() != null)
			{
				this.RootDirectory = new FileInfo(Assembly.GetEntryAssembly().Location).DirectoryName;
			}
			else
			{
				this.RootDirectory = new FileInfo(Assembly.GetAssembly(type).Location).DirectoryName;
			}
			base.Load(type);
		}

		// Token: 0x0400000E RID: 14
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x0400000F RID: 15
		public string RootDirectory;

		// Token: 0x04000010 RID: 16
		[ConfigProperty("IP", "中心服务器监听IP", "127.0.0.1")]
		public string Ip;

		// Token: 0x04000011 RID: 17
		[ConfigProperty("Port", "中心服务器监听端口", 9202)]
		public int Port;

		// Token: 0x04000012 RID: 18
		[ConfigProperty("LogConfigFile", "日志配置文件", "logconfig.xml")]
		public string LogConfigFile;

		// Token: 0x04000013 RID: 19
		[ConfigProperty("ScriptAssemblies", "脚本编译引用库", "")]
		public string ScriptAssemblies;

		// Token: 0x04000014 RID: 20
		[ConfigProperty("ScriptCompilationTarget", "脚本编译目标名称", "")]
		public string ScriptCompilationTarget;

		// Token: 0x04000015 RID: 21
		[ConfigProperty("LoginLapseInterval", "登陆超时时间,分钟为单位", 1)]
		public int LoginLapseInterval;

		// Token: 0x04000016 RID: 22
		[ConfigProperty("SaveInterval", "数据保存周期,分钟为单位", 1)]
		public int SaveIntervalInterval;

		// Token: 0x04000017 RID: 23
		[ConfigProperty("SaveRecordInterval", "日志保存周期,分钟为单位", 1)]
		public int SaveRecordInterval;

		// Token: 0x04000018 RID: 24
		[ConfigProperty("ScanAuctionInterval", "排名行扫描周期,分钟为单位", 60)]
		public int ScanAuctionInterval;

		// Token: 0x04000019 RID: 25
		[ConfigProperty("ScanMailInterval", "邮件扫描周期,分钟为单位", 60)]
		public int ScanMailInterval;

		// Token: 0x0400001A RID: 26
		[ConfigProperty("ScanConsortiaInterval", "工会扫描周期,以分钟为单位", 60)]
		public int ScanConsortiaInterval;

		// Token: 0x0400001B RID: 27
		[ConfigProperty("CrossServerIP", "跨区服务器IP", "127.0.0.1")]
		public string CrossServerIP;

		// Token: 0x0400001C RID: 28
		[ConfigProperty("CrossServerPort", "跨区服务器端口", 9300)]
		public int CrossServerPort;

		// Token: 0x0400001D RID: 29
		[ConfigProperty("CrossServerKey", "跨区服务器Key", "")]
		public string CrossServerKey;

		// Token: 0x0400001E RID: 30
		[ConfigProperty("BigAreaID", "跨区ID", 1)]
		public int BigAreaID;
	}
}
