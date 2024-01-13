using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200005F RID: 95
	public class ServerMapInfo
	{
		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06000A1C RID: 2588 RVA: 0x0000905E File Offset: 0x0000725E
		// (set) Token: 0x06000A1D RID: 2589 RVA: 0x00009066 File Offset: 0x00007266
		public int ServerID { get; set; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06000A1E RID: 2590 RVA: 0x0000906F File Offset: 0x0000726F
		// (set) Token: 0x06000A1F RID: 2591 RVA: 0x00009077 File Offset: 0x00007277
		public string OpenMap { get; set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06000A20 RID: 2592 RVA: 0x00009080 File Offset: 0x00007280
		// (set) Token: 0x06000A21 RID: 2593 RVA: 0x00009088 File Offset: 0x00007288
		public int IsSpecial { get; set; }
	}
}
