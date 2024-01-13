using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200004C RID: 76
	public class PetSkillInfo
	{
		// Token: 0x0600075D RID: 1885 RVA: 0x000073C8 File Offset: 0x000055C8
		public PetSkillInfo()
		{
			this._ID = -1;
			this._Name = "";
			this._ElementIDs = "";
			this._Description = "";
			this._BallType = -1;
			this._NewBallID = -1;
			this._CostMP = -1;
			this._Pic = -1;
			this._Action = "";
			this._EffectPic = "";
			this._Delay = -1;
			this._ColdDown = -1;
			this._GameType = -1;
			this._Probability = -1;
			this._Damage = -1;
			this._DamageCrit = -1;
		}

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x0600075E RID: 1886 RVA: 0x0000745F File Offset: 0x0000565F
		// (set) Token: 0x0600075F RID: 1887 RVA: 0x00007467 File Offset: 0x00005667
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				this._ID = value;
			}
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000760 RID: 1888 RVA: 0x00007470 File Offset: 0x00005670
		// (set) Token: 0x06000761 RID: 1889 RVA: 0x00007478 File Offset: 0x00005678
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
			}
		}

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000762 RID: 1890 RVA: 0x00007481 File Offset: 0x00005681
		// (set) Token: 0x06000763 RID: 1891 RVA: 0x00007489 File Offset: 0x00005689
		public string ElementIDs
		{
			get
			{
				return this._ElementIDs;
			}
			set
			{
				this._ElementIDs = value;
			}
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000764 RID: 1892 RVA: 0x00007492 File Offset: 0x00005692
		// (set) Token: 0x06000765 RID: 1893 RVA: 0x0000749A File Offset: 0x0000569A
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				this._Description = value;
			}
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000766 RID: 1894 RVA: 0x000074A3 File Offset: 0x000056A3
		// (set) Token: 0x06000767 RID: 1895 RVA: 0x000074AB File Offset: 0x000056AB
		public int BallType
		{
			get
			{
				return this._BallType;
			}
			set
			{
				this._BallType = value;
			}
		}

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000768 RID: 1896 RVA: 0x000074B4 File Offset: 0x000056B4
		// (set) Token: 0x06000769 RID: 1897 RVA: 0x000074BC File Offset: 0x000056BC
		public int NewBallID
		{
			get
			{
				return this._NewBallID;
			}
			set
			{
				this._NewBallID = value;
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x0600076A RID: 1898 RVA: 0x000074C5 File Offset: 0x000056C5
		// (set) Token: 0x0600076B RID: 1899 RVA: 0x000074CD File Offset: 0x000056CD
		public int CostMP
		{
			get
			{
				return this._CostMP;
			}
			set
			{
				this._CostMP = value;
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x0600076C RID: 1900 RVA: 0x000074D6 File Offset: 0x000056D6
		// (set) Token: 0x0600076D RID: 1901 RVA: 0x000074DE File Offset: 0x000056DE
		public int Pic
		{
			get
			{
				return this._Pic;
			}
			set
			{
				this._Pic = value;
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x0600076E RID: 1902 RVA: 0x000074E7 File Offset: 0x000056E7
		// (set) Token: 0x0600076F RID: 1903 RVA: 0x000074EF File Offset: 0x000056EF
		public string Action
		{
			get
			{
				return this._Action;
			}
			set
			{
				this._Action = value;
			}
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x000074F8 File Offset: 0x000056F8
		// (set) Token: 0x06000771 RID: 1905 RVA: 0x00007500 File Offset: 0x00005700
		public string EffectPic
		{
			get
			{
				return this._EffectPic;
			}
			set
			{
				this._EffectPic = value;
			}
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x00007509 File Offset: 0x00005709
		// (set) Token: 0x06000773 RID: 1907 RVA: 0x00007511 File Offset: 0x00005711
		public int Delay
		{
			get
			{
				return this._Delay;
			}
			set
			{
				this._Delay = value;
			}
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x0000751A File Offset: 0x0000571A
		// (set) Token: 0x06000775 RID: 1909 RVA: 0x00007522 File Offset: 0x00005722
		public int ColdDown
		{
			get
			{
				return this._ColdDown;
			}
			set
			{
				this._ColdDown = value;
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000776 RID: 1910 RVA: 0x0000752B File Offset: 0x0000572B
		// (set) Token: 0x06000777 RID: 1911 RVA: 0x00007533 File Offset: 0x00005733
		public int GameType
		{
			get
			{
				return this._GameType;
			}
			set
			{
				this._GameType = value;
			}
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x0000753C File Offset: 0x0000573C
		// (set) Token: 0x06000779 RID: 1913 RVA: 0x00007544 File Offset: 0x00005744
		public int Probability
		{
			get
			{
				return this._Probability;
			}
			set
			{
				this._Probability = value;
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x0600077A RID: 1914 RVA: 0x0000754D File Offset: 0x0000574D
		// (set) Token: 0x0600077B RID: 1915 RVA: 0x00007555 File Offset: 0x00005755
		public int Damage
		{
			get
			{
				return this._Damage;
			}
			set
			{
				this._Damage = value;
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x0000755E File Offset: 0x0000575E
		// (set) Token: 0x0600077D RID: 1917 RVA: 0x00007566 File Offset: 0x00005766
		public int DamageCrit
		{
			get
			{
				return this._DamageCrit;
			}
			set
			{
				this._DamageCrit = value;
			}
		}

		// Token: 0x0400040A RID: 1034
		private int _ID;

		// Token: 0x0400040B RID: 1035
		private string _Name;

		// Token: 0x0400040C RID: 1036
		private string _ElementIDs;

		// Token: 0x0400040D RID: 1037
		private string _Description;

		// Token: 0x0400040E RID: 1038
		private int _BallType;

		// Token: 0x0400040F RID: 1039
		private int _NewBallID;

		// Token: 0x04000410 RID: 1040
		private int _CostMP;

		// Token: 0x04000411 RID: 1041
		private int _Pic;

		// Token: 0x04000412 RID: 1042
		private string _Action;

		// Token: 0x04000413 RID: 1043
		private string _EffectPic;

		// Token: 0x04000414 RID: 1044
		private int _Delay;

		// Token: 0x04000415 RID: 1045
		private int _ColdDown;

		// Token: 0x04000416 RID: 1046
		private int _GameType;

		// Token: 0x04000417 RID: 1047
		private int _Probability;

		// Token: 0x04000418 RID: 1048
		private int _Damage;

		// Token: 0x04000419 RID: 1049
		private int _DamageCrit;
	}
}
