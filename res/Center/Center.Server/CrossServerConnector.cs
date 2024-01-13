using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using Bussiness;
using Game.Base;
using Game.Base.Packets;
using log4net;
using SqlDataProvider.Data;

namespace Center.Server
{
	// Token: 0x02000009 RID: 9
	public class CrossServerConnector : BaseConnector
	{
		// Token: 0x06000052 RID: 82 RVA: 0x0000222C File Offset: 0x0000042C
		protected override void OnConnect()
		{
			base.OnConnect();
			this.m_privLevel = ePrivLevel.Admin;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000223B File Offset: 0x0000043B
		protected override void OnDisconnect()
		{
			base.OnDisconnect();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002243 File Offset: 0x00000443
		public override void OnRecvPacket(GSPacketIn pkg)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.AsynProcessPacket), pkg);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004690 File Offset: 0x00002890
		protected void AsynProcessPacket(object state)
		{
			try
			{
				GSPacketIn gspacketIn = state as GSPacketIn;
				short code = gspacketIn.Code;
				switch (code)
				{
				case 0:
					this.HandleRSAKey(gspacketIn);
					break;
				case 1:
					break;
				case 2:
					this.HandleChargeReward(gspacketIn);
					break;
				case 3:
					this.HandleCreateCharacter(gspacketIn);
					break;
				default:
					if (code == 25)
					{
						this.HandleAreaBigBugle(gspacketIn);
					}
					break;
				}
			}
			catch (Exception exception)
			{
				CrossServerConnector.log.Error("AsynProcessPacket", exception);
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004710 File Offset: 0x00002910
		protected void HandleRSAKey(GSPacketIn packet)
		{
			RSAParameters parameters = default(RSAParameters);
			parameters.Modulus = packet.ReadBytes(128);
			parameters.Exponent = packet.ReadBytes();
			new RSACryptoServiceProvider().ImportParameters(parameters);
			this.SendKey();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002258 File Offset: 0x00000458
		private void HandleAreaBigBugle(GSPacketIn pkg)
		{
			CrossServerConnector.log.Debug("HandleAreaBigBugle");
			CenterServer.Instance.SendToALL(pkg);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004758 File Offset: 0x00002958
		private void HandleChargeReward(GSPacketIn pkg)
		{
			string text = pkg.ReadString();
			int num = pkg.ReadInt();
			int num2 = pkg.ReadInt();
			string text2 = pkg.ReadString();
			CrossServerConnector.log.Debug(string.Format("HandleChargeReward {0},{1},{2},{3}", new object[] { num2, text, num, text2 }));
			using (PlayerBussiness playerBussiness = new PlayerBussiness())
			{
				bool flag = num2 == CenterServer.Instance.Config.BigAreaID;
				PlayerInfo userSingleByUserName = playerBussiness.GetUserSingleByUserName(text2);
				if (userSingleByUserName != null)
				{
					if (flag)
					{
						PlayerInfo userSingleByUserName2 = playerBussiness.GetUserSingleByUserName(text);
						playerBussiness.SendMail(new MailInfo
						{
							Sender = "推广系统",
							Title = "推广系统提示",
							Receiver = userSingleByUserName.NickName,
							ReceiverID = userSingleByUserName.ID,
							Content = string.Format("亲爱的弹友，您所推广来的玩家{0}，角色名{1}，充值{2}元，返利已下发到您的账户。", text, userSingleByUserName2.NickName, num)
						});
						CenterServer.Instance.MailNotice(userSingleByUserName.ID);
					}
					else
					{
						playerBussiness.SendMail(new MailInfo
						{
							Sender = "推广系统",
							Title = "推广系统提示",
							Receiver = userSingleByUserName.NickName,
							ReceiverID = userSingleByUserName.ID,
							Content = string.Format("亲爱的弹友，您所推广来的玩家{0}，在{1}区，充值{2}元，返利已下发到您的账户。", text, num2, num)
						});
						CenterServer.Instance.MailNotice(userSingleByUserName.ID);
					}
				}
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000048F4 File Offset: 0x00002AF4
		private void HandleCreateCharacter(GSPacketIn pkg)
		{
			string text = pkg.ReadString();
			int num = pkg.ReadInt();
			string text2 = pkg.ReadString();
			CrossServerConnector.log.Debug(string.Format("HandleInviteSystemCreateCharacter {0},{1},{2}", num, text, text2));
			using (PlayerBussiness playerBussiness = new PlayerBussiness())
			{
				bool flag = num == CenterServer.Instance.Config.BigAreaID;
				PlayerInfo userSingleByUserName = playerBussiness.GetUserSingleByUserName(text2);
				if (flag)
				{
					PlayerInfo userSingleByUserName2 = playerBussiness.GetUserSingleByUserName(text);
					if (userSingleByUserName != null)
					{
						playerBussiness.SendMail(new MailInfo
						{
							Sender = "推广系统",
							Title = "推广系统提示",
							Receiver = userSingleByUserName2.NickName,
							ReceiverID = userSingleByUserName2.ID,
							Content = string.Concat(new string[] { "亲爱的萌新弹友，您是通过上级玩家", text2, "的推广链接进入游戏，其在本区的角色名为", userSingleByUserName.NickName, "，请联系他/她带你副本，帮助你早日起飞。" })
						});
						playerBussiness.SendMail(new MailInfo
						{
							Sender = "推广系统",
							Title = "推广系统提示",
							Receiver = userSingleByUserName.NickName,
							ReceiverID = userSingleByUserName.ID,
							Content = string.Concat(new string[] { "亲爱的弹友，您所推广来的玩家", text, "，已进入游戏，其在本区的角色名为", userSingleByUserName2.NickName, "。请给予他/她应有的帮助，帮助他/她早日起飞。" })
						});
						CenterServer.Instance.MailNotice(userSingleByUserName2.ID);
						CenterServer.Instance.MailNotice(userSingleByUserName.ID);
					}
					else
					{
						playerBussiness.SendMail(new MailInfo
						{
							Sender = "推广系统",
							Title = "推广系统提示",
							Receiver = userSingleByUserName2.NickName,
							ReceiverID = userSingleByUserName2.ID,
							Content = "亲爱的萌新弹友，您是通过上级玩家" + text2 + "的推广链接进入游戏，其尚未在本区建立角色。"
						});
						CenterServer.Instance.MailNotice(userSingleByUserName2.ID);
					}
				}
				else if (userSingleByUserName != null)
				{
					playerBussiness.SendMail(new MailInfo
					{
						Sender = "推广系统",
						Title = "推广系统提示",
						Receiver = userSingleByUserName.NickName,
						ReceiverID = userSingleByUserName.ID,
						Content = string.Format("亲爱的弹友，您所推广来的玩家{0}，已在{1}区进入游戏。", text, num)
					});
					CenterServer.Instance.MailNotice(userSingleByUserName.ID);
				}
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004B80 File Offset: 0x00002D80
		private void SendKey()
		{
			GSPacketIn gspacketIn = new GSPacketIn(1);
			gspacketIn.WriteString(this.key);
			gspacketIn.WriteInt(CenterServer.Instance.Config.BigAreaID);
			this.SendTCP(gspacketIn);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004BBC File Offset: 0x00002DBC
		public void SendChargeReward(string username, int count)
		{
			GSPacketIn gspacketIn = new GSPacketIn(2);
			gspacketIn.WriteString(username);
			gspacketIn.WriteInt(count);
			this.SendTCP(gspacketIn);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004BE8 File Offset: 0x00002DE8
		public void SendCreateCharacter(string loginName)
		{
			CrossServerConnector.log.Debug("SendCreateCharacter " + loginName);
			GSPacketIn gspacketIn = new GSPacketIn(3);
			gspacketIn.WriteString(loginName);
			this.SendTCP(gspacketIn);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002274 File Offset: 0x00000474
		public CrossServerConnector(string ip, int port, string key, byte[] readBuffer, byte[] sendBuffer)
			: base(ip, port, true, readBuffer, sendBuffer)
		{
			this.key = key;
			base.Strict = false;
		}

		// Token: 0x04000029 RID: 41
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x0400002A RID: 42
		private string key;
	}
}
