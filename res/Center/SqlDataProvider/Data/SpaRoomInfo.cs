using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000064 RID: 100
	public class SpaRoomInfo
	{
		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06000A89 RID: 2697 RVA: 0x000093FA File Offset: 0x000075FA
		// (set) Token: 0x06000A8A RID: 2698 RVA: 0x00009402 File Offset: 0x00007602
		public int RoomID { get; set; }

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06000A8B RID: 2699 RVA: 0x0000940B File Offset: 0x0000760B
		// (set) Token: 0x06000A8C RID: 2700 RVA: 0x00009413 File Offset: 0x00007613
		public string RoomName { get; set; }

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06000A8D RID: 2701 RVA: 0x0000941C File Offset: 0x0000761C
		// (set) Token: 0x06000A8E RID: 2702 RVA: 0x00009424 File Offset: 0x00007624
		public int PlayerID { get; set; }

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x0000942D File Offset: 0x0000762D
		// (set) Token: 0x06000A90 RID: 2704 RVA: 0x00009435 File Offset: 0x00007635
		public string PlayerName { get; set; }

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06000A91 RID: 2705 RVA: 0x0000943E File Offset: 0x0000763E
		// (set) Token: 0x06000A92 RID: 2706 RVA: 0x00009446 File Offset: 0x00007646
		public string Pwd { get; set; }

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x06000A93 RID: 2707 RVA: 0x0000944F File Offset: 0x0000764F
		// (set) Token: 0x06000A94 RID: 2708 RVA: 0x00009457 File Offset: 0x00007657
		public int AvailTime { get; set; }

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06000A95 RID: 2709 RVA: 0x00009460 File Offset: 0x00007660
		// (set) Token: 0x06000A96 RID: 2710 RVA: 0x00009468 File Offset: 0x00007668
		public int MaxCount { get; set; }

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06000A97 RID: 2711 RVA: 0x00009471 File Offset: 0x00007671
		// (set) Token: 0x06000A98 RID: 2712 RVA: 0x00009479 File Offset: 0x00007679
		public int MapIndex { get; set; }

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06000A99 RID: 2713 RVA: 0x00009482 File Offset: 0x00007682
		// (set) Token: 0x06000A9A RID: 2714 RVA: 0x0000948A File Offset: 0x0000768A
		public DateTime BeginTime { get; set; }

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06000A9B RID: 2715 RVA: 0x00009493 File Offset: 0x00007693
		// (set) Token: 0x06000A9C RID: 2716 RVA: 0x0000949B File Offset: 0x0000769B
		public DateTime BreakTime { get; set; }

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06000A9D RID: 2717 RVA: 0x000094A4 File Offset: 0x000076A4
		// (set) Token: 0x06000A9E RID: 2718 RVA: 0x000094AC File Offset: 0x000076AC
		public string RoomIntroduction { get; set; }

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x06000A9F RID: 2719 RVA: 0x000094B5 File Offset: 0x000076B5
		// (set) Token: 0x06000AA0 RID: 2720 RVA: 0x000094BD File Offset: 0x000076BD
		public int RoomType { get; set; }

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06000AA1 RID: 2721 RVA: 0x000094C6 File Offset: 0x000076C6
		// (set) Token: 0x06000AA2 RID: 2722 RVA: 0x000094CE File Offset: 0x000076CE
		public int ServerID { get; set; }

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x000094D7 File Offset: 0x000076D7
		// (set) Token: 0x06000AA4 RID: 2724 RVA: 0x000094DF File Offset: 0x000076DF
		public int RoomNumber { get; set; }
	}
}
