using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200001C RID: 28
	public class ConsortiaEquipControlInfo
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000208 RID: 520 RVA: 0x000031F4 File Offset: 0x000013F4
		// (set) Token: 0x06000209 RID: 521 RVA: 0x000031FC File Offset: 0x000013FC
		public int ConsortiaID { get; set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600020A RID: 522 RVA: 0x00003205 File Offset: 0x00001405
		// (set) Token: 0x0600020B RID: 523 RVA: 0x0000320D File Offset: 0x0000140D
		public int Type { get; set; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00003216 File Offset: 0x00001416
		// (set) Token: 0x0600020D RID: 525 RVA: 0x0000321E File Offset: 0x0000141E
		public int Level { get; set; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00003227 File Offset: 0x00001427
		// (set) Token: 0x0600020F RID: 527 RVA: 0x0000322F File Offset: 0x0000142F
		public int Riches { get; set; }
	}
}
