using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200002B RID: 43
	public class FeedbackAppraisal
	{
		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600035E RID: 862 RVA: 0x00003E16 File Offset: 0x00002016
		// (set) Token: 0x0600035F RID: 863 RVA: 0x00003E1E File Offset: 0x0000201E
		public int QuestionID { get; set; }

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000360 RID: 864 RVA: 0x00003E27 File Offset: 0x00002027
		// (set) Token: 0x06000361 RID: 865 RVA: 0x00003E2F File Offset: 0x0000202F
		public int ReplyID { get; set; }

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000362 RID: 866 RVA: 0x00003E38 File Offset: 0x00002038
		// (set) Token: 0x06000363 RID: 867 RVA: 0x00003E40 File Offset: 0x00002040
		public string AppraisalGrade { get; set; }

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000364 RID: 868 RVA: 0x00003E49 File Offset: 0x00002049
		// (set) Token: 0x06000365 RID: 869 RVA: 0x00003E51 File Offset: 0x00002051
		public string AppraisalContent { get; set; }
	}
}
