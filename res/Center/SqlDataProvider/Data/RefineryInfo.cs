using System;
using System.Collections.Generic;

namespace SqlDataProvider.Data
{
	// Token: 0x0200005C RID: 92
	public class RefineryInfo
	{
		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x060009D7 RID: 2519 RVA: 0x00008DFF File Offset: 0x00006FFF
		// (set) Token: 0x060009D8 RID: 2520 RVA: 0x00008E07 File Offset: 0x00007007
		public int RefineryID { get; set; }

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x060009D9 RID: 2521 RVA: 0x00008E10 File Offset: 0x00007010
		// (set) Token: 0x060009DA RID: 2522 RVA: 0x00008E18 File Offset: 0x00007018
		public int Item1 { get; set; }

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x060009DB RID: 2523 RVA: 0x00008E21 File Offset: 0x00007021
		// (set) Token: 0x060009DC RID: 2524 RVA: 0x00008E29 File Offset: 0x00007029
		public int Item1Count { get; set; }

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x060009DD RID: 2525 RVA: 0x00008E32 File Offset: 0x00007032
		// (set) Token: 0x060009DE RID: 2526 RVA: 0x00008E3A File Offset: 0x0000703A
		public int Item2 { get; set; }

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x060009DF RID: 2527 RVA: 0x00008E43 File Offset: 0x00007043
		// (set) Token: 0x060009E0 RID: 2528 RVA: 0x00008E4B File Offset: 0x0000704B
		public int Item2Count { get; set; }

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x060009E1 RID: 2529 RVA: 0x00008E54 File Offset: 0x00007054
		// (set) Token: 0x060009E2 RID: 2530 RVA: 0x00008E5C File Offset: 0x0000705C
		public int Item3 { get; set; }

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x060009E3 RID: 2531 RVA: 0x00008E65 File Offset: 0x00007065
		// (set) Token: 0x060009E4 RID: 2532 RVA: 0x00008E6D File Offset: 0x0000706D
		public int Item3Count { get; set; }

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x060009E5 RID: 2533 RVA: 0x00008E76 File Offset: 0x00007076
		// (set) Token: 0x060009E6 RID: 2534 RVA: 0x00008E7E File Offset: 0x0000707E
		public int Item4 { get; set; }

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x060009E7 RID: 2535 RVA: 0x00008E87 File Offset: 0x00007087
		// (set) Token: 0x060009E8 RID: 2536 RVA: 0x00008E8F File Offset: 0x0000708F
		public int Item4Count { get; set; }

		// Token: 0x0400053C RID: 1340
		public List<int> m_Equip = new List<int>();

		// Token: 0x0400053D RID: 1341
		public List<int> m_Reward = new List<int>();
	}
}
