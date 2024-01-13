using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000027 RID: 39
	public class DropInfo
	{
		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00003C7C File Offset: 0x00001E7C
		// (set) Token: 0x06000332 RID: 818 RVA: 0x00003C84 File Offset: 0x00001E84
		public int ID { get; set; }

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000333 RID: 819 RVA: 0x00003C8D File Offset: 0x00001E8D
		// (set) Token: 0x06000334 RID: 820 RVA: 0x00003C95 File Offset: 0x00001E95
		public int Time { get; set; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000335 RID: 821 RVA: 0x00003C9E File Offset: 0x00001E9E
		// (set) Token: 0x06000336 RID: 822 RVA: 0x00003CA6 File Offset: 0x00001EA6
		public int Count { get; set; }

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000337 RID: 823 RVA: 0x00003CAF File Offset: 0x00001EAF
		// (set) Token: 0x06000338 RID: 824 RVA: 0x00003CB7 File Offset: 0x00001EB7
		public int MaxCount { get; set; }

		// Token: 0x06000339 RID: 825 RVA: 0x00003CC0 File Offset: 0x00001EC0
		public DropInfo(int id, int time, int count, int maxCount)
		{
			this.ID = id;
			this.Time = time;
			this.Count = count;
			this.MaxCount = maxCount;
		}
	}
}
