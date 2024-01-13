using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000005 RID: 5
	public class AchievementConditionInfo : DataObject
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000020E8 File Offset: 0x000002E8
		// (set) Token: 0x06000014 RID: 20 RVA: 0x000020F0 File Offset: 0x000002F0
		public int AchievementID { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000020F9 File Offset: 0x000002F9
		// (set) Token: 0x06000016 RID: 22 RVA: 0x00002101 File Offset: 0x00000301
		public int CondictionID { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000017 RID: 23 RVA: 0x0000210A File Offset: 0x0000030A
		// (set) Token: 0x06000018 RID: 24 RVA: 0x00002112 File Offset: 0x00000312
		public int CondictionType { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000019 RID: 25 RVA: 0x0000211B File Offset: 0x0000031B
		// (set) Token: 0x0600001A RID: 26 RVA: 0x00002123 File Offset: 0x00000323
		public string Condiction_Para1 { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001B RID: 27 RVA: 0x0000212C File Offset: 0x0000032C
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002134 File Offset: 0x00000334
		public int Condiction_Para2 { get; set; }
	}
}
