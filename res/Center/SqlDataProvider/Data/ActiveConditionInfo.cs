using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200000A RID: 10
	public class ActiveConditionInfo
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600006C RID: 108 RVA: 0x000023F6 File Offset: 0x000005F6
		// (set) Token: 0x0600006D RID: 109 RVA: 0x000023FE File Offset: 0x000005FE
		public int ID { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00002407 File Offset: 0x00000607
		// (set) Token: 0x0600006F RID: 111 RVA: 0x0000240F File Offset: 0x0000060F
		public int ActiveID { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00002418 File Offset: 0x00000618
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00002420 File Offset: 0x00000620
		public int Conditiontype { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00002429 File Offset: 0x00000629
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00002431 File Offset: 0x00000631
		public int Condition { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000074 RID: 116 RVA: 0x0000243A File Offset: 0x0000063A
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00002442 File Offset: 0x00000642
		public string LimitGrade { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000076 RID: 118 RVA: 0x0000244B File Offset: 0x0000064B
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00002453 File Offset: 0x00000653
		public string AwardId { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000078 RID: 120 RVA: 0x0000245C File Offset: 0x0000065C
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00002464 File Offset: 0x00000664
		public bool IsMult { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600007A RID: 122 RVA: 0x0000246D File Offset: 0x0000066D
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00002475 File Offset: 0x00000675
		public DateTime StartTime { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600007C RID: 124 RVA: 0x0000247E File Offset: 0x0000067E
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00002486 File Offset: 0x00000686
		public DateTime EndTime { get; set; }
	}
}
