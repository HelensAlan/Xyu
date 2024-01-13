using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000019 RID: 25
	public class ConsortiaApplyAllyInfo
	{
		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00002F9A File Offset: 0x0000119A
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x00002FA2 File Offset: 0x000011A2
		public int ID { get; set; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00002FAB File Offset: 0x000011AB
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00002FB3 File Offset: 0x000011B3
		public int Consortia1ID { get; set; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00002FBC File Offset: 0x000011BC
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x00002FC4 File Offset: 0x000011C4
		public int Consortia2ID { get; set; }

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00002FCD File Offset: 0x000011CD
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x00002FD5 File Offset: 0x000011D5
		public DateTime Date { get; set; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00002FDE File Offset: 0x000011DE
		// (set) Token: 0x060001CA RID: 458 RVA: 0x00002FE6 File Offset: 0x000011E6
		public string Remark { get; set; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060001CB RID: 459 RVA: 0x00002FEF File Offset: 0x000011EF
		// (set) Token: 0x060001CC RID: 460 RVA: 0x00002FF7 File Offset: 0x000011F7
		public bool IsExist { get; set; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00003000 File Offset: 0x00001200
		// (set) Token: 0x060001CE RID: 462 RVA: 0x00003008 File Offset: 0x00001208
		public int State { get; set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00003011 File Offset: 0x00001211
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x00003019 File Offset: 0x00001219
		public string ConsortiaName { get; set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x00003022 File Offset: 0x00001222
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x0000302A File Offset: 0x0000122A
		public int Repute { get; set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00003033 File Offset: 0x00001233
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x0000303B File Offset: 0x0000123B
		public string ChairmanName { get; set; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00003044 File Offset: 0x00001244
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x0000304C File Offset: 0x0000124C
		public int Count { get; set; }

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00003055 File Offset: 0x00001255
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x0000305D File Offset: 0x0000125D
		public int CelebCount { get; set; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00003066 File Offset: 0x00001266
		// (set) Token: 0x060001DA RID: 474 RVA: 0x0000306E File Offset: 0x0000126E
		public int Honor { get; set; }

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00003077 File Offset: 0x00001277
		// (set) Token: 0x060001DC RID: 476 RVA: 0x0000307F File Offset: 0x0000127F
		public int Level { get; set; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00003088 File Offset: 0x00001288
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00003090 File Offset: 0x00001290
		public string Description { get; set; }
	}
}
