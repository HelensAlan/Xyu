using System;
using System.Reflection;
using Bussiness;
using log4net;
using SqlDataProvider.Data;

namespace Center.Server
{
	// Token: 0x02000005 RID: 5
	internal class ChargeRewardMgr
	{
		// Token: 0x06000041 RID: 65 RVA: 0x00004120 File Offset: 0x00002320
		public static void DoChargeReward(int userID)
		{
			try
			{
				RebateChargeInfo[] array = null;
				DateTime now = DateTime.Now;
				int num = 0;
				PlayerInfo userSingleByUserID;
				using (PlayerBussiness playerBussiness = new PlayerBussiness())
				{
					userSingleByUserID = playerBussiness.GetUserSingleByUserID(userID);
					if (userSingleByUserID == null)
					{
						return;
					}
					num = (userSingleByUserID.Sex ? 1 : 2);
				}
				using (PlayerBussiness playerBussiness2 = new PlayerBussiness())
				{
					array = playerBussiness2.GetChargeInfo(userSingleByUserID.UserName, userSingleByUserID.NickName, ref now);
				}
				foreach (RebateChargeInfo rebateChargeInfo in array)
				{
					string text = "";
					string text2 = "";
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					using (PlayerBussiness playerBussiness3 = new PlayerBussiness())
					{
						foreach (RebateItemInfo rebateItemInfo in playerBussiness3.GetChargeRewardItemsInfo(rebateChargeInfo.Money, rebateChargeInfo.Date))
						{
							if (rebateItemInfo.FirstChargeNeeded && rebateChargeInfo.Date.CompareTo(now) != 0)
							{
								break;
							}
							num2 += rebateItemInfo.Money;
							num3 += rebateItemInfo.Gold;
							num4 += rebateItemInfo.GiftToken;
							if (rebateItemInfo.ItemTemplateID > 0 && (rebateItemInfo.NeedSex == 0 || rebateItemInfo.NeedSex == num))
							{
								text += string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}|", new object[]
								{
									rebateItemInfo.ItemTemplateID,
									rebateItemInfo.Count,
									rebateItemInfo.ValidDate,
									rebateItemInfo.StrengthLevel,
									rebateItemInfo.AttackCompose,
									rebateItemInfo.DefendCompose,
									rebateItemInfo.AgilityCompose,
									rebateItemInfo.LuckCompose,
									rebateItemInfo.IsBind ? 1 : 0
								});
								text2 += string.Format("{0}_{1}|", rebateItemInfo.GiftPackageID, rebateItemInfo.RewardItemID);
							}
						}
						if (text.Length > 1)
						{
							text = text.Substring(0, text.Length - 1);
						}
					}
					using (PlayerBussiness playerBussiness4 = new PlayerBussiness())
					{
						playerBussiness4.DoChargeReward(userID, rebateChargeInfo, num2, num3, num4, text, text2);
					}
				}
			}
			catch (Exception exception)
			{
				if (ChargeRewardMgr.log.IsErrorEnabled)
				{
					ChargeRewardMgr.log.Error("Init", exception);
				}
			}
		}

		// Token: 0x04000021 RID: 33
		protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
	}
}
