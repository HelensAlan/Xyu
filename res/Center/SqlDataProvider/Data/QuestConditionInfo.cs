using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000055 RID: 85
	public class QuestConditionInfo
	{
		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06000919 RID: 2329 RVA: 0x000086CC File Offset: 0x000068CC
		// (set) Token: 0x0600091A RID: 2330 RVA: 0x000086D4 File Offset: 0x000068D4
		public int QuestID { get; set; }

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x0600091B RID: 2331 RVA: 0x000086DD File Offset: 0x000068DD
		// (set) Token: 0x0600091C RID: 2332 RVA: 0x000086E5 File Offset: 0x000068E5
		public int CondictionID { get; set; }

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x000086EE File Offset: 0x000068EE
		// (set) Token: 0x0600091E RID: 2334 RVA: 0x000086F6 File Offset: 0x000068F6
		public string CondictionTitle { get; set; }

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x000086FF File Offset: 0x000068FF
		// (set) Token: 0x06000920 RID: 2336 RVA: 0x00008707 File Offset: 0x00006907
		public int CondictionType { get; set; }

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06000921 RID: 2337 RVA: 0x00008710 File Offset: 0x00006910
		// (set) Token: 0x06000922 RID: 2338 RVA: 0x00008718 File Offset: 0x00006918
		public int Para1 { get; set; }

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06000923 RID: 2339 RVA: 0x00008721 File Offset: 0x00006921
		// (set) Token: 0x06000924 RID: 2340 RVA: 0x00008729 File Offset: 0x00006929
		public int Para2 { get; set; }

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x00008732 File Offset: 0x00006932
		// (set) Token: 0x06000926 RID: 2342 RVA: 0x0000873A File Offset: 0x0000693A
		public bool isOpitional { get; set; }
	}
}
