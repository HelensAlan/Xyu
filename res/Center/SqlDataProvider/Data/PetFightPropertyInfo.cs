using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000048 RID: 72
	public class PetFightPropertyInfo
	{
		// Token: 0x17000349 RID: 841
		// (get) Token: 0x060006E0 RID: 1760 RVA: 0x00006719 File Offset: 0x00004919
		// (set) Token: 0x060006E1 RID: 1761 RVA: 0x00006721 File Offset: 0x00004921
		public int Agility
		{
			get
			{
				return this._Agility;
			}
			set
			{
				this._Agility = value;
			}
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x060006E2 RID: 1762 RVA: 0x0000672A File Offset: 0x0000492A
		// (set) Token: 0x060006E3 RID: 1763 RVA: 0x00006732 File Offset: 0x00004932
		public int Attack
		{
			get
			{
				return this._Attack;
			}
			set
			{
				this._Attack = value;
			}
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x060006E4 RID: 1764 RVA: 0x0000673B File Offset: 0x0000493B
		// (set) Token: 0x060006E5 RID: 1765 RVA: 0x00006743 File Offset: 0x00004943
		public int Blood
		{
			get
			{
				return this._Blood;
			}
			set
			{
				this._Blood = value;
			}
		}

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x060006E6 RID: 1766 RVA: 0x0000674C File Offset: 0x0000494C
		// (set) Token: 0x060006E7 RID: 1767 RVA: 0x00006754 File Offset: 0x00004954
		public int Defence
		{
			get
			{
				return this._Defence;
			}
			set
			{
				this._Defence = value;
			}
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x060006E8 RID: 1768 RVA: 0x0000675D File Offset: 0x0000495D
		// (set) Token: 0x060006E9 RID: 1769 RVA: 0x00006765 File Offset: 0x00004965
		public int Exp
		{
			get
			{
				return this._Exp;
			}
			set
			{
				this._Exp = value;
			}
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x060006EA RID: 1770 RVA: 0x0000676E File Offset: 0x0000496E
		// (set) Token: 0x060006EB RID: 1771 RVA: 0x00006776 File Offset: 0x00004976
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

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x060006EC RID: 1772 RVA: 0x0000677F File Offset: 0x0000497F
		// (set) Token: 0x060006ED RID: 1773 RVA: 0x00006787 File Offset: 0x00004987
		public int Lucky
		{
			get
			{
				return this._Lucky;
			}
			set
			{
				this._Lucky = value;
			}
		}

		// Token: 0x040003D1 RID: 977
		private int _Agility;

		// Token: 0x040003D2 RID: 978
		private int _Attack;

		// Token: 0x040003D3 RID: 979
		private int _Blood;

		// Token: 0x040003D4 RID: 980
		private int _Defence;

		// Token: 0x040003D5 RID: 981
		private int _Exp;

		// Token: 0x040003D6 RID: 982
		private int _ID;

		// Token: 0x040003D7 RID: 983
		private int _Lucky;
	}
}
