using System;
using System.Collections;

namespace Game.Base.Config
{
	// Token: 0x02000028 RID: 40
	public class ConfigElement
	{
		// Token: 0x17000023 RID: 35
		public ConfigElement this[string key]
		{
			get
			{
				Hashtable children = this.m_children;
				lock (children)
				{
					if (!this.m_children.Contains(key))
					{
						this.m_children.Add(key, this.GetNewConfigElement(this));
					}
				}
				return (ConfigElement)this.m_children[key];
			}
			set
			{
				Hashtable children = this.m_children;
				lock (children)
				{
					this.m_children[key] = value;
				}
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00006E30 File Offset: 0x00005030
		public ConfigElement Parent
		{
			get
			{
				return this.m_parent;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00006E38 File Offset: 0x00005038
		public bool HasChildren
		{
			get
			{
				return this.m_children.Count > 0;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00006E48 File Offset: 0x00005048
		public Hashtable Children
		{
			get
			{
				return this.m_children;
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00006E50 File Offset: 0x00005050
		public ConfigElement(ConfigElement parent)
		{
			this.m_parent = parent;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00006E6A File Offset: 0x0000506A
		protected virtual ConfigElement GetNewConfigElement(ConfigElement parent)
		{
			return new ConfigElement(parent);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00006E72 File Offset: 0x00005072
		public string GetString()
		{
			return this.m_value;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00006E7A File Offset: 0x0000507A
		public string GetString(string defaultValue)
		{
			if (this.m_value == null)
			{
				return defaultValue;
			}
			return this.m_value;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00006E8C File Offset: 0x0000508C
		public int GetInt()
		{
			return int.Parse(this.m_value);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00006E99 File Offset: 0x00005099
		public int GetInt(int defaultValue)
		{
			if (this.m_value == null)
			{
				return defaultValue;
			}
			return int.Parse(this.m_value);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00006EB0 File Offset: 0x000050B0
		public long GetLong()
		{
			return long.Parse(this.m_value);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00006EBD File Offset: 0x000050BD
		public long GetLong(long defaultValue)
		{
			if (this.m_value == null)
			{
				return defaultValue;
			}
			return long.Parse(this.m_value);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00006ED4 File Offset: 0x000050D4
		public bool GetBoolean()
		{
			return bool.Parse(this.m_value);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00006EE1 File Offset: 0x000050E1
		public bool GetBoolean(bool defaultValue)
		{
			if (this.m_value == null)
			{
				return defaultValue;
			}
			return bool.Parse(this.m_value);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00006EF8 File Offset: 0x000050F8
		public void Set(object value)
		{
			this.m_value = value.ToString();
		}

		// Token: 0x0400007D RID: 125
		protected ConfigElement m_parent;

		// Token: 0x0400007E RID: 126
		protected Hashtable m_children = new Hashtable();

		// Token: 0x0400007F RID: 127
		protected string m_value;
	}
}
