using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000052 RID: 82
	public class PveInfo
	{
		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x060008CE RID: 2254 RVA: 0x00008450 File Offset: 0x00006650
		// (set) Token: 0x060008CF RID: 2255 RVA: 0x00008458 File Offset: 0x00006658
		public int ID { get; set; }

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x060008D0 RID: 2256 RVA: 0x00008461 File Offset: 0x00006661
		// (set) Token: 0x060008D1 RID: 2257 RVA: 0x00008469 File Offset: 0x00006669
		public string Name { get; set; }

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x060008D2 RID: 2258 RVA: 0x00008472 File Offset: 0x00006672
		// (set) Token: 0x060008D3 RID: 2259 RVA: 0x0000847A File Offset: 0x0000667A
		public string SimpleTemplateIds { get; set; }

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x060008D4 RID: 2260 RVA: 0x00008483 File Offset: 0x00006683
		// (set) Token: 0x060008D5 RID: 2261 RVA: 0x0000848B File Offset: 0x0000668B
		public string NormalTemplateIds { get; set; }

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x060008D6 RID: 2262 RVA: 0x00008494 File Offset: 0x00006694
		// (set) Token: 0x060008D7 RID: 2263 RVA: 0x0000849C File Offset: 0x0000669C
		public string HardTemplateIds { get; set; }

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x060008D8 RID: 2264 RVA: 0x000084A5 File Offset: 0x000066A5
		// (set) Token: 0x060008D9 RID: 2265 RVA: 0x000084AD File Offset: 0x000066AD
		public string TerrorTemplateIds { get; set; }

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x060008DA RID: 2266 RVA: 0x000084B6 File Offset: 0x000066B6
		// (set) Token: 0x060008DB RID: 2267 RVA: 0x000084BE File Offset: 0x000066BE
		public int Type { get; set; }

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x060008DC RID: 2268 RVA: 0x000084C7 File Offset: 0x000066C7
		// (set) Token: 0x060008DD RID: 2269 RVA: 0x000084CF File Offset: 0x000066CF
		public int LevelLimits { get; set; }

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x060008DE RID: 2270 RVA: 0x000084D8 File Offset: 0x000066D8
		// (set) Token: 0x060008DF RID: 2271 RVA: 0x000084E0 File Offset: 0x000066E0
		public string Pic { get; set; }

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x060008E0 RID: 2272 RVA: 0x000084E9 File Offset: 0x000066E9
		// (set) Token: 0x060008E1 RID: 2273 RVA: 0x000084F1 File Offset: 0x000066F1
		public string Description { get; set; }

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x060008E2 RID: 2274 RVA: 0x000084FA File Offset: 0x000066FA
		// (set) Token: 0x060008E3 RID: 2275 RVA: 0x00008502 File Offset: 0x00006702
		public string SimpleGameScript { get; set; }

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x060008E4 RID: 2276 RVA: 0x0000850B File Offset: 0x0000670B
		// (set) Token: 0x060008E5 RID: 2277 RVA: 0x00008513 File Offset: 0x00006713
		public string NormalGameScript { get; set; }

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x060008E6 RID: 2278 RVA: 0x0000851C File Offset: 0x0000671C
		// (set) Token: 0x060008E7 RID: 2279 RVA: 0x00008524 File Offset: 0x00006724
		public string HardGameScript { get; set; }

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x060008E8 RID: 2280 RVA: 0x0000852D File Offset: 0x0000672D
		// (set) Token: 0x060008E9 RID: 2281 RVA: 0x00008535 File Offset: 0x00006735
		public string TerrorGameScript { get; set; }

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x060008EA RID: 2282 RVA: 0x0000853E File Offset: 0x0000673E
		// (set) Token: 0x060008EB RID: 2283 RVA: 0x00008546 File Offset: 0x00006746
		public string AdviceTips { get; set; }

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x060008EC RID: 2284 RVA: 0x0000854F File Offset: 0x0000674F
		// (set) Token: 0x060008ED RID: 2285 RVA: 0x00008557 File Offset: 0x00006757
		public int Ordering { get; set; }
	}
}
