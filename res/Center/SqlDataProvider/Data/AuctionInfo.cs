using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200000C RID: 12
	public class AuctionInfo
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x000025D1 File Offset: 0x000007D1
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x000025D9 File Offset: 0x000007D9
		public int AuctionID { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x000025E2 File Offset: 0x000007E2
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x000025EA File Offset: 0x000007EA
		public string Name { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x000025F3 File Offset: 0x000007F3
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x000025FB File Offset: 0x000007FB
		public int Category { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00002604 File Offset: 0x00000804
		// (set) Token: 0x060000AB RID: 171 RVA: 0x0000260C File Offset: 0x0000080C
		public int AuctioneerID { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00002615 File Offset: 0x00000815
		// (set) Token: 0x060000AD RID: 173 RVA: 0x0000261D File Offset: 0x0000081D
		public string AuctioneerName { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00002626 File Offset: 0x00000826
		// (set) Token: 0x060000AF RID: 175 RVA: 0x0000262E File Offset: 0x0000082E
		public int ItemID { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00002637 File Offset: 0x00000837
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x0000263F File Offset: 0x0000083F
		public int PayType { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x00002648 File Offset: 0x00000848
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x00002650 File Offset: 0x00000850
		public int Price { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x00002659 File Offset: 0x00000859
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x00002661 File Offset: 0x00000861
		public int Rise { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x0000266A File Offset: 0x0000086A
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x00002672 File Offset: 0x00000872
		public int Mouthful { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x0000267B File Offset: 0x0000087B
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x00002683 File Offset: 0x00000883
		public DateTime BeginDate { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000BA RID: 186 RVA: 0x0000268C File Offset: 0x0000088C
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00002694 File Offset: 0x00000894
		public int ValidDate { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000BC RID: 188 RVA: 0x0000269D File Offset: 0x0000089D
		// (set) Token: 0x060000BD RID: 189 RVA: 0x000026A5 File Offset: 0x000008A5
		public int BuyerID { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000BE RID: 190 RVA: 0x000026AE File Offset: 0x000008AE
		// (set) Token: 0x060000BF RID: 191 RVA: 0x000026B6 File Offset: 0x000008B6
		public string BuyerName { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x000026BF File Offset: 0x000008BF
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x000026C7 File Offset: 0x000008C7
		public bool IsExist { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x000026D0 File Offset: 0x000008D0
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x000026D8 File Offset: 0x000008D8
		public int TemplateID { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x000026E1 File Offset: 0x000008E1
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x000026E9 File Offset: 0x000008E9
		public int Random { get; set; }
	}
}
