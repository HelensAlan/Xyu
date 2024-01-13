using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000016 RID: 22
	public class CategoryInfo
	{
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00002D51 File Offset: 0x00000F51
		// (set) Token: 0x0600017D RID: 381 RVA: 0x00002D59 File Offset: 0x00000F59
		public int ID { get; set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00002D62 File Offset: 0x00000F62
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00002D6A File Offset: 0x00000F6A
		public string Name { get; set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000180 RID: 384 RVA: 0x00002D73 File Offset: 0x00000F73
		// (set) Token: 0x06000181 RID: 385 RVA: 0x00002D7B File Offset: 0x00000F7B
		public int Place { get; set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000182 RID: 386 RVA: 0x00002D84 File Offset: 0x00000F84
		// (set) Token: 0x06000183 RID: 387 RVA: 0x00002D8C File Offset: 0x00000F8C
		public string Remark { get; set; }
	}
}
