using System;
using System.Reflection;
using Game.Base.Config;
using log4net;
using SqlDataProvider.Data;

namespace Bussiness
{
	// Token: 0x0200000C RID: 12
	public abstract class GameProperties
	{
		// Token: 0x0600008F RID: 143 RVA: 0x0000B3D4 File Offset: 0x000095D4
		private static void Load(Type type)
		{
			using (ServiceBussiness sb = new ServiceBussiness())
			{
				foreach (FieldInfo f in type.GetFields())
				{
					if (f.IsStatic)
					{
						object[] attribs = f.GetCustomAttributes(typeof(ConfigPropertyAttribute), false);
						if (attribs.Length != 0)
						{
							ConfigPropertyAttribute attrib = (ConfigPropertyAttribute)attribs[0];
							f.SetValue(null, GameProperties.LoadProperty(attrib, sb));
						}
					}
				}
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000B458 File Offset: 0x00009658
		private static void Save(Type type)
		{
			using (ServiceBussiness sb = new ServiceBussiness())
			{
				foreach (FieldInfo f in type.GetFields())
				{
					if (f.IsStatic)
					{
						object[] attribs = f.GetCustomAttributes(typeof(ConfigPropertyAttribute), false);
						if (attribs.Length != 0)
						{
							GameProperties.SaveProperty((ConfigPropertyAttribute)attribs[0], sb, f.GetValue(null));
						}
					}
				}
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000B4D8 File Offset: 0x000096D8
		private static object LoadProperty(ConfigPropertyAttribute attrib, ServiceBussiness sb)
		{
			string key = attrib.Key;
			ServerProperty property = sb.GetServerPropertyByKey(key);
			if (property == null)
			{
				property = new ServerProperty
				{
					Key = key,
					Value = attrib.DefaultValue.ToString()
				};
				GameProperties.log.Error("Cannot find server property " + key + ",keep it default value!");
			}
			GameProperties.log.Debug("Loading " + key + " Value is " + property.Value);
			object result;
			try
			{
				result = Convert.ChangeType(property.Value, attrib.DefaultValue.GetType());
			}
			catch (Exception e)
			{
				GameProperties.log.Error("Exception in GameProperties Load: ", e);
				result = null;
			}
			return result;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000B590 File Offset: 0x00009790
		private static void SaveProperty(ConfigPropertyAttribute attrib, ServiceBussiness sb, object value)
		{
			try
			{
				sb.UpdateServerPropertyByKey(attrib.Key, value.ToString());
			}
			catch (Exception ex)
			{
				GameProperties.log.Error("Exception in GameProperties Save: ", ex);
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000B5D8 File Offset: 0x000097D8
		public static void Refresh()
		{
			GameProperties.log.Info("Refreshing game properties!");
			GameProperties.Load(typeof(GameProperties));
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000B5F8 File Offset: 0x000097F8
		public static void Save()
		{
			GameProperties.log.Info("Saving game properties into db!");
			GameProperties.Save(typeof(GameProperties));
		}

		// Token: 0x04000022 RID: 34
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000023 RID: 35
		[ConfigProperty("Edition", "当前游戏版本", "11000")]
		public static readonly string EDITION;

		// Token: 0x04000024 RID: 36
		[ConfigProperty("MustComposeGold", "合成消耗金币价格", 1000)]
		public static readonly int PRICE_COMPOSE_GOLD;

		// Token: 0x04000025 RID: 37
		[ConfigProperty("MustFusionGold", "熔炼消耗金币价格", 1000)]
		public static readonly int PRICE_FUSION_GOLD;

		// Token: 0x04000026 RID: 38
		[ConfigProperty("MustStrengthenGold", "强化金币消耗价格", 1000)]
		public static readonly int PRICE_STRENGHTN_GOLD;

		// Token: 0x04000027 RID: 39
		[ConfigProperty("CheckRewardItem", "验证码奖励物品", 11001)]
		public static readonly int CHECK_REWARD_ITEM;

		// Token: 0x04000028 RID: 40
		[ConfigProperty("CheckCount", "多少场出一次验证码", 20)]
		public static readonly int CHECKCODE_PER_GAME_COUNT;

		// Token: 0x04000029 RID: 41
		[ConfigProperty("HymenealMoney", "求婚的价格", 1000)]
		public static readonly int PRICE_PROPOSE;

		// Token: 0x0400002A RID: 42
		[ConfigProperty("DivorcedMoney", "离婚的价格", 1000)]
		public static readonly int PRICE_DIVORCED;

		// Token: 0x0400002B RID: 43
		[ConfigProperty("MarryRoomCreateMoney", "结婚房间的价格,2小时、3小时、4小时用逗号分隔", "2000,2700,3400")]
		public static readonly string PRICE_MARRY_ROOM;

		// Token: 0x0400002C RID: 44
		[ConfigProperty("BoxAppearCondition", "箱子物品提示的等级", 4)]
		public static readonly int BOX_APPEAR_CONDITION;

		// Token: 0x0400002D RID: 45
		[ConfigProperty("DisableCommands", "禁止使用的命令", "")]
		public static readonly string DISABLED_COMMANDS;

		// Token: 0x0400002E RID: 46
		[ConfigProperty("AssState", "防沉迷系统的开关,True打开,False关闭", false)]
		public static bool ASS_STATE;

		// Token: 0x0400002F RID: 47
		[ConfigProperty("DailyAwardState", "每日奖励开关,True打开,False关闭", true)]
		public static bool DAILY_AWARD_STATE;

		// Token: 0x04000030 RID: 48
		[ConfigProperty("Cess", "交易扣税", 0.1)]
		public static readonly double Cess;

		// Token: 0x04000031 RID: 49
		[ConfigProperty("BeginAuction", "拍买时起始随机时间", 20)]
		public static int BeginAuction;

		// Token: 0x04000032 RID: 50
		[ConfigProperty("EndAuction", "拍买时结束随机时间", 40)]
		public static int EndAuction;

		// Token: 0x04000033 RID: 51
		[ConfigProperty("Equip", "始化装备", "3101,6101,5101,7001|3201,6201,5201,7001")]
		public static string Equip;

		// Token: 0x04000034 RID: 52
		[ConfigProperty("CopyInviteLevelLimit", "邀请进入副本最低等级", 9)]
		public static int CopyInviteLevelLimit;

		// Token: 0x04000035 RID: 53
		[ConfigProperty("SpaRoomCreateMoney", "温泉房间的价格,2小时", "800,1600")]
		public static readonly string PRICE_SPA_ROOM;

		// Token: 0x04000036 RID: 54
		[ConfigProperty("SpaPubRoomCount", "温泉公共房间数量", "1,2")]
		public static readonly string COUNT_SPA_PUBROOM;

		// Token: 0x04000037 RID: 55
		[ConfigProperty("SpaPriRoomCount", "温泉私有房间数量上限", 2000)]
		public static int COUNT_SPA_PRIROOM;

		// Token: 0x04000038 RID: 56
		[ConfigProperty("RefreshLimitShopCount", "限量商品数量更新时间", "20:00")]
		public static string RefreshLimitShopCount;

		// Token: 0x04000039 RID: 57
		[ConfigProperty("LimitShopState", "限量购买开关", true)]
		public static bool LimitShopState;

		// Token: 0x0400003A RID: 58
		[ConfigProperty("GoHomeState", "回老家活动的开关", true)]
		public static bool GoHomeState;

		// Token: 0x0400003B RID: 59
		[ConfigProperty("SpaPubRoomServerID", "温泉公共房间的频道id", "1|10")]
		public static string SERVERID_SPA_PUBROOM;

		// Token: 0x0400003C RID: 60
		[ConfigProperty("SeizeNpc", "夺宝奇兵活动开关", true)]
		public static bool SEIZENPC;

		// Token: 0x0400003D RID: 61
		[ConfigProperty("SpaPubRoomLoginPay", "登录温泉公共房间的扣费", "10000,200")]
		public static string LOGIN_PAY_SPA_PUBROOM;

		// Token: 0x0400003E RID: 62
		[ConfigProperty("SpaPriRoomInitTime", "温泉私有房间的默认分钟", 60)]
		public static int INIT_TIME_SPA_PRIROOM;

		// Token: 0x0400003F RID: 63
		[ConfigProperty("SpaPriRoomContinueTime", "温泉私有房间的每次续费的延长分钟", 60)]
		public static int CONTINUE_TIME_SPA_PRIROOM;

		// Token: 0x04000040 RID: 64
		[ConfigProperty("SpaPubRoomTimeLimit", "玩家每日在公共房间的时间上限", "60,60")]
		public static string PLAYER_TIMELIMIT_SPA_PUBROOM;

		// Token: 0x04000041 RID: 65
		[ConfigProperty("SpaPubRoomPlayerMaxCount", "温泉公共房间最大人数", "10,10")]
		public static string PLAYER_MAXCOUNT_SPA_PUBROOM;

		// Token: 0x04000042 RID: 66
		[ConfigProperty("ChatCount", "ChatCount", "5")]
		public static string ChatCount;

		// Token: 0x04000043 RID: 67
		[ConfigProperty("DefaultGold", "DefaultGold", "0")]
		public static string DefaultGold;

		// Token: 0x04000044 RID: 68
		[ConfigProperty("DefaultMoney", "DefaultMoney", "0")]
		public static string DefaultMoney;

		// Token: 0x04000045 RID: 69
		[ConfigProperty("DefaultGiftToken", "DefaultGiftToken", "200")]
		public static string DefaultGiftToken;

		// Token: 0x04000046 RID: 70
		[ConfigProperty("NpcPlayerState", "NpcPlayerState", "True")]
		public static string NpcPlayerState;

		// Token: 0x04000047 RID: 71
		[ConfigProperty("ExchangMoneyToGold", "ExchangMoneyToGold", "200")]
		public static string ExchangMoneyToGold;

		// Token: 0x04000048 RID: 72
		[ConfigProperty("MustTransferGold", "MustTransferGold", "10000")]
		public static string MustTransferGold;

		// Token: 0x04000049 RID: 73
		[ConfigProperty("MustInlayGold", "MustInlayGold", "2000")]
		public static string MustInlayGold;

		// Token: 0x0400004A RID: 74
		[ConfigProperty("DispatchesMoney", "DispatchesMoney", "500")]
		public static string DispatchesMoney;

		// Token: 0x0400004B RID: 75
		[ConfigProperty("DismountGemMoney", "DismountGemMoney", "500")]
		public static string DismountGemMoney;

		// Token: 0x0400004C RID: 76
		[ConfigProperty("CanExperience", "CanExperience", "False")]
		public static string CanExperience;

		// Token: 0x0400004D RID: 77
		[ConfigProperty("MaxStrengthLevel", "MaxStrengthLevel", "12")]
		public static string MaxStrengthLevel;

		// Token: 0x0400004E RID: 78
		[ConfigProperty("AASInterfaceSwitch", "AASInterfaceSwitch", "0")]
		public static string AASInterfaceSwitch;

		// Token: 0x0400004F RID: 79
		[ConfigProperty("VIPMaxLevel", "VIPMaxLevel", "9")]
		public static string VIPMaxLevel;

		// Token: 0x04000050 RID: 80
		[ConfigProperty("VIPExpNeededForEachLv", "VIPExpNeededForEachLv", "0|150|350|700|1250|2050|3050|4250|5650")]
		public static string VIPExpNeededForEachLv;

		// Token: 0x04000051 RID: 81
		[ConfigProperty("VIPExpGainPerDay", "VIPExpGainPerDay", "10")]
		public static string VIPExpGainPerDay;

		// Token: 0x04000052 RID: 82
		[ConfigProperty("VIPExpDecreasePerDay", "VIPExpDecreasePerDay", "5")]
		public static string VIPExpDecreasePerDay;

		// Token: 0x04000053 RID: 83
		[ConfigProperty("VIPGpBonusRatePerLevel", "VIPGpBonusRatePerLevel", "0.1")]
		public static string VIPGpBonusRatePerLevel;

		// Token: 0x04000054 RID: 84
		[ConfigProperty("VIPSpaTimeBonusPerLevel", "VIPSpaTimeBonusPerLevel", "30")]
		public static string VIPSpaTimeBonusPerLevel;

		// Token: 0x04000055 RID: 85
		[ConfigProperty("VIPOfferDecreaseRate", "VIPOfferDecreaseRate", "0.5")]
		public static string VIPOfferDecreaseRate;

		// Token: 0x04000056 RID: 86
		[ConfigProperty("OpenHolesGold", "OpenHolesGold", "200")]
		public static string OpenHolesGold;

		// Token: 0x04000057 RID: 87
		[ConfigProperty("DefaultGP", "DefaultGP", "1")]
		public static string DefaultGP;

		// Token: 0x04000058 RID: 88
		[ConfigProperty("IsOpenUseLog", "IsOpenUseLog", "False")]
		public static string IsOpenUseLog;

		// Token: 0x04000059 RID: 89
		[ConfigProperty("InviterRewardGrade", "InviterRewardGrade", "5,112065|10,11462")]
		public static string InviterRewardGrade;

		// Token: 0x0400005A RID: 90
		[ConfigProperty("MAXLevel", "MAXLevel", "50")]
		public static string MAXLevel;

		// Token: 0x0400005B RID: 91
		[ConfigProperty("GiftLimit", "GiftLimit", "16")]
		public static string GiftLimit;

		// Token: 0x0400005C RID: 92
		[ConfigProperty("DivorcedDiscountMoney", "DivorcedDiscountMoney", "999")]
		public static string DivorcedDiscountMoney;

		// Token: 0x0400005D RID: 93
		[ConfigProperty("LotterySilverRewardTimes", "LotterySilverRewardTimes", "10")]
		public static string LotterySilverRewardTimes;

		// Token: 0x0400005E RID: 94
		[ConfigProperty("LotteryGoldRewardTimes", "LotteryGoldRewardTimes", "100")]
		public static string LotteryGoldRewardTimes;

		// Token: 0x0400005F RID: 95
		[ConfigProperty("HoleLevelUpExpList", "HoleLevelUpExpList", "400|600|700|800")]
		public static string HoleLevelUpExpList;

		// Token: 0x04000060 RID: 96
		[ConfigProperty("SendRandUserFaceInterval", "SendRandUserFaceInterval", "25")]
		public static string SendRandUserFaceInterval;

		// Token: 0x04000061 RID: 97
		[ConfigProperty("UserFaceRange", "UserFaceRange", "49|66")]
		public static string UserFaceRange;

		// Token: 0x04000062 RID: 98
		[ConfigProperty("CoupleFightGPRate", "CoupleFightGPRate", "0.5")]
		public static string CoupleFightGPRate;

		// Token: 0x04000063 RID: 99
		[ConfigProperty("ConsortiaFightRate", "ConsortiaFightRate", "0.1|0.2")]
		public static string ConsortiaFightRate;

		// Token: 0x04000064 RID: 100
		[ConfigProperty("MarrayAutoAward", "MarrayAutoAward", "False")]
		public static string MarrayAutoAward;

		// Token: 0x04000065 RID: 101
		[ConfigProperty("WeddingAutoAward", "WeddingAutoAward", "False")]
		public static string WeddingAutoAward;

		// Token: 0x04000066 RID: 102
		[ConfigProperty("GhostGPMax", "GhostGPMax", "1000")]
		public static string GhostGPMax;

		// Token: 0x04000067 RID: 103
		[ConfigProperty("PlayerGPMax", "PlayerGPMax", "10000")]
		public static string PlayerGPMax;

		// Token: 0x04000068 RID: 104
		[ConfigProperty("PICKUP_SNENIOR_ROBOT", "PICKUP_SNENIOR_ROBOT", "True")]
		public static string PICKUP_SNENIOR_ROBOT;

		// Token: 0x04000069 RID: 105
		[ConfigProperty("FightSendFace_Open", "FightSendFace_Open", "True")]
		public static string FightSendFace_Open;

		// Token: 0x0400006A RID: 106
		[ConfigProperty("IsOpenAreBigBugle", "IsOpenAreBigBugle", "False")]
		public static string IsOpenAreBigBugle;

		// Token: 0x0400006B RID: 107
		[ConfigProperty("IsPasswordTwoFailedLockBag", "IsPasswordTwoFailedLockBag", "False")]
		public static string IsPasswordTwoFailedLockBag;

		// Token: 0x0400006C RID: 108
		[ConfigProperty("FightLabLimitGrade", "FightLabLimitGrade", "15")]
		public static string FightLabLimitGrade;

		// Token: 0x0400006D RID: 109
		[ConfigProperty("VIPExpBonusForValueVIP", "VIPExpBonusForValueVIP", "5")]
		public static string VIPExpBonusForValueVIP;

		// Token: 0x0400006E RID: 110
		[ConfigProperty("ExerciseMaxLevel", "ExerciseMaxLevel", "55")]
		public static string ExerciseMaxLevel;

		// Token: 0x0400006F RID: 111
		[ConfigProperty("LotteryTemplateExchange", "LotteryTemplateExchange", "11001|11005|11009|11013|11019|9002|9003|9005|9006|8002|8003|8004|8006|11017")]
		public static string LotteryTemplateExchange;

		// Token: 0x04000070 RID: 112
		[ConfigProperty("SpaWorldMaxCount", "SpaWorldMaxCount", "500")]
		public static string SpaWorldMaxCount;

		// Token: 0x04000071 RID: 113
		[ConfigProperty("SpaWorldIds", "SpaWorldIds", "1,1")]
		public static string SpaWorldIds;

		// Token: 0x04000072 RID: 114
		[ConfigProperty("LuckStoneExchangeRule", "LuckStoneExchangeRule", "101,8|102,4|103,2|104,1")]
		public static string LuckStoneExchangeRule;

		// Token: 0x04000073 RID: 115
		[ConfigProperty("LuckyNumMoney", "LuckyNumMoney", "99")]
		public static string LuckyNumMoney;

		// Token: 0x04000074 RID: 116
		[ConfigProperty("LuckStoneCoefficient", "LuckStoneCoefficient", "0.33|0.55|0.75|1")]
		public static string LuckStoneCoefficient;

		// Token: 0x04000075 RID: 117
		[ConfigProperty("MissionMinute", "MissionMinute", "360")]
		public static string MissionMinute;

		// Token: 0x04000076 RID: 118
		[ConfigProperty("MissionBuffDay", "MissionBuffDay", "1")]
		public static string MissionBuffDay;

		// Token: 0x04000077 RID: 119
		[ConfigProperty("MissionRiches", "MissionRiches", "3000|3000|5000|5000|8000|8000|10000|10000|12000|12000")]
		public static string MissionRiches;

		// Token: 0x04000078 RID: 120
		[ConfigProperty("MissionAwardRiches", "MissionAwardRiches", "4500|4500|7500|7500|12000|12000|15000|15000|18000|18000")]
		public static string MissionAwardRiches;

		// Token: 0x04000079 RID: 121
		[ConfigProperty("MissionAwardGP", "MissionAwardGP", "100000|100000|200000|200000|300000|300000|400000|400000|500000|500000")]
		public static string MissionAwardGP;

		// Token: 0x0400007A RID: 122
		[ConfigProperty("MissionAwardOffer", "MissionAwardOffer", "500|500|1000|1000|1500|1500|2000|2000|2500|2500")]
		public static string MissionAwardOffer;

		// Token: 0x0400007B RID: 123
		[ConfigProperty("MissionAgainMoney", "MissionAgainMoney", "500")]
		public static string MissionAgainMoney;

		// Token: 0x0400007C RID: 124
		[ConfigProperty("MaxCountBuyOneDay", "MaxCountBuyOneDay", "3")]
		public static string MaxCountBuyOneDay;

		// Token: 0x0400007D RID: 125
		[ConfigProperty("GpExchangeForEachOfferLvMax", "GpExchangeForEachOfferLvMax", "600")]
		public static string GpExchangeForEachOfferLvMax;

		// Token: 0x0400007E RID: 126
		[ConfigProperty("MaxMedalCount", "MaxMedalCount", "999")]
		public static string MaxMedalCount;

		// Token: 0x0400007F RID: 127
		[ConfigProperty("RollAward", "RollAward", "0|110|120|150|180|200")]
		public static string RollAward;

		// Token: 0x04000080 RID: 128
		[ConfigProperty("RollFirstProbability", "RollFirstProbability", "1000|1000|1000|2000|2000|3000")]
		public static string RollFirstProbability;

		// Token: 0x04000081 RID: 129
		[ConfigProperty("RollProbability", "RollProbability", "2500|3000|3000|700|500|300")]
		public static string RollProbability;

		// Token: 0x04000082 RID: 130
		[ConfigProperty("AwardMaxMoney", "AwardMaxMoney", "1000")]
		public static string AwardMaxMoney;

		// Token: 0x04000083 RID: 131
		[ConfigProperty("RollTimes", "RollTimes", "1")]
		public static string RollTimes;

		// Token: 0x04000084 RID: 132
		[ConfigProperty("BecomeVIPAward", "BecomeVIPAward", "112164")]
		public static string BecomeVIPAward;

		// Token: 0x04000085 RID: 133
		[ConfigProperty("MarryRoomSendGiftItemID", "MarryRoomSendGiftItemID", "11900")]
		public static string MarryRoomSendGiftItemID;

		// Token: 0x04000086 RID: 134
		[ConfigProperty("PveCheckCodeCount", "PveCheckCodeCount", "3")]
		public static string PveCheckCodeCount;

		// Token: 0x04000087 RID: 135
		[ConfigProperty("GameMgrUseFor", "GameMgrUseFor", "1")]
		public static string GameMgrUseFor;

		// Token: 0x04000088 RID: 136
		[ConfigProperty("BlessTemplateID", "BlessTemplateID", "11560|11561|11562")]
		public static string BlessTemplateID;

		// Token: 0x04000089 RID: 137
		[ConfigProperty("BlessValid", "BlessValid", "30|30|30")]
		public static string BlessValid;

		// Token: 0x0400008A RID: 138
		[ConfigProperty("BlessDropProbability", "BlessDropProbability", "190|260|50")]
		public static string BlessDropProbability;

		// Token: 0x0400008B RID: 139
		[ConfigProperty("BlessProbability", "BlessProbability", "2000|2000|2000")]
		public static string BlessProbability;

		// Token: 0x0400008C RID: 140
		[ConfigProperty("BlessCategoryID", "BlessCategoryID", "7|5|1")]
		public static string BlessCategoryID;

		// Token: 0x0400008D RID: 141
		[ConfigProperty("BlessEquipLevel", "BlessEquipLevel", "12|12|12")]
		public static string BlessEquipLevel;

		// Token: 0x0400008E RID: 142
		[ConfigProperty("SpaAddictionMoneyNeeded", "SpaAddictionMoneyNeeded", "100")]
		public static string SpaAddictionMoneyNeeded;

		// Token: 0x0400008F RID: 143
		[ConfigProperty("TakeCardMoney", "TakeCardMoney", "486")]
		public static string TakeCardMoney;

		// Token: 0x04000090 RID: 144
		[ConfigProperty("TakeCardDiscount", "TakeCardDiscount", "0.1")]
		public static string TakeCardDiscount;

		// Token: 0x04000091 RID: 145
		[ConfigProperty("ConsortiaStrengthenEx", "ConsortiaStrengthenEx", "1|2|3|4|5|6|7|8|9|10")]
		public static string ConsortiaStrengthenEx;

		// Token: 0x04000092 RID: 146
		[ConfigProperty("IsCardUpgradeNoticeEnabled", "IsCardUpgradeNoticeEnabled", "False")]
		public static string IsCardUpgradeNoticeEnabled;

		// Token: 0x04000093 RID: 147
		[ConfigProperty("OverseaVIPFeatures", "OverseaVIPFeatures", "False")]
		public static string OverseaVIPFeatures;

		// Token: 0x04000094 RID: 148
		[ConfigProperty("MalaysiaFeatures", "MalaysiaFeatures", "False")]
		public static string MalaysiaFeatures;

		// Token: 0x04000095 RID: 149
		[ConfigProperty("VietnamFeatures", "VietnamFeatures", "False")]
		public static string VietnamFeatures;

		// Token: 0x04000096 RID: 150
		[ConfigProperty("LotteryRewardSwitch", "LotteryRewardSwitch", "True")]
		public static string LotteryRewardSwitch;

		// Token: 0x04000097 RID: 151
		[ConfigProperty("SNSMessageExtend", "SNSMessageExtend", "False")]
		public static string SNSMessageExtend;

		// Token: 0x04000098 RID: 152
		[ConfigProperty("OverseaNewLotteryBox", "OverseaNewLotteryBox", "False")]
		public static string OverseaNewLotteryBox;

		// Token: 0x04000099 RID: 153
		[ConfigProperty("HotSpringExp", "HotSpringExp", "200,240,288,346,415,498,597,717,860,946,1041,1145,1259,1385,1523,1676,1843,2028,2231,2342,2459,2582,2711,2847,2989,3139,3295,3460,3633,3815,3929,4047,4169,4294,4423,4555,4692,4833,4978,5127,5281,5439,5602,5770,5944,6122,6306,6495,6690,6890,7097,7310,7529,7755,7988,8227,8474,8728,8990,9260")]
		public static string HotSpringExp;

		// Token: 0x0400009A RID: 154
		[ConfigProperty("Nimbus6ItemIDs", "特效6物品ID", "")]
		public static string Nimbus6ItemIDs;
	}
}
