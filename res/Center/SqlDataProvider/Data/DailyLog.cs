using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000024 RID: 36
	public class DailyLog
	{
		// Token: 0x1700017E RID: 382
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00003BDC File Offset: 0x00001DDC
		// (set) Token: 0x0600031F RID: 799 RVA: 0x00003BE4 File Offset: 0x00001DE4
		public int UserID { get; set; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000320 RID: 800 RVA: 0x00003BED File Offset: 0x00001DED
		// (set) Token: 0x06000321 RID: 801 RVA: 0x00003BF5 File Offset: 0x00001DF5
		public int UserAwardLog { get; set; }

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000322 RID: 802 RVA: 0x00003BFE File Offset: 0x00001DFE
		// (set) Token: 0x06000323 RID: 803 RVA: 0x00003C06 File Offset: 0x00001E06
		public string DayLog { get; set; }
	}
}
