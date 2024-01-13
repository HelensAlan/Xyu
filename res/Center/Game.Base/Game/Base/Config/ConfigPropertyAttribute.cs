using System;

namespace Game.Base.Config
{
	// Token: 0x02000029 RID: 41
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class ConfigPropertyAttribute : Attribute
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00006F06 File Offset: 0x00005106
		public string Key
		{
			get
			{
				return this.m_key;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000148 RID: 328 RVA: 0x00006F0E File Offset: 0x0000510E
		public string Description
		{
			get
			{
				return this.m_description;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00006F16 File Offset: 0x00005116
		public object DefaultValue
		{
			get
			{
				return this.m_defaultValue;
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00006F1E File Offset: 0x0000511E
		public ConfigPropertyAttribute(string key, string description, object defaultValue)
		{
			this.m_key = key;
			this.m_description = description;
			this.m_defaultValue = defaultValue;
		}

		// Token: 0x04000080 RID: 128
		private string m_key;

		// Token: 0x04000081 RID: 129
		private string m_description;

		// Token: 0x04000082 RID: 130
		private object m_defaultValue;
	}
}
