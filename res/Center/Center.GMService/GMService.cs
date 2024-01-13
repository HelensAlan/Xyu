using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using Bussiness;
using Center.GMService.DataContracts;
using Center.GMService.ServiceContracts;
using Center.Server;
using Game.Base.Packets;
using log4net;
using SqlDataProvider.Data;

namespace Center.GMService
{
	// Token: 0x02000003 RID: 3
	public class GMService : IGMService, IUserService, IConsortiaService, IChargeReward, IChargeActive
	{
		// Token: 0x06000005 RID: 5 RVA: 0x0000286C File Offset: 0x00000A6C
		public static bool Start()
		{
			bool result;
			try
			{
				if (GMService.host != null)
				{
					if (GMService.host.State == CommunicationState.Opened)
					{
						GMService.log.Info("GMService already started!");
						result = true;
						return result;
					}
					GMService.host.Close();
					GMService.host = null;
				}
				GMService.host = new ServiceHost(typeof(GMService), new Uri[0]);
				GMService.host.Open();
				GMService.log.Info("GMService started!");
				result = true;
			}
			catch (Exception ex)
			{
				GMService.log.ErrorFormat("Start GMService failed:{0}", ex);
				result = false;
			}
			return result;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002914 File Offset: 0x00000B14
		public static void Stop()
		{
			try
			{
				if (GMService.host != null)
				{
					GMService.host.Close();
					GMService.host = null;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002950 File Offset: 0x00000B50
		public CommonReturnData GMCreateConsortium(string consortiumName, int chairmanID)
		{
			PlayerInfo playerInfo = null;
			CommonReturnData result = new CommonReturnData();
			CommonReturnData result2;
			using (PlayerBussiness db = new PlayerBussiness())
			{
				playerInfo = db.GetUserSingleByUserID(chairmanID);
				if (playerInfo == null)
				{
					result.OperationResult = 1;
					result.NotifyMsg = "获取会长信息失败！";
					result2 = result;
					return result2;
				}
			}
			using (ConsortiaBussiness db2 = new ConsortiaBussiness())
			{
				ConsortiaLevelInfo levelInfo = ConsortiaLevelMgr.FindConsortiaLevelInfo(1);
				if (levelInfo == null)
				{
					result.OperationResult = 1;
					result.NotifyMsg = "获取公会配置信息失败！";
					result2 = result;
				}
				else
				{
					ConsortiaInfo info = new ConsortiaInfo();
					string msg = string.Empty;
					ConsortiaDutyInfo dutyInfo = new ConsortiaDutyInfo();
					info.BuildDate = DateTime.Now;
					info.CelebCount = 0;
					info.ChairmanID = playerInfo.ID;
					info.ChairmanName = playerInfo.NickName;
					info.ConsortiaName = consortiumName;
					info.CreatorID = info.ChairmanID;
					info.CreatorName = info.ChairmanName;
					info.Description = "";
					info.Honor = 0;
					info.IP = "";
					info.IsExist = true;
					info.Level = levelInfo.Level;
					info.MaxCount = levelInfo.Count;
					info.Riches = levelInfo.Riches;
					info.Placard = "";
					info.Port = 0;
					info.Repute = 0;
					info.Count = 1;
					info.IsSystemCreate = true;
					info.IsActive = false;
					if (db2.AddConsortia(info, ref msg, ref dutyInfo))
					{
						SystemConsortiaMrg.ReLoad();
						GSPacketIn pkg = new GSPacketIn(130);
						pkg.WriteInt(info.ConsortiaID);
						pkg.WriteInt(playerInfo.Offer);
						pkg.WriteString(info.ChairmanName);
						CenterServer.Instance.SendToALL(pkg, null);
						result.ID = info.ConsortiaID;
						result.OperationResult = 0;
						result.NotifyMsg = "创建公会成功！";
						result2 = result;
					}
					else
					{
						result.OperationResult = 1;
						result.NotifyMsg = "创建公会失败！";
						result2 = result;
					}
				}
			}
			return result2;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002B8C File Offset: 0x00000D8C
		public CommonReturnData GMTransferConsortium(int consortiumID, int newChairmanID)
		{
			PlayerInfo newChairmanInfo = null;
			PlayerInfo oldChairmanInfo = null;
			ConsortiaInfo consortiumInfo = null;
			CommonReturnData result = new CommonReturnData();
			CommonReturnData result2;
			using (ConsortiaBussiness db = new ConsortiaBussiness())
			{
				consortiumInfo = db.GetConsortiaSingle(consortiumID);
				if (consortiumInfo == null)
				{
					result.OperationResult = 1;
					result.NotifyMsg = "指定公会不存在！";
					result2 = result;
					return result2;
				}
				if (consortiumInfo.ChairmanID == newChairmanID)
				{
					result.OperationResult = 1;
					result.NotifyMsg = "对方已经是指定公会的会长，无需转让！";
					result2 = result;
					return result2;
				}
			}
			using (PlayerBussiness db2 = new PlayerBussiness())
			{
				newChairmanInfo = db2.GetUserSingleByUserID(newChairmanID);
				oldChairmanInfo = db2.GetUserSingleByUserID(consortiumInfo.ChairmanID);
				if (newChairmanInfo == null || oldChairmanInfo == null)
				{
					result.OperationResult = 1;
					result.NotifyMsg = "获取新旧会长信息失败！";
					result2 = result;
					return result2;
				}
				if (newChairmanInfo.ConsortiaID != consortiumID)
				{
					result.OperationResult = 1;
					result.NotifyMsg = "不能转让给非本公会成员！";
					result2 = result;
					return result2;
				}
				if (newChairmanInfo.Grade < 5)
				{
					result.OperationResult = 1;
					result.NotifyMsg = "新会长等级不足！";
					result2 = result;
					return result2;
				}
			}
			using (ConsortiaBussiness db3 = new ConsortiaBussiness())
			{
				string tempUserName = "";
				int tempUserID = 0;
				string msg = "";
				ConsortiaDutyInfo dutyInfo = new ConsortiaDutyInfo();
				if (db3.UpdateConsortiaChairman(newChairmanInfo.NickName, consortiumInfo.ConsortiaID, oldChairmanInfo.ID, ref msg, ref dutyInfo, ref tempUserID, ref tempUserName))
				{
					SystemConsortiaMrg.ReLoad();
					ConsortiaDutyInfo orderInfo = new ConsortiaDutyInfo
					{
						Level = oldChairmanInfo.DutyLevel,
						DutyName = oldChairmanInfo.DutyName,
						Right = oldChairmanInfo.Right
					};
					GSPacketIn pkg = new GSPacketIn(128);
					pkg.WriteByte(8);
					pkg.WriteByte(9);
					pkg.WriteInt(consortiumInfo.ConsortiaID);
					pkg.WriteInt(newChairmanInfo.ID);
					pkg.WriteString(newChairmanInfo.NickName);
					pkg.WriteInt(orderInfo.Level);
					pkg.WriteString(orderInfo.DutyName);
					pkg.WriteInt(orderInfo.Right);
					pkg.WriteInt(0);
					pkg.WriteString("");
					CenterServer.Instance.SendToALL(pkg, null);
					pkg = new GSPacketIn(128);
					pkg.WriteByte(8);
					pkg.WriteByte(8);
					pkg.WriteInt(consortiumInfo.ConsortiaID);
					pkg.WriteInt(oldChairmanInfo.ID);
					pkg.WriteString(oldChairmanInfo.NickName);
					pkg.WriteInt(dutyInfo.Level);
					pkg.WriteString(dutyInfo.DutyName);
					pkg.WriteInt(dutyInfo.Right);
					pkg.WriteInt(0);
					pkg.WriteString("");
					CenterServer.Instance.SendToALL(pkg, null);
					if (db3.UpdateConsortiaIsBanChat(newChairmanInfo.ID, newChairmanInfo.ConsortiaID, newChairmanInfo.ID, false, ref tempUserID, ref tempUserName, ref msg))
					{
						pkg = new GSPacketIn(128);
						pkg.WriteByte(5);
						pkg.WriteBoolean(false);
						pkg.WriteInt(newChairmanInfo.ConsortiaID);
						pkg.WriteString(newChairmanInfo.NickName);
						pkg.WriteInt(oldChairmanInfo.ID);
						pkg.WriteString(oldChairmanInfo.NickName);
						CenterServer.Instance.SendToALL(pkg, null);
					}
					result.OperationResult = 0;
					result.NotifyMsg = "转让会长成功！";
					result2 = result;
				}
				else
				{
					result.OperationResult = 1;
					result.NotifyMsg = "转让会长失败！";
					result2 = result;
				}
			}
			return result2;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002F48 File Offset: 0x00001148
		public bool GMIsConsortiumExisted(string consortiumName)
		{
			bool consortiaCheckByConsortiaName;
			using (PlayerBussiness db = new PlayerBussiness())
			{
				consortiaCheckByConsortiaName = db.GetConsortiaCheckByConsortiaName(consortiumName);
			}
			return consortiaCheckByConsortiaName;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002F80 File Offset: 0x00001180
		public List<ConsortiumData> GMGetSystemConsortiumList()
		{
			List<ConsortiumData> allConsortia = new List<ConsortiumData>();
			using (ConsortiaBussiness db = new ConsortiaBussiness())
			{
				ConsortiaInfo[] tempConsortia = db.GetAllSystemConsortia();
				if (tempConsortia.Length != 0)
				{
					foreach (ConsortiaInfo consortiumInfo in tempConsortia)
					{
						allConsortia.Add(new ConsortiumData
						{
							ConsortiaID = consortiumInfo.ConsortiaID,
							BuildDate = consortiumInfo.BuildDate,
							CelebCount = consortiumInfo.CelebCount,
							ChairmanID = consortiumInfo.ChairmanID,
							ChairmanName = consortiumInfo.ChairmanName,
							ConsortiaName = consortiumInfo.ConsortiaName,
							CreatorID = consortiumInfo.CreatorID,
							CreatorName = consortiumInfo.CreatorName,
							Description = consortiumInfo.Description,
							Honor = consortiumInfo.Honor,
							IsExist = consortiumInfo.IsExist,
							Level = consortiumInfo.Level,
							MaxCount = consortiumInfo.MaxCount,
							Placard = consortiumInfo.Placard,
							IP = consortiumInfo.IP,
							Port = consortiumInfo.Port,
							Repute = consortiumInfo.Repute,
							Count = consortiumInfo.Count,
							Riches = consortiumInfo.Riches,
							DeductDate = consortiumInfo.DeductDate,
							StoreLevel = consortiumInfo.StoreLevel,
							SmithLevel = consortiumInfo.SmithLevel,
							ShopLevel = consortiumInfo.ShopLevel,
							BufferLevel = consortiumInfo.BufferLevel,
							IsSystemCreate = consortiumInfo.IsSystemCreate
						});
					}
				}
			}
			return allConsortia;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00003140 File Offset: 0x00001340
		public List<ConsortiumUserData> GMGetConsortiumUserListByName(string consortiumName, int page, int size, out int total, int order, int state)
		{
			List<ConsortiumUserData> allUsersList = new List<ConsortiumUserData>();
			List<ConsortiumUserData> result;
			using (ConsortiaBussiness db = new ConsortiaBussiness())
			{
				total = 0;
				ConsortiaInfo consortiumInfo = db.GetConsortiaSingleByName(consortiumName);
				if (consortiumInfo == null)
				{
					result = allUsersList;
				}
				else
				{
					result = this.GMGetConsortiumUserListByID(consortiumInfo.ConsortiaID, page, size, out total, order, state);
				}
			}
			return result;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000031A0 File Offset: 0x000013A0
		public List<ConsortiumUserData> GMGetConsortiumUserListByID(int consortiumID, int page, int size, out int total, int order, int state)
		{
			List<ConsortiumUserData> allUsersList = new List<ConsortiumUserData>();
			List<ConsortiumUserData> result;
			using (ConsortiaBussiness db = new ConsortiaBussiness())
			{
				total = 0;
				ConsortiaUserInfo[] tempUsersInfo = db.GetConsortiaUsersPage(page, size, ref total, order, consortiumID, -1, state);
				if (tempUsersInfo.Length != 0)
				{
					foreach (ConsortiaUserInfo userInfo in tempUsersInfo)
					{
						allUsersList.Add(new ConsortiumUserData
						{
							ID = userInfo.ID,
							ConsortiaID = userInfo.ConsortiaID,
							DutyID = userInfo.DutyID,
							DutyName = userInfo.DutyName,
							IsExist = userInfo.IsExist,
							RatifierID = userInfo.RatifierID,
							RatifierName = userInfo.RatifierName,
							Remark = userInfo.Remark,
							UserID = userInfo.UserID,
							UserName = userInfo.UserName,
							Grade = userInfo.Grade,
							GP = userInfo.GP,
							Repute = userInfo.Repute,
							State = userInfo.State,
							Right = userInfo.Right,
							Offer = userInfo.Offer,
							Colors = userInfo.Colors,
							Style = userInfo.Style,
							Hide = userInfo.Hide,
							Skin = userInfo.Skin,
							Level = userInfo.Level,
							LastDate = userInfo.LastDate,
							Sex = userInfo.Sex,
							IsBanChat = userInfo.IsBanChat,
							Win = userInfo.Win,
							Total = userInfo.Total,
							Escape = userInfo.Escape,
							RichesOffer = userInfo.RichesOffer,
							RichesRob = userInfo.RichesRob,
							LoginName = userInfo.LoginName,
							Nimbus = userInfo.Nimbus,
							FightPower = userInfo.FightPower
						});
					}
				}
				result = allUsersList;
			}
			return result;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000033D0 File Offset: 0x000015D0
		public List<ConsortiumUserData> GMGetCanTransferUserList(int consortiumID)
		{
			List<ConsortiumUserData> allUserList = new List<ConsortiumUserData>();
			string queryWhere = " ConsortiaID=" + consortiumID.ToString() + " and Grade>=5 and datediff(hh,LastDate,getdate())<=72 ";
			string sOrder = " Repute desc,FightPower desc ";
			int total = 0;
			List<ConsortiumUserData> result;
			using (ConsortiaBussiness db = new ConsortiaBussiness())
			{
				foreach (object obj in db.GetPage("V_Consortia_Users", queryWhere, 1, 40, "*", sOrder, "ID", ref total).Rows)
				{
					DataRow dataRow = (DataRow)obj;
					ConsortiumUserData info = new ConsortiumUserData
					{
						ID = (int)dataRow["ID"],
						ConsortiaID = (int)dataRow["ConsortiaID"],
						DutyID = (int)dataRow["DutyID"],
						DutyName = dataRow["DutyName"].ToString(),
						IsExist = (bool)dataRow["IsExist"],
						RatifierID = (int)dataRow["RatifierID"],
						RatifierName = dataRow["RatifierName"].ToString(),
						Remark = dataRow["Remark"].ToString(),
						UserID = (int)dataRow["UserID"],
						UserName = dataRow["UserName"].ToString(),
						Grade = (int)dataRow["Grade"],
						GP = (int)dataRow["GP"],
						Repute = (int)dataRow["Repute"],
						State = (int)dataRow["State"],
						Right = (int)dataRow["Right"],
						Offer = (int)dataRow["Offer"],
						Colors = dataRow["Colors"].ToString(),
						Style = dataRow["Style"].ToString(),
						Hide = (int)dataRow["Hide"]
					};
					info.Skin = ((dataRow["Skin"] == null) ? "" : info.Skin);
					info.Level = (int)dataRow["Level"];
					info.LastDate = (DateTime)dataRow["LastDate"];
					info.Sex = (bool)dataRow["Sex"];
					info.IsBanChat = (bool)dataRow["IsBanChat"];
					info.Win = (int)dataRow["Win"];
					info.Total = (int)dataRow["Total"];
					info.Escape = (int)dataRow["Escape"];
					info.RichesOffer = (int)dataRow["RichesOffer"];
					info.RichesRob = (int)dataRow["RichesRob"];
					info.LoginName = ((dataRow["LoginName"] == null) ? "" : dataRow["LoginName"].ToString());
					info.Nimbus = (int)dataRow["Nimbus"];
					info.FightPower = (int)dataRow["FightPower"];
					allUserList.Add(info);
				}
				result = allUserList;
			}
			return result;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000037CC File Offset: 0x000019CC
		public CommonReturnData GMQuitConsortium(int userID, int consortiumID)
		{
			CommonReturnData result = new CommonReturnData();
			CommonReturnData result2;
			using (PlayerBussiness db = new PlayerBussiness())
			{
				PlayerInfo userInfo = db.GetUserSingleByUserID(userID);
				if (userInfo == null)
				{
					result.OperationResult = 1;
					result.NotifyMsg = "获取角色信息失败！";
					result2 = result;
					return result2;
				}
				if (userInfo.ConsortiaID != consortiumID)
				{
					result.OperationResult = 1;
					result.NotifyMsg = "角色不是指定公会的成员，无需退出！";
					result2 = result;
					return result2;
				}
			}
			using (ConsortiaBussiness db2 = new ConsortiaBussiness())
			{
				string msg = "";
				string nickName = "";
				if (db2.DeleteConsortiaUser(userID, userID, consortiumID, ref msg, ref nickName))
				{
					GSPacketIn pkg = new GSPacketIn(128);
					pkg.WriteByte(3);
					pkg.WriteInt(userID);
					pkg.WriteInt(consortiumID);
					pkg.WriteBoolean(false);
					pkg.WriteString(nickName);
					pkg.WriteString(nickName);
					CenterServer.Instance.SendToALL(pkg, null);
					result.OperationResult = 0;
					result.NotifyMsg = "退会成功！";
					result2 = result;
				}
				else
				{
					result.OperationResult = 1;
					result.NotifyMsg = msg;
					result2 = result;
				}
			}
			return result2;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00003904 File Offset: 0x00001B04
		public bool GMIsPlayerExist(string nickName)
		{
			bool result;
			using (PlayerBussiness db = new PlayerBussiness())
			{
				if (db.GetUserCheckByNickName(nickName))
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00003944 File Offset: 0x00001B44
		public CommonReturnData GMCreatePlayer(string userName, string nickName, int grade, int sex)
		{
			CommonReturnData result = new CommonReturnData();
			CommonReturnData result2;
			if (!string.IsNullOrEmpty(nickName) && Encoding.Default.GetByteCount(nickName) <= 14)
			{
				using (PlayerBussiness db = new PlayerBussiness())
				{
					if (db.GetUserCheckByNickName(nickName))
					{
						result.OperationResult = 1;
						result.NotifyMsg = "角色名已被使用！";
						result2 = result;
						return result2;
					}
				}
				string hairID = "";
				string faceID = "";
				string clothID = "";
				string armID = "";
				string armColor = "";
				string hairColor = "";
				string faceColor = "";
				string clothColor = "";
				PlayerInfo info = null;
				using (ServiceBussiness db2 = new ServiceBussiness())
				{
					string equip = db2.GetGameEquip();
					string curr_Equip = ((sex == 1) ? equip.Split(new char[] { '|' })[0] : equip.Split(new char[] { '|' })[1]);
					hairID = curr_Equip.Split(new char[] { ',' })[0];
					faceID = curr_Equip.Split(new char[] { ',' })[1];
					clothID = curr_Equip.Split(new char[] { ',' })[2];
					armID = curr_Equip.Split(new char[] { ',' })[3];
				}
				using (PlayerBussiness db3 = new PlayerBussiness())
				{
					if (!db3.ActivePlayer(ref info, userName, "", sex == 1, 0, 0, 0, "127.0.0.1", "GMService"))
					{
						result.OperationResult = 1;
						result.NotifyMsg = "激活用户角色失败！";
						return result;
					}
					string style = string.Concat(new string[] { armID, ",", hairID, ",", faceID, ",", clothID });
					string message = null;
					if (!db3.RegisterPlayer(userName, "", nickName, style, style, armColor, hairColor, faceColor, clothColor, sex, ref message, int.Parse(ConfigurationManager.AppSettings["ValidDate"])))
					{
						result.OperationResult = 1;
						result.NotifyMsg = "更新角色信息失败！";
						return result;
					}
					bool isExist = true;
					int isFirst = 1;
					bool isError = true;
					DateTime forbidDate = DateTime.Now;
					info = db3.LoginGame(userName, ref isFirst, ref isExist, ref isError, true, ref forbidDate, nickName);
					if (info == null)
					{
						result.OperationResult = 1;
						result.NotifyMsg = "验证账号信息失败！";
						return result;
					}
					info = db3.GetUserSingleByUserID(info.ID);
					if (info == null)
					{
						result.OperationResult = 1;
						result.NotifyMsg = "获取角色信息失败！";
						return result;
					}
					Random random = new Random();
					info.Grade = grade;
					info.GP = 30000;
					info.FightPower = 498;
					info.Win = random.Next(40, 50);
					info.Total = random.Next(95, 105);
					if (db3.UpdatePlayer(info))
					{
						result.ID = info.ID;
						result.OperationResult = 0;
						result.NotifyMsg = "创建角色成功！";
						return result;
					}
					result.OperationResult = 1;
					result.NotifyMsg = "更新角色等级失败！";
					return result;
				}
			}
			result.OperationResult = 1;
			result.NotifyMsg = "角色名长度为0或超过长度限制！";
			result2 = result;
			return result2;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003CC4 File Offset: 0x00001EC4
		public CommonReturnData GMSetChargeReward(ChargeRewardInfo[] rewardInfos, ChargeRewardItem[] rewardItems)
		{
			CommonReturnData result = new CommonReturnData();
			if (this.GMInvalidChargeReward())
			{
				using (GMBussiness db = new GMBussiness())
				{
					if (!db.AddChargeReward(rewardInfos))
					{
						result.OperationResult = 1;
						result.NotifyMsg = "添加奖励信息失败";
						return result;
					}
				}
				using (GMBussiness db2 = new GMBussiness())
				{
					if (!db2.AddChargeRewardItems(rewardItems))
					{
						this.GMInvalidChargeReward();
						result.OperationResult = 1;
						result.NotifyMsg = "添加奖励物品信息失败";
						return result;
					}
				}
				result.NotifyMsg = "配置奖励信息成功！";
				result.OperationResult = 0;
				return result;
			}
			result.OperationResult = 1;
			result.NotifyMsg = "清空奖励信息失败";
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003D9C File Offset: 0x00001F9C
		public bool GMInvalidChargeReward()
		{
			bool result;
			using (GMBussiness db = new GMBussiness())
			{
				result = db.InvalidChargeReward();
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00003DD4 File Offset: 0x00001FD4
		public bool GMSetActiveState(string key, string value)
		{
			using (ServiceBussiness sb = new ServiceBussiness())
			{
				if (sb.UpdateServerPropertyByKey(key, value))
				{
					GSPacketIn pkg = new GSPacketIn(205);
					CenterServer.Instance.SendToALL(pkg, null);
					return true;
				}
			}
			return false;
		}

		// Token: 0x04000001 RID: 1
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000002 RID: 2
		private static ServiceHost host = null;
	}
}
