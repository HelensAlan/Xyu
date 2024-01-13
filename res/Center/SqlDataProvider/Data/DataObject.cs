using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000025 RID: 37
	public class DataObject
	{
		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000325 RID: 805 RVA: 0x00003C17 File Offset: 0x00001E17
		// (set) Token: 0x06000326 RID: 806 RVA: 0x00003C1F File Offset: 0x00001E1F
		public bool IsDirty
		{
			get
			{
				return this._isDirty;
			}
			set
			{
				this._isDirty = value;
			}
		}

		// Token: 0x04000205 RID: 517
		protected bool _isDirty;
	}
}
