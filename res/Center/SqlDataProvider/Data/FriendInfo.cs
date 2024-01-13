using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000030 RID: 48
	public class FriendInfo : DataObject
	{
		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x000041A1 File Offset: 0x000023A1
		// (set) Token: 0x060003CA RID: 970 RVA: 0x000041A9 File Offset: 0x000023A9
		public int ID { get; set; }

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060003CB RID: 971 RVA: 0x000041B2 File Offset: 0x000023B2
		// (set) Token: 0x060003CC RID: 972 RVA: 0x000041BA File Offset: 0x000023BA
		public int UserID { get; set; }

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x060003CD RID: 973 RVA: 0x000041C3 File Offset: 0x000023C3
		// (set) Token: 0x060003CE RID: 974 RVA: 0x000041CB File Offset: 0x000023CB
		public int FriendID { get; set; }

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x060003CF RID: 975 RVA: 0x000041D4 File Offset: 0x000023D4
		// (set) Token: 0x060003D0 RID: 976 RVA: 0x000041DC File Offset: 0x000023DC
		public DateTime AddDate { get; set; }

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x000041E5 File Offset: 0x000023E5
		// (set) Token: 0x060003D2 RID: 978 RVA: 0x000041ED File Offset: 0x000023ED
		public string Remark { get; set; }

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x060003D3 RID: 979 RVA: 0x000041F6 File Offset: 0x000023F6
		// (set) Token: 0x060003D4 RID: 980 RVA: 0x000041FE File Offset: 0x000023FE
		public bool IsExist { get; set; }

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x00004207 File Offset: 0x00002407
		// (set) Token: 0x060003D6 RID: 982 RVA: 0x0000420F File Offset: 0x0000240F
		public string NickName { get; set; }

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x00004218 File Offset: 0x00002418
		// (set) Token: 0x060003D8 RID: 984 RVA: 0x00004220 File Offset: 0x00002420
		public string UserName { get; set; }

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x00004229 File Offset: 0x00002429
		// (set) Token: 0x060003DA RID: 986 RVA: 0x00004231 File Offset: 0x00002431
		public string Style { get; set; }

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060003DB RID: 987 RVA: 0x0000423A File Offset: 0x0000243A
		// (set) Token: 0x060003DC RID: 988 RVA: 0x00004242 File Offset: 0x00002442
		public int Sex { get; set; }

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060003DD RID: 989 RVA: 0x0000424B File Offset: 0x0000244B
		// (set) Token: 0x060003DE RID: 990 RVA: 0x00004253 File Offset: 0x00002453
		public string DutyName { get; set; }

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060003DF RID: 991 RVA: 0x0000425C File Offset: 0x0000245C
		// (set) Token: 0x060003E0 RID: 992 RVA: 0x00004264 File Offset: 0x00002464
		public string Colors { get; set; }

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060003E1 RID: 993 RVA: 0x0000426D File Offset: 0x0000246D
		// (set) Token: 0x060003E2 RID: 994 RVA: 0x00004275 File Offset: 0x00002475
		public int Grade { get; set; }

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x0000427E File Offset: 0x0000247E
		// (set) Token: 0x060003E4 RID: 996 RVA: 0x00004286 File Offset: 0x00002486
		public int Hide { get; set; }

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x0000428F File Offset: 0x0000248F
		// (set) Token: 0x060003E6 RID: 998 RVA: 0x00004297 File Offset: 0x00002497
		public int State { get; set; }

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x000042A0 File Offset: 0x000024A0
		// (set) Token: 0x060003E8 RID: 1000 RVA: 0x000042A8 File Offset: 0x000024A8
		public int Offer { get; set; }

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x000042B1 File Offset: 0x000024B1
		// (set) Token: 0x060003EA RID: 1002 RVA: 0x000042B9 File Offset: 0x000024B9
		public string ConsortiaName { get; set; }

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x060003EB RID: 1003 RVA: 0x000042C2 File Offset: 0x000024C2
		// (set) Token: 0x060003EC RID: 1004 RVA: 0x000042CA File Offset: 0x000024CA
		public int Win { get; set; }

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x060003ED RID: 1005 RVA: 0x000042D3 File Offset: 0x000024D3
		// (set) Token: 0x060003EE RID: 1006 RVA: 0x000042DB File Offset: 0x000024DB
		public int Total { get; set; }

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x000042E4 File Offset: 0x000024E4
		// (set) Token: 0x060003F0 RID: 1008 RVA: 0x000042EC File Offset: 0x000024EC
		public int Escape { get; set; }

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x000042F5 File Offset: 0x000024F5
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x000042FD File Offset: 0x000024FD
		public int Relation { get; set; }

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x00004306 File Offset: 0x00002506
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x0000430E File Offset: 0x0000250E
		public int Repute { get; set; }

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x00004317 File Offset: 0x00002517
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x0000431F File Offset: 0x0000251F
		public int Nimbus { get; set; }

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x00004328 File Offset: 0x00002528
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x00004330 File Offset: 0x00002530
		public int AchievementPoint { get; set; }

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x00004339 File Offset: 0x00002539
		// (set) Token: 0x060003FA RID: 1018 RVA: 0x00004341 File Offset: 0x00002541
		public string Honor { get; set; }

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x0000434A File Offset: 0x0000254A
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x00004352 File Offset: 0x00002552
		public int FightPower { get; set; }

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x0000435B File Offset: 0x0000255B
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x00004363 File Offset: 0x00002563
		public int TypeVIP { get; set; }

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x0000436C File Offset: 0x0000256C
		// (set) Token: 0x06000400 RID: 1024 RVA: 0x00004374 File Offset: 0x00002574
		public int VIPLevel { get; set; }

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x0000437D File Offset: 0x0000257D
		// (set) Token: 0x06000402 RID: 1026 RVA: 0x00004385 File Offset: 0x00002585
		public bool IsMarried { get; set; }
	}
}
