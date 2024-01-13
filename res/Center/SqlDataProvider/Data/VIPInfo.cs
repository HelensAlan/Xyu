using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200006A RID: 106
	public class VIPInfo
	{
		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x06000ADD RID: 2781 RVA: 0x000096D6 File Offset: 0x000078D6
		// (set) Token: 0x06000ADE RID: 2782 RVA: 0x000096DE File Offset: 0x000078DE
		public int UserID { get; set; }

		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x06000ADF RID: 2783 RVA: 0x000096E7 File Offset: 0x000078E7
		// (set) Token: 0x06000AE0 RID: 2784 RVA: 0x000096EF File Offset: 0x000078EF
		public int TypeVIP { get; set; }

		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x06000AE1 RID: 2785 RVA: 0x000096F8 File Offset: 0x000078F8
		// (set) Token: 0x06000AE2 RID: 2786 RVA: 0x00009700 File Offset: 0x00007900
		public int VIPLevel { get; set; }

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x06000AE3 RID: 2787 RVA: 0x00009709 File Offset: 0x00007909
		// (set) Token: 0x06000AE4 RID: 2788 RVA: 0x00009711 File Offset: 0x00007911
		public int VIPExp { get; set; }

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x06000AE5 RID: 2789 RVA: 0x0000971A File Offset: 0x0000791A
		// (set) Token: 0x06000AE6 RID: 2790 RVA: 0x00009722 File Offset: 0x00007922
		public DateTime VIPExpireDay
		{
			get
			{
				return this._vipExpireDay;
			}
			set
			{
				this._vipExpireDay = value;
				if (this._vipExpireDay < DateTime.Now)
				{
					this.TypeVIP = 0;
				}
			}
		}

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x06000AE7 RID: 2791 RVA: 0x00009744 File Offset: 0x00007944
		// (set) Token: 0x06000AE8 RID: 2792 RVA: 0x0000974C File Offset: 0x0000794C
		public int VIPNextLevelDaysNeeded { get; set; }

		// Token: 0x040005BE RID: 1470
		private DateTime _vipExpireDay;
	}
}
