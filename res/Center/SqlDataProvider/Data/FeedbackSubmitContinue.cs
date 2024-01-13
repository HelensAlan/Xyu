using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200002E RID: 46
	public class FeedbackSubmitContinue
	{
		// Token: 0x170001BD RID: 445
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x00004070 File Offset: 0x00002270
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x00004078 File Offset: 0x00002278
		public int QuestionID { get; set; }

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x00004081 File Offset: 0x00002281
		// (set) Token: 0x060003A8 RID: 936 RVA: 0x00004089 File Offset: 0x00002289
		public int UserID { get; set; }

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x00004092 File Offset: 0x00002292
		// (set) Token: 0x060003AA RID: 938 RVA: 0x0000409A File Offset: 0x0000229A
		public string NickName { get; set; }

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x060003AB RID: 939 RVA: 0x000040A3 File Offset: 0x000022A3
		// (set) Token: 0x060003AC RID: 940 RVA: 0x000040AB File Offset: 0x000022AB
		public int ReplyID { get; set; }

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x060003AD RID: 941 RVA: 0x000040B4 File Offset: 0x000022B4
		// (set) Token: 0x060003AE RID: 942 RVA: 0x000040BC File Offset: 0x000022BC
		public string ReplyContent { get; set; }
	}
}
