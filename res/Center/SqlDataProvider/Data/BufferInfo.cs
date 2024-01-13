using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000012 RID: 18
	public class BufferInfo : DataObject
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00002A52 File Offset: 0x00000C52
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00002A5A File Offset: 0x00000C5A
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

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00002A6A File Offset: 0x00000C6A
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00002A72 File Offset: 0x00000C72
		public int Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00002A82 File Offset: 0x00000C82
		// (set) Token: 0x06000131 RID: 305 RVA: 0x00002A8A File Offset: 0x00000C8A
		public int Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000132 RID: 306 RVA: 0x00002A9A File Offset: 0x00000C9A
		// (set) Token: 0x06000133 RID: 307 RVA: 0x00002AA2 File Offset: 0x00000CA2
		public DateTime BeginDate
		{
			get
			{
				return this._beginDate;
			}
			set
			{
				this._beginDate = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00002AB2 File Offset: 0x00000CB2
		// (set) Token: 0x06000135 RID: 309 RVA: 0x00002ABA File Offset: 0x00000CBA
		public int ValidDate
		{
			get
			{
				return this._validDate;
			}
			set
			{
				this._validDate = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00002ACA File Offset: 0x00000CCA
		// (set) Token: 0x06000137 RID: 311 RVA: 0x00002AD2 File Offset: 0x00000CD2
		public int ValidCount
		{
			get
			{
				return this._validCount;
			}
			set
			{
				this._validCount = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00002AE2 File Offset: 0x00000CE2
		// (set) Token: 0x06000139 RID: 313 RVA: 0x00002AEA File Offset: 0x00000CEA
		public string Data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00002AFA File Offset: 0x00000CFA
		// (set) Token: 0x0600013B RID: 315 RVA: 0x00002B02 File Offset: 0x00000D02
		public bool IsExist
		{
			get
			{
				return this._isExist;
			}
			set
			{
				this._isExist = value;
				this._isDirty = true;
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00002B12 File Offset: 0x00000D12
		public DateTime GetEndDate()
		{
			return this._beginDate.AddMinutes((double)this._validDate);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00002B26 File Offset: 0x00000D26
		public bool IsValid()
		{
			return this._beginDate.AddMinutes((double)this._validDate) > DateTime.Now;
		}

		// Token: 0x04000113 RID: 275
		private int _userID;

		// Token: 0x04000114 RID: 276
		private int _type;

		// Token: 0x04000115 RID: 277
		private int _value;

		// Token: 0x04000116 RID: 278
		private DateTime _beginDate;

		// Token: 0x04000117 RID: 279
		private int _validDate;

		// Token: 0x04000118 RID: 280
		private int _validCount;

		// Token: 0x04000119 RID: 281
		private string _data;

		// Token: 0x0400011A RID: 282
		private bool _isExist;
	}
}
