using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200002F RID: 47
	public class FightRateInfo
	{
		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x000040CD File Offset: 0x000022CD
		// (set) Token: 0x060003B1 RID: 945 RVA: 0x000040D5 File Offset: 0x000022D5
		public int ID { get; set; }

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x000040DE File Offset: 0x000022DE
		// (set) Token: 0x060003B3 RID: 947 RVA: 0x000040E6 File Offset: 0x000022E6
		public int ServerID { get; set; }

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x000040EF File Offset: 0x000022EF
		// (set) Token: 0x060003B5 RID: 949 RVA: 0x000040F7 File Offset: 0x000022F7
		public int Rate { get; set; }

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x00004100 File Offset: 0x00002300
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x00004108 File Offset: 0x00002308
		public DateTime BeginDay { get; set; }

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x00004111 File Offset: 0x00002311
		// (set) Token: 0x060003B9 RID: 953 RVA: 0x00004119 File Offset: 0x00002319
		public DateTime EndDay { get; set; }

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060003BA RID: 954 RVA: 0x00004122 File Offset: 0x00002322
		// (set) Token: 0x060003BB RID: 955 RVA: 0x0000412A File Offset: 0x0000232A
		public DateTime BeginTime { get; set; }

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060003BC RID: 956 RVA: 0x00004133 File Offset: 0x00002333
		// (set) Token: 0x060003BD RID: 957 RVA: 0x0000413B File Offset: 0x0000233B
		public DateTime EndTime { get; set; }

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060003BE RID: 958 RVA: 0x00004144 File Offset: 0x00002344
		// (set) Token: 0x060003BF RID: 959 RVA: 0x0000414C File Offset: 0x0000234C
		public int BoyTemplateID { get; set; }

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x00004155 File Offset: 0x00002355
		// (set) Token: 0x060003C1 RID: 961 RVA: 0x0000415D File Offset: 0x0000235D
		public int GirlTemplateID { get; set; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x00004166 File Offset: 0x00002366
		// (set) Token: 0x060003C3 RID: 963 RVA: 0x0000416E File Offset: 0x0000236E
		public string SelfCue { get; set; }

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x00004177 File Offset: 0x00002377
		// (set) Token: 0x060003C5 RID: 965 RVA: 0x0000417F File Offset: 0x0000237F
		public string EnemyCue { get; set; }

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x00004188 File Offset: 0x00002388
		// (set) Token: 0x060003C7 RID: 967 RVA: 0x00004190 File Offset: 0x00002390
		public string Name { get; set; }
	}
}
