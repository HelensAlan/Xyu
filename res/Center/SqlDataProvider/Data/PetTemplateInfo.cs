using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200004F RID: 79
	public class PetTemplateInfo
	{
		// Token: 0x06000794 RID: 1940 RVA: 0x00007660 File Offset: 0x00005860
		public PetTemplateInfo()
		{
			this._TemplateID = -1;
			this._Name = "";
			this._KindID = -1;
			this._Description = "";
			this._Pic = "";
			this._RareLevel = -1;
			this._MP = -1;
			this._StarLevel = -1;
			this._GameAssetUrl = "";
			this._EvolutionID = -1;
			this._HighAgility = -1;
			this._HighAgilityGrow = -1;
			this._HighAttack = -1;
			this._HighAttackGrow = -1;
			this._HighBlood = -1;
			this._HighBloodGrow = -1;
			this._HighDamage = -1;
			this._HighDamageGrow = -1;
			this._HighDefence = -1;
			this._HighDefenceGrow = -1;
			this._HighGuard = -1;
			this._HighGuardGrow = -1;
			this._HighLuck = -1;
			this._HighLuckGrow = -1;
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000795 RID: 1941 RVA: 0x0000772B File Offset: 0x0000592B
		// (set) Token: 0x06000796 RID: 1942 RVA: 0x00007733 File Offset: 0x00005933
		public int TemplateID
		{
			get
			{
				return this._TemplateID;
			}
			set
			{
				this._TemplateID = value;
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000797 RID: 1943 RVA: 0x0000773C File Offset: 0x0000593C
		// (set) Token: 0x06000798 RID: 1944 RVA: 0x00007744 File Offset: 0x00005944
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

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000799 RID: 1945 RVA: 0x0000774D File Offset: 0x0000594D
		// (set) Token: 0x0600079A RID: 1946 RVA: 0x00007755 File Offset: 0x00005955
		public int KindID
		{
			get
			{
				return this._KindID;
			}
			set
			{
				this._KindID = value;
			}
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x0000775E File Offset: 0x0000595E
		// (set) Token: 0x0600079C RID: 1948 RVA: 0x00007766 File Offset: 0x00005966
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

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x0000776F File Offset: 0x0000596F
		// (set) Token: 0x0600079E RID: 1950 RVA: 0x00007777 File Offset: 0x00005977
		public string Pic
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

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x0600079F RID: 1951 RVA: 0x00007780 File Offset: 0x00005980
		// (set) Token: 0x060007A0 RID: 1952 RVA: 0x00007788 File Offset: 0x00005988
		public int RareLevel
		{
			get
			{
				return this._RareLevel;
			}
			set
			{
				this._RareLevel = value;
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x060007A1 RID: 1953 RVA: 0x00007791 File Offset: 0x00005991
		// (set) Token: 0x060007A2 RID: 1954 RVA: 0x00007799 File Offset: 0x00005999
		public int MP
		{
			get
			{
				return this._MP;
			}
			set
			{
				this._MP = value;
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x000077A2 File Offset: 0x000059A2
		// (set) Token: 0x060007A4 RID: 1956 RVA: 0x000077AA File Offset: 0x000059AA
		public int StarLevel
		{
			get
			{
				return this._StarLevel;
			}
			set
			{
				this._StarLevel = value;
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x060007A5 RID: 1957 RVA: 0x000077B3 File Offset: 0x000059B3
		// (set) Token: 0x060007A6 RID: 1958 RVA: 0x000077BB File Offset: 0x000059BB
		public string GameAssetUrl
		{
			get
			{
				return this._GameAssetUrl;
			}
			set
			{
				this._GameAssetUrl = value;
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x060007A7 RID: 1959 RVA: 0x000077C4 File Offset: 0x000059C4
		// (set) Token: 0x060007A8 RID: 1960 RVA: 0x000077CC File Offset: 0x000059CC
		public int EvolutionID
		{
			get
			{
				return this._EvolutionID;
			}
			set
			{
				this._EvolutionID = value;
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x060007A9 RID: 1961 RVA: 0x000077D5 File Offset: 0x000059D5
		// (set) Token: 0x060007AA RID: 1962 RVA: 0x000077DD File Offset: 0x000059DD
		public int HighAgility
		{
			get
			{
				return this._HighAgility;
			}
			set
			{
				this._HighAgility = value;
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x060007AB RID: 1963 RVA: 0x000077E6 File Offset: 0x000059E6
		// (set) Token: 0x060007AC RID: 1964 RVA: 0x000077EE File Offset: 0x000059EE
		public int HighAgilityGrow
		{
			get
			{
				return this._HighAgilityGrow;
			}
			set
			{
				this._HighAgilityGrow = value;
			}
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x060007AD RID: 1965 RVA: 0x000077F7 File Offset: 0x000059F7
		// (set) Token: 0x060007AE RID: 1966 RVA: 0x000077FF File Offset: 0x000059FF
		public int HighAttack
		{
			get
			{
				return this._HighAttack;
			}
			set
			{
				this._HighAttack = value;
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x060007AF RID: 1967 RVA: 0x00007808 File Offset: 0x00005A08
		// (set) Token: 0x060007B0 RID: 1968 RVA: 0x00007810 File Offset: 0x00005A10
		public int HighAttackGrow
		{
			get
			{
				return this._HighAttackGrow;
			}
			set
			{
				this._HighAttackGrow = value;
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x060007B1 RID: 1969 RVA: 0x00007819 File Offset: 0x00005A19
		// (set) Token: 0x060007B2 RID: 1970 RVA: 0x00007821 File Offset: 0x00005A21
		public int HighBlood
		{
			get
			{
				return this._HighBlood;
			}
			set
			{
				this._HighBlood = value;
			}
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x0000782A File Offset: 0x00005A2A
		// (set) Token: 0x060007B4 RID: 1972 RVA: 0x00007832 File Offset: 0x00005A32
		public int HighBloodGrow
		{
			get
			{
				return this._HighBloodGrow;
			}
			set
			{
				this._HighBloodGrow = value;
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x060007B5 RID: 1973 RVA: 0x0000783B File Offset: 0x00005A3B
		// (set) Token: 0x060007B6 RID: 1974 RVA: 0x00007843 File Offset: 0x00005A43
		public int HighDamage
		{
			get
			{
				return this._HighDamage;
			}
			set
			{
				this._HighDamage = value;
			}
		}

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x060007B7 RID: 1975 RVA: 0x0000784C File Offset: 0x00005A4C
		// (set) Token: 0x060007B8 RID: 1976 RVA: 0x00007854 File Offset: 0x00005A54
		public int HighDamageGrow
		{
			get
			{
				return this._HighDamageGrow;
			}
			set
			{
				this._HighDamageGrow = value;
			}
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x0000785D File Offset: 0x00005A5D
		// (set) Token: 0x060007BA RID: 1978 RVA: 0x00007865 File Offset: 0x00005A65
		public int HighDefence
		{
			get
			{
				return this._HighDefence;
			}
			set
			{
				this._HighDefence = value;
			}
		}

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x060007BB RID: 1979 RVA: 0x0000786E File Offset: 0x00005A6E
		// (set) Token: 0x060007BC RID: 1980 RVA: 0x00007876 File Offset: 0x00005A76
		public int HighDefenceGrow
		{
			get
			{
				return this._HighDefenceGrow;
			}
			set
			{
				this._HighDefenceGrow = value;
			}
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x060007BD RID: 1981 RVA: 0x0000787F File Offset: 0x00005A7F
		// (set) Token: 0x060007BE RID: 1982 RVA: 0x00007887 File Offset: 0x00005A87
		public int HighGuard
		{
			get
			{
				return this._HighGuard;
			}
			set
			{
				this._HighGuard = value;
			}
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x060007BF RID: 1983 RVA: 0x00007890 File Offset: 0x00005A90
		// (set) Token: 0x060007C0 RID: 1984 RVA: 0x00007898 File Offset: 0x00005A98
		public int HighGuardGrow
		{
			get
			{
				return this._HighGuardGrow;
			}
			set
			{
				this._HighGuardGrow = value;
			}
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x060007C1 RID: 1985 RVA: 0x000078A1 File Offset: 0x00005AA1
		// (set) Token: 0x060007C2 RID: 1986 RVA: 0x000078A9 File Offset: 0x00005AA9
		public int HighLuck
		{
			get
			{
				return this._HighLuck;
			}
			set
			{
				this._HighLuck = value;
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x060007C3 RID: 1987 RVA: 0x000078B2 File Offset: 0x00005AB2
		// (set) Token: 0x060007C4 RID: 1988 RVA: 0x000078BA File Offset: 0x00005ABA
		public int HighLuckGrow
		{
			get
			{
				return this._HighLuckGrow;
			}
			set
			{
				this._HighLuckGrow = value;
			}
		}

		// Token: 0x04000424 RID: 1060
		private int _TemplateID;

		// Token: 0x04000425 RID: 1061
		private string _Name;

		// Token: 0x04000426 RID: 1062
		private int _KindID;

		// Token: 0x04000427 RID: 1063
		private string _Description;

		// Token: 0x04000428 RID: 1064
		private string _Pic;

		// Token: 0x04000429 RID: 1065
		private int _RareLevel;

		// Token: 0x0400042A RID: 1066
		private int _MP;

		// Token: 0x0400042B RID: 1067
		private int _StarLevel;

		// Token: 0x0400042C RID: 1068
		private string _GameAssetUrl;

		// Token: 0x0400042D RID: 1069
		private int _EvolutionID;

		// Token: 0x0400042E RID: 1070
		private int _HighAgility;

		// Token: 0x0400042F RID: 1071
		private int _HighAgilityGrow;

		// Token: 0x04000430 RID: 1072
		private int _HighAttack;

		// Token: 0x04000431 RID: 1073
		private int _HighAttackGrow;

		// Token: 0x04000432 RID: 1074
		private int _HighBlood;

		// Token: 0x04000433 RID: 1075
		private int _HighBloodGrow;

		// Token: 0x04000434 RID: 1076
		private int _HighDamage;

		// Token: 0x04000435 RID: 1077
		private int _HighDamageGrow;

		// Token: 0x04000436 RID: 1078
		private int _HighDefence;

		// Token: 0x04000437 RID: 1079
		private int _HighDefenceGrow;

		// Token: 0x04000438 RID: 1080
		private int _HighGuard;

		// Token: 0x04000439 RID: 1081
		private int _HighGuardGrow;

		// Token: 0x0400043A RID: 1082
		private int _HighLuck;

		// Token: 0x0400043B RID: 1083
		private int _HighLuckGrow;
	}
}
