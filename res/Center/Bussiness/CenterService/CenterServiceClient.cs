using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Bussiness.CenterService
{
	// Token: 0x0200002C RID: 44
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	[DebuggerStepThrough]
	public class CenterServiceClient : ClientBase<ICenterService>, ICenterService
	{
		// Token: 0x0600021F RID: 543 RVA: 0x00021AFA File Offset: 0x0001FCFA
		public CenterServiceClient()
		{
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00021B02 File Offset: 0x0001FD02
		public CenterServiceClient(string endpointConfigurationName)
			: base(endpointConfigurationName)
		{
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00021B0B File Offset: 0x0001FD0B
		public CenterServiceClient(string endpointConfigurationName, string remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00021B15 File Offset: 0x0001FD15
		public CenterServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00021B1F File Offset: 0x0001FD1F
		public CenterServiceClient(Binding binding, EndpointAddress remoteAddress)
			: base(binding, remoteAddress)
		{
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00021B29 File Offset: 0x0001FD29
		public ServerData[] GetServerList()
		{
			return base.Channel.GetServerList();
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00021B36 File Offset: 0x0001FD36
		public bool ChargeMoney(int userID, string chargeID)
		{
			return base.Channel.ChargeMoney(userID, chargeID);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00021B45 File Offset: 0x0001FD45
		public bool ChargeGiftToken(int userID, int giftToken)
		{
			return base.Channel.ChargeGiftToken(userID, giftToken);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00021B54 File Offset: 0x0001FD54
		public bool SystemNotice(string msg)
		{
			return base.Channel.SystemNotice(msg);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00021B62 File Offset: 0x0001FD62
		public bool KitoffUser(int playerID, string msg)
		{
			return base.Channel.KitoffUser(playerID, msg);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00021B71 File Offset: 0x0001FD71
		public bool ReLoadServerList()
		{
			return base.Channel.ReLoadServerList();
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00021B7E File Offset: 0x0001FD7E
		public bool MailNotice(int playerID)
		{
			return base.Channel.MailNotice(playerID);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00021B8C File Offset: 0x0001FD8C
		public bool ActivePlayer(bool isActive)
		{
			return base.Channel.ActivePlayer(isActive);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00021B9A File Offset: 0x0001FD9A
		public bool CreatePlayer(int id, string name, string password, bool isFirst)
		{
			return base.Channel.CreatePlayer(id, name, password, isFirst);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00021BAC File Offset: 0x0001FDAC
		public bool ValidateLoginAndGetID(string name, string password, ref int userID, ref bool isFirst)
		{
			return base.Channel.ValidateLoginAndGetID(name, password, ref userID, ref isFirst);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00021BBE File Offset: 0x0001FDBE
		public bool AASUpdateState(bool state)
		{
			return base.Channel.AASUpdateState(state);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00021BCC File Offset: 0x0001FDCC
		public int AASGetState()
		{
			return base.Channel.AASGetState();
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00021BD9 File Offset: 0x0001FDD9
		public int ExperienceRateUpdate(int serverId)
		{
			return base.Channel.ExperienceRateUpdate(serverId);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00021BE7 File Offset: 0x0001FDE7
		public int NoticeServerUpdate(int serverId, int type)
		{
			return base.Channel.NoticeServerUpdate(serverId, type);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00021BF6 File Offset: 0x0001FDF6
		public bool UpdateConfigState(int type, bool state)
		{
			return base.Channel.UpdateConfigState(type, state);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00021C05 File Offset: 0x0001FE05
		public int GetConfigState(int type)
		{
			return base.Channel.GetConfigState(type);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00021C13 File Offset: 0x0001FE13
		public bool Reload(string type)
		{
			return base.Channel.Reload(type);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00021C21 File Offset: 0x0001FE21
		public bool CheckUserValidate(int playerID, string keyString)
		{
			return base.Channel.CheckUserValidate(playerID, keyString);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00021C30 File Offset: 0x0001FE30
		public bool SendAreaBigBugle(int playerID, int areaID, string nickName, string msg, string areaName)
		{
			return base.Channel.SendAreaBigBugle(playerID, areaID, nickName, msg, areaName);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00021C44 File Offset: 0x0001FE44
		public bool GameServerSendAreaBigBugle(int userid, int areaid, string nickName, string message, string areaName)
		{
			return base.Channel.GameServerSendAreaBigBugle(userid, areaid, nickName, message, areaName);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00021C58 File Offset: 0x0001FE58
		public bool Charge(string username, int money, bool isDirect)
		{
			return base.Channel.Charge(username, money, isDirect);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00021C68 File Offset: 0x0001FE68
		public void VisualizeRegister(string username)
		{
			base.Channel.VisualizeRegister(username);
		}
	}
}
