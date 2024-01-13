using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000013 RID: 19
	public class CardInfo
	{
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600013F RID: 319 RVA: 0x00002B4C File Offset: 0x00000D4C
		// (set) Token: 0x06000140 RID: 320 RVA: 0x00002B54 File Offset: 0x00000D54
		public int CardID { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00002B5D File Offset: 0x00000D5D
		// (set) Token: 0x06000142 RID: 322 RVA: 0x00002B65 File Offset: 0x00000D65
		public int UserID { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000143 RID: 323 RVA: 0x00002B6E File Offset: 0x00000D6E
		// (set) Token: 0x06000144 RID: 324 RVA: 0x00002B76 File Offset: 0x00000D76
		public int Count { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00002B7F File Offset: 0x00000D7F
		// (set) Token: 0x06000146 RID: 326 RVA: 0x00002B87 File Offset: 0x00000D87
		public int Place { get; set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00002B90 File Offset: 0x00000D90
		// (set) Token: 0x06000148 RID: 328 RVA: 0x00002B98 File Offset: 0x00000D98
		public int TemplateID { get; set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00002BA1 File Offset: 0x00000DA1
		// (set) Token: 0x0600014A RID: 330 RVA: 0x00002BA9 File Offset: 0x00000DA9
		public int Attack { get; set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600014B RID: 331 RVA: 0x00002BB2 File Offset: 0x00000DB2
		// (set) Token: 0x0600014C RID: 332 RVA: 0x00002BBA File Offset: 0x00000DBA
		public int Defence { get; set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600014D RID: 333 RVA: 0x00002BC3 File Offset: 0x00000DC3
		// (set) Token: 0x0600014E RID: 334 RVA: 0x00002BCB File Offset: 0x00000DCB
		public int Agility { get; set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600014F RID: 335 RVA: 0x00002BD4 File Offset: 0x00000DD4
		// (set) Token: 0x06000150 RID: 336 RVA: 0x00002BDC File Offset: 0x00000DDC
		public int Luck { get; set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000151 RID: 337 RVA: 0x00002BE5 File Offset: 0x00000DE5
		// (set) Token: 0x06000152 RID: 338 RVA: 0x00002BED File Offset: 0x00000DED
		public int Damage { get; set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00002BF6 File Offset: 0x00000DF6
		// (set) Token: 0x06000154 RID: 340 RVA: 0x00002BFE File Offset: 0x00000DFE
		public int Guard { get; set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000155 RID: 341 RVA: 0x00002C07 File Offset: 0x00000E07
		// (set) Token: 0x06000156 RID: 342 RVA: 0x00002C0F File Offset: 0x00000E0F
		public int Level { get; set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00002C18 File Offset: 0x00000E18
		// (set) Token: 0x06000158 RID: 344 RVA: 0x00002C20 File Offset: 0x00000E20
		public int CardGP { get; set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000159 RID: 345 RVA: 0x00002C29 File Offset: 0x00000E29
		// (set) Token: 0x0600015A RID: 346 RVA: 0x00002C31 File Offset: 0x00000E31
		public bool IsFirstGet { get; set; }
	}
}
