using System;
using System.Configuration;
using System.Reflection;
using log4net;

namespace Bussiness
{
	// Token: 0x02000016 RID: 22
	public class StaticFunction
	{
		// Token: 0x0600018C RID: 396 RVA: 0x0001E198 File Offset: 0x0001C398
		public static bool UpdateConfig(string fileName, string name, string value)
		{
			try
			{
				Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
				{
					ExeConfigFilename = fileName
				}, ConfigurationUserLevel.None);
				configuration.AppSettings.Settings[name].Value = value;
				configuration.Save();
				ConfigurationManager.RefreshSection("appSettings");
				return true;
			}
			catch (Exception e)
			{
				if (StaticFunction.log.IsErrorEnabled)
				{
					StaticFunction.log.Error("UpdateConfig", e);
				}
			}
			return false;
		}

		// Token: 0x0400009E RID: 158
		protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
	}
}
