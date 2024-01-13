using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000018 RID: 24
	public class ConsortiaAllyInfo
	{
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000190 RID: 400 RVA: 0x00002DFA File Offset: 0x00000FFA
		// (set) Token: 0x06000191 RID: 401 RVA: 0x00002E02 File Offset: 0x00001002
		public int ID { get; set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000192 RID: 402 RVA: 0x00002E0B File Offset: 0x0000100B
		// (set) Token: 0x06000193 RID: 403 RVA: 0x00002E13 File Offset: 0x00001013
		public int Consortia1ID { get; set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00002E1C File Offset: 0x0000101C
		// (set) Token: 0x06000195 RID: 405 RVA: 0x00002E24 File Offset: 0x00001024
		public int Consortia2ID { get; set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00002E2D File Offset: 0x0000102D
		// (set) Token: 0x06000197 RID: 407 RVA: 0x00002E35 File Offset: 0x00001035
		public int State { get; set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00002E3E File Offset: 0x0000103E
		// (set) Token: 0x06000199 RID: 409 RVA: 0x00002E46 File Offset: 0x00001046
		public DateTime Date { get; set; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600019A RID: 410 RVA: 0x00002E4F File Offset: 0x0000104F
		// (set) Token: 0x0600019B RID: 411 RVA: 0x00002E57 File Offset: 0x00001057
		public int ValidDate { get; set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00002E60 File Offset: 0x00001060
		// (set) Token: 0x0600019D RID: 413 RVA: 0x00002E68 File Offset: 0x00001068
		public bool IsExist { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00002E71 File Offset: 0x00001071
		// (set) Token: 0x0600019F RID: 415 RVA: 0x00002E79 File Offset: 0x00001079
		public string ConsortiaName1 { get; set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00002E82 File Offset: 0x00001082
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x00002E8A File Offset: 0x0000108A
		public int Count1 { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00002E93 File Offset: 0x00001093
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x00002E9B File Offset: 0x0000109B
		public int Repute1 { get; set; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00002EA4 File Offset: 0x000010A4
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x00002EAC File Offset: 0x000010AC
		public string ConsortiaName2 { get; set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x00002EB5 File Offset: 0x000010B5
		// (set) Token: 0x060001A7 RID: 423 RVA: 0x00002EBD File Offset: 0x000010BD
		public int Count2 { get; set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x00002EC6 File Offset: 0x000010C6
		// (set) Token: 0x060001A9 RID: 425 RVA: 0x00002ECE File Offset: 0x000010CE
		public int Repute2 { get; set; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00002ED7 File Offset: 0x000010D7
		// (set) Token: 0x060001AB RID: 427 RVA: 0x00002EDF File Offset: 0x000010DF
		public string ChairmanName1 { get; set; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060001AC RID: 428 RVA: 0x00002EE8 File Offset: 0x000010E8
		// (set) Token: 0x060001AD RID: 429 RVA: 0x00002EF0 File Offset: 0x000010F0
		public string ChairmanName2 { get; set; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060001AE RID: 430 RVA: 0x00002EF9 File Offset: 0x000010F9
		// (set) Token: 0x060001AF RID: 431 RVA: 0x00002F01 File Offset: 0x00001101
		public int Level1 { get; set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x00002F0A File Offset: 0x0000110A
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x00002F12 File Offset: 0x00001112
		public int Level2 { get; set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x00002F1B File Offset: 0x0000111B
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x00002F23 File Offset: 0x00001123
		public int Honor1 { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x00002F2C File Offset: 0x0000112C
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x00002F34 File Offset: 0x00001134
		public int Honor2 { get; set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x00002F3D File Offset: 0x0000113D
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x00002F45 File Offset: 0x00001145
		public string Description1 { get; set; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x00002F4E File Offset: 0x0000114E
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x00002F56 File Offset: 0x00001156
		public string Description2 { get; set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060001BA RID: 442 RVA: 0x00002F5F File Offset: 0x0000115F
		// (set) Token: 0x060001BB RID: 443 RVA: 0x00002F67 File Offset: 0x00001167
		public int Riches1 { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060001BC RID: 444 RVA: 0x00002F70 File Offset: 0x00001170
		// (set) Token: 0x060001BD RID: 445 RVA: 0x00002F78 File Offset: 0x00001178
		public int Riches2 { get; set; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00002F81 File Offset: 0x00001181
		// (set) Token: 0x060001BF RID: 447 RVA: 0x00002F89 File Offset: 0x00001189
		public bool IsApply { get; set; }
	}
}
