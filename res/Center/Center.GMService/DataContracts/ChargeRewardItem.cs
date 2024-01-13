using System;
using System.Runtime.Serialization;

namespace Center.GMService.DataContracts
{
	// Token: 0x0200000A RID: 10
	[DataContract]
	public class ChargeRewardItem
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00003EBE File Offset: 0x000020BE
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00003EC6 File Offset: 0x000020C6
		[DataMember]
		public int GiftPackageID { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00003ECF File Offset: 0x000020CF
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00003ED7 File Offset: 0x000020D7
		[DataMember]
		public int TemplateID { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00003EE0 File Offset: 0x000020E0
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00003EE8 File Offset: 0x000020E8
		[DataMember]
		public int Count { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00003EF1 File Offset: 0x000020F1
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00003EF9 File Offset: 0x000020F9
		[DataMember]
		public int ValidDate { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00003F02 File Offset: 0x00002102
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00003F0A File Offset: 0x0000210A
		[DataMember]
		public int StrengthLevel { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00003F13 File Offset: 0x00002113
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00003F1B File Offset: 0x0000211B
		[DataMember]
		public int AttackCompose { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00003F24 File Offset: 0x00002124
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00003F2C File Offset: 0x0000212C
		[DataMember]
		public int DefendCompose { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00003F35 File Offset: 0x00002135
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00003F3D File Offset: 0x0000213D
		[DataMember]
		public int LuckCompose { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00003F46 File Offset: 0x00002146
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00003F4E File Offset: 0x0000214E
		[DataMember]
		public int AgilityCompose { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00003F57 File Offset: 0x00002157
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00003F5F File Offset: 0x0000215F
		[DataMember]
		public int Money { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00003F68 File Offset: 0x00002168
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00003F70 File Offset: 0x00002170
		[DataMember]
		public int Gold { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00003F79 File Offset: 0x00002179
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00003F81 File Offset: 0x00002181
		[DataMember]
		public int GiftToken { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00003F8A File Offset: 0x0000218A
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00003F92 File Offset: 0x00002192
		[DataMember]
		public bool IsBind { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00003F9B File Offset: 0x0000219B
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00003FA3 File Offset: 0x000021A3
		[DataMember]
		public int NeedSex { get; set; }

		// Token: 0x0600004C RID: 76 RVA: 0x00003FAC File Offset: 0x000021AC
		public ChargeRewardItem()
		{
			this.Count = 1;
			this.IsBind = true;
			this.StrengthLevel = 0;
			this.AttackCompose = 0;
			this.DefendCompose = 0;
			this.LuckCompose = 0;
			this.AgilityCompose = 0;
			this.Money = 0;
			this.Gold = 0;
			this.GiftToken = 0;
		}
	}
}
