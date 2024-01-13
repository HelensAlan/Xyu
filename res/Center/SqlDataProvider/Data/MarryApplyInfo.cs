using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000041 RID: 65
	public class MarryApplyInfo
	{
		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x00005E84 File Offset: 0x00004084
		// (set) Token: 0x060005F3 RID: 1523 RVA: 0x00005E8C File Offset: 0x0000408C
		public int UserID { get; set; }

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x00005E95 File Offset: 0x00004095
		// (set) Token: 0x060005F5 RID: 1525 RVA: 0x00005E9D File Offset: 0x0000409D
		public int ApplyUserID { get; set; }

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x00005EA6 File Offset: 0x000040A6
		// (set) Token: 0x060005F7 RID: 1527 RVA: 0x00005EAE File Offset: 0x000040AE
		public string ApplyUserName { get; set; }

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x060005F8 RID: 1528 RVA: 0x00005EB7 File Offset: 0x000040B7
		// (set) Token: 0x060005F9 RID: 1529 RVA: 0x00005EBF File Offset: 0x000040BF
		public int ApplyType { get; set; }

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x060005FA RID: 1530 RVA: 0x00005EC8 File Offset: 0x000040C8
		// (set) Token: 0x060005FB RID: 1531 RVA: 0x00005ED0 File Offset: 0x000040D0
		public bool ApplyResult { get; set; }

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x060005FC RID: 1532 RVA: 0x00005ED9 File Offset: 0x000040D9
		// (set) Token: 0x060005FD RID: 1533 RVA: 0x00005EE1 File Offset: 0x000040E1
		public string LoveProclamation { get; set; }

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x060005FE RID: 1534 RVA: 0x00005EEA File Offset: 0x000040EA
		// (set) Token: 0x060005FF RID: 1535 RVA: 0x00005EF2 File Offset: 0x000040F2
		public int ID { get; set; }
	}
}
