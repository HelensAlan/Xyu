using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200003A RID: 58
	public class LogFight
	{
		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x000056D8 File Offset: 0x000038D8
		// (set) Token: 0x06000529 RID: 1321 RVA: 0x000056E0 File Offset: 0x000038E0
		public int ApplicationId { get; set; }

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x000056E9 File Offset: 0x000038E9
		// (set) Token: 0x0600052B RID: 1323 RVA: 0x000056F1 File Offset: 0x000038F1
		public int SubId { get; set; }

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x0600052C RID: 1324 RVA: 0x000056FA File Offset: 0x000038FA
		// (set) Token: 0x0600052D RID: 1325 RVA: 0x00005702 File Offset: 0x00003902
		public int LineId { get; set; }

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x0600052E RID: 1326 RVA: 0x0000570B File Offset: 0x0000390B
		// (set) Token: 0x0600052F RID: 1327 RVA: 0x00005713 File Offset: 0x00003913
		public int RoomType { get; set; }

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000530 RID: 1328 RVA: 0x0000571C File Offset: 0x0000391C
		// (set) Token: 0x06000531 RID: 1329 RVA: 0x00005724 File Offset: 0x00003924
		public int FightType { get; set; }

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000532 RID: 1330 RVA: 0x0000572D File Offset: 0x0000392D
		// (set) Token: 0x06000533 RID: 1331 RVA: 0x00005735 File Offset: 0x00003935
		public DateTime PlayBegin { get; set; }

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x0000573E File Offset: 0x0000393E
		// (set) Token: 0x06000535 RID: 1333 RVA: 0x00005746 File Offset: 0x00003946
		public DateTime PlayEnd { get; set; }

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x0000574F File Offset: 0x0000394F
		// (set) Token: 0x06000537 RID: 1335 RVA: 0x00005757 File Offset: 0x00003957
		public int UserCount { get; set; }

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x00005760 File Offset: 0x00003960
		// (set) Token: 0x06000539 RID: 1337 RVA: 0x00005768 File Offset: 0x00003968
		public int MapId { get; set; }

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x00005771 File Offset: 0x00003971
		// (set) Token: 0x0600053B RID: 1339 RVA: 0x00005779 File Offset: 0x00003979
		public string Users { get; set; }

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x00005782 File Offset: 0x00003982
		// (set) Token: 0x0600053D RID: 1341 RVA: 0x0000578A File Offset: 0x0000398A
		public string PlayResult { get; set; }
	}
}
