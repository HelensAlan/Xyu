using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200004E RID: 78
	public class PetStarExpInfo
	{
		// Token: 0x1700039A RID: 922
		// (get) Token: 0x0600078D RID: 1933 RVA: 0x00007623 File Offset: 0x00005823
		// (set) Token: 0x0600078E RID: 1934 RVA: 0x0000762B File Offset: 0x0000582B
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

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x0600078F RID: 1935 RVA: 0x00007634 File Offset: 0x00005834
		// (set) Token: 0x06000790 RID: 1936 RVA: 0x0000763C File Offset: 0x0000583C
		public int NewID
		{
			get
			{
				return this._NewID;
			}
			set
			{
				this._NewID = value;
			}
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000791 RID: 1937 RVA: 0x00007645 File Offset: 0x00005845
		// (set) Token: 0x06000792 RID: 1938 RVA: 0x0000764D File Offset: 0x0000584D
		public int OldID
		{
			get
			{
				return this._OldID;
			}
			set
			{
				this._OldID = value;
			}
		}

		// Token: 0x04000421 RID: 1057
		private int _Exp;

		// Token: 0x04000422 RID: 1058
		private int _NewID;

		// Token: 0x04000423 RID: 1059
		private int _OldID;
	}
}
