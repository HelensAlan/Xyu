using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000050 RID: 80
	public class PlayerInfo : DataObject
	{
		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x060007C5 RID: 1989 RVA: 0x000078C3 File Offset: 0x00005AC3
		// (set) Token: 0x060007C6 RID: 1990 RVA: 0x000078CB File Offset: 0x00005ACB
		public string AreaName
		{
			get
			{
				return this._areaName;
			}
			set
			{
				this._areaName = value;
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x060007C7 RID: 1991 RVA: 0x000078D4 File Offset: 0x00005AD4
		// (set) Token: 0x060007C8 RID: 1992 RVA: 0x000078DC File Offset: 0x00005ADC
		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x060007C9 RID: 1993 RVA: 0x000078EC File Offset: 0x00005AEC
		// (set) Token: 0x060007CA RID: 1994 RVA: 0x000078F4 File Offset: 0x00005AF4
		public string UserName
		{
			get
			{
				return this._userName;
			}
			set
			{
				this._userName = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x060007CB RID: 1995 RVA: 0x00007904 File Offset: 0x00005B04
		// (set) Token: 0x060007CC RID: 1996 RVA: 0x0000790C File Offset: 0x00005B0C
		public string NickName
		{
			get
			{
				return this._nickName;
			}
			set
			{
				this._nickName = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x060007CD RID: 1997 RVA: 0x0000791C File Offset: 0x00005B1C
		// (set) Token: 0x060007CE RID: 1998 RVA: 0x00007924 File Offset: 0x00005B24
		public bool Sex
		{
			get
			{
				return this._sex;
			}
			set
			{
				this._sex = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x060007CF RID: 1999 RVA: 0x00007934 File Offset: 0x00005B34
		// (set) Token: 0x060007D0 RID: 2000 RVA: 0x0000793C File Offset: 0x00005B3C
		public int Attack
		{
			get
			{
				return this._attack;
			}
			set
			{
				this._attack = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x060007D1 RID: 2001 RVA: 0x0000794C File Offset: 0x00005B4C
		// (set) Token: 0x060007D2 RID: 2002 RVA: 0x00007954 File Offset: 0x00005B54
		public int Defence
		{
			get
			{
				return this._defence;
			}
			set
			{
				this._defence = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x00007964 File Offset: 0x00005B64
		// (set) Token: 0x060007D4 RID: 2004 RVA: 0x0000796C File Offset: 0x00005B6C
		public int Luck
		{
			get
			{
				return this._luck;
			}
			set
			{
				this._luck = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x060007D5 RID: 2005 RVA: 0x0000797C File Offset: 0x00005B7C
		// (set) Token: 0x060007D6 RID: 2006 RVA: 0x00007984 File Offset: 0x00005B84
		public int Agility
		{
			get
			{
				return this._agility;
			}
			set
			{
				this._agility = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x060007D7 RID: 2007 RVA: 0x00007994 File Offset: 0x00005B94
		// (set) Token: 0x060007D8 RID: 2008 RVA: 0x0000799C File Offset: 0x00005B9C
		public int Gold
		{
			get
			{
				return this._gold;
			}
			set
			{
				this._gold = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x060007D9 RID: 2009 RVA: 0x000079AC File Offset: 0x00005BAC
		// (set) Token: 0x060007DA RID: 2010 RVA: 0x000079B4 File Offset: 0x00005BB4
		public int Money
		{
			get
			{
				return this._money;
			}
			set
			{
				this._money = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x060007DB RID: 2011 RVA: 0x000079C4 File Offset: 0x00005BC4
		// (set) Token: 0x060007DC RID: 2012 RVA: 0x000079CC File Offset: 0x00005BCC
		public string Style
		{
			get
			{
				return this._style;
			}
			set
			{
				this._style = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x060007DD RID: 2013 RVA: 0x000079DC File Offset: 0x00005BDC
		// (set) Token: 0x060007DE RID: 2014 RVA: 0x000079E4 File Offset: 0x00005BE4
		public string Colors
		{
			get
			{
				return this._colors;
			}
			set
			{
				this._colors = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x060007DF RID: 2015 RVA: 0x000079F4 File Offset: 0x00005BF4
		// (set) Token: 0x060007E0 RID: 2016 RVA: 0x000079FC File Offset: 0x00005BFC
		public int Hide
		{
			get
			{
				return this._hide;
			}
			set
			{
				this._hide = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x060007E1 RID: 2017 RVA: 0x00007A0C File Offset: 0x00005C0C
		// (set) Token: 0x060007E2 RID: 2018 RVA: 0x00007A14 File Offset: 0x00005C14
		public int Grade
		{
			get
			{
				return this._grade;
			}
			set
			{
				this._grade = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x060007E3 RID: 2019 RVA: 0x00007A24 File Offset: 0x00005C24
		// (set) Token: 0x060007E4 RID: 2020 RVA: 0x00007A2C File Offset: 0x00005C2C
		public int GP
		{
			get
			{
				return this._gp;
			}
			set
			{
				this._gp = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x060007E5 RID: 2021 RVA: 0x00007A3C File Offset: 0x00005C3C
		// (set) Token: 0x060007E6 RID: 2022 RVA: 0x00007A44 File Offset: 0x00005C44
		public string Honor
		{
			get
			{
				return this._honor;
			}
			set
			{
				this._honor = value;
			}
		}

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x00007A4D File Offset: 0x00005C4D
		// (set) Token: 0x060007E8 RID: 2024 RVA: 0x00007A55 File Offset: 0x00005C55
		public int State
		{
			get
			{
				return this._state;
			}
			set
			{
				this._state = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x00007A65 File Offset: 0x00005C65
		// (set) Token: 0x060007EA RID: 2026 RVA: 0x00007A6D File Offset: 0x00005C6D
		public int ConsortiaID
		{
			get
			{
				return this._consortiaID;
			}
			set
			{
				if (this._consortiaID == 0 || value == 0)
				{
					this._richesRob = 0;
					this._richesOffer = 0;
				}
				this._consortiaID = value;
			}
		}

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x00007A8F File Offset: 0x00005C8F
		// (set) Token: 0x060007EC RID: 2028 RVA: 0x00007A97 File Offset: 0x00005C97
		public int Repute
		{
			get
			{
				return this._repute;
			}
			set
			{
				this._repute = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x060007ED RID: 2029 RVA: 0x00007AA7 File Offset: 0x00005CA7
		// (set) Token: 0x060007EE RID: 2030 RVA: 0x00007AAF File Offset: 0x00005CAF
		public DateTime? ExpendDate
		{
			get
			{
				return this._expendDate;
			}
			set
			{
				this._expendDate = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x060007EF RID: 2031 RVA: 0x00007ABF File Offset: 0x00005CBF
		// (set) Token: 0x060007F0 RID: 2032 RVA: 0x00007AC7 File Offset: 0x00005CC7
		public int Offer
		{
			get
			{
				return this._offer;
			}
			set
			{
				this._offer = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x00007AD7 File Offset: 0x00005CD7
		// (set) Token: 0x060007F2 RID: 2034 RVA: 0x00007ADF File Offset: 0x00005CDF
		public string ConsortiaName
		{
			get
			{
				return this._consortiaName;
			}
			set
			{
				this._consortiaName = value;
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x060007F3 RID: 2035 RVA: 0x00007AE8 File Offset: 0x00005CE8
		// (set) Token: 0x060007F4 RID: 2036 RVA: 0x00007AF0 File Offset: 0x00005CF0
		public int Win
		{
			get
			{
				return this._win;
			}
			set
			{
				this._win = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x00007B00 File Offset: 0x00005D00
		// (set) Token: 0x060007F6 RID: 2038 RVA: 0x00007B08 File Offset: 0x00005D08
		public int Total
		{
			get
			{
				return this._total;
			}
			set
			{
				this._total = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x00007B18 File Offset: 0x00005D18
		// (set) Token: 0x060007F8 RID: 2040 RVA: 0x00007B20 File Offset: 0x00005D20
		public int Escape
		{
			get
			{
				return this._escape;
			}
			set
			{
				this._escape = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x060007F9 RID: 2041 RVA: 0x00007B30 File Offset: 0x00005D30
		// (set) Token: 0x060007FA RID: 2042 RVA: 0x00007B38 File Offset: 0x00005D38
		public string Skin
		{
			get
			{
				return this._skin;
			}
			set
			{
				this._skin = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x060007FB RID: 2043 RVA: 0x00007B48 File Offset: 0x00005D48
		// (set) Token: 0x060007FC RID: 2044 RVA: 0x00007B50 File Offset: 0x00005D50
		public bool IsConsortia
		{
			get
			{
				return this._isConsortia;
			}
			set
			{
				this._isConsortia = value;
			}
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x060007FD RID: 2045 RVA: 0x00007B59 File Offset: 0x00005D59
		// (set) Token: 0x060007FE RID: 2046 RVA: 0x00007B61 File Offset: 0x00005D61
		public bool IsBanChat { get; set; }

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x060007FF RID: 2047 RVA: 0x00007B6A File Offset: 0x00005D6A
		// (set) Token: 0x06000800 RID: 2048 RVA: 0x00007B72 File Offset: 0x00005D72
		public int ReputeOffer { get; set; }

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x06000801 RID: 2049 RVA: 0x00007B7B File Offset: 0x00005D7B
		// (set) Token: 0x06000802 RID: 2050 RVA: 0x00007B83 File Offset: 0x00005D83
		public int ConsortiaRepute { get; set; }

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x00007B8C File Offset: 0x00005D8C
		// (set) Token: 0x06000804 RID: 2052 RVA: 0x00007B94 File Offset: 0x00005D94
		public int ConsortiaLevel { get; set; }

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06000805 RID: 2053 RVA: 0x00007B9D File Offset: 0x00005D9D
		// (set) Token: 0x06000806 RID: 2054 RVA: 0x00007BA5 File Offset: 0x00005DA5
		public int StoreLevel { get; set; }

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06000807 RID: 2055 RVA: 0x00007BAE File Offset: 0x00005DAE
		// (set) Token: 0x06000808 RID: 2056 RVA: 0x00007BB6 File Offset: 0x00005DB6
		public int ShopLevel { get; set; }

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x00007BBF File Offset: 0x00005DBF
		// (set) Token: 0x0600080A RID: 2058 RVA: 0x00007BC7 File Offset: 0x00005DC7
		public int SmithLevel { get; set; }

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x0600080B RID: 2059 RVA: 0x00007BD0 File Offset: 0x00005DD0
		// (set) Token: 0x0600080C RID: 2060 RVA: 0x00007BD8 File Offset: 0x00005DD8
		public int BufferLevel { get; set; }

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x0600080D RID: 2061 RVA: 0x00007BE1 File Offset: 0x00005DE1
		// (set) Token: 0x0600080E RID: 2062 RVA: 0x00007BE9 File Offset: 0x00005DE9
		public int ConsortiaHonor { get; set; }

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x0600080F RID: 2063 RVA: 0x00007BF2 File Offset: 0x00005DF2
		// (set) Token: 0x06000810 RID: 2064 RVA: 0x00007BFA File Offset: 0x00005DFA
		public string ChairmanName { get; set; }

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06000811 RID: 2065 RVA: 0x00007C04 File Offset: 0x00005E04
		// (set) Token: 0x06000812 RID: 2066 RVA: 0x00007C31 File Offset: 0x00005E31
		public int AntiAddiction
		{
			get
			{
				return this._antiAddiction + (int)(DateTime.Now - this._antiDate).TotalMinutes;
			}
			set
			{
				this._antiAddiction = value;
				this._antiDate = DateTime.Now;
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06000813 RID: 2067 RVA: 0x00007C45 File Offset: 0x00005E45
		// (set) Token: 0x06000814 RID: 2068 RVA: 0x00007C4D File Offset: 0x00005E4D
		public DateTime AntiDate
		{
			get
			{
				return this._antiDate;
			}
			set
			{
				this._antiDate = value;
			}
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06000815 RID: 2069 RVA: 0x00007C56 File Offset: 0x00005E56
		// (set) Token: 0x06000816 RID: 2070 RVA: 0x00007C5E File Offset: 0x00005E5E
		public int RichesOffer
		{
			get
			{
				return this._richesOffer;
			}
			set
			{
				this._richesOffer = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x00007C6E File Offset: 0x00005E6E
		// (set) Token: 0x06000818 RID: 2072 RVA: 0x00007C76 File Offset: 0x00005E76
		public int RichesRob
		{
			get
			{
				return this._richesRob;
			}
			set
			{
				this._richesRob = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x00007C86 File Offset: 0x00005E86
		// (set) Token: 0x0600081A RID: 2074 RVA: 0x00007C8E File Offset: 0x00005E8E
		public int DutyLevel { get; set; }

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x0600081B RID: 2075 RVA: 0x00007C97 File Offset: 0x00005E97
		// (set) Token: 0x0600081C RID: 2076 RVA: 0x00007C9F File Offset: 0x00005E9F
		public string DutyName { get; set; }

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x0600081D RID: 2077 RVA: 0x00007CA8 File Offset: 0x00005EA8
		// (set) Token: 0x0600081E RID: 2078 RVA: 0x00007CB0 File Offset: 0x00005EB0
		public int Right { get; set; }

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x0600081F RID: 2079 RVA: 0x00007CB9 File Offset: 0x00005EB9
		// (set) Token: 0x06000820 RID: 2080 RVA: 0x00007CC1 File Offset: 0x00005EC1
		public int AddDayGP { get; set; }

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06000821 RID: 2081 RVA: 0x00007CCA File Offset: 0x00005ECA
		// (set) Token: 0x06000822 RID: 2082 RVA: 0x00007CD2 File Offset: 0x00005ED2
		public int AddWeekGP { get; set; }

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06000823 RID: 2083 RVA: 0x00007CDB File Offset: 0x00005EDB
		// (set) Token: 0x06000824 RID: 2084 RVA: 0x00007CE3 File Offset: 0x00005EE3
		public int AddDayOffer { get; set; }

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x06000825 RID: 2085 RVA: 0x00007CEC File Offset: 0x00005EEC
		// (set) Token: 0x06000826 RID: 2086 RVA: 0x00007CF4 File Offset: 0x00005EF4
		public int AddWeekOffer { get; set; }

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x06000827 RID: 2087 RVA: 0x00007CFD File Offset: 0x00005EFD
		// (set) Token: 0x06000828 RID: 2088 RVA: 0x00007D05 File Offset: 0x00005F05
		public int ConsortiaRiches { get; set; }

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x06000829 RID: 2089 RVA: 0x00007D0E File Offset: 0x00005F0E
		// (set) Token: 0x0600082A RID: 2090 RVA: 0x00007D16 File Offset: 0x00005F16
		public int CheckCount
		{
			get
			{
				return this._checkCount;
			}
			set
			{
				if (value == 0)
				{
					this._checkCode = string.Empty;
					this._checkError = 0;
				}
				this._checkCount = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x0600082B RID: 2091 RVA: 0x00007D3B File Offset: 0x00005F3B
		// (set) Token: 0x0600082C RID: 2092 RVA: 0x00007D43 File Offset: 0x00005F43
		public string CheckCode
		{
			get
			{
				return this._checkCode;
			}
			set
			{
				this._checkDate = DateTime.Now;
				this._checkCode = value;
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x0600082D RID: 2093 RVA: 0x00007D57 File Offset: 0x00005F57
		// (set) Token: 0x0600082E RID: 2094 RVA: 0x00007D5F File Offset: 0x00005F5F
		public int CheckError
		{
			get
			{
				return this._checkError;
			}
			set
			{
				this._checkError = value;
			}
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x0600082F RID: 2095 RVA: 0x00007D68 File Offset: 0x00005F68
		public DateTime CheckDate
		{
			get
			{
				return this._checkDate;
			}
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x06000830 RID: 2096 RVA: 0x00007D70 File Offset: 0x00005F70
		// (set) Token: 0x06000831 RID: 2097 RVA: 0x00007D78 File Offset: 0x00005F78
		public bool IsMarried
		{
			get
			{
				return this._isMarried;
			}
			set
			{
				this._isMarried = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06000832 RID: 2098 RVA: 0x00007D88 File Offset: 0x00005F88
		// (set) Token: 0x06000833 RID: 2099 RVA: 0x00007D90 File Offset: 0x00005F90
		public int SpouseID
		{
			get
			{
				return this._spouseID;
			}
			set
			{
				if (this._spouseID != value)
				{
					this._spouseID = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06000834 RID: 2100 RVA: 0x00007DA9 File Offset: 0x00005FA9
		// (set) Token: 0x06000835 RID: 2101 RVA: 0x00007DB1 File Offset: 0x00005FB1
		public string SpouseName
		{
			get
			{
				return this._spouseName;
			}
			set
			{
				if (this._spouseName != value)
				{
					this._spouseName = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06000836 RID: 2102 RVA: 0x00007DCF File Offset: 0x00005FCF
		// (set) Token: 0x06000837 RID: 2103 RVA: 0x00007DD7 File Offset: 0x00005FD7
		public int MarryInfoID
		{
			get
			{
				return this._marryInfoID;
			}
			set
			{
				if (this._marryInfoID != value)
				{
					this._marryInfoID = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x00007DF0 File Offset: 0x00005FF0
		// (set) Token: 0x06000839 RID: 2105 RVA: 0x00007DF8 File Offset: 0x00005FF8
		public bool IsLocked
		{
			get
			{
				return this._isLocked;
			}
			set
			{
				this._isLocked = value;
			}
		}

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x0600083A RID: 2106 RVA: 0x00007E01 File Offset: 0x00006001
		public bool HasBagPassword
		{
			get
			{
				return !string.IsNullOrEmpty(this._PasswordTwo);
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x0600083B RID: 2107 RVA: 0x00007E11 File Offset: 0x00006011
		// (set) Token: 0x0600083C RID: 2108 RVA: 0x00007E19 File Offset: 0x00006019
		public string PasswordTwo
		{
			get
			{
				return this._PasswordTwo;
			}
			set
			{
				this._PasswordTwo = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x0600083D RID: 2109 RVA: 0x00007E29 File Offset: 0x00006029
		// (set) Token: 0x0600083E RID: 2110 RVA: 0x00007E31 File Offset: 0x00006031
		public int DayLoginCount
		{
			get
			{
				return this._dayLoginCount;
			}
			set
			{
				this._dayLoginCount = value;
				this._isDirty = true;
			}
		}

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x00007E41 File Offset: 0x00006041
		// (set) Token: 0x06000840 RID: 2112 RVA: 0x00007E49 File Offset: 0x00006049
		public bool IsCreatedMarryRoom
		{
			get
			{
				return this._isCreatedMarryRoom;
			}
			set
			{
				if (this._isCreatedMarryRoom != value)
				{
					this._isCreatedMarryRoom = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x00007E62 File Offset: 0x00006062
		public int Riches
		{
			get
			{
				return this.RichesRob + this.RichesOffer;
			}
		}

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x00007E71 File Offset: 0x00006071
		// (set) Token: 0x06000843 RID: 2115 RVA: 0x00007E79 File Offset: 0x00006079
		public int SelfMarryRoomID
		{
			get
			{
				return this._selfMarryRoomID;
			}
			set
			{
				if (this._selfMarryRoomID != value)
				{
					this._selfMarryRoomID = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06000844 RID: 2116 RVA: 0x00007E92 File Offset: 0x00006092
		// (set) Token: 0x06000845 RID: 2117 RVA: 0x00007E9A File Offset: 0x0000609A
		public bool IsGotRing
		{
			get
			{
				return this._isGotRing;
			}
			set
			{
				if (this._isGotRing != value)
				{
					this._isGotRing = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x00007EB3 File Offset: 0x000060B3
		// (set) Token: 0x06000847 RID: 2119 RVA: 0x00007EBB File Offset: 0x000060BB
		public bool Rename
		{
			get
			{
				return this._rename;
			}
			set
			{
				if (this._rename != value)
				{
					this._rename = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x00007ED4 File Offset: 0x000060D4
		// (set) Token: 0x06000849 RID: 2121 RVA: 0x00007EDC File Offset: 0x000060DC
		public bool ConsortiaRename
		{
			get
			{
				return this._consortiaRename;
			}
			set
			{
				if (this._consortiaRename != value)
				{
					this._consortiaRename = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x00007EF5 File Offset: 0x000060F5
		// (set) Token: 0x0600084B RID: 2123 RVA: 0x00007EFD File Offset: 0x000060FD
		public int Nimbus
		{
			get
			{
				return this._nimbus;
			}
			set
			{
				if (this._nimbus != value)
				{
					this._nimbus = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x00007F16 File Offset: 0x00006116
		// (set) Token: 0x0600084D RID: 2125 RVA: 0x00007F1E File Offset: 0x0000611E
		public int FightPower
		{
			get
			{
				return this._fightPower;
			}
			set
			{
				if (this._fightPower != value)
				{
					this._fightPower = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x00007F37 File Offset: 0x00006137
		// (set) Token: 0x0600084F RID: 2127 RVA: 0x00007F3F File Offset: 0x0000613F
		public int IsFirst
		{
			get
			{
				return this._IsFirst;
			}
			set
			{
				this._IsFirst = value;
			}
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x00007F48 File Offset: 0x00006148
		// (set) Token: 0x06000851 RID: 2129 RVA: 0x00007F50 File Offset: 0x00006150
		public int GiftToken
		{
			get
			{
				return this._GiftToken;
			}
			set
			{
				this._GiftToken = value;
			}
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06000852 RID: 2130 RVA: 0x00007F59 File Offset: 0x00006159
		// (set) Token: 0x06000853 RID: 2131 RVA: 0x00007F61 File Offset: 0x00006161
		public DateTime LastAward
		{
			get
			{
				return this._LastAward;
			}
			set
			{
				this._LastAward = value;
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x00007F6A File Offset: 0x0000616A
		// (set) Token: 0x06000855 RID: 2133 RVA: 0x00007F72 File Offset: 0x00006172
		public DateTime LastAuncherAward
		{
			get
			{
				return this._LastAuncherAward;
			}
			set
			{
				this._LastAuncherAward = value;
			}
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06000856 RID: 2134 RVA: 0x00007F7B File Offset: 0x0000617B
		// (set) Token: 0x06000857 RID: 2135 RVA: 0x00007F83 File Offset: 0x00006183
		public DateTime LastVIPAward { get; set; }

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06000858 RID: 2136 RVA: 0x00007F8C File Offset: 0x0000618C
		// (set) Token: 0x06000859 RID: 2137 RVA: 0x00007F94 File Offset: 0x00006194
		public byte[] QuestSite
		{
			get
			{
				return this._QuestSite;
			}
			set
			{
				this._QuestSite = value;
			}
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x0600085A RID: 2138 RVA: 0x00007F9D File Offset: 0x0000619D
		// (set) Token: 0x0600085B RID: 2139 RVA: 0x00007FA5 File Offset: 0x000061A5
		public DateTime LastDate
		{
			get
			{
				return this.m_lastDate;
			}
			set
			{
				this.m_lastDate = value;
			}
		}

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x0600085C RID: 2140 RVA: 0x00007FAE File Offset: 0x000061AE
		// (set) Token: 0x0600085D RID: 2141 RVA: 0x00007FB6 File Offset: 0x000061B6
		public string PvePermission
		{
			get
			{
				return this.m_pvePermission;
			}
			set
			{
				this.m_pvePermission = value;
			}
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x0600085E RID: 2142 RVA: 0x00007FBF File Offset: 0x000061BF
		// (set) Token: 0x0600085F RID: 2143 RVA: 0x00007FC7 File Offset: 0x000061C7
		public string FightLabPermission
		{
			get
			{
				return this.m_fightlabPermission;
			}
			set
			{
				this.m_fightlabPermission = value;
			}
		}

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06000860 RID: 2144 RVA: 0x00007FD0 File Offset: 0x000061D0
		// (set) Token: 0x06000861 RID: 2145 RVA: 0x00007FD8 File Offset: 0x000061D8
		public string PasswordQuest1
		{
			get
			{
				return this.m_PasswordQuest1;
			}
			set
			{
				this.m_PasswordQuest1 = value;
			}
		}

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06000862 RID: 2146 RVA: 0x00007FE1 File Offset: 0x000061E1
		// (set) Token: 0x06000863 RID: 2147 RVA: 0x00007FE9 File Offset: 0x000061E9
		public string PasswordQuest2
		{
			get
			{
				return this.m_PasswordQuest2;
			}
			set
			{
				this.m_PasswordQuest2 = value;
			}
		}

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06000864 RID: 2148 RVA: 0x00007FF2 File Offset: 0x000061F2
		// (set) Token: 0x06000865 RID: 2149 RVA: 0x00007FFA File Offset: 0x000061FA
		public int FailedPasswordAttemptCount
		{
			get
			{
				return this.m_FailedPasswordAttemptCount;
			}
			set
			{
				this.m_FailedPasswordAttemptCount = value;
			}
		}

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06000866 RID: 2150 RVA: 0x00008003 File Offset: 0x00006203
		// (set) Token: 0x06000867 RID: 2151 RVA: 0x0000800B File Offset: 0x0000620B
		public int AnswerSite
		{
			get
			{
				return this.m_AnswerSite;
			}
			set
			{
				this.m_AnswerSite = value;
			}
		}

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06000868 RID: 2152 RVA: 0x00008014 File Offset: 0x00006214
		// (set) Token: 0x06000869 RID: 2153 RVA: 0x0000801C File Offset: 0x0000621C
		public int ChatCount
		{
			get
			{
				return this.m_ChatCount;
			}
			set
			{
				this.m_ChatCount = value;
			}
		}

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x00008025 File Offset: 0x00006225
		// (set) Token: 0x0600086B RID: 2155 RVA: 0x0000802D File Offset: 0x0000622D
		public int AchievementPoint
		{
			get
			{
				return this.m_AchievementPoint;
			}
			set
			{
				this.m_AchievementPoint = value;
			}
		}

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x0600086C RID: 2156 RVA: 0x00008036 File Offset: 0x00006236
		// (set) Token: 0x0600086D RID: 2157 RVA: 0x0000803E File Offset: 0x0000623E
		public int Rank
		{
			get
			{
				return this.m_Rank;
			}
			set
			{
				this.m_Rank = value;
			}
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x0600086E RID: 2158 RVA: 0x00008047 File Offset: 0x00006247
		// (set) Token: 0x0600086F RID: 2159 RVA: 0x0000804F File Offset: 0x0000624F
		public int AddDayAchievementPoint
		{
			get
			{
				return this.m_AddDayAchievementPoint;
			}
			set
			{
				this.m_AddDayAchievementPoint = value;
			}
		}

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06000870 RID: 2160 RVA: 0x00008058 File Offset: 0x00006258
		// (set) Token: 0x06000871 RID: 2161 RVA: 0x00008060 File Offset: 0x00006260
		public int AddWeekAchievementPoint
		{
			get
			{
				return this.m_AddWeekAchievementPoint;
			}
			set
			{
				this.m_AddWeekAchievementPoint = value;
			}
		}

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06000872 RID: 2162 RVA: 0x00008069 File Offset: 0x00006269
		// (set) Token: 0x06000873 RID: 2163 RVA: 0x00008071 File Offset: 0x00006271
		public int OnlineTime
		{
			get
			{
				return this.m_OnlineTime;
			}
			set
			{
				this.m_OnlineTime = value;
			}
		}

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06000874 RID: 2164 RVA: 0x0000807A File Offset: 0x0000627A
		// (set) Token: 0x06000875 RID: 2165 RVA: 0x00008082 File Offset: 0x00006282
		public int BoxProgression
		{
			get
			{
				return this.m_BoxProgression;
			}
			set
			{
				this.m_BoxProgression = value;
			}
		}

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06000876 RID: 2166 RVA: 0x0000808B File Offset: 0x0000628B
		// (set) Token: 0x06000877 RID: 2167 RVA: 0x00008093 File Offset: 0x00006293
		public DateTime BoxGetDate
		{
			get
			{
				return this.m_BoxGetDate;
			}
			set
			{
				this.m_BoxGetDate = value;
			}
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06000878 RID: 2168 RVA: 0x0000809C File Offset: 0x0000629C
		// (set) Token: 0x06000879 RID: 2169 RVA: 0x000080A4 File Offset: 0x000062A4
		public int GetBoxLevel
		{
			get
			{
				return this.m_getBoxLevel;
			}
			set
			{
				this.m_getBoxLevel = value;
			}
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x0600087A RID: 2170 RVA: 0x000080AD File Offset: 0x000062AD
		// (set) Token: 0x0600087B RID: 2171 RVA: 0x000080B5 File Offset: 0x000062B5
		public int SpaPubGoldRoomLimit
		{
			get
			{
				return this.m_SpaPubGoldRoomLimit;
			}
			set
			{
				this.m_SpaPubGoldRoomLimit = value;
			}
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x0600087C RID: 2172 RVA: 0x000080BE File Offset: 0x000062BE
		// (set) Token: 0x0600087D RID: 2173 RVA: 0x000080C6 File Offset: 0x000062C6
		public DateTime LastSpaDate
		{
			get
			{
				return this.m_LastSpaDate;
			}
			set
			{
				this.m_LastSpaDate = value;
			}
		}

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x0600087E RID: 2174 RVA: 0x000080CF File Offset: 0x000062CF
		// (set) Token: 0x0600087F RID: 2175 RVA: 0x000080D7 File Offset: 0x000062D7
		public DateTime AddGPLastDate
		{
			get
			{
				return this.m_AddGPLastDate;
			}
			set
			{
				this.m_AddGPLastDate = value;
			}
		}

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x000080E0 File Offset: 0x000062E0
		// (set) Token: 0x06000881 RID: 2177 RVA: 0x000080E8 File Offset: 0x000062E8
		public int SpaPubMoneyRoomLimit
		{
			get
			{
				return this.m_SpaPubMoneyRoomLimit;
			}
			set
			{
				this.m_SpaPubMoneyRoomLimit = value;
			}
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x000080F1 File Offset: 0x000062F1
		// (set) Token: 0x06000883 RID: 2179 RVA: 0x000080F9 File Offset: 0x000062F9
		public bool IsInSpaPubGoldToday
		{
			get
			{
				return this.m_IsInSpaPubGoldToday;
			}
			set
			{
				this.m_IsInSpaPubGoldToday = value;
			}
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06000884 RID: 2180 RVA: 0x00008102 File Offset: 0x00006302
		// (set) Token: 0x06000885 RID: 2181 RVA: 0x0000810A File Offset: 0x0000630A
		public bool IsInSpaPubMoneyToday
		{
			get
			{
				return this.m_IsInSpaPubMoneyToday;
			}
			set
			{
				this.m_IsInSpaPubMoneyToday = value;
			}
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06000886 RID: 2182 RVA: 0x00008113 File Offset: 0x00006313
		// (set) Token: 0x06000887 RID: 2183 RVA: 0x0000811B File Offset: 0x0000631B
		public int AlreadyGetBox
		{
			get
			{
				return this.m_AlreadyGetBox;
			}
			set
			{
				this.m_AlreadyGetBox = value;
			}
		}

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06000888 RID: 2184 RVA: 0x00008124 File Offset: 0x00006324
		// (set) Token: 0x06000889 RID: 2185 RVA: 0x0000812C File Offset: 0x0000632C
		public int TypeVIP { get; set; }

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x0600088A RID: 2186 RVA: 0x00008135 File Offset: 0x00006335
		// (set) Token: 0x0600088B RID: 2187 RVA: 0x0000813D File Offset: 0x0000633D
		public int VIPLevel { get; set; }

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x0600088C RID: 2188 RVA: 0x00008146 File Offset: 0x00006346
		// (set) Token: 0x0600088D RID: 2189 RVA: 0x0000814E File Offset: 0x0000634E
		public int VIPExp { get; set; }

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x0600088E RID: 2190 RVA: 0x00008157 File Offset: 0x00006357
		// (set) Token: 0x0600088F RID: 2191 RVA: 0x0000815F File Offset: 0x0000635F
		public DateTime VIPExpireDay { get; set; }

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06000890 RID: 2192 RVA: 0x00008168 File Offset: 0x00006368
		// (set) Token: 0x06000891 RID: 2193 RVA: 0x00008170 File Offset: 0x00006370
		public int VIPNextLevelDaysNeeded { get; set; }

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06000892 RID: 2194 RVA: 0x0000817C File Offset: 0x0000637C
		public bool CanTakeVipReward
		{
			get
			{
				return this.LastVIPAward.Date.AddDays(7.0) <= DateTime.Now.Date;
			}
		}

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x000081BA File Offset: 0x000063BA
		// (set) Token: 0x06000894 RID: 2196 RVA: 0x000081C2 File Offset: 0x000063C2
		public int BadgeID { get; set; }

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06000895 RID: 2197 RVA: 0x000081CB File Offset: 0x000063CB
		// (set) Token: 0x06000896 RID: 2198 RVA: 0x000081D3 File Offset: 0x000063D3
		public int Blood { get; set; }

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06000897 RID: 2199 RVA: 0x000081DC File Offset: 0x000063DC
		// (set) Token: 0x06000898 RID: 2200 RVA: 0x000081E4 File Offset: 0x000063E4
		public byte[] WeaklessGuildProgress { get; set; }

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06000899 RID: 2201 RVA: 0x000081ED File Offset: 0x000063ED
		// (set) Token: 0x0600089A RID: 2202 RVA: 0x000081F5 File Offset: 0x000063F5
		public string WeaklessGuildProgressStr { get; set; }

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x0600089B RID: 2203 RVA: 0x000081FE File Offset: 0x000063FE
		// (set) Token: 0x0600089C RID: 2204 RVA: 0x00008206 File Offset: 0x00006406
		public TexpInfo Texp { get; set; }

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x0600089D RID: 2205 RVA: 0x0000820F File Offset: 0x0000640F
		// (set) Token: 0x0600089E RID: 2206 RVA: 0x00008217 File Offset: 0x00006417
		public int MysteriousSPAR { get; set; }

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x00008220 File Offset: 0x00006420
		// (set) Token: 0x060008A0 RID: 2208 RVA: 0x00008228 File Offset: 0x00006428
		public int LotteryScore { get; set; }

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x060008A1 RID: 2209 RVA: 0x00008231 File Offset: 0x00006431
		// (set) Token: 0x060008A2 RID: 2210 RVA: 0x00008239 File Offset: 0x00006439
		public string AcademyDungeon { get; set; }

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x060008A3 RID: 2211 RVA: 0x00008242 File Offset: 0x00006442
		// (set) Token: 0x060008A4 RID: 2212 RVA: 0x0000824A File Offset: 0x0000644A
		public DateTime LastAcademyDungeon { get; set; }

		// Token: 0x060008A5 RID: 2213 RVA: 0x00008253 File Offset: 0x00006453
		public PlayerInfo()
		{
			this._isLocked = true;
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x00008264 File Offset: 0x00006464
		public void ClearConsortia()
		{
			this.ConsortiaID = 0;
			this.ConsortiaName = "";
			this.RichesOffer = 0;
			this.ConsortiaRepute = 0;
			this.ConsortiaLevel = 0;
			this.StoreLevel = 0;
			this.ShopLevel = 0;
			this.SmithLevel = 0;
			this.BufferLevel = 0;
			this.ConsortiaHonor = 0;
			this.RichesOffer = 0;
			this.RichesRob = 0;
			this.DutyLevel = 0;
			this.DutyName = "";
			this.Right = 0;
			this.AddDayGP = 0;
			this.AddWeekGP = 0;
			this.AddDayOffer = 0;
			this.AddWeekOffer = 0;
			this.ConsortiaRiches = 0;
		}

		// Token: 0x0400043C RID: 1084
		private string _areaName;

		// Token: 0x0400043D RID: 1085
		private int _id;

		// Token: 0x0400043E RID: 1086
		private string _userName;

		// Token: 0x0400043F RID: 1087
		private string _nickName;

		// Token: 0x04000440 RID: 1088
		private bool _sex;

		// Token: 0x04000441 RID: 1089
		private int _attack;

		// Token: 0x04000442 RID: 1090
		private int _defence;

		// Token: 0x04000443 RID: 1091
		private int _luck;

		// Token: 0x04000444 RID: 1092
		private int _agility;

		// Token: 0x04000445 RID: 1093
		private int _gold;

		// Token: 0x04000446 RID: 1094
		private int _money;

		// Token: 0x04000447 RID: 1095
		private string _style;

		// Token: 0x04000448 RID: 1096
		private string _colors;

		// Token: 0x04000449 RID: 1097
		private int _hide;

		// Token: 0x0400044A RID: 1098
		private int _grade;

		// Token: 0x0400044B RID: 1099
		private int _gp;

		// Token: 0x0400044C RID: 1100
		private string _honor;

		// Token: 0x0400044D RID: 1101
		private int _state;

		// Token: 0x0400044E RID: 1102
		private int _consortiaID;

		// Token: 0x0400044F RID: 1103
		private int _repute;

		// Token: 0x04000450 RID: 1104
		private DateTime? _expendDate;

		// Token: 0x04000451 RID: 1105
		private int _offer;

		// Token: 0x04000452 RID: 1106
		private string _consortiaName;

		// Token: 0x04000453 RID: 1107
		private int _win;

		// Token: 0x04000454 RID: 1108
		private int _total;

		// Token: 0x04000455 RID: 1109
		private int _escape;

		// Token: 0x04000456 RID: 1110
		private string _skin;

		// Token: 0x04000457 RID: 1111
		private bool _isConsortia;

		// Token: 0x04000458 RID: 1112
		private int _antiAddiction;

		// Token: 0x04000459 RID: 1113
		private DateTime _antiDate;

		// Token: 0x0400045A RID: 1114
		private int _richesOffer;

		// Token: 0x0400045B RID: 1115
		private int _richesRob;

		// Token: 0x0400045C RID: 1116
		private int _checkCount;

		// Token: 0x0400045D RID: 1117
		private string _checkCode;

		// Token: 0x0400045E RID: 1118
		private int _checkError;

		// Token: 0x0400045F RID: 1119
		private DateTime _checkDate;

		// Token: 0x04000460 RID: 1120
		private bool _isMarried;

		// Token: 0x04000461 RID: 1121
		private int _spouseID;

		// Token: 0x04000462 RID: 1122
		private string _spouseName;

		// Token: 0x04000463 RID: 1123
		private int _marryInfoID;

		// Token: 0x04000464 RID: 1124
		private bool _isLocked;

		// Token: 0x04000465 RID: 1125
		private string _PasswordTwo;

		// Token: 0x04000466 RID: 1126
		private int _dayLoginCount;

		// Token: 0x04000467 RID: 1127
		private bool _isCreatedMarryRoom;

		// Token: 0x04000468 RID: 1128
		private int _selfMarryRoomID;

		// Token: 0x04000469 RID: 1129
		private bool _isGotRing;

		// Token: 0x0400046A RID: 1130
		private bool _rename;

		// Token: 0x0400046B RID: 1131
		private bool _consortiaRename;

		// Token: 0x0400046C RID: 1132
		private int _nimbus;

		// Token: 0x0400046D RID: 1133
		private int _fightPower;

		// Token: 0x0400046E RID: 1134
		private int _IsFirst;

		// Token: 0x0400046F RID: 1135
		private int _GiftToken;

		// Token: 0x04000470 RID: 1136
		private DateTime _LastAward;

		// Token: 0x04000471 RID: 1137
		private DateTime _LastAuncherAward;

		// Token: 0x04000472 RID: 1138
		private byte[] _QuestSite;

		// Token: 0x04000473 RID: 1139
		private DateTime m_lastDate;

		// Token: 0x04000474 RID: 1140
		private string m_pvePermission;

		// Token: 0x04000475 RID: 1141
		private string m_fightlabPermission;

		// Token: 0x04000476 RID: 1142
		private string m_PasswordQuest1;

		// Token: 0x04000477 RID: 1143
		private string m_PasswordQuest2;

		// Token: 0x04000478 RID: 1144
		private int m_FailedPasswordAttemptCount;

		// Token: 0x04000479 RID: 1145
		private int m_AnswerSite;

		// Token: 0x0400047A RID: 1146
		private int m_ChatCount;

		// Token: 0x0400047B RID: 1147
		private int m_AchievementPoint;

		// Token: 0x0400047C RID: 1148
		private int m_Rank;

		// Token: 0x0400047D RID: 1149
		private int m_AddDayAchievementPoint;

		// Token: 0x0400047E RID: 1150
		private int m_AddWeekAchievementPoint;

		// Token: 0x0400047F RID: 1151
		private int m_OnlineTime;

		// Token: 0x04000480 RID: 1152
		private int m_BoxProgression;

		// Token: 0x04000481 RID: 1153
		private DateTime m_BoxGetDate;

		// Token: 0x04000482 RID: 1154
		private int m_getBoxLevel;

		// Token: 0x04000483 RID: 1155
		private int m_SpaPubGoldRoomLimit;

		// Token: 0x04000484 RID: 1156
		private DateTime m_LastSpaDate;

		// Token: 0x04000485 RID: 1157
		private DateTime m_AddGPLastDate;

		// Token: 0x04000486 RID: 1158
		private int m_SpaPubMoneyRoomLimit;

		// Token: 0x04000487 RID: 1159
		private bool m_IsInSpaPubGoldToday;

		// Token: 0x04000488 RID: 1160
		private bool m_IsInSpaPubMoneyToday;

		// Token: 0x04000489 RID: 1161
		private int m_AlreadyGetBox;
	}
}
