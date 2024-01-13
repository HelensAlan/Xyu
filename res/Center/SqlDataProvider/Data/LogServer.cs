using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200003D RID: 61
	public class LogServer
	{
		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x00005954 File Offset: 0x00003B54
		// (set) Token: 0x06000574 RID: 1396 RVA: 0x0000595C File Offset: 0x00003B5C
		public int ApplicationId { get; set; }

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x00005965 File Offset: 0x00003B65
		// (set) Token: 0x06000576 RID: 1398 RVA: 0x0000596D File Offset: 0x00003B6D
		public int SubId { get; set; }

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000577 RID: 1399 RVA: 0x00005976 File Offset: 0x00003B76
		// (set) Token: 0x06000578 RID: 1400 RVA: 0x0000597E File Offset: 0x00003B7E
		public DateTime EnterTime { get; set; }

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x00005987 File Offset: 0x00003B87
		// (set) Token: 0x0600057A RID: 1402 RVA: 0x0000598F File Offset: 0x00003B8F
		public int Online { get; set; }

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x00005998 File Offset: 0x00003B98
		// (set) Token: 0x0600057C RID: 1404 RVA: 0x000059A0 File Offset: 0x00003BA0
		public int Reg { get; set; }

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x000059A9 File Offset: 0x00003BA9
		// (set) Token: 0x0600057E RID: 1406 RVA: 0x000059B1 File Offset: 0x00003BB1
		public int PayMan { get; set; }
	}
}
