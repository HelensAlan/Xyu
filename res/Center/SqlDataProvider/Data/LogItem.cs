using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200003B RID: 59
	public class LogItem
	{
		// Token: 0x17000280 RID: 640
		// (get) Token: 0x0600053F RID: 1343 RVA: 0x0000579B File Offset: 0x0000399B
		// (set) Token: 0x06000540 RID: 1344 RVA: 0x000057A3 File Offset: 0x000039A3
		public int ApplicationId { get; set; }

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000541 RID: 1345 RVA: 0x000057AC File Offset: 0x000039AC
		// (set) Token: 0x06000542 RID: 1346 RVA: 0x000057B4 File Offset: 0x000039B4
		public int SubId { get; set; }

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000543 RID: 1347 RVA: 0x000057BD File Offset: 0x000039BD
		// (set) Token: 0x06000544 RID: 1348 RVA: 0x000057C5 File Offset: 0x000039C5
		public int LineId { get; set; }

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000545 RID: 1349 RVA: 0x000057CE File Offset: 0x000039CE
		// (set) Token: 0x06000546 RID: 1350 RVA: 0x000057D6 File Offset: 0x000039D6
		public DateTime EnterTime { get; set; }

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000547 RID: 1351 RVA: 0x000057DF File Offset: 0x000039DF
		// (set) Token: 0x06000548 RID: 1352 RVA: 0x000057E7 File Offset: 0x000039E7
		public int UserId { get; set; }

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x000057F0 File Offset: 0x000039F0
		// (set) Token: 0x0600054A RID: 1354 RVA: 0x000057F8 File Offset: 0x000039F8
		public int Operation { get; set; }

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x0600054B RID: 1355 RVA: 0x00005801 File Offset: 0x00003A01
		// (set) Token: 0x0600054C RID: 1356 RVA: 0x00005809 File Offset: 0x00003A09
		public string ItemName { get; set; }

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x00005812 File Offset: 0x00003A12
		// (set) Token: 0x0600054E RID: 1358 RVA: 0x0000581A File Offset: 0x00003A1A
		public int ItemID { get; set; }

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x0600054F RID: 1359 RVA: 0x00005823 File Offset: 0x00003A23
		// (set) Token: 0x06000550 RID: 1360 RVA: 0x0000582B File Offset: 0x00003A2B
		public string BeginProperty { get; set; }

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000551 RID: 1361 RVA: 0x00005834 File Offset: 0x00003A34
		// (set) Token: 0x06000552 RID: 1362 RVA: 0x0000583C File Offset: 0x00003A3C
		public string EndProperty { get; set; }

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000553 RID: 1363 RVA: 0x00005845 File Offset: 0x00003A45
		// (set) Token: 0x06000554 RID: 1364 RVA: 0x0000584D File Offset: 0x00003A4D
		public int Result { get; set; }
	}
}
