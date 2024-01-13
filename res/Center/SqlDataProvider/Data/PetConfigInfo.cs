using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000047 RID: 71
	public class PetConfigInfo
	{
		// Token: 0x060006D9 RID: 1753 RVA: 0x000066C1 File Offset: 0x000048C1
		public PetConfigInfo()
		{
			this._ID = -1;
			this._Name = "";
			this._Value = "";
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x000066E6 File Offset: 0x000048E6
		// (set) Token: 0x060006DB RID: 1755 RVA: 0x000066EE File Offset: 0x000048EE
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

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x060006DC RID: 1756 RVA: 0x000066F7 File Offset: 0x000048F7
		// (set) Token: 0x060006DD RID: 1757 RVA: 0x000066FF File Offset: 0x000048FF
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

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x060006DE RID: 1758 RVA: 0x00006708 File Offset: 0x00004908
		// (set) Token: 0x060006DF RID: 1759 RVA: 0x00006710 File Offset: 0x00004910
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				this._Value = value;
			}
		}

		// Token: 0x040003CE RID: 974
		private int _ID;

		// Token: 0x040003CF RID: 975
		private string _Name;

		// Token: 0x040003D0 RID: 976
		private string _Value;
	}
}
