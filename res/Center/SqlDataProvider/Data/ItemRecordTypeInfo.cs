using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000037 RID: 55
	public class ItemRecordTypeInfo
	{
		// Token: 0x17000244 RID: 580
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x000052F1 File Offset: 0x000034F1
		// (set) Token: 0x060004C4 RID: 1220 RVA: 0x000052F9 File Offset: 0x000034F9
		public int RecordID { get; set; }

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x00005302 File Offset: 0x00003502
		// (set) Token: 0x060004C6 RID: 1222 RVA: 0x0000530A File Offset: 0x0000350A
		public string Name { get; set; }

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x00005313 File Offset: 0x00003513
		// (set) Token: 0x060004C8 RID: 1224 RVA: 0x0000531B File Offset: 0x0000351B
		public string Description { get; set; }
	}
}
