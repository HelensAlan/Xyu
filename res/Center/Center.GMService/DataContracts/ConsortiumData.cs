using System;
using System.Runtime.Serialization;

namespace Center.GMService.DataContracts
{
	// Token: 0x0200000C RID: 12
	[DataContract]
	public class ConsortiumData
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00004059 File Offset: 0x00002259
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00004061 File Offset: 0x00002261
		[DataMember]
		public int ConsortiaID { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000056 RID: 86 RVA: 0x0000406A File Offset: 0x0000226A
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00004072 File Offset: 0x00002272
		[DataMember]
		public string ConsortiaName { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000058 RID: 88 RVA: 0x0000407B File Offset: 0x0000227B
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00004083 File Offset: 0x00002283
		[DataMember]
		public int Honor { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600005A RID: 90 RVA: 0x0000408C File Offset: 0x0000228C
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00004094 File Offset: 0x00002294
		[DataMember]
		public int CreatorID { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600005C RID: 92 RVA: 0x0000409D File Offset: 0x0000229D
		// (set) Token: 0x0600005D RID: 93 RVA: 0x000040A5 File Offset: 0x000022A5
		[DataMember]
		public string CreatorName { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600005E RID: 94 RVA: 0x000040AE File Offset: 0x000022AE
		// (set) Token: 0x0600005F RID: 95 RVA: 0x000040B6 File Offset: 0x000022B6
		[DataMember]
		public int ChairmanID { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000060 RID: 96 RVA: 0x000040BF File Offset: 0x000022BF
		// (set) Token: 0x06000061 RID: 97 RVA: 0x000040C7 File Offset: 0x000022C7
		[DataMember]
		public string ChairmanName { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000062 RID: 98 RVA: 0x000040D0 File Offset: 0x000022D0
		// (set) Token: 0x06000063 RID: 99 RVA: 0x000040D8 File Offset: 0x000022D8
		[DataMember]
		public string Description { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000040E1 File Offset: 0x000022E1
		// (set) Token: 0x06000065 RID: 101 RVA: 0x000040E9 File Offset: 0x000022E9
		[DataMember]
		public string Placard { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000040F2 File Offset: 0x000022F2
		// (set) Token: 0x06000067 RID: 103 RVA: 0x000040FA File Offset: 0x000022FA
		[DataMember]
		public int Level { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00004103 File Offset: 0x00002303
		// (set) Token: 0x06000069 RID: 105 RVA: 0x0000410B File Offset: 0x0000230B
		[DataMember]
		public int MaxCount { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00004114 File Offset: 0x00002314
		// (set) Token: 0x0600006B RID: 107 RVA: 0x0000411C File Offset: 0x0000231C
		[DataMember]
		public int CelebCount { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00004125 File Offset: 0x00002325
		// (set) Token: 0x0600006D RID: 109 RVA: 0x0000412D File Offset: 0x0000232D
		[DataMember]
		public DateTime BuildDate { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00004136 File Offset: 0x00002336
		// (set) Token: 0x0600006F RID: 111 RVA: 0x0000413E File Offset: 0x0000233E
		[DataMember]
		public int Repute { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00004147 File Offset: 0x00002347
		// (set) Token: 0x06000071 RID: 113 RVA: 0x0000414F File Offset: 0x0000234F
		[DataMember]
		public int Count { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00004158 File Offset: 0x00002358
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00004160 File Offset: 0x00002360
		[DataMember]
		public string IP { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00004169 File Offset: 0x00002369
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00004171 File Offset: 0x00002371
		[DataMember]
		public int Port { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000076 RID: 118 RVA: 0x0000417A File Offset: 0x0000237A
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00004182 File Offset: 0x00002382
		[DataMember]
		public bool IsExist { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000078 RID: 120 RVA: 0x0000418B File Offset: 0x0000238B
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00004193 File Offset: 0x00002393
		[DataMember]
		public int Riches { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600007A RID: 122 RVA: 0x0000419C File Offset: 0x0000239C
		// (set) Token: 0x0600007B RID: 123 RVA: 0x000041A4 File Offset: 0x000023A4
		[DataMember]
		public DateTime DeductDate { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600007C RID: 124 RVA: 0x000041AD File Offset: 0x000023AD
		// (set) Token: 0x0600007D RID: 125 RVA: 0x000041B5 File Offset: 0x000023B5
		[DataMember]
		public int AddDayRiches { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600007E RID: 126 RVA: 0x000041BE File Offset: 0x000023BE
		// (set) Token: 0x0600007F RID: 127 RVA: 0x000041C6 File Offset: 0x000023C6
		[DataMember]
		public int AddWeekRiches { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000080 RID: 128 RVA: 0x000041CF File Offset: 0x000023CF
		// (set) Token: 0x06000081 RID: 129 RVA: 0x000041D7 File Offset: 0x000023D7
		[DataMember]
		public int AddDayHonor { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000082 RID: 130 RVA: 0x000041E0 File Offset: 0x000023E0
		// (set) Token: 0x06000083 RID: 131 RVA: 0x000041E8 File Offset: 0x000023E8
		[DataMember]
		public int AddWeekHonor { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000084 RID: 132 RVA: 0x000041F1 File Offset: 0x000023F1
		// (set) Token: 0x06000085 RID: 133 RVA: 0x000041F9 File Offset: 0x000023F9
		[DataMember]
		public int LastDayRiches { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00004202 File Offset: 0x00002402
		// (set) Token: 0x06000087 RID: 135 RVA: 0x0000420A File Offset: 0x0000240A
		[DataMember]
		public bool OpenApply { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00004213 File Offset: 0x00002413
		// (set) Token: 0x06000089 RID: 137 RVA: 0x0000421B File Offset: 0x0000241B
		[DataMember]
		public int BufferLevel { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00004224 File Offset: 0x00002424
		// (set) Token: 0x0600008B RID: 139 RVA: 0x0000422C File Offset: 0x0000242C
		[DataMember]
		public int ShopLevel { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600008C RID: 140 RVA: 0x00004235 File Offset: 0x00002435
		// (set) Token: 0x0600008D RID: 141 RVA: 0x0000423D File Offset: 0x0000243D
		[DataMember]
		public int SmithLevel { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00004246 File Offset: 0x00002446
		// (set) Token: 0x0600008F RID: 143 RVA: 0x0000424E File Offset: 0x0000244E
		[DataMember]
		public int StoreLevel { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00004257 File Offset: 0x00002457
		// (set) Token: 0x06000091 RID: 145 RVA: 0x0000425F File Offset: 0x0000245F
		[DataMember]
		public int FightPower { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00004268 File Offset: 0x00002468
		// (set) Token: 0x06000093 RID: 147 RVA: 0x00004270 File Offset: 0x00002470
		[DataMember]
		public bool IsSystemCreate { get; set; }
	}
}
