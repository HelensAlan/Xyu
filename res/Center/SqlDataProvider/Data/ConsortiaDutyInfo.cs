using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200001B RID: 27
	public class ConsortiaDutyInfo
	{
		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00003186 File Offset: 0x00001386
		// (set) Token: 0x060001FC RID: 508 RVA: 0x0000318E File Offset: 0x0000138E
		public int DutyID { get; set; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060001FD RID: 509 RVA: 0x00003197 File Offset: 0x00001397
		// (set) Token: 0x060001FE RID: 510 RVA: 0x0000319F File Offset: 0x0000139F
		public int ConsortiaID { get; set; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060001FF RID: 511 RVA: 0x000031A8 File Offset: 0x000013A8
		// (set) Token: 0x06000200 RID: 512 RVA: 0x000031B0 File Offset: 0x000013B0
		public int Level { get; set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000201 RID: 513 RVA: 0x000031B9 File Offset: 0x000013B9
		// (set) Token: 0x06000202 RID: 514 RVA: 0x000031C1 File Offset: 0x000013C1
		public string DutyName { get; set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000203 RID: 515 RVA: 0x000031CA File Offset: 0x000013CA
		// (set) Token: 0x06000204 RID: 516 RVA: 0x000031D2 File Offset: 0x000013D2
		public int Right { get; set; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000205 RID: 517 RVA: 0x000031DB File Offset: 0x000013DB
		// (set) Token: 0x06000206 RID: 518 RVA: 0x000031E3 File Offset: 0x000013E3
		public bool IsExist { get; set; }
	}
}
