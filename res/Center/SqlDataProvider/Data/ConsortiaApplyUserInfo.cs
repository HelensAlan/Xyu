using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200001A RID: 26
	public class ConsortiaApplyUserInfo
	{
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x000030A1 File Offset: 0x000012A1
		// (set) Token: 0x060001E1 RID: 481 RVA: 0x000030A9 File Offset: 0x000012A9
		public int ID { get; set; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x000030B2 File Offset: 0x000012B2
		// (set) Token: 0x060001E3 RID: 483 RVA: 0x000030BA File Offset: 0x000012BA
		public int ConsortiaID { get; set; }

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x000030C3 File Offset: 0x000012C3
		// (set) Token: 0x060001E5 RID: 485 RVA: 0x000030CB File Offset: 0x000012CB
		public string ConsortiaName { get; set; }

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x000030D4 File Offset: 0x000012D4
		// (set) Token: 0x060001E7 RID: 487 RVA: 0x000030DC File Offset: 0x000012DC
		public int UserID { get; set; }

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x000030E5 File Offset: 0x000012E5
		// (set) Token: 0x060001E9 RID: 489 RVA: 0x000030ED File Offset: 0x000012ED
		public string UserName { get; set; }

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060001EA RID: 490 RVA: 0x000030F6 File Offset: 0x000012F6
		// (set) Token: 0x060001EB RID: 491 RVA: 0x000030FE File Offset: 0x000012FE
		public DateTime ApplyDate { get; set; }

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00003107 File Offset: 0x00001307
		// (set) Token: 0x060001ED RID: 493 RVA: 0x0000310F File Offset: 0x0000130F
		public string Remark { get; set; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00003118 File Offset: 0x00001318
		// (set) Token: 0x060001EF RID: 495 RVA: 0x00003120 File Offset: 0x00001320
		public bool IsExist { get; set; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00003129 File Offset: 0x00001329
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x00003131 File Offset: 0x00001331
		public int UserLevel { get; set; }

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x0000313A File Offset: 0x0000133A
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x00003142 File Offset: 0x00001342
		public int Win { get; set; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x0000314B File Offset: 0x0000134B
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x00003153 File Offset: 0x00001353
		public int Total { get; set; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x0000315C File Offset: 0x0000135C
		// (set) Token: 0x060001F7 RID: 503 RVA: 0x00003164 File Offset: 0x00001364
		public int Repute { get; set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x0000316D File Offset: 0x0000136D
		// (set) Token: 0x060001F9 RID: 505 RVA: 0x00003175 File Offset: 0x00001375
		public int FightPower { get; set; }
	}
}
