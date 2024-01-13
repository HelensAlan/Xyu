using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using Bussiness;
using Bussiness.Interface;
using Center.Server.Statics;
using Game.Base.Packets;
using log4net;
using SqlDataProvider.Data;

namespace Center.Server
{
	// Token: 0x02000004 RID: 4
	public class CenterService : ICenterService
	{
		// Token: 0x06000028 RID: 40 RVA: 0x00003A90 File Offset: 0x00001C90
		public List<ServerData> GetServerList()
		{
			ServerInfo[] servers = ServerMgr.Servers;
			List<ServerData> list = new List<ServerData>();
			foreach (ServerInfo serverInfo in servers)
			{
				list.Add(new ServerData
				{
					Id = serverInfo.ID,
					Name = serverInfo.Name,
					Ip = serverInfo.IP,
					Port = serverInfo.Port,
					State = serverInfo.State,
					MustLevel = serverInfo.MustLevel,
					LowestLevel = serverInfo.LowestLevel,
					Online = serverInfo.Online
				});
			}
			return list;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000215B File Offset: 0x0000035B
		public bool GameServerSendAreaBigBugle(int userid, int areaid, string nickName, string message, string areaName)
		{
			return false;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003B28 File Offset: 0x00001D28
		public bool ChargeMoney(int userID, string chargeID)
		{
			ServerClient serverClient = LoginMgr.GetServerClient(userID);
			ChargeRewardMgr.DoChargeReward(userID);
			bool result;
			if (serverClient != null)
			{
				serverClient.SendChargeMoney(userID, chargeID);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003B54 File Offset: 0x00001D54
		public bool ChargeGiftToken(int userID, int giftToken)
		{
			PlayerInfo playerInfo = null;
			using (PlayerBussiness playerBussiness = new PlayerBussiness())
			{
				playerInfo = playerBussiness.GetUserSingleByUserID(userID);
				if (playerInfo == null)
				{
					return false;
				}
			}
			MailInfo mail = new MailInfo
			{
				Content = LanguageMgr.GetTranslation("ChargeGiftTokenToUser.Content", new object[] { giftToken }),
				Title = LanguageMgr.GetTranslation("ChargeGiftTokenToUser.Title", new object[0]),
				Gold = 0,
				IsExist = true,
				Money = 0,
				GiftToken = giftToken,
				Receiver = playerInfo.NickName,
				ReceiverID = playerInfo.ID,
				Sender = playerInfo.NickName,
				SenderID = playerInfo.ID,
				Type = 1
			};
			using (PlayerBussiness playerBussiness2 = new PlayerBussiness())
			{
				if (playerBussiness2.SendMail(mail))
				{
					if (LoginMgr.GetServerClient(userID) != null)
					{
						GSPacketIn gspacketIn = new GSPacketIn(117);
						gspacketIn.WriteInt(userID);
						gspacketIn.WriteInt(1);
						CenterServer.Instance.SendToALL(gspacketIn);
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003C94 File Offset: 0x00001E94
		public bool SystemNotice(string msg)
		{
			bool result;
			try
			{
				CenterServer.Instance.SendSystemNotice(msg);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003CC8 File Offset: 0x00001EC8
		public bool KitoffUser(int playerID, string msg)
		{
			try
			{
				ServerClient serverClient = LoginMgr.GetServerClient(playerID);
				if (serverClient != null)
				{
					msg = (string.IsNullOrEmpty(msg) ? "You are kicking out by GM!" : msg);
					serverClient.SendKitoffUser(playerID, msg);
					Console.WriteLine(msg);
					LoginMgr.RemovePlayer(playerID);
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000215E File Offset: 0x0000035E
		public bool ReLoadServerList()
		{
			return ServerMgr.ReLoadServerList();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003D24 File Offset: 0x00001F24
		public bool MailNotice(int playerID)
		{
			try
			{
				ServerClient serverClient = LoginMgr.GetServerClient(playerID);
				if (serverClient != null)
				{
					GSPacketIn gspacketIn = new GSPacketIn(117);
					gspacketIn.WriteInt(playerID);
					gspacketIn.WriteInt(1);
					serverClient.SendTCP(gspacketIn);
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003D74 File Offset: 0x00001F74
		public bool AASUpdateState(bool state)
		{
			try
			{
				GameProperties.ASS_STATE = state;
				GameProperties.Save();
				return CenterServer.Instance.ClientsExecuteCmd("/load /property");
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003DB4 File Offset: 0x00001FB4
		public int AASGetState()
		{
			try
			{
				return GameProperties.ASS_STATE ? 1 : 0;
			}
			catch
			{
			}
			return 2;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003DE8 File Offset: 0x00001FE8
		public int ExperienceRateUpdate(int serverId)
		{
			try
			{
				return CenterServer.Instance.RateUpdate(serverId);
			}
			catch
			{
			}
			return 2;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003E1C File Offset: 0x0000201C
		public int NoticeServerUpdate(int serverId, int type)
		{
			try
			{
				return CenterServer.Instance.NoticeServerUpdate(serverId, type);
			}
			catch
			{
			}
			return 2;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003E50 File Offset: 0x00002050
		public bool UpdateConfigState(int type, bool state)
		{
			try
			{
				if (type == 1)
				{
					GameProperties.ASS_STATE = state;
				}
				else
				{
					GameProperties.DAILY_AWARD_STATE = state;
				}
				GameProperties.Save();
				return CenterServer.Instance.ClientsExecuteCmd("/load /property");
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003E9C File Offset: 0x0000209C
		public int GetConfigState(int type)
		{
			try
			{
				if (type == 1)
				{
					return GameProperties.ASS_STATE ? 1 : 0;
				}
				if (type == 2)
				{
					return GameProperties.DAILY_AWARD_STATE ? 1 : 0;
				}
			}
			catch
			{
			}
			return 2;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003EE8 File Offset: 0x000020E8
		public bool Reload(string type)
		{
			try
			{
				return CenterServer.Instance.ClientsExecuteCmd("/load /" + type);
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003F24 File Offset: 0x00002124
		public bool ActivePlayer(bool isActive)
		{
			try
			{
				if (isActive)
				{
					LogMgr.AddRegCount();
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003F58 File Offset: 0x00002158
		public bool CreatePlayer(int id, string name, string password, bool isFirst)
		{
			try
			{
				LoginMgr.CreatePlayer(new Player
				{
					Id = id,
					Name = name,
					Password = password,
					IsFirst = isFirst
				});
				return true;
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003FA8 File Offset: 0x000021A8
		public bool ValidateLoginAndGetID(string name, string password, ref int userID, ref bool isFirst)
		{
			try
			{
				Player[] allPlayer = LoginMgr.GetAllPlayer();
				if (allPlayer != null)
				{
					foreach (Player player in allPlayer)
					{
						if (player.Name == name && player.Password == password)
						{
							userID = player.Id;
							isFirst = player.IsFirst;
							return true;
						}
					}
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00004020 File Offset: 0x00002220
		public bool CheckUserValidate(int playerID, string keyString)
		{
			try
			{
				Player player = LoginMgr.GetPlayer(playerID);
				if (player != null)
				{
					return BaseInterface.md5(player.Password) == keyString;
				}
			}
			catch (Exception arg)
			{
				CenterService.log.Error(string.Format("Check User Validate Error:{0}", arg));
			}
			return false;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002165 File Offset: 0x00000365
		public bool Charge(string username, int money, bool isDirect)
		{
			return CenterServer.Instance.Charge(username, money, isDirect);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002174 File Offset: 0x00000374
		public void VisualizeRegister(string username)
		{
			CenterServer.CrossServer.SendCreateCharacter(username);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00004078 File Offset: 0x00002278
		public static bool Start()
		{
			bool result;
			try
			{
				CenterService.host = new ServiceHost(typeof(CenterService), new Uri[0]);
				CenterService.host.Open();
				CenterService.log.Info("Center Service started!");
				result = true;
			}
			catch (Exception arg)
			{
				CenterService.log.ErrorFormat("Start center server failed:{0}", arg);
				result = false;
			}
			return result;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000040E4 File Offset: 0x000022E4
		public static void Stop()
		{
			try
			{
				if (CenterService.host != null)
				{
					CenterService.host.Close();
					CenterService.host = null;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400001F RID: 31
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000020 RID: 32
		private static ServiceHost host;
	}
}
