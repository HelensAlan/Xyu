using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000059 RID: 89
	public class RebateChargeInfo
	{
		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06000992 RID: 2450 RVA: 0x00008BB6 File Offset: 0x00006DB6
		// (set) Token: 0x06000993 RID: 2451 RVA: 0x00008BBE File Offset: 0x00006DBE
		public string ChargeID { get; set; }

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x00008BC7 File Offset: 0x00006DC7
		// (set) Token: 0x06000995 RID: 2453 RVA: 0x00008BCF File Offset: 0x00006DCF
		public string UserName { get; set; }

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06000996 RID: 2454 RVA: 0x00008BD8 File Offset: 0x00006DD8
		// (set) Token: 0x06000997 RID: 2455 RVA: 0x00008BE0 File Offset: 0x00006DE0
		public string NickName { get; set; }

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06000998 RID: 2456 RVA: 0x00008BE9 File Offset: 0x00006DE9
		// (set) Token: 0x06000999 RID: 2457 RVA: 0x00008BF1 File Offset: 0x00006DF1
		public int Money { get; set; }

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x0600099A RID: 2458 RVA: 0x00008BFA File Offset: 0x00006DFA
		// (set) Token: 0x0600099B RID: 2459 RVA: 0x00008C02 File Offset: 0x00006E02
		public DateTime Date { get; set; }
	}
}
