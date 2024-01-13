using System;

namespace Center.Server
{
	// Token: 0x02000010 RID: 16
	public class Player
	{
		// Token: 0x0400006C RID: 108
		public int Id;

		// Token: 0x0400006D RID: 109
		public string Name;

		// Token: 0x0400006E RID: 110
		public string Password;

		// Token: 0x0400006F RID: 111
		public long LastTime;

		// Token: 0x04000070 RID: 112
		public bool IsFirst;

		// Token: 0x04000071 RID: 113
		public ePlayerState State;

		// Token: 0x04000072 RID: 114
		public ServerClient CurrentServer;
	}
}
