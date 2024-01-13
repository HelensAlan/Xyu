using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200004A RID: 74
	public class PetLevelInfo
	{
		// Token: 0x06000747 RID: 1863 RVA: 0x000072B7 File Offset: 0x000054B7
		public PetLevelInfo()
		{
			this._Level = -1;
			this._GP = -1;
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000748 RID: 1864 RVA: 0x000072CD File Offset: 0x000054CD
		// (set) Token: 0x06000749 RID: 1865 RVA: 0x000072D5 File Offset: 0x000054D5
		public int Level
		{
			get
			{
				return this._Level;
			}
			set
			{
				this._Level = value;
			}
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x0600074A RID: 1866 RVA: 0x000072DE File Offset: 0x000054DE
		// (set) Token: 0x0600074B RID: 1867 RVA: 0x000072E6 File Offset: 0x000054E6
		public int GP
		{
			get
			{
				return this._GP;
			}
			set
			{
				this._GP = value;
			}
		}

		// Token: 0x04000400 RID: 1024
		private int _Level;

		// Token: 0x04000401 RID: 1025
		private int _GP;
	}
}
