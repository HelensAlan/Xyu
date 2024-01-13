using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200001D RID: 29
	public class ConsortiaEventInfo
	{
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000211 RID: 529 RVA: 0x00003240 File Offset: 0x00001440
		// (set) Token: 0x06000212 RID: 530 RVA: 0x00003248 File Offset: 0x00001448
		public int ID { get; set; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000213 RID: 531 RVA: 0x00003251 File Offset: 0x00001451
		// (set) Token: 0x06000214 RID: 532 RVA: 0x00003259 File Offset: 0x00001459
		public int ConsortiaID { get; set; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00003262 File Offset: 0x00001462
		// (set) Token: 0x06000216 RID: 534 RVA: 0x0000326A File Offset: 0x0000146A
		public string Remark { get; set; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000217 RID: 535 RVA: 0x00003273 File Offset: 0x00001473
		// (set) Token: 0x06000218 RID: 536 RVA: 0x0000327B File Offset: 0x0000147B
		public DateTime Date { get; set; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000219 RID: 537 RVA: 0x00003284 File Offset: 0x00001484
		// (set) Token: 0x0600021A RID: 538 RVA: 0x0000328C File Offset: 0x0000148C
		public bool IsExist { get; set; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600021B RID: 539 RVA: 0x00003295 File Offset: 0x00001495
		// (set) Token: 0x0600021C RID: 540 RVA: 0x0000329D File Offset: 0x0000149D
		public int Type { get; set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600021D RID: 541 RVA: 0x000032A6 File Offset: 0x000014A6
		// (set) Token: 0x0600021E RID: 542 RVA: 0x000032AE File Offset: 0x000014AE
		public string NickName { get; set; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600021F RID: 543 RVA: 0x000032B7 File Offset: 0x000014B7
		// (set) Token: 0x06000220 RID: 544 RVA: 0x000032BF File Offset: 0x000014BF
		public int EventValue { get; set; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000221 RID: 545 RVA: 0x000032C8 File Offset: 0x000014C8
		// (set) Token: 0x06000222 RID: 546 RVA: 0x000032D0 File Offset: 0x000014D0
		public string ManagerName { get; set; }
	}
}
