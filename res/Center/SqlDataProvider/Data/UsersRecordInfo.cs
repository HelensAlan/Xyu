using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000069 RID: 105
	public class UsersRecordInfo : DataObject
	{
		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06000AD6 RID: 2774 RVA: 0x00009686 File Offset: 0x00007886
		// (set) Token: 0x06000AD7 RID: 2775 RVA: 0x0000968E File Offset: 0x0000788E
		public int UserID
		{
			get
			{
				return this._userID;
			}
			set
			{
				this._userID = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06000AD8 RID: 2776 RVA: 0x0000969E File Offset: 0x0000789E
		// (set) Token: 0x06000AD9 RID: 2777 RVA: 0x000096A6 File Offset: 0x000078A6
		public int RecordID
		{
			get
			{
				return this._recordID;
			}
			set
			{
				this._recordID = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x06000ADA RID: 2778 RVA: 0x000096B6 File Offset: 0x000078B6
		// (set) Token: 0x06000ADB RID: 2779 RVA: 0x000096BE File Offset: 0x000078BE
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

		// Token: 0x040005B7 RID: 1463
		private int _userID;

		// Token: 0x040005B8 RID: 1464
		private int _recordID;

		// Token: 0x040005B9 RID: 1465
		private int _total;
	}
}
