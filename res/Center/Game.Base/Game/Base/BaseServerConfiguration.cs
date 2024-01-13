using System;
using System.IO;
using System.Net;
using Game.Base.Config;

namespace Game.Base
{
	// Token: 0x02000009 RID: 9
	public class BaseServerConfiguration
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000052 RID: 82 RVA: 0x000035B5 File Offset: 0x000017B5
		// (set) Token: 0x06000053 RID: 83 RVA: 0x000035BD File Offset: 0x000017BD
		public ushort Port
		{
			get
			{
				return this._port;
			}
			set
			{
				this._port = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000054 RID: 84 RVA: 0x000035C6 File Offset: 0x000017C6
		// (set) Token: 0x06000055 RID: 85 RVA: 0x000035CE File Offset: 0x000017CE
		public IPAddress Ip
		{
			get
			{
				return this._ip;
			}
			set
			{
				this._ip = value;
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000035D8 File Offset: 0x000017D8
		protected virtual void LoadFromConfig(ConfigElement root)
		{
			string ip = root["Server"]["IP"].GetString("any");
			if (ip == "any")
			{
				this._ip = IPAddress.Any;
			}
			else
			{
				this._ip = IPAddress.Parse(ip);
			}
			this._port = (ushort)root["Server"]["Port"].GetInt((int)this._port);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003654 File Offset: 0x00001854
		public void LoadFromXMLFile(FileInfo configFile)
		{
			XMLConfigFile xmlConfig = XMLConfigFile.ParseXMLFile(configFile);
			this.LoadFromConfig(xmlConfig);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003670 File Offset: 0x00001870
		protected virtual void SaveToConfig(ConfigElement root)
		{
			root["Server"]["Port"].Set(this._port);
			root["Server"]["IP"].Set(this._ip);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000036C4 File Offset: 0x000018C4
		public void SaveToXMLFile(FileInfo configFile)
		{
			if (configFile == null)
			{
				throw new ArgumentNullException("configFile");
			}
			XMLConfigFile config = new XMLConfigFile();
			this.SaveToConfig(config);
			config.Save(configFile);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000036F3 File Offset: 0x000018F3
		public BaseServerConfiguration()
		{
			this._port = 7000;
			this._ip = IPAddress.Any;
		}

		// Token: 0x0400002B RID: 43
		protected ushort _port;

		// Token: 0x0400002C RID: 44
		protected IPAddress _ip;
	}
}
