using System;
using System.CodeDom.Compiler;
using System.ServiceModel;

namespace Bussiness.CenterService
{
	// Token: 0x0200002D RID: 45
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	[ServiceContract(ConfigurationName = "CenterService.ICenterService")]
	public interface ICenterService
	{
		// Token: 0x0600023A RID: 570
		[OperationContract(Action = "http://tempuri.org/ICenterService/GetServerList", ReplyAction = "http://tempuri.org/ICenterService/GetServerListResponse")]
		ServerData[] GetServerList();

		// Token: 0x0600023B RID: 571
		[OperationContract(Action = "http://tempuri.org/ICenterService/ChargeMoney", ReplyAction = "http://tempuri.org/ICenterService/ChargeMoneyResponse")]
		bool ChargeMoney(int userID, string chargeID);

		// Token: 0x0600023C RID: 572
		[OperationContract(Action = "http://tempuri.org/ICenterService/ChargeGiftToken", ReplyAction = "http://tempuri.org/ICenterService/ChargeGiftTokenResponse")]
		bool ChargeGiftToken(int userID, int giftToken);

		// Token: 0x0600023D RID: 573
		[OperationContract(Action = "http://tempuri.org/ICenterService/SystemNotice", ReplyAction = "http://tempuri.org/ICenterService/SystemNoticeResponse")]
		bool SystemNotice(string msg);

		// Token: 0x0600023E RID: 574
		[OperationContract(Action = "http://tempuri.org/ICenterService/KitoffUser", ReplyAction = "http://tempuri.org/ICenterService/KitoffUserResponse")]
		bool KitoffUser(int playerID, string msg);

		// Token: 0x0600023F RID: 575
		[OperationContract(Action = "http://tempuri.org/ICenterService/ReLoadServerList", ReplyAction = "http://tempuri.org/ICenterService/ReLoadServerListResponse")]
		bool ReLoadServerList();

		// Token: 0x06000240 RID: 576
		[OperationContract(Action = "http://tempuri.org/ICenterService/MailNotice", ReplyAction = "http://tempuri.org/ICenterService/MailNoticeResponse")]
		bool MailNotice(int playerID);

		// Token: 0x06000241 RID: 577
		[OperationContract(Action = "http://tempuri.org/ICenterService/ActivePlayer", ReplyAction = "http://tempuri.org/ICenterService/ActivePlayerResponse")]
		bool ActivePlayer(bool isActive);

		// Token: 0x06000242 RID: 578
		[OperationContract(Action = "http://tempuri.org/ICenterService/CreatePlayer", ReplyAction = "http://tempuri.org/ICenterService/CreatePlayerResponse")]
		bool CreatePlayer(int id, string name, string password, bool isFirst);

		// Token: 0x06000243 RID: 579
		[OperationContract(Action = "http://tempuri.org/ICenterService/ValidateLoginAndGetID", ReplyAction = "http://tempuri.org/ICenterService/ValidateLoginAndGetIDResponse")]
		bool ValidateLoginAndGetID(string name, string password, ref int userID, ref bool isFirst);

		// Token: 0x06000244 RID: 580
		[OperationContract(Action = "http://tempuri.org/ICenterService/AASUpdateState", ReplyAction = "http://tempuri.org/ICenterService/AASUpdateStateResponse")]
		bool AASUpdateState(bool state);

		// Token: 0x06000245 RID: 581
		[OperationContract(Action = "http://tempuri.org/ICenterService/AASGetState", ReplyAction = "http://tempuri.org/ICenterService/AASGetStateResponse")]
		int AASGetState();

		// Token: 0x06000246 RID: 582
		[OperationContract(Action = "http://tempuri.org/ICenterService/ExperienceRateUpdate", ReplyAction = "http://tempuri.org/ICenterService/ExperienceRateUpdateResponse")]
		int ExperienceRateUpdate(int serverId);

		// Token: 0x06000247 RID: 583
		[OperationContract(Action = "http://tempuri.org/ICenterService/NoticeServerUpdate", ReplyAction = "http://tempuri.org/ICenterService/NoticeServerUpdateResponse")]
		int NoticeServerUpdate(int serverId, int type);

		// Token: 0x06000248 RID: 584
		[OperationContract(Action = "http://tempuri.org/ICenterService/UpdateConfigState", ReplyAction = "http://tempuri.org/ICenterService/UpdateConfigStateResponse")]
		bool UpdateConfigState(int type, bool state);

		// Token: 0x06000249 RID: 585
		[OperationContract(Action = "http://tempuri.org/ICenterService/GetConfigState", ReplyAction = "http://tempuri.org/ICenterService/GetConfigStateResponse")]
		int GetConfigState(int type);

		// Token: 0x0600024A RID: 586
		[OperationContract(Action = "http://tempuri.org/ICenterService/Reload", ReplyAction = "http://tempuri.org/ICenterService/ReloadResponse")]
		bool Reload(string type);

		// Token: 0x0600024B RID: 587
		[OperationContract(Action = "http://tempuri.org/ICenterService/CheckUserValidate", ReplyAction = "http://tempuri.org/ICenterService/CheckUserValidateResponse")]
		bool CheckUserValidate(int playerID, string keyString);

		// Token: 0x0600024C RID: 588
		[OperationContract(Action = "http://tempuri.org/ICenterService/SendAreaBigBugle", ReplyAction = "http://tempuri.org/ICenterService/SendAreaBigBugleResponse")]
		bool SendAreaBigBugle(int playerID, int areaID, string nickName, string msg, string areaName);

		// Token: 0x0600024D RID: 589
		[OperationContract(Action = "http://tempuri.org/ICenterService/GameServerSendAreaBigBugle", ReplyAction = "http://tempuri.org/ICenterService/GameServerSendAreaBigBugleResponse")]
		bool GameServerSendAreaBigBugle(int userid, int areaid, string nickName, string message, string areaName);

		// Token: 0x0600024E RID: 590
		[OperationContract(Action = "http://tempuri.org/ICenterService/Charge", ReplyAction = "http://tempuri.org/ICenterService/ChargeResponse")]
		bool Charge(string username, int money, bool isDirect);

		// Token: 0x0600024F RID: 591
		[OperationContract(Action = "http://tempuri.org/ICenterService/VisualizeRegister", ReplyAction = "http://tempuri.org/ICenterService/VisualizeRegisterResponse")]
		void VisualizeRegister(string username);
	}
}
