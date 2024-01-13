using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000011 RID: 17
	public class BoxInfo
	{
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000121 RID: 289 RVA: 0x000029F5 File Offset: 0x00000BF5
		// (set) Token: 0x06000122 RID: 290 RVA: 0x000029FD File Offset: 0x00000BFD
		public int ID { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00002A06 File Offset: 0x00000C06
		// (set) Token: 0x06000124 RID: 292 RVA: 0x00002A0E File Offset: 0x00000C0E
		public int Type { get; set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00002A17 File Offset: 0x00000C17
		// (set) Token: 0x06000126 RID: 294 RVA: 0x00002A1F File Offset: 0x00000C1F
		public int Level { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00002A28 File Offset: 0x00000C28
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00002A30 File Offset: 0x00000C30
		public int Condition { get; set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00002A39 File Offset: 0x00000C39
		// (set) Token: 0x0600012A RID: 298 RVA: 0x00002A41 File Offset: 0x00000C41
		public string Template { get; set; }
	}
}
