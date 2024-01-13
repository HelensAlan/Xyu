using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000028 RID: 40
	public class DropItem
	{
		// Token: 0x1700018A RID: 394
		// (get) Token: 0x0600033A RID: 826 RVA: 0x00003CE5 File Offset: 0x00001EE5
		// (set) Token: 0x0600033B RID: 827 RVA: 0x00003CED File Offset: 0x00001EED
		public int Id { get; set; }

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x0600033C RID: 828 RVA: 0x00003CF6 File Offset: 0x00001EF6
		// (set) Token: 0x0600033D RID: 829 RVA: 0x00003CFE File Offset: 0x00001EFE
		public int DropId { get; set; }

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600033E RID: 830 RVA: 0x00003D07 File Offset: 0x00001F07
		// (set) Token: 0x0600033F RID: 831 RVA: 0x00003D0F File Offset: 0x00001F0F
		public int ItemId { get; set; }

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000340 RID: 832 RVA: 0x00003D18 File Offset: 0x00001F18
		// (set) Token: 0x06000341 RID: 833 RVA: 0x00003D20 File Offset: 0x00001F20
		public int ValueDate { get; set; }

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000342 RID: 834 RVA: 0x00003D29 File Offset: 0x00001F29
		// (set) Token: 0x06000343 RID: 835 RVA: 0x00003D31 File Offset: 0x00001F31
		public bool IsBind { get; set; }

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000344 RID: 836 RVA: 0x00003D3A File Offset: 0x00001F3A
		// (set) Token: 0x06000345 RID: 837 RVA: 0x00003D42 File Offset: 0x00001F42
		public int Random { get; set; }

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000346 RID: 838 RVA: 0x00003D4B File Offset: 0x00001F4B
		// (set) Token: 0x06000347 RID: 839 RVA: 0x00003D53 File Offset: 0x00001F53
		public int BeginData { get; set; }

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000348 RID: 840 RVA: 0x00003D5C File Offset: 0x00001F5C
		// (set) Token: 0x06000349 RID: 841 RVA: 0x00003D64 File Offset: 0x00001F64
		public int EndData { get; set; }

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x0600034A RID: 842 RVA: 0x00003D6D File Offset: 0x00001F6D
		// (set) Token: 0x0600034B RID: 843 RVA: 0x00003D75 File Offset: 0x00001F75
		public bool IsTips { get; set; }

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x0600034C RID: 844 RVA: 0x00003D7E File Offset: 0x00001F7E
		// (set) Token: 0x0600034D RID: 845 RVA: 0x00003D86 File Offset: 0x00001F86
		public bool IsLogs { get; set; }
	}
}
