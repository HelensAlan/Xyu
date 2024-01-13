using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000058 RID: 88
	public class RateInfo
	{
		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06000983 RID: 2435 RVA: 0x00008B37 File Offset: 0x00006D37
		// (set) Token: 0x06000984 RID: 2436 RVA: 0x00008B3F File Offset: 0x00006D3F
		public int ServerID { get; set; }

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06000985 RID: 2437 RVA: 0x00008B48 File Offset: 0x00006D48
		// (set) Token: 0x06000986 RID: 2438 RVA: 0x00008B50 File Offset: 0x00006D50
		public int Type { get; set; }

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06000987 RID: 2439 RVA: 0x00008B59 File Offset: 0x00006D59
		// (set) Token: 0x06000988 RID: 2440 RVA: 0x00008B61 File Offset: 0x00006D61
		public float Rate { get; set; }

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06000989 RID: 2441 RVA: 0x00008B6A File Offset: 0x00006D6A
		// (set) Token: 0x0600098A RID: 2442 RVA: 0x00008B72 File Offset: 0x00006D72
		public DateTime BeginDay { get; set; }

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x0600098B RID: 2443 RVA: 0x00008B7B File Offset: 0x00006D7B
		// (set) Token: 0x0600098C RID: 2444 RVA: 0x00008B83 File Offset: 0x00006D83
		public DateTime EndDay { get; set; }

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x0600098D RID: 2445 RVA: 0x00008B8C File Offset: 0x00006D8C
		// (set) Token: 0x0600098E RID: 2446 RVA: 0x00008B94 File Offset: 0x00006D94
		public DateTime BeginTime { get; set; }

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x0600098F RID: 2447 RVA: 0x00008B9D File Offset: 0x00006D9D
		// (set) Token: 0x06000990 RID: 2448 RVA: 0x00008BA5 File Offset: 0x00006DA5
		public DateTime EndTime { get; set; }
	}
}
