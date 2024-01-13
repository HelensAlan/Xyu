using System;

namespace Game.Base.Events
{
	// Token: 0x02000024 RID: 36
	public class ScriptEvent : RoadEvent
	{
		// Token: 0x0600012E RID: 302 RVA: 0x00006B92 File Offset: 0x00004D92
		protected ScriptEvent(string name)
			: base(name)
		{
		}

		// Token: 0x0400007A RID: 122
		public static readonly ScriptEvent Loaded = new ScriptEvent("Script.Loaded");

		// Token: 0x0400007B RID: 123
		public static readonly ScriptEvent Unloaded = new ScriptEvent("Script.Unloaded");
	}
}
