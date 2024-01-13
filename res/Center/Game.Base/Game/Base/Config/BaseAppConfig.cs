using System;
using System.Configuration;
using System.Reflection;
using log4net;

namespace Game.Base.Config
{
	// Token: 0x02000027 RID: 39
	public abstract class BaseAppConfig
	{
		// Token: 0x06000132 RID: 306 RVA: 0x00006BCB File Offset: 0x00004DCB
		public BaseAppConfig()
		{
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00006BD4 File Offset: 0x00004DD4
		protected virtual void Load(Type type)
		{
			ConfigurationManager.RefreshSection("appSettings");
			foreach (FieldInfo f in type.GetFields())
			{
				object[] attribs = f.GetCustomAttributes(typeof(ConfigPropertyAttribute), false);
				if (attribs.Length != 0)
				{
					ConfigPropertyAttribute attrib = (ConfigPropertyAttribute)attribs[0];
					f.SetValue(this, this.LoadConfigProperty(attrib));
				}
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00006C34 File Offset: 0x00004E34
		public void Save(string fileName, Type type)
		{
			Configuration config = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
			{
				ExeConfigFilename = fileName
			}, ConfigurationUserLevel.None);
			foreach (FieldInfo f in type.GetFields())
			{
				object[] attribs = f.GetCustomAttributes(typeof(ConfigPropertyAttribute), false);
				if (attribs.Length != 0)
				{
					ConfigPropertyAttribute attrib = (ConfigPropertyAttribute)attribs[0];
					config.AppSettings.Settings[attrib.Key].Value = f.GetValue(this).ToString();
				}
			}
			config.Save();
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00006CC0 File Offset: 0x00004EC0
		private object LoadConfigProperty(ConfigPropertyAttribute attrib)
		{
			string key = attrib.Key;
			string value = ConfigurationSettings.AppSettings[key];
			if (value == null)
			{
				value = attrib.DefaultValue.ToString();
				BaseAppConfig.log.Warn("Loading " + key + " value is null,using default vaule:" + value);
			}
			else
			{
				BaseAppConfig.log.Debug("Loading " + key + " Value is " + value);
			}
			object result;
			try
			{
				result = Convert.ChangeType(value, attrib.DefaultValue.GetType());
			}
			catch (Exception e)
			{
				BaseAppConfig.log.Error("Exception in ServerProperties Load: ", e);
				result = null;
			}
			return result;
		}

		// Token: 0x0400007C RID: 124
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
	}
}
