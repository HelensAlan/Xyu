using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200002D RID: 45
	public class FeedbackSubmit
	{
		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000378 RID: 888 RVA: 0x00003EF2 File Offset: 0x000020F2
		// (set) Token: 0x06000379 RID: 889 RVA: 0x00003EFA File Offset: 0x000020FA
		public int QuestionID { get; set; }

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x0600037A RID: 890 RVA: 0x00003F03 File Offset: 0x00002103
		// (set) Token: 0x0600037B RID: 891 RVA: 0x00003F0B File Offset: 0x0000210B
		public string QuestionTitle { get; set; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x0600037C RID: 892 RVA: 0x00003F14 File Offset: 0x00002114
		// (set) Token: 0x0600037D RID: 893 RVA: 0x00003F1C File Offset: 0x0000211C
		public string QuestionContent { get; set; }

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x0600037E RID: 894 RVA: 0x00003F25 File Offset: 0x00002125
		// (set) Token: 0x0600037F RID: 895 RVA: 0x00003F2D File Offset: 0x0000212D
		public string OccurrenceDate { get; set; }

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00003F36 File Offset: 0x00002136
		// (set) Token: 0x06000381 RID: 897 RVA: 0x00003F3E File Offset: 0x0000213E
		public int QuestionType { get; set; }

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00003F47 File Offset: 0x00002147
		// (set) Token: 0x06000383 RID: 899 RVA: 0x00003F4F File Offset: 0x0000214F
		public string GoodsGetMethod { get; set; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000384 RID: 900 RVA: 0x00003F58 File Offset: 0x00002158
		// (set) Token: 0x06000385 RID: 901 RVA: 0x00003F60 File Offset: 0x00002160
		public string GoodsGetDate { get; set; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000386 RID: 902 RVA: 0x00003F69 File Offset: 0x00002169
		// (set) Token: 0x06000387 RID: 903 RVA: 0x00003F71 File Offset: 0x00002171
		public string ChargeOrderID { get; set; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000388 RID: 904 RVA: 0x00003F7A File Offset: 0x0000217A
		// (set) Token: 0x06000389 RID: 905 RVA: 0x00003F82 File Offset: 0x00002182
		public string ChargeMethod { get; set; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x0600038A RID: 906 RVA: 0x00003F8B File Offset: 0x0000218B
		// (set) Token: 0x0600038B RID: 907 RVA: 0x00003F93 File Offset: 0x00002193
		public int ChargeMoneys { get; set; }

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x0600038C RID: 908 RVA: 0x00003F9C File Offset: 0x0000219C
		// (set) Token: 0x0600038D RID: 909 RVA: 0x00003FA4 File Offset: 0x000021A4
		public bool ActivityIsError { get; set; }

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x0600038E RID: 910 RVA: 0x00003FAD File Offset: 0x000021AD
		// (set) Token: 0x0600038F RID: 911 RVA: 0x00003FB5 File Offset: 0x000021B5
		public string ActivityName { get; set; }

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000390 RID: 912 RVA: 0x00003FBE File Offset: 0x000021BE
		// (set) Token: 0x06000391 RID: 913 RVA: 0x00003FC6 File Offset: 0x000021C6
		public string ReportUserName { get; set; }

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000392 RID: 914 RVA: 0x00003FCF File Offset: 0x000021CF
		// (set) Token: 0x06000393 RID: 915 RVA: 0x00003FD7 File Offset: 0x000021D7
		public string ReportUrl { get; set; }

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000394 RID: 916 RVA: 0x00003FE0 File Offset: 0x000021E0
		// (set) Token: 0x06000395 RID: 917 RVA: 0x00003FE8 File Offset: 0x000021E8
		public string UserFullName { get; set; }

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000396 RID: 918 RVA: 0x00003FF1 File Offset: 0x000021F1
		// (set) Token: 0x06000397 RID: 919 RVA: 0x00003FF9 File Offset: 0x000021F9
		public string UserPhone { get; set; }

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000398 RID: 920 RVA: 0x00004002 File Offset: 0x00002202
		// (set) Token: 0x06000399 RID: 921 RVA: 0x0000400A File Offset: 0x0000220A
		public string ComplaintsTitle { get; set; }

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00004013 File Offset: 0x00002213
		// (set) Token: 0x0600039B RID: 923 RVA: 0x0000401B File Offset: 0x0000221B
		public string ComplaintsSource { get; set; }

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00004024 File Offset: 0x00002224
		// (set) Token: 0x0600039D RID: 925 RVA: 0x0000402C File Offset: 0x0000222C
		public int UserID { get; set; }

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00004035 File Offset: 0x00002235
		// (set) Token: 0x0600039F RID: 927 RVA: 0x0000403D File Offset: 0x0000223D
		public string UserName { get; set; }

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x00004046 File Offset: 0x00002246
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x0000404E File Offset: 0x0000224E
		public string UserNickName { get; set; }

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00004057 File Offset: 0x00002257
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x0000405F File Offset: 0x0000225F
		public bool IsExist { get; set; }
	}
}
