using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200005E RID: 94
	public class ServerInfo
	{
		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06000A01 RID: 2561 RVA: 0x00008F79 File Offset: 0x00007179
		// (set) Token: 0x06000A02 RID: 2562 RVA: 0x00008F81 File Offset: 0x00007181
		public int ID { get; set; }

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06000A03 RID: 2563 RVA: 0x00008F8A File Offset: 0x0000718A
		// (set) Token: 0x06000A04 RID: 2564 RVA: 0x00008F92 File Offset: 0x00007192
		public string Name { get; set; }

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06000A05 RID: 2565 RVA: 0x00008F9B File Offset: 0x0000719B
		// (set) Token: 0x06000A06 RID: 2566 RVA: 0x00008FA3 File Offset: 0x000071A3
		public string IP { get; set; }

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06000A07 RID: 2567 RVA: 0x00008FAC File Offset: 0x000071AC
		// (set) Token: 0x06000A08 RID: 2568 RVA: 0x00008FB4 File Offset: 0x000071B4
		public int Port { get; set; }

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06000A09 RID: 2569 RVA: 0x00008FBD File Offset: 0x000071BD
		// (set) Token: 0x06000A0A RID: 2570 RVA: 0x00008FC5 File Offset: 0x000071C5
		public int State { get; set; }

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06000A0B RID: 2571 RVA: 0x00008FCE File Offset: 0x000071CE
		// (set) Token: 0x06000A0C RID: 2572 RVA: 0x00008FD6 File Offset: 0x000071D6
		public int Online { get; set; }

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06000A0D RID: 2573 RVA: 0x00008FDF File Offset: 0x000071DF
		// (set) Token: 0x06000A0E RID: 2574 RVA: 0x00008FE7 File Offset: 0x000071E7
		public int Total { get; set; }

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06000A0F RID: 2575 RVA: 0x00008FF0 File Offset: 0x000071F0
		// (set) Token: 0x06000A10 RID: 2576 RVA: 0x00008FF8 File Offset: 0x000071F8
		public int Room { get; set; }

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06000A11 RID: 2577 RVA: 0x00009001 File Offset: 0x00007201
		// (set) Token: 0x06000A12 RID: 2578 RVA: 0x00009009 File Offset: 0x00007209
		public string Remark { get; set; }

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06000A13 RID: 2579 RVA: 0x00009012 File Offset: 0x00007212
		// (set) Token: 0x06000A14 RID: 2580 RVA: 0x0000901A File Offset: 0x0000721A
		public string RSA { get; set; }

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06000A15 RID: 2581 RVA: 0x00009023 File Offset: 0x00007223
		// (set) Token: 0x06000A16 RID: 2582 RVA: 0x0000902B File Offset: 0x0000722B
		public int MustLevel { get; set; }

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06000A17 RID: 2583 RVA: 0x00009034 File Offset: 0x00007234
		// (set) Token: 0x06000A18 RID: 2584 RVA: 0x0000903C File Offset: 0x0000723C
		public int LowestLevel { get; set; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06000A19 RID: 2585 RVA: 0x00009045 File Offset: 0x00007245
		// (set) Token: 0x06000A1A RID: 2586 RVA: 0x0000904D File Offset: 0x0000724D
		public bool NewerServer { get; set; }
	}
}
