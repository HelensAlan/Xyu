using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200001F RID: 31
	public class ConsortiaInviteUserInfo
	{
		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600026F RID: 623 RVA: 0x0000360F File Offset: 0x0000180F
		// (set) Token: 0x06000270 RID: 624 RVA: 0x00003617 File Offset: 0x00001817
		public int ID { get; set; }

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000271 RID: 625 RVA: 0x00003620 File Offset: 0x00001820
		// (set) Token: 0x06000272 RID: 626 RVA: 0x00003628 File Offset: 0x00001828
		public int ConsortiaID { get; set; }

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000273 RID: 627 RVA: 0x00003631 File Offset: 0x00001831
		// (set) Token: 0x06000274 RID: 628 RVA: 0x00003639 File Offset: 0x00001839
		public string ConsortiaName { get; set; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00003642 File Offset: 0x00001842
		// (set) Token: 0x06000276 RID: 630 RVA: 0x0000364A File Offset: 0x0000184A
		public int UserID { get; set; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00003653 File Offset: 0x00001853
		// (set) Token: 0x06000278 RID: 632 RVA: 0x0000365B File Offset: 0x0000185B
		public string UserName { get; set; }

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000279 RID: 633 RVA: 0x00003664 File Offset: 0x00001864
		// (set) Token: 0x0600027A RID: 634 RVA: 0x0000366C File Offset: 0x0000186C
		public int InviteID { get; set; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x0600027B RID: 635 RVA: 0x00003675 File Offset: 0x00001875
		// (set) Token: 0x0600027C RID: 636 RVA: 0x0000367D File Offset: 0x0000187D
		public string InviteName { get; set; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x0600027D RID: 637 RVA: 0x00003686 File Offset: 0x00001886
		// (set) Token: 0x0600027E RID: 638 RVA: 0x0000368E File Offset: 0x0000188E
		public DateTime InviteDate { get; set; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00003697 File Offset: 0x00001897
		// (set) Token: 0x06000280 RID: 640 RVA: 0x0000369F File Offset: 0x0000189F
		public string Remark { get; set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000281 RID: 641 RVA: 0x000036A8 File Offset: 0x000018A8
		// (set) Token: 0x06000282 RID: 642 RVA: 0x000036B0 File Offset: 0x000018B0
		public bool IsExist { get; set; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000283 RID: 643 RVA: 0x000036B9 File Offset: 0x000018B9
		// (set) Token: 0x06000284 RID: 644 RVA: 0x000036C1 File Offset: 0x000018C1
		public string ChairmanName { get; set; }

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000285 RID: 645 RVA: 0x000036CA File Offset: 0x000018CA
		// (set) Token: 0x06000286 RID: 646 RVA: 0x000036D2 File Offset: 0x000018D2
		public int CelebCount { get; set; }

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000287 RID: 647 RVA: 0x000036DB File Offset: 0x000018DB
		// (set) Token: 0x06000288 RID: 648 RVA: 0x000036E3 File Offset: 0x000018E3
		public int Honor { get; set; }

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000289 RID: 649 RVA: 0x000036EC File Offset: 0x000018EC
		// (set) Token: 0x0600028A RID: 650 RVA: 0x000036F4 File Offset: 0x000018F4
		public int Repute { get; set; }

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600028B RID: 651 RVA: 0x000036FD File Offset: 0x000018FD
		// (set) Token: 0x0600028C RID: 652 RVA: 0x00003705 File Offset: 0x00001905
		public int Count { get; set; }
	}
}
