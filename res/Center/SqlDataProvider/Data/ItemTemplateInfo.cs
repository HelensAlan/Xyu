using System;
using System.Runtime.CompilerServices;
using Lsj.Util.Text;

namespace SqlDataProvider.Data
{
	// Token: 0x02000038 RID: 56
	public class ItemTemplateInfo : DataObject
	{
		// Token: 0x17000247 RID: 583
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x0000532C File Offset: 0x0000352C
		// (set) Token: 0x060004CB RID: 1227 RVA: 0x00005334 File Offset: 0x00003534
		public int TemplateID { get; set; }

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x0000533D File Offset: 0x0000353D
		// (set) Token: 0x060004CD RID: 1229 RVA: 0x00005345 File Offset: 0x00003545
		public string Name { get; set; }

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x0000534E File Offset: 0x0000354E
		// (set) Token: 0x060004CF RID: 1231 RVA: 0x00005356 File Offset: 0x00003556
		public int CategoryID { get; set; }

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x0000535F File Offset: 0x0000355F
		// (set) Token: 0x060004D1 RID: 1233 RVA: 0x00005367 File Offset: 0x00003567
		public string Description { get; set; }

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x00005370 File Offset: 0x00003570
		// (set) Token: 0x060004D3 RID: 1235 RVA: 0x00005378 File Offset: 0x00003578
		public int Attack { get; set; }

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x00005381 File Offset: 0x00003581
		// (set) Token: 0x060004D5 RID: 1237 RVA: 0x00005389 File Offset: 0x00003589
		public int Defence { get; set; }

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x00005392 File Offset: 0x00003592
		// (set) Token: 0x060004D7 RID: 1239 RVA: 0x0000539A File Offset: 0x0000359A
		public int Luck { get; set; }

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x000053A3 File Offset: 0x000035A3
		// (set) Token: 0x060004D9 RID: 1241 RVA: 0x000053AB File Offset: 0x000035AB
		public int Agility { get; set; }

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x000053B4 File Offset: 0x000035B4
		// (set) Token: 0x060004DB RID: 1243 RVA: 0x000053BC File Offset: 0x000035BC
		public int Level { get; set; }

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x060004DC RID: 1244 RVA: 0x000053C5 File Offset: 0x000035C5
		// (set) Token: 0x060004DD RID: 1245 RVA: 0x000053CD File Offset: 0x000035CD
		public string Pic { get; set; }

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x000053D6 File Offset: 0x000035D6
		// (set) Token: 0x060004DF RID: 1247 RVA: 0x000053DE File Offset: 0x000035DE
		public string AddTime { get; set; }

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x000053E7 File Offset: 0x000035E7
		// (set) Token: 0x060004E1 RID: 1249 RVA: 0x000053EF File Offset: 0x000035EF
		public int Quality { get; set; }

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x000053F8 File Offset: 0x000035F8
		// (set) Token: 0x060004E3 RID: 1251 RVA: 0x00005400 File Offset: 0x00003600
		public int MaxCount { get; set; }

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x060004E4 RID: 1252 RVA: 0x00005409 File Offset: 0x00003609
		// (set) Token: 0x060004E5 RID: 1253 RVA: 0x00005411 File Offset: 0x00003611
		public string Data { get; set; }

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0000541A File Offset: 0x0000361A
		// (set) Token: 0x060004E7 RID: 1255 RVA: 0x00005422 File Offset: 0x00003622
		public int Property1 { get; set; }

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x060004E8 RID: 1256 RVA: 0x0000542B File Offset: 0x0000362B
		// (set) Token: 0x060004E9 RID: 1257 RVA: 0x00005433 File Offset: 0x00003633
		public int Property2 { get; set; }

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x0000543C File Offset: 0x0000363C
		// (set) Token: 0x060004EB RID: 1259 RVA: 0x00005444 File Offset: 0x00003644
		public int Property3 { get; set; }

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x0000544D File Offset: 0x0000364D
		// (set) Token: 0x060004ED RID: 1261 RVA: 0x00005455 File Offset: 0x00003655
		public int Property4 { get; set; }

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x060004EE RID: 1262 RVA: 0x0000545E File Offset: 0x0000365E
		// (set) Token: 0x060004EF RID: 1263 RVA: 0x00005466 File Offset: 0x00003666
		public int Property5 { get; set; }

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x0000546F File Offset: 0x0000366F
		// (set) Token: 0x060004F1 RID: 1265 RVA: 0x00005477 File Offset: 0x00003677
		public int Property6 { get; set; }

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x060004F2 RID: 1266 RVA: 0x00005480 File Offset: 0x00003680
		// (set) Token: 0x060004F3 RID: 1267 RVA: 0x00005488 File Offset: 0x00003688
		public int Property7 { get; set; }

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x00005491 File Offset: 0x00003691
		// (set) Token: 0x060004F5 RID: 1269 RVA: 0x00005499 File Offset: 0x00003699
		public int Property8 { get; set; }

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x000054A2 File Offset: 0x000036A2
		// (set) Token: 0x060004F7 RID: 1271 RVA: 0x000054AA File Offset: 0x000036AA
		public int NeedSex { get; set; }

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x000054B3 File Offset: 0x000036B3
		// (set) Token: 0x060004F9 RID: 1273 RVA: 0x000054BB File Offset: 0x000036BB
		public int NeedLevel { get; set; }

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x060004FA RID: 1274 RVA: 0x000054C4 File Offset: 0x000036C4
		// (set) Token: 0x060004FB RID: 1275 RVA: 0x000054CC File Offset: 0x000036CC
		public bool CanDrop { get; set; }

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x000054D5 File Offset: 0x000036D5
		// (set) Token: 0x060004FD RID: 1277 RVA: 0x000054DD File Offset: 0x000036DD
		public bool CanDelete { get; set; }

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x000054E6 File Offset: 0x000036E6
		// (set) Token: 0x060004FF RID: 1279 RVA: 0x000054EE File Offset: 0x000036EE
		public bool CanEquip { get; set; }

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x000054F7 File Offset: 0x000036F7
		// (set) Token: 0x06000501 RID: 1281 RVA: 0x000054FF File Offset: 0x000036FF
		public bool CanUse { get; set; }

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x00005508 File Offset: 0x00003708
		// (set) Token: 0x06000503 RID: 1283 RVA: 0x00005510 File Offset: 0x00003710
		public string Script { get; set; }

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x00005519 File Offset: 0x00003719
		// (set) Token: 0x06000505 RID: 1285 RVA: 0x00005521 File Offset: 0x00003721
		public string Colors { get; set; }

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x0000552A File Offset: 0x0000372A
		// (set) Token: 0x06000507 RID: 1287 RVA: 0x00005532 File Offset: 0x00003732
		public bool CanStrengthen { get; set; }

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x0000553B File Offset: 0x0000373B
		// (set) Token: 0x06000509 RID: 1289 RVA: 0x00005543 File Offset: 0x00003743
		public bool CanCompose { get; set; }

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x0000554C File Offset: 0x0000374C
		// (set) Token: 0x0600050B RID: 1291 RVA: 0x00005554 File Offset: 0x00003754
		public int BindType { get; set; }

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x0000555D File Offset: 0x0000375D
		// (set) Token: 0x0600050D RID: 1293 RVA: 0x00005565 File Offset: 0x00003765
		public int FusionType { get; set; }

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x0000556E File Offset: 0x0000376E
		// (set) Token: 0x0600050F RID: 1295 RVA: 0x00005576 File Offset: 0x00003776
		public int FusionRate { get; set; }

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000510 RID: 1296 RVA: 0x0000557F File Offset: 0x0000377F
		// (set) Token: 0x06000511 RID: 1297 RVA: 0x00005587 File Offset: 0x00003787
		public int FusionNeedRate { get; set; }

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000512 RID: 1298 RVA: 0x00005590 File Offset: 0x00003790
		// (set) Token: 0x06000513 RID: 1299 RVA: 0x00005598 File Offset: 0x00003798
		public int RefineryType { get; set; }

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000514 RID: 1300 RVA: 0x000055A1 File Offset: 0x000037A1
		// (set) Token: 0x06000515 RID: 1301 RVA: 0x000055A9 File Offset: 0x000037A9
		public string Hole { get; set; }

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x000055B2 File Offset: 0x000037B2
		// (set) Token: 0x06000517 RID: 1303 RVA: 0x000055BA File Offset: 0x000037BA
		public int RefineryLevel { get; set; }

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x000055C4 File Offset: 0x000037C4
		public eBageType BagType
		{
			get
			{
				int categoryID = this.CategoryID;
				if (categoryID <= 20)
				{
					if (categoryID - 10 > 2 && categoryID != 20)
					{
						goto IL_28;
					}
				}
				else if (categoryID != 23 && categoryID != 25)
				{
					goto IL_28;
				}
				return eBageType.PropBag;
				IL_28:
				return eBageType.MainBag;
			}
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x000055FC File Offset: 0x000037FC
		// (set) Token: 0x0600051A RID: 1306 RVA: 0x00005604 File Offset: 0x00003804
		public int ReclaimValue { get; set; }

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0000560D File Offset: 0x0000380D
		// (set) Token: 0x0600051C RID: 1308 RVA: 0x00005615 File Offset: 0x00003815
		public int ReclaimType { get; set; }

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x0000561E File Offset: 0x0000381E
		// (set) Token: 0x0600051E RID: 1310 RVA: 0x00005626 File Offset: 0x00003826
		public int CanRecycle { get; set; }

		// Token: 0x0600051F RID: 1311 RVA: 0x00005630 File Offset: 0x00003830
		[return: TupleElementNames(new string[] { "level", "type" })]
		public ValueTuple<int, int> GetHoleInfo(int num)
		{
			string[] holes = this.Hole.Split(new char[] { '|' });
			if (holes.Length >= num)
			{
				string[] info = holes[num - 1].Split(new char[] { ',' });
				if (info.Length == 2)
				{
					return new ValueTuple<int, int>(info[0].ConvertToInt(0), info[1].ConvertToInt(-1));
				}
			}
			return new ValueTuple<int, int>(0, -1);
		}
	}
}
