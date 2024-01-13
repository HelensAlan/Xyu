using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000054 RID: 84
	public class QuestAwardInfo
	{
		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x000085F8 File Offset: 0x000067F8
		// (set) Token: 0x06000901 RID: 2305 RVA: 0x00008600 File Offset: 0x00006800
		public int QuestID { get; set; }

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x00008609 File Offset: 0x00006809
		// (set) Token: 0x06000903 RID: 2307 RVA: 0x00008611 File Offset: 0x00006811
		public int RewardItemID { get; set; }

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x0000861A File Offset: 0x0000681A
		// (set) Token: 0x06000905 RID: 2309 RVA: 0x00008622 File Offset: 0x00006822
		public bool IsSelect { get; set; }

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x0000862B File Offset: 0x0000682B
		// (set) Token: 0x06000907 RID: 2311 RVA: 0x00008633 File Offset: 0x00006833
		public int RewardItemValid { get; set; }

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x0000863C File Offset: 0x0000683C
		// (set) Token: 0x06000909 RID: 2313 RVA: 0x00008644 File Offset: 0x00006844
		public int RewardItemCount { get; set; }

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x0000864D File Offset: 0x0000684D
		// (set) Token: 0x0600090B RID: 2315 RVA: 0x00008655 File Offset: 0x00006855
		public int StrengthenLevel { get; set; }

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x0600090C RID: 2316 RVA: 0x0000865E File Offset: 0x0000685E
		// (set) Token: 0x0600090D RID: 2317 RVA: 0x00008666 File Offset: 0x00006866
		public int AttackCompose { get; set; }

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x0600090E RID: 2318 RVA: 0x0000866F File Offset: 0x0000686F
		// (set) Token: 0x0600090F RID: 2319 RVA: 0x00008677 File Offset: 0x00006877
		public int DefendCompose { get; set; }

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x00008680 File Offset: 0x00006880
		// (set) Token: 0x06000911 RID: 2321 RVA: 0x00008688 File Offset: 0x00006888
		public int AgilityCompose { get; set; }

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x00008691 File Offset: 0x00006891
		// (set) Token: 0x06000913 RID: 2323 RVA: 0x00008699 File Offset: 0x00006899
		public int LuckCompose { get; set; }

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06000914 RID: 2324 RVA: 0x000086A2 File Offset: 0x000068A2
		// (set) Token: 0x06000915 RID: 2325 RVA: 0x000086AA File Offset: 0x000068AA
		public bool IsCount { get; set; }

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06000916 RID: 2326 RVA: 0x000086B3 File Offset: 0x000068B3
		// (set) Token: 0x06000917 RID: 2327 RVA: 0x000086BB File Offset: 0x000068BB
		public bool IsBind { get; set; }
	}
}
