using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200002C RID: 44
	public class FeedbackRead
	{
		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000367 RID: 871 RVA: 0x00003E62 File Offset: 0x00002062
		// (set) Token: 0x06000368 RID: 872 RVA: 0x00003E6A File Offset: 0x0000206A
		public int QuestionID { get; set; }

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000369 RID: 873 RVA: 0x00003E73 File Offset: 0x00002073
		// (set) Token: 0x0600036A RID: 874 RVA: 0x00003E7B File Offset: 0x0000207B
		public int ReplyID { get; set; }

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x0600036B RID: 875 RVA: 0x00003E84 File Offset: 0x00002084
		// (set) Token: 0x0600036C RID: 876 RVA: 0x00003E8C File Offset: 0x0000208C
		public int UserID { get; set; }

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x0600036D RID: 877 RVA: 0x00003E95 File Offset: 0x00002095
		// (set) Token: 0x0600036E RID: 878 RVA: 0x00003E9D File Offset: 0x0000209D
		public string OccurrenceDate { get; set; }

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600036F RID: 879 RVA: 0x00003EA6 File Offset: 0x000020A6
		// (set) Token: 0x06000370 RID: 880 RVA: 0x00003EAE File Offset: 0x000020AE
		public string Title { get; set; }

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000371 RID: 881 RVA: 0x00003EB7 File Offset: 0x000020B7
		// (set) Token: 0x06000372 RID: 882 RVA: 0x00003EBF File Offset: 0x000020BF
		public string QuestionContent { get; set; }

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000373 RID: 883 RVA: 0x00003EC8 File Offset: 0x000020C8
		// (set) Token: 0x06000374 RID: 884 RVA: 0x00003ED0 File Offset: 0x000020D0
		public string ReplyContent { get; set; }

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000375 RID: 885 RVA: 0x00003ED9 File Offset: 0x000020D9
		// (set) Token: 0x06000376 RID: 886 RVA: 0x00003EE1 File Offset: 0x000020E1
		public bool IsExist { get; set; }
	}
}
