using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Center.Server
{
	// Token: 0x0200000E RID: 14
	[ServiceContract]
	public interface ICenterService
	{
		// Token: 0x0600005F RID: 95
		[OperationContract]
		List<ServerData> GetServerList();

		// Token: 0x06000060 RID: 96
		[OperationContract]
		bool ChargeMoney(int userID, string chargeID);

		// Token: 0x06000061 RID: 97
		[OperationContract]
		bool ChargeGiftToken(int userID, int giftToken);

		// Token: 0x06000062 RID: 98
		[OperationContract]
		bool SystemNotice(string msg);

		// Token: 0x06000063 RID: 99
		[OperationContract]
		bool KitoffUser(int playerID, string msg);

		// Token: 0x06000064 RID: 100
		[OperationContract]
		bool ReLoadServerList();

		// Token: 0x06000065 RID: 101
		[OperationContract]
		bool MailNotice(int playerID);

		// Token: 0x06000066 RID: 102
		[OperationContract]
		bool ActivePlayer(bool isActive);

		// Token: 0x06000067 RID: 103
		[OperationContract]
		bool CreatePlayer(int id, string name, string password, bool isFirst);

		// Token: 0x06000068 RID: 104
		[OperationContract]
		bool ValidateLoginAndGetID(string name, string password, ref int userID, ref bool isFirst);

		// Token: 0x06000069 RID: 105
		[OperationContract]
		bool AASUpdateState(bool state);

		// Token: 0x0600006A RID: 106
		[OperationContract]
		int AASGetState();

		// Token: 0x0600006B RID: 107
		[OperationContract]
		int ExperienceRateUpdate(int serverId);

		// Token: 0x0600006C RID: 108
		[OperationContract]
		int NoticeServerUpdate(int serverId, int type);

		// Token: 0x0600006D RID: 109
		[OperationContract]
		bool UpdateConfigState(int type, bool state);

		// Token: 0x0600006E RID: 110
		[OperationContract]
		int GetConfigState(int type);

		// Token: 0x0600006F RID: 111
		[OperationContract]
		bool Reload(string type);

		// Token: 0x06000070 RID: 112
		[OperationContract]
		bool CheckUserValidate(int playerID, string keyString);

		// Token: 0x06000071 RID: 113
		[OperationContract]
		bool Charge(string username, int money, bool isDirect);

		// Token: 0x06000072 RID: 114
		[OperationContract]
		void VisualizeRegister(string username);
	}
}
