using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000036 RID: 54
	public class ItemJoinShopInfo
	{
		// Token: 0x1700023D RID: 573
		// (get) Token: 0x060004B4 RID: 1204 RVA: 0x0000523D File Offset: 0x0000343D
		// (set) Token: 0x060004B5 RID: 1205 RVA: 0x00005245 File Offset: 0x00003445
		public int TemplateID { get; set; }

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x0000524E File Offset: 0x0000344E
		// (set) Token: 0x060004B7 RID: 1207 RVA: 0x00005256 File Offset: 0x00003456
		public int Data { get; set; }

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x0000525F File Offset: 0x0000345F
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x00005267 File Offset: 0x00003467
		public int Moneys { get; set; }

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x00005270 File Offset: 0x00003470
		// (set) Token: 0x060004BB RID: 1211 RVA: 0x00005278 File Offset: 0x00003478
		public int Gold { get; set; }

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x00005281 File Offset: 0x00003481
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x00005289 File Offset: 0x00003489
		public int GiftToken { get; set; }

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x00005292 File Offset: 0x00003492
		// (set) Token: 0x060004BF RID: 1215 RVA: 0x0000529A File Offset: 0x0000349A
		public int Offer { get; set; }

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x000052A3 File Offset: 0x000034A3
		// (set) Token: 0x060004C1 RID: 1217 RVA: 0x000052AB File Offset: 0x000034AB
		public string OtherPay { get; set; }

		// Token: 0x060004C2 RID: 1218 RVA: 0x000052B4 File Offset: 0x000034B4
		public ItemJoinShopInfo(int templateID, int data, int moneys, int gold, int giftToken, int offer, string otherPay)
		{
			this.TemplateID = templateID;
			this.Data = data;
			this.Moneys = moneys;
			this.Gold = gold;
			this.GiftToken = giftToken;
			this.Offer = offer;
			this.OtherPay = otherPay;
		}
	}
}
