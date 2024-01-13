using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000017 RID: 23
	public class ChargeRecordInfo
	{
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00002D9D File Offset: 0x00000F9D
		// (set) Token: 0x06000186 RID: 390 RVA: 0x00002DA5 File Offset: 0x00000FA5
		public string PayWay { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00002DAE File Offset: 0x00000FAE
		// (set) Token: 0x06000188 RID: 392 RVA: 0x00002DB6 File Offset: 0x00000FB6
		public int TotalBoy { get; set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00002DBF File Offset: 0x00000FBF
		// (set) Token: 0x0600018A RID: 394 RVA: 0x00002DC7 File Offset: 0x00000FC7
		public int TotalGirl { get; set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600018B RID: 395 RVA: 0x00002DD0 File Offset: 0x00000FD0
		// (set) Token: 0x0600018C RID: 396 RVA: 0x00002DD8 File Offset: 0x00000FD8
		public int BoyTotalPay { get; set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600018D RID: 397 RVA: 0x00002DE1 File Offset: 0x00000FE1
		// (set) Token: 0x0600018E RID: 398 RVA: 0x00002DE9 File Offset: 0x00000FE9
		public int GirlTotalPay { get; set; }
	}
}
