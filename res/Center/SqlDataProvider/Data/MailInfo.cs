using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200003E RID: 62
	public class MailInfo
	{
		// Token: 0x1700029F RID: 671
		// (get) Token: 0x06000580 RID: 1408 RVA: 0x000059C2 File Offset: 0x00003BC2
		// (set) Token: 0x06000581 RID: 1409 RVA: 0x000059CA File Offset: 0x00003BCA
		public int ID { get; set; }

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06000582 RID: 1410 RVA: 0x000059D3 File Offset: 0x00003BD3
		// (set) Token: 0x06000583 RID: 1411 RVA: 0x000059DB File Offset: 0x00003BDB
		public int SenderID { get; set; }

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x000059E4 File Offset: 0x00003BE4
		// (set) Token: 0x06000585 RID: 1413 RVA: 0x000059EC File Offset: 0x00003BEC
		public string Sender { get; set; }

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000586 RID: 1414 RVA: 0x000059F5 File Offset: 0x00003BF5
		// (set) Token: 0x06000587 RID: 1415 RVA: 0x000059FD File Offset: 0x00003BFD
		public int ReceiverID { get; set; }

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x00005A06 File Offset: 0x00003C06
		// (set) Token: 0x06000589 RID: 1417 RVA: 0x00005A0E File Offset: 0x00003C0E
		public string Receiver { get; set; }

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x00005A17 File Offset: 0x00003C17
		// (set) Token: 0x0600058B RID: 1419 RVA: 0x00005A1F File Offset: 0x00003C1F
		public string Title { get; set; }

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x00005A28 File Offset: 0x00003C28
		// (set) Token: 0x0600058D RID: 1421 RVA: 0x00005A30 File Offset: 0x00003C30
		public string Content { get; set; }

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x00005A39 File Offset: 0x00003C39
		// (set) Token: 0x0600058F RID: 1423 RVA: 0x00005A41 File Offset: 0x00003C41
		public string Annex1 { get; set; }

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x00005A4A File Offset: 0x00003C4A
		// (set) Token: 0x06000591 RID: 1425 RVA: 0x00005A52 File Offset: 0x00003C52
		public string Annex2 { get; set; }

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x00005A5B File Offset: 0x00003C5B
		// (set) Token: 0x06000593 RID: 1427 RVA: 0x00005A63 File Offset: 0x00003C63
		public int Gold { get; set; }

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x00005A6C File Offset: 0x00003C6C
		// (set) Token: 0x06000595 RID: 1429 RVA: 0x00005A74 File Offset: 0x00003C74
		public int Money { get; set; }

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x00005A7D File Offset: 0x00003C7D
		// (set) Token: 0x06000597 RID: 1431 RVA: 0x00005A85 File Offset: 0x00003C85
		public int GiftToken { get; set; }

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000598 RID: 1432 RVA: 0x00005A8E File Offset: 0x00003C8E
		// (set) Token: 0x06000599 RID: 1433 RVA: 0x00005A96 File Offset: 0x00003C96
		public bool IsExist { get; set; }

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x00005A9F File Offset: 0x00003C9F
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x00005AA7 File Offset: 0x00003CA7
		public int Type { get; set; }

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x00005AB0 File Offset: 0x00003CB0
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x00005AB8 File Offset: 0x00003CB8
		public int ValidDate { get; set; }

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x00005AC1 File Offset: 0x00003CC1
		// (set) Token: 0x0600059F RID: 1439 RVA: 0x00005AC9 File Offset: 0x00003CC9
		public bool IsRead { get; set; }

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x00005AD2 File Offset: 0x00003CD2
		// (set) Token: 0x060005A1 RID: 1441 RVA: 0x00005ADA File Offset: 0x00003CDA
		public DateTime SendTime { get; set; }

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x00005AE3 File Offset: 0x00003CE3
		// (set) Token: 0x060005A3 RID: 1443 RVA: 0x00005AEB File Offset: 0x00003CEB
		public string Annex1Name { get; set; }

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x060005A4 RID: 1444 RVA: 0x00005AF4 File Offset: 0x00003CF4
		// (set) Token: 0x060005A5 RID: 1445 RVA: 0x00005AFC File Offset: 0x00003CFC
		public string Annex2Name { get; set; }

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x060005A6 RID: 1446 RVA: 0x00005B05 File Offset: 0x00003D05
		// (set) Token: 0x060005A7 RID: 1447 RVA: 0x00005B0D File Offset: 0x00003D0D
		public string Annex3 { get; set; }

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x00005B16 File Offset: 0x00003D16
		// (set) Token: 0x060005A9 RID: 1449 RVA: 0x00005B1E File Offset: 0x00003D1E
		public string Annex4 { get; set; }

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x00005B27 File Offset: 0x00003D27
		// (set) Token: 0x060005AB RID: 1451 RVA: 0x00005B2F File Offset: 0x00003D2F
		public string Annex5 { get; set; }

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x00005B38 File Offset: 0x00003D38
		// (set) Token: 0x060005AD RID: 1453 RVA: 0x00005B40 File Offset: 0x00003D40
		public string Annex3Name { get; set; }

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x060005AE RID: 1454 RVA: 0x00005B49 File Offset: 0x00003D49
		// (set) Token: 0x060005AF RID: 1455 RVA: 0x00005B51 File Offset: 0x00003D51
		public string Annex4Name { get; set; }

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x00005B5A File Offset: 0x00003D5A
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x00005B62 File Offset: 0x00003D62
		public string Annex5Name { get; set; }

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x00005B6B File Offset: 0x00003D6B
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x00005B73 File Offset: 0x00003D73
		public string AnnexRemark { get; set; }

		// Token: 0x060005B4 RID: 1460 RVA: 0x00005B7C File Offset: 0x00003D7C
		public void Revert()
		{
			this.ID = 0;
			this.SenderID = 0;
			this.Sender = "";
			this.ReceiverID = 0;
			this.Receiver = "";
			this.Title = "";
			this.Content = "";
			this.Annex1 = "";
			this.Annex2 = "";
			this.Gold = 0;
			this.Money = 0;
			this.GiftToken = 0;
			this.IsExist = false;
			this.Type = 0;
			this.ValidDate = 0;
			this.IsRead = false;
			this.SendTime = DateTime.Now;
			this.Annex1Name = "";
			this.Annex2Name = "";
			this.Annex3 = "";
			this.Annex4 = "";
			this.Annex5 = "";
			this.Annex3Name = "";
			this.Annex4Name = "";
			this.Annex5Name = "";
			this.AnnexRemark = "";
		}
	}
}
