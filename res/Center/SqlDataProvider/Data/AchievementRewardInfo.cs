using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000008 RID: 8
	public class AchievementRewardInfo : DataObject
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000022A3 File Offset: 0x000004A3
		// (set) Token: 0x06000045 RID: 69 RVA: 0x000022AB File Offset: 0x000004AB
		public int AchievementID { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000046 RID: 70 RVA: 0x000022B4 File Offset: 0x000004B4
		// (set) Token: 0x06000047 RID: 71 RVA: 0x000022BC File Offset: 0x000004BC
		public int RewardType { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000022C5 File Offset: 0x000004C5
		// (set) Token: 0x06000049 RID: 73 RVA: 0x000022CD File Offset: 0x000004CD
		public string RewardPara { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000022D6 File Offset: 0x000004D6
		// (set) Token: 0x0600004B RID: 75 RVA: 0x000022DE File Offset: 0x000004DE
		public int RewardValueId { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000022E7 File Offset: 0x000004E7
		// (set) Token: 0x0600004D RID: 77 RVA: 0x000022EF File Offset: 0x000004EF
		public int RewardCount { get; set; }
	}
}
