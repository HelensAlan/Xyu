using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200000F RID: 15
	public class BigBugleInfo
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00002908 File Offset: 0x00000B08
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00002910 File Offset: 0x00000B10
		public int ID { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00002919 File Offset: 0x00000B19
		// (set) Token: 0x06000108 RID: 264 RVA: 0x00002921 File Offset: 0x00000B21
		public int UserID { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000109 RID: 265 RVA: 0x0000292A File Offset: 0x00000B2A
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00002932 File Offset: 0x00000B32
		public int AreaID { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600010B RID: 267 RVA: 0x0000293B File Offset: 0x00000B3B
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00002943 File Offset: 0x00000B43
		public string NickName { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600010D RID: 269 RVA: 0x0000294C File Offset: 0x00000B4C
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00002954 File Offset: 0x00000B54
		public string Message { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600010F RID: 271 RVA: 0x0000295D File Offset: 0x00000B5D
		// (set) Token: 0x06000110 RID: 272 RVA: 0x00002965 File Offset: 0x00000B65
		public bool State { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000111 RID: 273 RVA: 0x0000296E File Offset: 0x00000B6E
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00002976 File Offset: 0x00000B76
		public string IP { get; set; }
	}
}
