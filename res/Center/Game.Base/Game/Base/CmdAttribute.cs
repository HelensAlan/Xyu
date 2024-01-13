using System;

namespace Game.Base
{
	// Token: 0x0200000B RID: 11
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class CmdAttribute : Attribute
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003711 File Offset: 0x00001911
		public string Cmd
		{
			get
			{
				return this.m_cmd;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00003719 File Offset: 0x00001919
		public string[] Aliases
		{
			get
			{
				return this.m_cmdAliases;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00003721 File Offset: 0x00001921
		public uint Level
		{
			get
			{
				return this.m_lvl;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00003729 File Offset: 0x00001929
		public string Description
		{
			get
			{
				return this.m_description;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00003731 File Offset: 0x00001931
		public string[] Usage
		{
			get
			{
				return this.m_usage;
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003739 File Offset: 0x00001939
		public CmdAttribute(string cmd, string[] alias, ePrivLevel lvl, string desc, params string[] usage)
		{
			this.m_cmd = cmd;
			this.m_cmdAliases = alias;
			this.m_lvl = (uint)lvl;
			this.m_description = desc;
			this.m_usage = usage;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003766 File Offset: 0x00001966
		public CmdAttribute(string cmd, ePrivLevel lvl, string desc, params string[] usage)
			: this(cmd, null, lvl, desc, usage)
		{
		}

		// Token: 0x0400002D RID: 45
		private string m_cmd;

		// Token: 0x0400002E RID: 46
		private string[] m_cmdAliases;

		// Token: 0x0400002F RID: 47
		private uint m_lvl;

		// Token: 0x04000030 RID: 48
		private string m_description;

		// Token: 0x04000031 RID: 49
		private string[] m_usage;
	}
}
