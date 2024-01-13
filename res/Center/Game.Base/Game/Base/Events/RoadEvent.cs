using System;

namespace Game.Base.Events
{
	// Token: 0x02000021 RID: 33
	public abstract class RoadEvent
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600011B RID: 283 RVA: 0x0000679C File Offset: 0x0000499C
		public string Name
		{
			get
			{
				return this.m_EventName;
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000067A4 File Offset: 0x000049A4
		public RoadEvent(string name)
		{
			this.m_EventName = name;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000067B3 File Offset: 0x000049B3
		public override string ToString()
		{
			return "DOLEvent(" + this.m_EventName + ")";
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000067CA File Offset: 0x000049CA
		public virtual bool IsValidFor(object o)
		{
			return true;
		}

		// Token: 0x04000075 RID: 117
		protected string m_EventName;
	}
}
