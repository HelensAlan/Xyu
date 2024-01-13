using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000046 RID: 70
	public class NpcInfo
	{
		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000692 RID: 1682 RVA: 0x00006466 File Offset: 0x00004666
		// (set) Token: 0x06000693 RID: 1683 RVA: 0x0000646E File Offset: 0x0000466E
		public int ID { get; set; }

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000694 RID: 1684 RVA: 0x00006477 File Offset: 0x00004677
		// (set) Token: 0x06000695 RID: 1685 RVA: 0x0000647F File Offset: 0x0000467F
		public string Name { get; set; }

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000696 RID: 1686 RVA: 0x00006488 File Offset: 0x00004688
		// (set) Token: 0x06000697 RID: 1687 RVA: 0x00006490 File Offset: 0x00004690
		public int Level { get; set; }

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000698 RID: 1688 RVA: 0x00006499 File Offset: 0x00004699
		// (set) Token: 0x06000699 RID: 1689 RVA: 0x000064A1 File Offset: 0x000046A1
		public int Camp { get; set; }

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x0600069A RID: 1690 RVA: 0x000064AA File Offset: 0x000046AA
		// (set) Token: 0x0600069B RID: 1691 RVA: 0x000064B2 File Offset: 0x000046B2
		public int Type { get; set; }

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x0600069C RID: 1692 RVA: 0x000064BB File Offset: 0x000046BB
		// (set) Token: 0x0600069D RID: 1693 RVA: 0x000064C3 File Offset: 0x000046C3
		public int X { get; set; }

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x000064CC File Offset: 0x000046CC
		// (set) Token: 0x0600069F RID: 1695 RVA: 0x000064D4 File Offset: 0x000046D4
		public int Y { get; set; }

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x060006A0 RID: 1696 RVA: 0x000064DD File Offset: 0x000046DD
		// (set) Token: 0x060006A1 RID: 1697 RVA: 0x000064E5 File Offset: 0x000046E5
		public int Width { get; set; }

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x060006A2 RID: 1698 RVA: 0x000064EE File Offset: 0x000046EE
		// (set) Token: 0x060006A3 RID: 1699 RVA: 0x000064F6 File Offset: 0x000046F6
		public int Height { get; set; }

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x060006A4 RID: 1700 RVA: 0x000064FF File Offset: 0x000046FF
		// (set) Token: 0x060006A5 RID: 1701 RVA: 0x00006507 File Offset: 0x00004707
		public int Blood { get; set; }

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x060006A6 RID: 1702 RVA: 0x00006510 File Offset: 0x00004710
		// (set) Token: 0x060006A7 RID: 1703 RVA: 0x00006518 File Offset: 0x00004718
		public int MoveMin { get; set; }

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x060006A8 RID: 1704 RVA: 0x00006521 File Offset: 0x00004721
		// (set) Token: 0x060006A9 RID: 1705 RVA: 0x00006529 File Offset: 0x00004729
		public int MoveMax { get; set; }

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x060006AA RID: 1706 RVA: 0x00006532 File Offset: 0x00004732
		// (set) Token: 0x060006AB RID: 1707 RVA: 0x0000653A File Offset: 0x0000473A
		public int BaseDamage { get; set; }

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x060006AC RID: 1708 RVA: 0x00006543 File Offset: 0x00004743
		// (set) Token: 0x060006AD RID: 1709 RVA: 0x0000654B File Offset: 0x0000474B
		public int BaseGuard { get; set; }

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x060006AE RID: 1710 RVA: 0x00006554 File Offset: 0x00004754
		// (set) Token: 0x060006AF RID: 1711 RVA: 0x0000655C File Offset: 0x0000475C
		public int Attack { get; set; }

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x060006B0 RID: 1712 RVA: 0x00006565 File Offset: 0x00004765
		// (set) Token: 0x060006B1 RID: 1713 RVA: 0x0000656D File Offset: 0x0000476D
		public int Defence { get; set; }

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x060006B2 RID: 1714 RVA: 0x00006576 File Offset: 0x00004776
		// (set) Token: 0x060006B3 RID: 1715 RVA: 0x0000657E File Offset: 0x0000477E
		public int Agility { get; set; }

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x060006B4 RID: 1716 RVA: 0x00006587 File Offset: 0x00004787
		// (set) Token: 0x060006B5 RID: 1717 RVA: 0x0000658F File Offset: 0x0000478F
		public int Lucky { get; set; }

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x060006B6 RID: 1718 RVA: 0x00006598 File Offset: 0x00004798
		// (set) Token: 0x060006B7 RID: 1719 RVA: 0x000065A0 File Offset: 0x000047A0
		public string ModelID { get; set; }

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x060006B8 RID: 1720 RVA: 0x000065A9 File Offset: 0x000047A9
		// (set) Token: 0x060006B9 RID: 1721 RVA: 0x000065B1 File Offset: 0x000047B1
		public string ResourcesPath { get; set; }

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x060006BA RID: 1722 RVA: 0x000065BA File Offset: 0x000047BA
		// (set) Token: 0x060006BB RID: 1723 RVA: 0x000065C2 File Offset: 0x000047C2
		public int DropRate { get; set; }

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x060006BC RID: 1724 RVA: 0x000065CB File Offset: 0x000047CB
		// (set) Token: 0x060006BD RID: 1725 RVA: 0x000065D3 File Offset: 0x000047D3
		public int Experience { get; set; }

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x060006BE RID: 1726 RVA: 0x000065DC File Offset: 0x000047DC
		// (set) Token: 0x060006BF RID: 1727 RVA: 0x000065E4 File Offset: 0x000047E4
		public int Delay { get; set; }

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x060006C0 RID: 1728 RVA: 0x000065ED File Offset: 0x000047ED
		// (set) Token: 0x060006C1 RID: 1729 RVA: 0x000065F5 File Offset: 0x000047F5
		public int Immunity { get; set; }

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x060006C2 RID: 1730 RVA: 0x000065FE File Offset: 0x000047FE
		// (set) Token: 0x060006C3 RID: 1731 RVA: 0x00006606 File Offset: 0x00004806
		public int Alert { get; set; }

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x060006C4 RID: 1732 RVA: 0x0000660F File Offset: 0x0000480F
		// (set) Token: 0x060006C5 RID: 1733 RVA: 0x00006617 File Offset: 0x00004817
		public int Range { get; set; }

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x060006C6 RID: 1734 RVA: 0x00006620 File Offset: 0x00004820
		// (set) Token: 0x060006C7 RID: 1735 RVA: 0x00006628 File Offset: 0x00004828
		public int Preserve { get; set; }

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x060006C8 RID: 1736 RVA: 0x00006631 File Offset: 0x00004831
		// (set) Token: 0x060006C9 RID: 1737 RVA: 0x00006639 File Offset: 0x00004839
		public string Script { get; set; }

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x060006CA RID: 1738 RVA: 0x00006642 File Offset: 0x00004842
		// (set) Token: 0x060006CB RID: 1739 RVA: 0x0000664A File Offset: 0x0000484A
		public int Probability { get; set; }

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x060006CC RID: 1740 RVA: 0x00006653 File Offset: 0x00004853
		// (set) Token: 0x060006CD RID: 1741 RVA: 0x0000665B File Offset: 0x0000485B
		public int CurrentBallId { get; set; }

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x00006664 File Offset: 0x00004864
		// (set) Token: 0x060006CF RID: 1743 RVA: 0x0000666C File Offset: 0x0000486C
		public int FireX { get; set; }

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x060006D0 RID: 1744 RVA: 0x00006675 File Offset: 0x00004875
		// (set) Token: 0x060006D1 RID: 1745 RVA: 0x0000667D File Offset: 0x0000487D
		public int FireY { get; set; }

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x060006D2 RID: 1746 RVA: 0x00006686 File Offset: 0x00004886
		// (set) Token: 0x060006D3 RID: 1747 RVA: 0x0000668E File Offset: 0x0000488E
		public int DropId { get; set; }

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x060006D4 RID: 1748 RVA: 0x00006697 File Offset: 0x00004897
		// (set) Token: 0x060006D5 RID: 1749 RVA: 0x0000669F File Offset: 0x0000489F
		public int MaxBeatDis { get; set; }

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x060006D6 RID: 1750 RVA: 0x000066A8 File Offset: 0x000048A8
		// (set) Token: 0x060006D7 RID: 1751 RVA: 0x000066B0 File Offset: 0x000048B0
		public int Speed { get; set; }
	}
}
