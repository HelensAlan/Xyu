using System;

namespace Game.Base
{
	// Token: 0x0200000D RID: 13
	public class ConsoleClient : BaseClient
	{
		// Token: 0x06000073 RID: 115 RVA: 0x00003DA7 File Offset: 0x00001FA7
		public ConsoleClient()
			: base(null, null)
		{
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003DB1 File Offset: 0x00001FB1
		public override void DisplayMessage(string msg)
		{
			Console.WriteLine(msg);
		}
	}
}
