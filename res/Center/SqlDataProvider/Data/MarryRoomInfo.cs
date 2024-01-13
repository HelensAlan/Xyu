using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000044 RID: 68
	public class MarryRoomInfo
	{
		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x00006155 File Offset: 0x00004355
		// (set) Token: 0x06000648 RID: 1608 RVA: 0x0000615D File Offset: 0x0000435D
		public int ID { get; set; }

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x00006166 File Offset: 0x00004366
		// (set) Token: 0x0600064A RID: 1610 RVA: 0x0000616E File Offset: 0x0000436E
		public string Name { get; set; }

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x0600064B RID: 1611 RVA: 0x00006177 File Offset: 0x00004377
		// (set) Token: 0x0600064C RID: 1612 RVA: 0x0000617F File Offset: 0x0000437F
		public int PlayerID { get; set; }

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x00006188 File Offset: 0x00004388
		// (set) Token: 0x0600064E RID: 1614 RVA: 0x00006190 File Offset: 0x00004390
		public string PlayerName { get; set; }

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x00006199 File Offset: 0x00004399
		// (set) Token: 0x06000650 RID: 1616 RVA: 0x000061A1 File Offset: 0x000043A1
		public int GroomID { get; set; }

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x000061AA File Offset: 0x000043AA
		// (set) Token: 0x06000652 RID: 1618 RVA: 0x000061B2 File Offset: 0x000043B2
		public string GroomName { get; set; }

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x000061BB File Offset: 0x000043BB
		// (set) Token: 0x06000654 RID: 1620 RVA: 0x000061C3 File Offset: 0x000043C3
		public int BrideID { get; set; }

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x000061CC File Offset: 0x000043CC
		// (set) Token: 0x06000656 RID: 1622 RVA: 0x000061D4 File Offset: 0x000043D4
		public string BrideName { get; set; }

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000657 RID: 1623 RVA: 0x000061DD File Offset: 0x000043DD
		// (set) Token: 0x06000658 RID: 1624 RVA: 0x000061E5 File Offset: 0x000043E5
		public string Pwd { get; set; }

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000659 RID: 1625 RVA: 0x000061EE File Offset: 0x000043EE
		// (set) Token: 0x0600065A RID: 1626 RVA: 0x000061F6 File Offset: 0x000043F6
		public int AvailTime { get; set; }

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x0600065B RID: 1627 RVA: 0x000061FF File Offset: 0x000043FF
		// (set) Token: 0x0600065C RID: 1628 RVA: 0x00006207 File Offset: 0x00004407
		public int MaxCount { get; set; }

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x00006210 File Offset: 0x00004410
		// (set) Token: 0x0600065E RID: 1630 RVA: 0x00006218 File Offset: 0x00004418
		public bool GuestInvite { get; set; }

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x0600065F RID: 1631 RVA: 0x00006221 File Offset: 0x00004421
		// (set) Token: 0x06000660 RID: 1632 RVA: 0x00006229 File Offset: 0x00004429
		public int MapIndex { get; set; }

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000661 RID: 1633 RVA: 0x00006232 File Offset: 0x00004432
		// (set) Token: 0x06000662 RID: 1634 RVA: 0x0000623A File Offset: 0x0000443A
		public DateTime BeginTime { get; set; }

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000663 RID: 1635 RVA: 0x00006243 File Offset: 0x00004443
		// (set) Token: 0x06000664 RID: 1636 RVA: 0x0000624B File Offset: 0x0000444B
		public DateTime BreakTime { get; set; }

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000665 RID: 1637 RVA: 0x00006254 File Offset: 0x00004454
		// (set) Token: 0x06000666 RID: 1638 RVA: 0x0000625C File Offset: 0x0000445C
		public string RoomIntroduction { get; set; }

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000667 RID: 1639 RVA: 0x00006265 File Offset: 0x00004465
		// (set) Token: 0x06000668 RID: 1640 RVA: 0x0000626D File Offset: 0x0000446D
		public int ServerID { get; set; }

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x00006276 File Offset: 0x00004476
		// (set) Token: 0x0600066A RID: 1642 RVA: 0x0000627E File Offset: 0x0000447E
		public bool IsHymeneal { get; set; }

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x0600066B RID: 1643 RVA: 0x00006287 File Offset: 0x00004487
		// (set) Token: 0x0600066C RID: 1644 RVA: 0x0000628F File Offset: 0x0000448F
		public bool IsGunsaluteUsed { get; set; }
	}
}
