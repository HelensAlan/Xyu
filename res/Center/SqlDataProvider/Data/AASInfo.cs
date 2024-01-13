using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000004 RID: 4
	public class AASInfo
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000209C File Offset: 0x0000029C
		// (set) Token: 0x0600000B RID: 11 RVA: 0x000020A4 File Offset: 0x000002A4
		public int UserID { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000020AD File Offset: 0x000002AD
		// (set) Token: 0x0600000D RID: 13 RVA: 0x000020B5 File Offset: 0x000002B5
		public string Name { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000020BE File Offset: 0x000002BE
		// (set) Token: 0x0600000F RID: 15 RVA: 0x000020C6 File Offset: 0x000002C6
		public string IDNumber { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000020CF File Offset: 0x000002CF
		// (set) Token: 0x06000011 RID: 17 RVA: 0x000020D7 File Offset: 0x000002D7
		public int State { get; set; }
	}
}
