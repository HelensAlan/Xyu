using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200000B RID: 11
	public class ActiveInfo
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00002497 File Offset: 0x00000697
		// (set) Token: 0x06000080 RID: 128 RVA: 0x0000249F File Offset: 0x0000069F
		public int ActiveID { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000024A8 File Offset: 0x000006A8
		// (set) Token: 0x06000082 RID: 130 RVA: 0x000024B0 File Offset: 0x000006B0
		public string Title { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000083 RID: 131 RVA: 0x000024B9 File Offset: 0x000006B9
		// (set) Token: 0x06000084 RID: 132 RVA: 0x000024C1 File Offset: 0x000006C1
		public string Description { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000085 RID: 133 RVA: 0x000024CA File Offset: 0x000006CA
		// (set) Token: 0x06000086 RID: 134 RVA: 0x000024D2 File Offset: 0x000006D2
		public string Content { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000087 RID: 135 RVA: 0x000024DB File Offset: 0x000006DB
		// (set) Token: 0x06000088 RID: 136 RVA: 0x000024E3 File Offset: 0x000006E3
		public string AwardContent { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000089 RID: 137 RVA: 0x000024EC File Offset: 0x000006EC
		// (set) Token: 0x0600008A RID: 138 RVA: 0x000024F4 File Offset: 0x000006F4
		public int HasKey { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600008B RID: 139 RVA: 0x000024FD File Offset: 0x000006FD
		// (set) Token: 0x0600008C RID: 140 RVA: 0x00002505 File Offset: 0x00000705
		public DateTime StartDate { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600008D RID: 141 RVA: 0x0000250E File Offset: 0x0000070E
		// (set) Token: 0x0600008E RID: 142 RVA: 0x00002516 File Offset: 0x00000716
		public DateTime EndDate { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600008F RID: 143 RVA: 0x0000251F File Offset: 0x0000071F
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00002527 File Offset: 0x00000727
		public bool IsOnly { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00002530 File Offset: 0x00000730
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00002538 File Offset: 0x00000738
		public int Type { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00002541 File Offset: 0x00000741
		// (set) Token: 0x06000094 RID: 148 RVA: 0x00002549 File Offset: 0x00000749
		public int ActiveType { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00002552 File Offset: 0x00000752
		// (set) Token: 0x06000096 RID: 150 RVA: 0x0000255A File Offset: 0x0000075A
		public string ActionTimeContent { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00002563 File Offset: 0x00000763
		// (set) Token: 0x06000098 RID: 152 RVA: 0x0000256B File Offset: 0x0000076B
		public bool IsAdvance { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00002574 File Offset: 0x00000774
		// (set) Token: 0x0600009A RID: 154 RVA: 0x0000257C File Offset: 0x0000077C
		public string GoodsExchangeTypes { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00002585 File Offset: 0x00000785
		// (set) Token: 0x0600009C RID: 156 RVA: 0x0000258D File Offset: 0x0000078D
		public string GoodsExchangeNum { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00002596 File Offset: 0x00000796
		// (set) Token: 0x0600009E RID: 158 RVA: 0x0000259E File Offset: 0x0000079E
		public string limitType { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600009F RID: 159 RVA: 0x000025A7 File Offset: 0x000007A7
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x000025AF File Offset: 0x000007AF
		public string limitValue { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x000025B8 File Offset: 0x000007B8
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x000025C0 File Offset: 0x000007C0
		public bool IsShow { get; set; }
	}
}
