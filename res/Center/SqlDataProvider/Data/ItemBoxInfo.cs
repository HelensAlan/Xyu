using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000034 RID: 52
	public class ItemBoxInfo : DataObject
	{
		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x00004535 File Offset: 0x00002735
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x0000453D File Offset: 0x0000273D
		public int Id { get; set; }

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x00004546 File Offset: 0x00002746
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x0000454E File Offset: 0x0000274E
		public int DataId { get; set; }

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x00004557 File Offset: 0x00002757
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x0000455F File Offset: 0x0000275F
		public int TemplateId { get; set; }

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x00004568 File Offset: 0x00002768
		// (set) Token: 0x0600043C RID: 1084 RVA: 0x00004570 File Offset: 0x00002770
		public bool IsSelect { get; set; }

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00004579 File Offset: 0x00002779
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x00004581 File Offset: 0x00002781
		public bool IsBind { get; set; }

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x0000458A File Offset: 0x0000278A
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x00004592 File Offset: 0x00002792
		public int ItemValid { get; set; }

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x0000459B File Offset: 0x0000279B
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x000045A3 File Offset: 0x000027A3
		public int ItemCount { get; set; }

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x000045AC File Offset: 0x000027AC
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x000045B4 File Offset: 0x000027B4
		public int StrengthenLevel { get; set; }

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x000045BD File Offset: 0x000027BD
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x000045C5 File Offset: 0x000027C5
		public int AttackCompose { get; set; }

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x000045CE File Offset: 0x000027CE
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x000045D6 File Offset: 0x000027D6
		public int DefendCompose { get; set; }

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x000045DF File Offset: 0x000027DF
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x000045E7 File Offset: 0x000027E7
		public int AgilityCompose { get; set; }

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x000045F0 File Offset: 0x000027F0
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x000045F8 File Offset: 0x000027F8
		public int LuckCompose { get; set; }

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x00004601 File Offset: 0x00002801
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x00004609 File Offset: 0x00002809
		public int Random { get; set; }

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x00004612 File Offset: 0x00002812
		// (set) Token: 0x06000450 RID: 1104 RVA: 0x0000461A File Offset: 0x0000281A
		public bool IsTips { get; set; }

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x00004623 File Offset: 0x00002823
		// (set) Token: 0x06000452 RID: 1106 RVA: 0x0000462B File Offset: 0x0000282B
		public bool IsLogs { get; set; }
	}
}
