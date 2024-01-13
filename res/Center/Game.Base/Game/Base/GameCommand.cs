using System;

namespace Game.Base
{
	// Token: 0x0200000F RID: 15
	public class GameCommand
	{
		// Token: 0x04000039 RID: 57
		public string[] m_usage;

		// Token: 0x0400003A RID: 58
		public string m_cmd;

		// Token: 0x0400003B RID: 59
		public uint m_lvl;

		// Token: 0x0400003C RID: 60
		public string m_desc;

		// Token: 0x0400003D RID: 61
		public ICommandHandler m_cmdHandler;
	}
}
