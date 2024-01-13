using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000023 RID: 35
	public class DailyAwardInfo
	{
		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000307 RID: 775 RVA: 0x00003B19 File Offset: 0x00001D19
		// (set) Token: 0x06000308 RID: 776 RVA: 0x00003B21 File Offset: 0x00001D21
		public int ID { get; set; }

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000309 RID: 777 RVA: 0x00003B2A File Offset: 0x00001D2A
		// (set) Token: 0x0600030A RID: 778 RVA: 0x00003B32 File Offset: 0x00001D32
		public int Type { get; set; }

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x0600030B RID: 779 RVA: 0x00003B3B File Offset: 0x00001D3B
		// (set) Token: 0x0600030C RID: 780 RVA: 0x00003B43 File Offset: 0x00001D43
		public int TemplateID { get; set; }

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x0600030D RID: 781 RVA: 0x00003B4C File Offset: 0x00001D4C
		// (set) Token: 0x0600030E RID: 782 RVA: 0x00003B54 File Offset: 0x00001D54
		public int Count { get; set; }

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600030F RID: 783 RVA: 0x00003B5D File Offset: 0x00001D5D
		// (set) Token: 0x06000310 RID: 784 RVA: 0x00003B65 File Offset: 0x00001D65
		public int ValidDate { get; set; }

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000311 RID: 785 RVA: 0x00003B6E File Offset: 0x00001D6E
		// (set) Token: 0x06000312 RID: 786 RVA: 0x00003B76 File Offset: 0x00001D76
		public bool IsBinds { get; set; }

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000313 RID: 787 RVA: 0x00003B7F File Offset: 0x00001D7F
		// (set) Token: 0x06000314 RID: 788 RVA: 0x00003B87 File Offset: 0x00001D87
		public int Sex { get; set; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000315 RID: 789 RVA: 0x00003B90 File Offset: 0x00001D90
		// (set) Token: 0x06000316 RID: 790 RVA: 0x00003B98 File Offset: 0x00001D98
		public string Remark { get; set; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000317 RID: 791 RVA: 0x00003BA1 File Offset: 0x00001DA1
		// (set) Token: 0x06000318 RID: 792 RVA: 0x00003BA9 File Offset: 0x00001DA9
		public string CountRemark { get; set; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000319 RID: 793 RVA: 0x00003BB2 File Offset: 0x00001DB2
		// (set) Token: 0x0600031A RID: 794 RVA: 0x00003BBA File Offset: 0x00001DBA
		public int GetWay { get; set; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x0600031B RID: 795 RVA: 0x00003BC3 File Offset: 0x00001DC3
		// (set) Token: 0x0600031C RID: 796 RVA: 0x00003BCB File Offset: 0x00001DCB
		public int AwardDays { get; set; }
	}
}
