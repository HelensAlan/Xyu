using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000007 RID: 7
	public class AchievementInfo : DataObject
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000021AD File Offset: 0x000003AD
		// (set) Token: 0x06000028 RID: 40 RVA: 0x000021B5 File Offset: 0x000003B5
		public int ID { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000021BE File Offset: 0x000003BE
		// (set) Token: 0x0600002A RID: 42 RVA: 0x000021C6 File Offset: 0x000003C6
		public int PlaceID { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000021CF File Offset: 0x000003CF
		// (set) Token: 0x0600002C RID: 44 RVA: 0x000021D7 File Offset: 0x000003D7
		public string Title { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000021E0 File Offset: 0x000003E0
		// (set) Token: 0x0600002E RID: 46 RVA: 0x000021E8 File Offset: 0x000003E8
		public string Detail { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000021F1 File Offset: 0x000003F1
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000021F9 File Offset: 0x000003F9
		public int NeedMinLevel { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002202 File Offset: 0x00000402
		// (set) Token: 0x06000032 RID: 50 RVA: 0x0000220A File Offset: 0x0000040A
		public int NeedMaxLevel { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00002213 File Offset: 0x00000413
		// (set) Token: 0x06000034 RID: 52 RVA: 0x0000221B File Offset: 0x0000041B
		public string PreAchievementID { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002224 File Offset: 0x00000424
		// (set) Token: 0x06000036 RID: 54 RVA: 0x0000222C File Offset: 0x0000042C
		public int IsOther { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002235 File Offset: 0x00000435
		// (set) Token: 0x06000038 RID: 56 RVA: 0x0000223D File Offset: 0x0000043D
		public int AchievementType { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002246 File Offset: 0x00000446
		// (set) Token: 0x0600003A RID: 58 RVA: 0x0000224E File Offset: 0x0000044E
		public bool CanHide { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002257 File Offset: 0x00000457
		// (set) Token: 0x0600003C RID: 60 RVA: 0x0000225F File Offset: 0x0000045F
		public DateTime StartDate { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002268 File Offset: 0x00000468
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00002270 File Offset: 0x00000470
		public DateTime EndDate { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002279 File Offset: 0x00000479
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002281 File Offset: 0x00000481
		public int AchievementPoint { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000041 RID: 65 RVA: 0x0000228A File Offset: 0x0000048A
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00002292 File Offset: 0x00000492
		public int PicID { get; set; }
	}
}
