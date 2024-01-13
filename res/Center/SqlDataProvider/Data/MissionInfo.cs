using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000045 RID: 69
	public class MissionInfo
	{
		// Token: 0x17000312 RID: 786
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x000062A0 File Offset: 0x000044A0
		// (set) Token: 0x0600066F RID: 1647 RVA: 0x000062A8 File Offset: 0x000044A8
		public int Id
		{
			get
			{
				return this.m_id;
			}
			set
			{
				this.m_id = value;
			}
		}

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x000062B1 File Offset: 0x000044B1
		// (set) Token: 0x06000671 RID: 1649 RVA: 0x000062B9 File Offset: 0x000044B9
		public string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				this.m_name = value;
			}
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x000062C2 File Offset: 0x000044C2
		// (set) Token: 0x06000673 RID: 1651 RVA: 0x000062CA File Offset: 0x000044CA
		public int TotalCount
		{
			get
			{
				return this.m_totalCount;
			}
			set
			{
				this.m_totalCount = value;
			}
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x000062D3 File Offset: 0x000044D3
		// (set) Token: 0x06000675 RID: 1653 RVA: 0x000062DB File Offset: 0x000044DB
		public int TotalTurn
		{
			get
			{
				return this.m_totalTurn;
			}
			set
			{
				this.m_totalTurn = value;
			}
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000676 RID: 1654 RVA: 0x000062E4 File Offset: 0x000044E4
		// (set) Token: 0x06000677 RID: 1655 RVA: 0x000062EC File Offset: 0x000044EC
		public int IncrementDelay
		{
			get
			{
				return this.m_incrementDelay;
			}
			set
			{
				this.m_incrementDelay = value;
			}
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x000062F5 File Offset: 0x000044F5
		// (set) Token: 0x06000679 RID: 1657 RVA: 0x000062FD File Offset: 0x000044FD
		public int Delay
		{
			get
			{
				return this.m_delay;
			}
			set
			{
				this.m_delay = value;
			}
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x0600067A RID: 1658 RVA: 0x00006306 File Offset: 0x00004506
		// (set) Token: 0x0600067B RID: 1659 RVA: 0x0000630E File Offset: 0x0000450E
		public string Script
		{
			get
			{
				return this.m_script;
			}
			set
			{
				this.m_script = value;
			}
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x0600067C RID: 1660 RVA: 0x00006317 File Offset: 0x00004517
		// (set) Token: 0x0600067D RID: 1661 RVA: 0x0000631F File Offset: 0x0000451F
		public string Success
		{
			get
			{
				return this.m_success;
			}
			set
			{
				this.m_success = value;
			}
		}

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x0600067E RID: 1662 RVA: 0x00006328 File Offset: 0x00004528
		// (set) Token: 0x0600067F RID: 1663 RVA: 0x00006330 File Offset: 0x00004530
		public string Failure
		{
			get
			{
				return this.m_failure;
			}
			set
			{
				this.m_failure = value;
			}
		}

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06000680 RID: 1664 RVA: 0x00006339 File Offset: 0x00004539
		// (set) Token: 0x06000681 RID: 1665 RVA: 0x00006341 File Offset: 0x00004541
		public string Description
		{
			get
			{
				return this.m_description;
			}
			set
			{
				this.m_description = value;
			}
		}

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000682 RID: 1666 RVA: 0x0000634A File Offset: 0x0000454A
		// (set) Token: 0x06000683 RID: 1667 RVA: 0x00006352 File Offset: 0x00004552
		public string Title
		{
			get
			{
				return this.m_title;
			}
			set
			{
				this.m_title = value;
			}
		}

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x0000635B File Offset: 0x0000455B
		// (set) Token: 0x06000685 RID: 1669 RVA: 0x00006363 File Offset: 0x00004563
		public int Param1
		{
			get
			{
				return this.m_param1;
			}
			set
			{
				this.m_param1 = value;
			}
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000686 RID: 1670 RVA: 0x0000636C File Offset: 0x0000456C
		// (set) Token: 0x06000687 RID: 1671 RVA: 0x00006374 File Offset: 0x00004574
		public int Param2
		{
			get
			{
				return this.m_param2;
			}
			set
			{
				this.m_param2 = value;
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000688 RID: 1672 RVA: 0x0000637D File Offset: 0x0000457D
		// (set) Token: 0x06000689 RID: 1673 RVA: 0x00006385 File Offset: 0x00004585
		public int Param3
		{
			get
			{
				return this.m_param3;
			}
			set
			{
				this.m_param3 = value;
			}
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x0600068A RID: 1674 RVA: 0x0000638E File Offset: 0x0000458E
		// (set) Token: 0x0600068B RID: 1675 RVA: 0x00006396 File Offset: 0x00004596
		public int Param4
		{
			get
			{
				return this.m_param4;
			}
			set
			{
				this.m_param4 = value;
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x0600068C RID: 1676 RVA: 0x0000639F File Offset: 0x0000459F
		// (set) Token: 0x0600068D RID: 1677 RVA: 0x000063A7 File Offset: 0x000045A7
		public int TakeCard
		{
			get
			{
				return this.m_takeCard;
			}
			set
			{
				this.m_takeCard = value;
			}
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x0600068E RID: 1678 RVA: 0x000063B0 File Offset: 0x000045B0
		// (set) Token: 0x0600068F RID: 1679 RVA: 0x000063B8 File Offset: 0x000045B8
		public string Pic { get; set; }

		// Token: 0x06000690 RID: 1680 RVA: 0x000063C1 File Offset: 0x000045C1
		public MissionInfo()
		{
			this.m_param1 = -1;
			this.m_param2 = -1;
			this.m_param3 = -1;
			this.m_param4 = -1;
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x000063E8 File Offset: 0x000045E8
		public MissionInfo(int id, string name, string key, string description, int totalCount, int totalTurn, int initDelay, int delay, string title, int param1, int param2, int takeCard)
		{
			this.m_id = id;
			this.m_name = name;
			this.m_description = description;
			this.m_failure = key;
			this.m_totalCount = totalCount;
			this.m_totalTurn = totalTurn;
			this.m_incrementDelay = initDelay;
			this.m_delay = delay;
			this.m_title = title;
			this.m_param1 = param1;
			this.m_param2 = param2;
			this.m_takeCard = takeCard;
			this.m_param3 = -1;
			this.m_param4 = -1;
		}

		// Token: 0x0400039A RID: 922
		private int m_id;

		// Token: 0x0400039B RID: 923
		private string m_name;

		// Token: 0x0400039C RID: 924
		private int m_totalCount;

		// Token: 0x0400039D RID: 925
		private int m_totalTurn;

		// Token: 0x0400039E RID: 926
		private int m_incrementDelay;

		// Token: 0x0400039F RID: 927
		private int m_delay;

		// Token: 0x040003A0 RID: 928
		private string m_script;

		// Token: 0x040003A1 RID: 929
		private string m_failure;

		// Token: 0x040003A2 RID: 930
		private string m_success;

		// Token: 0x040003A3 RID: 931
		private string m_title;

		// Token: 0x040003A4 RID: 932
		private int m_param1;

		// Token: 0x040003A5 RID: 933
		private int m_param2;

		// Token: 0x040003A6 RID: 934
		private int m_param3;

		// Token: 0x040003A7 RID: 935
		private int m_param4;

		// Token: 0x040003A8 RID: 936
		private int m_takeCard;

		// Token: 0x040003A9 RID: 937
		private string m_description;
	}
}
