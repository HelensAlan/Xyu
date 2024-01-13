using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000057 RID: 87
	public class QuestInfo : DataObject
	{
		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x0000890F File Offset: 0x00006B0F
		// (set) Token: 0x06000943 RID: 2371 RVA: 0x00008917 File Offset: 0x00006B17
		public int ID { get; set; }

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x00008920 File Offset: 0x00006B20
		// (set) Token: 0x06000945 RID: 2373 RVA: 0x00008928 File Offset: 0x00006B28
		public int QuestID { get; set; }

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x06000946 RID: 2374 RVA: 0x00008931 File Offset: 0x00006B31
		// (set) Token: 0x06000947 RID: 2375 RVA: 0x00008939 File Offset: 0x00006B39
		public string Title { get; set; }

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06000948 RID: 2376 RVA: 0x00008942 File Offset: 0x00006B42
		// (set) Token: 0x06000949 RID: 2377 RVA: 0x0000894A File Offset: 0x00006B4A
		public string Detail { get; set; }

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x0600094A RID: 2378 RVA: 0x00008953 File Offset: 0x00006B53
		// (set) Token: 0x0600094B RID: 2379 RVA: 0x0000895B File Offset: 0x00006B5B
		public string Objective { get; set; }

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x00008964 File Offset: 0x00006B64
		// (set) Token: 0x0600094D RID: 2381 RVA: 0x0000896C File Offset: 0x00006B6C
		public int NeedMinLevel { get; set; }

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x0600094E RID: 2382 RVA: 0x00008975 File Offset: 0x00006B75
		// (set) Token: 0x0600094F RID: 2383 RVA: 0x0000897D File Offset: 0x00006B7D
		public int NeedMaxLevel { get; set; }

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06000950 RID: 2384 RVA: 0x00008986 File Offset: 0x00006B86
		// (set) Token: 0x06000951 RID: 2385 RVA: 0x0000898E File Offset: 0x00006B8E
		public string PreQuestID { get; set; }

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x00008997 File Offset: 0x00006B97
		// (set) Token: 0x06000953 RID: 2387 RVA: 0x0000899F File Offset: 0x00006B9F
		public string NextQuestID { get; set; }

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x000089A8 File Offset: 0x00006BA8
		// (set) Token: 0x06000955 RID: 2389 RVA: 0x000089B0 File Offset: 0x00006BB0
		public int IsOther { get; set; }

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x000089B9 File Offset: 0x00006BB9
		// (set) Token: 0x06000957 RID: 2391 RVA: 0x000089C1 File Offset: 0x00006BC1
		public bool CanRepeat { get; set; }

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06000958 RID: 2392 RVA: 0x000089CA File Offset: 0x00006BCA
		// (set) Token: 0x06000959 RID: 2393 RVA: 0x000089D2 File Offset: 0x00006BD2
		public int RepeatInterval { get; set; }

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x0600095A RID: 2394 RVA: 0x000089DB File Offset: 0x00006BDB
		// (set) Token: 0x0600095B RID: 2395 RVA: 0x000089E3 File Offset: 0x00006BE3
		public int RepeatMax { get; set; }

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x000089EC File Offset: 0x00006BEC
		// (set) Token: 0x0600095D RID: 2397 RVA: 0x000089F4 File Offset: 0x00006BF4
		public int RewardGP { get; set; }

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x0600095E RID: 2398 RVA: 0x000089FD File Offset: 0x00006BFD
		// (set) Token: 0x0600095F RID: 2399 RVA: 0x00008A05 File Offset: 0x00006C05
		public int RewardGold { get; set; }

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06000960 RID: 2400 RVA: 0x00008A0E File Offset: 0x00006C0E
		// (set) Token: 0x06000961 RID: 2401 RVA: 0x00008A16 File Offset: 0x00006C16
		public int RewardGiftToken { get; set; }

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x00008A1F File Offset: 0x00006C1F
		// (set) Token: 0x06000963 RID: 2403 RVA: 0x00008A27 File Offset: 0x00006C27
		public int RewardOffer { get; set; }

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x00008A30 File Offset: 0x00006C30
		// (set) Token: 0x06000965 RID: 2405 RVA: 0x00008A38 File Offset: 0x00006C38
		public int RewardRiches { get; set; }

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06000966 RID: 2406 RVA: 0x00008A41 File Offset: 0x00006C41
		// (set) Token: 0x06000967 RID: 2407 RVA: 0x00008A49 File Offset: 0x00006C49
		public int RewardBuffID { get; set; }

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x00008A52 File Offset: 0x00006C52
		// (set) Token: 0x06000969 RID: 2409 RVA: 0x00008A5A File Offset: 0x00006C5A
		public int RewardBuffDate { get; set; }

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x0600096A RID: 2410 RVA: 0x00008A63 File Offset: 0x00006C63
		// (set) Token: 0x0600096B RID: 2411 RVA: 0x00008A6B File Offset: 0x00006C6B
		public int RewardMoney { get; set; }

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x0600096C RID: 2412 RVA: 0x00008A74 File Offset: 0x00006C74
		// (set) Token: 0x0600096D RID: 2413 RVA: 0x00008A7C File Offset: 0x00006C7C
		public decimal Rands { get; set; }

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x00008A85 File Offset: 0x00006C85
		// (set) Token: 0x0600096F RID: 2415 RVA: 0x00008A8D File Offset: 0x00006C8D
		public int RandDouble { get; set; }

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06000970 RID: 2416 RVA: 0x00008A96 File Offset: 0x00006C96
		// (set) Token: 0x06000971 RID: 2417 RVA: 0x00008A9E File Offset: 0x00006C9E
		public bool TimeMode { get; set; }

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06000972 RID: 2418 RVA: 0x00008AA7 File Offset: 0x00006CA7
		// (set) Token: 0x06000973 RID: 2419 RVA: 0x00008AAF File Offset: 0x00006CAF
		public DateTime StartDate { get; set; }

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x00008AB8 File Offset: 0x00006CB8
		// (set) Token: 0x06000975 RID: 2421 RVA: 0x00008AC0 File Offset: 0x00006CC0
		public DateTime EndDate { get; set; }

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x00008AC9 File Offset: 0x00006CC9
		// (set) Token: 0x06000977 RID: 2423 RVA: 0x00008AD1 File Offset: 0x00006CD1
		public int MapID { get; set; }

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x00008ADA File Offset: 0x00006CDA
		// (set) Token: 0x06000979 RID: 2425 RVA: 0x00008AE2 File Offset: 0x00006CE2
		public bool AutoEquip { get; set; }

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x00008AEB File Offset: 0x00006CEB
		// (set) Token: 0x0600097B RID: 2427 RVA: 0x00008AF3 File Offset: 0x00006CF3
		public int RewardMedal { get; set; }

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x00008AFC File Offset: 0x00006CFC
		// (set) Token: 0x0600097D RID: 2429 RVA: 0x00008B04 File Offset: 0x00006D04
		public string Rank { get; set; }

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x00008B0D File Offset: 0x00006D0D
		// (set) Token: 0x0600097F RID: 2431 RVA: 0x00008B15 File Offset: 0x00006D15
		public int StarLev { get; set; }

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x00008B1E File Offset: 0x00006D1E
		// (set) Token: 0x06000981 RID: 2433 RVA: 0x00008B26 File Offset: 0x00006D26
		public int NotMustCount { get; set; }
	}
}
