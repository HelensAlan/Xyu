using System;

namespace Game.Base.Events
{
	// Token: 0x0200001E RID: 30
	public class GameServerEvent : RoadEvent
	{
		// Token: 0x06000117 RID: 279 RVA: 0x00006754 File Offset: 0x00004954
		protected GameServerEvent(string name)
			: base(name)
		{
		}

		// Token: 0x04000072 RID: 114
		public static readonly GameServerEvent Started = new GameServerEvent("Server.Started");

		// Token: 0x04000073 RID: 115
		public static readonly GameServerEvent Stopped = new GameServerEvent("Server.Stopped");

		// Token: 0x04000074 RID: 116
		public static readonly GameServerEvent WorldSave = new GameServerEvent("Server.WorldSave");
	}
}
