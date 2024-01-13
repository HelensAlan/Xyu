using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200004B RID: 75
	public class PetSkillElementInfo
	{
		// Token: 0x0600074C RID: 1868 RVA: 0x000072F0 File Offset: 0x000054F0
		public PetSkillElementInfo()
		{
			this._ID = -1;
			this._Name = "";
			this._EffectPic = "";
			this._Description = "";
			this._Pic = -1;
			this._type = -1;
			this._data = -1;
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x0600074D RID: 1869 RVA: 0x00007340 File Offset: 0x00005540
		// (set) Token: 0x0600074E RID: 1870 RVA: 0x00007348 File Offset: 0x00005548
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

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x0600074F RID: 1871 RVA: 0x00007351 File Offset: 0x00005551
		// (set) Token: 0x06000750 RID: 1872 RVA: 0x00007359 File Offset: 0x00005559
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

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000751 RID: 1873 RVA: 0x00007362 File Offset: 0x00005562
		// (set) Token: 0x06000752 RID: 1874 RVA: 0x0000736A File Offset: 0x0000556A
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

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000753 RID: 1875 RVA: 0x00007373 File Offset: 0x00005573
		// (set) Token: 0x06000754 RID: 1876 RVA: 0x0000737B File Offset: 0x0000557B
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

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000755 RID: 1877 RVA: 0x00007384 File Offset: 0x00005584
		// (set) Token: 0x06000756 RID: 1878 RVA: 0x0000738C File Offset: 0x0000558C
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

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000757 RID: 1879 RVA: 0x00007395 File Offset: 0x00005595
		// (set) Token: 0x06000758 RID: 1880 RVA: 0x0000739D File Offset: 0x0000559D
		public int Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x000073A6 File Offset: 0x000055A6
		// (set) Token: 0x0600075A RID: 1882 RVA: 0x000073AE File Offset: 0x000055AE
		public int Data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x000073B7 File Offset: 0x000055B7
		// (set) Token: 0x0600075C RID: 1884 RVA: 0x000073BF File Offset: 0x000055BF
		public int Turn
		{
			get
			{
				return this._turn;
			}
			set
			{
				this._turn = value;
			}
		}

		// Token: 0x04000402 RID: 1026
		private int _ID;

		// Token: 0x04000403 RID: 1027
		private string _Name;

		// Token: 0x04000404 RID: 1028
		private string _EffectPic;

		// Token: 0x04000405 RID: 1029
		private string _Description;

		// Token: 0x04000406 RID: 1030
		private int _Pic;

		// Token: 0x04000407 RID: 1031
		private int _type;

		// Token: 0x04000408 RID: 1032
		private int _data;

		// Token: 0x04000409 RID: 1033
		private int _turn;
	}
}
