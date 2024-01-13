using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Bussiness;
using Center.Server.Managers;
using Game.Base;
using Game.Base.Packets;
using log4net;
using SqlDataProvider.Data;

namespace Center.Server
{
	// Token: 0x02000011 RID: 17
	public class ServerClient : BaseClient
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000083 RID: 131 RVA: 0x000022CD File Offset: 0x000004CD
		// (set) Token: 0x06000084 RID: 132 RVA: 0x000022D5 File Offset: 0x000004D5
		public ServerInfo Info { get; set; }

		// Token: 0x06000085 RID: 133 RVA: 0x00005150 File Offset: 0x00003350
		protected override void OnConnect()
		{
			base.OnConnect();
			this._rsa = new RSACryptoServiceProvider();
			RSAParameters rsaparameters = this._rsa.ExportParameters(false);
			this.SendRSAKey(rsaparameters.Modulus, rsaparameters.Exponent);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00005190 File Offset: 0x00003390
		protected override void OnDisconnect()
		{
			base.OnDisconnect();
			this._rsa = null;
			if (!this.IsManager)
			{
				List<Player> serverPlayers = LoginMgr.GetServerPlayers(this);
				LoginMgr.RemovePlayer(serverPlayers);
				this.SendUserOffline(serverPlayers);
				ServerClient.log.InfoFormat("{0}({1}:{2}) disconntected!", this.Info.Name, this.Info.IP, this.Info.Port);
				if (this.Info != null)
				{
					this.Info.State = 1;
					this.Info.Online = 0;
				}
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000521C File Offset: 0x0000341C
		public override void OnRecvPacket(GSPacketIn pkg)
		{
			short code = pkg.Code;
			if (code <= 130)
			{
				if (code <= 117)
				{
					switch (code)
					{
					case 1:
						this.HandleLogin(pkg);
						return;
					case 2:
					case 7:
					case 8:
					case 9:
					case 16:
					case 17:
					case 18:
					case 20:
					case 21:
					case 22:
					case 23:
					case 24:
					case 27:
					case 28:
					case 29:
					case 30:
					case 31:
					case 32:
					case 33:
					case 34:
					case 35:
					case 36:
						break;
					case 3:
						this.HandleUserLogin(pkg);
						return;
					case 4:
						this.HandleUserOffline(pkg);
						return;
					case 5:
						this.HandleUserOnline(pkg);
						return;
					case 6:
						this.HandleQuestUserState(pkg);
						return;
					case 10:
						this.HandkeItemStrengthen(pkg);
						return;
					case 11:
						this.HandleCmdResult(pkg);
						return;
					case 12:
						this.HandlePing(pkg);
						return;
					case 13:
						this.HandleUpdatePlayerState(pkg);
						return;
					case 14:
						this.HandleGetItemMessage(pkg);
						return;
					case 15:
						this.HandleShutdown(pkg);
						return;
					case 19:
						this.HandleChatScene(pkg);
						return;
					case 25:
						this.HandleAreaBigBugle(pkg);
						return;
					case 26:
						this.HandleMarryRoomInfoToPlayer(pkg);
						return;
					case 37:
						this.HandleChatPersonal(pkg);
						return;
					default:
						if (code == 72)
						{
							this.HandleBigBugle(pkg);
							return;
						}
						if (code != 117)
						{
							return;
						}
						this.HandleMailResponse(pkg);
						return;
					}
				}
				else if (code <= 123)
				{
					if (code == 118)
					{
						this.HandleMessage(pkg);
						return;
					}
					if (code != 123)
					{
						return;
					}
					this.HandleDispatches(pkg);
					return;
				}
				else
				{
					if (code == 128)
					{
						this.HandleConsortiaResponse(pkg);
						return;
					}
					if (code != 130)
					{
						return;
					}
					this.HandleConsortiaCreate(pkg);
					return;
				}
			}
			else if (code <= 204)
			{
				if (code <= 168)
				{
					switch (code)
					{
					case 156:
						this.HandleConsortiaOffer(pkg);
						return;
					case 157:
					case 159:
						break;
					case 158:
						this.HandleConsortiaFight(pkg);
						return;
					case 160:
						this.HandleFriend(pkg);
						return;
					default:
						if (code != 168)
						{
							return;
						}
						this.HandleUpdateLimitCount(pkg);
						return;
					}
				}
				else
				{
					if (code == 178)
					{
						this.HandleMacroDrop(pkg);
						return;
					}
					if (code != 204)
					{
						return;
					}
					this.HandleUpdateShopNotice(pkg);
					return;
				}
			}
			else if (code <= 241)
			{
				if (code == 240)
				{
					this.HandleIPAndPort(pkg);
					return;
				}
				if (code != 241)
				{
					return;
				}
				this.HandleMarryRoomDispose(pkg);
				return;
			}
			else
			{
				if (code == 252)
				{
					this.HandleManagerLogin(pkg);
					return;
				}
				if (code != 254)
				{
					return;
				}
				this.HandleManagerCmd(pkg);
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000022DE File Offset: 0x000004DE
		public void HandleManagerLogin(GSPacketIn pkg)
		{
			if (pkg.ReadString() == ServerClient.MANAGER_KEY)
			{
				this.IsManager = true;
				return;
			}
			this.Disconnect();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000054A0 File Offset: 0x000036A0
		public void HandleManagerCmd(GSPacketIn pkg)
		{
			if (this.IsManager)
			{
				string text = pkg.ReadString();
				try
				{
					if (!CommandMgr.HandleCommandNoPlvl(this, text))
					{
						this.DisplayMessage("Unknown command: " + text);
					}
				}
				catch (Exception ex)
				{
					this.DisplayMessage("error:" + ex.Message);
				}
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00005504 File Offset: 0x00003704
		public override void DisplayMessage(string msg)
		{
			if (this.IsManager)
			{
				GSPacketIn gspacketIn = new GSPacketIn(255);
				gspacketIn.WriteString(msg);
				this.SendTCP(gspacketIn);
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00002300 File Offset: 0x00000500
		private void HandleGetItemMessage(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00005534 File Offset: 0x00003734
		public void HandleLogin(GSPacketIn pkg)
		{
			byte[] rgb = pkg.ReadBytes();
			string @string = Encoding.UTF8.GetString(this._rsa.Decrypt(rgb, false));
			string[] array = @string.Split(new char[] { ',' });
			if (array.Length != 2)
			{
				ServerClient.log.ErrorFormat("Error Login Packet from {0},content:{1}", base.TcpEndpoint, @string);
				this.Disconnect();
				return;
			}
			this._rsa = null;
			int num = int.Parse(array[0]);
			this.Info = ServerMgr.GetServerInfo(num);
			if (this.Info == null || this.Info.State != 1)
			{
				ServerClient.log.ErrorFormat("Error Login Packet from {0} want to login serverid:{1}", base.TcpEndpoint, num);
				this.Disconnect();
				return;
			}
			base.Strict = false;
			this.Info.Online = 0;
			this.Info.State = 2;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000230F File Offset: 0x0000050F
		public void HandleIPAndPort(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00005608 File Offset: 0x00003808
		private void HandleUserLogin(GSPacketIn pkg)
		{
			int num = pkg.ReadInt();
			if (LoginMgr.TryLoginPlayer(num, this))
			{
				this.SendAllowUserLogin(num, true);
				return;
			}
			this.SendAllowUserLogin(num, false);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00005638 File Offset: 0x00003838
		private void HandleUserOnline(GSPacketIn pkg)
		{
			int num = pkg.ReadInt();
			for (int i = 0; i < num; i++)
			{
				int id = pkg.ReadInt();
				pkg.ReadInt();
				LoginMgr.PlayerLogined(id, this);
			}
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00005678 File Offset: 0x00003878
		private void HandleUserOffline(GSPacketIn pkg)
		{
			new List<int>();
			int num = pkg.ReadInt();
			for (int i = 0; i < num; i++)
			{
				int id = pkg.ReadInt();
				pkg.ReadInt();
				LoginMgr.PlayerLoginOut(id, this);
			}
			this._svr.SendToALL(pkg);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000056C0 File Offset: 0x000038C0
		private void HandleUserPrivateMsg(GSPacketIn pkg, int playerid)
		{
			ServerClient serverClient = LoginMgr.GetServerClient(playerid);
			if (serverClient != null)
			{
				serverClient.SendTCP(pkg);
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000231E File Offset: 0x0000051E
		public void HandleUserPublicMsg(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000056E0 File Offset: 0x000038E0
		public void HandleQuestUserState(GSPacketIn pkg)
		{
			int num = pkg.ReadInt();
			if (LoginMgr.GetServerClient(num) == null)
			{
				this.SendUserState(num, false);
				return;
			}
			this.SendUserState(num, true);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000232D File Offset: 0x0000052D
		public void HandlePing(GSPacketIn pkg)
		{
			this.Info.Online = pkg.ReadInt();
			this.Info.State = ServerMgr.GetState(this.Info.Online, this.Info.Total);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00005710 File Offset: 0x00003910
		public void HandleChatPersonal(GSPacketIn pkg)
		{
			ServerClient serverClient = LoginMgr.GetServerClient(pkg.ReadInt());
			if (serverClient != null)
			{
				serverClient.SendTCP(pkg);
				return;
			}
			int clientID = pkg.ClientID;
			string str = pkg.ReadString();
			GSPacketIn gspacketIn = new GSPacketIn(38);
			gspacketIn.WriteInt(1);
			gspacketIn.WriteInt(clientID);
			gspacketIn.WriteString(str);
			this.SendTCP(gspacketIn);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00002366 File Offset: 0x00000566
		public void HandleBigBugle(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00002375 File Offset: 0x00000575
		public void HandleDispatches(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00002384 File Offset: 0x00000584
		private void HandleAreaBigBugle(GSPacketIn pkg)
		{
			CenterServer.CrossServer.SendTCP(pkg);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00002391 File Offset: 0x00000591
		public void HandleFriend(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000023A0 File Offset: 0x000005A0
		public void HandleFriendState(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000023AF File Offset: 0x000005AF
		public void HandleUpdateLimitCount(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000023BE File Offset: 0x000005BE
		public void HandleUpdateShopNotice(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000023CD File Offset: 0x000005CD
		public void HandleFirendResponse(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00005768 File Offset: 0x00003968
		public void HandleMailResponse(GSPacketIn pkg)
		{
			int playerid = pkg.ReadInt();
			this.HandleUserPrivateMsg(pkg, playerid);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000023DC File Offset: 0x000005DC
		public void HandleChatScene(GSPacketIn pkg)
		{
			pkg.ReadInt();
			if (pkg.ReadByte() == 3)
			{
				this.HandleChatConsortia(pkg);
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000023F5 File Offset: 0x000005F5
		public void HandleChatConsortia(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002404 File Offset: 0x00000604
		public void HandleConsortiaResponse(GSPacketIn pkg)
		{
			pkg.ReadByte();
			this._svr.SendToALL(pkg, null);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000241A File Offset: 0x0000061A
		public void HandleConsortiaOffer(GSPacketIn pkg)
		{
			pkg.ReadInt();
			pkg.ReadInt();
			pkg.ReadInt();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00002431 File Offset: 0x00000631
		public void HandleConsortiaCreate(GSPacketIn pkg)
		{
			pkg.ReadInt();
			pkg.ReadInt();
			this._svr.SendToALL(pkg, null);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000244E File Offset: 0x0000064E
		public void HandleConsortiaUpGrade(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000245D File Offset: 0x0000065D
		public void HandleConsortiaFight(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000246B File Offset: 0x0000066B
		public void HandkeItemStrengthen(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg, this);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00005784 File Offset: 0x00003984
		public void HandleUpdatePlayerState(GSPacketIn pkg)
		{
			Player player = LoginMgr.GetPlayer(pkg.ReadInt());
			if (player != null && player.CurrentServer != null)
			{
				player.CurrentServer.SendTCP(pkg);
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000057B4 File Offset: 0x000039B4
		public void HandleMarryRoomInfoToPlayer(GSPacketIn pkg)
		{
			Player player = LoginMgr.GetPlayer(pkg.ReadInt());
			if (player != null && player.CurrentServer != null)
			{
				player.CurrentServer.SendTCP(pkg);
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000247A File Offset: 0x0000067A
		public void HandleMarryRoomDispose(GSPacketIn pkg)
		{
			this._svr.SendToALL(pkg);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000057E4 File Offset: 0x000039E4
		public void HandleShutdown(GSPacketIn pkg)
		{
			int num = pkg.ReadInt();
			if (pkg.ReadBoolean())
			{
				Console.WriteLine(num.ToString() + "  begin stoping !");
				return;
			}
			Console.WriteLine(num.ToString() + "  is stoped !");
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00005830 File Offset: 0x00003A30
		public void HandleMacroDrop(GSPacketIn pkg)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			int num = pkg.ReadInt();
			for (int i = 0; i < num; i++)
			{
				int key = pkg.ReadInt();
				int value = pkg.ReadInt();
				dictionary.Add(key, value);
			}
			MacroDropMgr.DropNotice(dictionary);
			this.NeedSyncMacroDrop = true;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000587C File Offset: 0x00003A7C
		public void SendRSAKey(byte[] m, byte[] e)
		{
			GSPacketIn gspacketIn = new GSPacketIn(0);
			gspacketIn.Write(m);
			gspacketIn.Write(e);
			this.SendTCP(gspacketIn);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000058A8 File Offset: 0x00003AA8
		public void SendAllowUserLogin(int playerid, bool allow)
		{
			GSPacketIn gspacketIn = new GSPacketIn(3);
			gspacketIn.WriteInt(playerid);
			gspacketIn.WriteBoolean(allow);
			this.SendTCP(gspacketIn);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00002488 File Offset: 0x00000688
		public void SendKitoffUser(int playerid)
		{
			this.SendKitoffUser(playerid, LanguageMgr.GetTranslation("Center.Server.SendKitoffUser", new object[0]));
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000058D4 File Offset: 0x00003AD4
		public void SendKitoffUser(int playerid, string msg)
		{
			GSPacketIn gspacketIn = new GSPacketIn(2);
			gspacketIn.WriteInt(playerid);
			gspacketIn.WriteString(msg);
			this.SendTCP(gspacketIn);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00005900 File Offset: 0x00003B00
		public void SendUserOffline(List<Player> users)
		{
			for (int i = 0; i < users.Count; i += 100)
			{
				int num = ((i + 100 > users.Count) ? (users.Count - i) : 100);
				GSPacketIn gspacketIn = new GSPacketIn(4);
				gspacketIn.WriteInt(num);
				for (int j = i; j < i + num; j++)
				{
					gspacketIn.WriteInt(users[j].Id);
					gspacketIn.WriteInt(0);
				}
				this.SendTCP(gspacketIn);
				this._svr.SendToALL(gspacketIn, this);
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00005984 File Offset: 0x00003B84
		public void SendUserState(int player, bool state)
		{
			GSPacketIn gspacketIn = new GSPacketIn(6, player);
			gspacketIn.WriteBoolean(state);
			this.SendTCP(gspacketIn);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000059A8 File Offset: 0x00003BA8
		public void SendChargeMoney(int player, string chargeID)
		{
			GSPacketIn gspacketIn = new GSPacketIn(9, player);
			gspacketIn.WriteString(chargeID);
			this.SendTCP(gspacketIn);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000059CC File Offset: 0x00003BCC
		public void SendChargeGiftToken(int player, int giftToken)
		{
			GSPacketIn gspacketIn = new GSPacketIn(16, player);
			gspacketIn.WriteInt(giftToken);
			this.SendTCP(gspacketIn);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000059F0 File Offset: 0x00003BF0
		public void SendASS(bool state)
		{
			GSPacketIn gspacketIn = new GSPacketIn(7);
			gspacketIn.WriteBoolean(state);
			this.SendTCP(gspacketIn);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00005A14 File Offset: 0x00003C14
		public void HandleCmdResult(GSPacketIn pkg)
		{
			if (this.m_currentCmdClient != null)
			{
				string msg = string.Format("{0}:'{1}' execute:{2}", this.Info.Name, pkg.ReadString(), pkg.ReadBoolean());
				this.m_currentCmdClient.DisplayMessage(msg);
				this.m_currentCmdClient = null;
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00005A64 File Offset: 0x00003C64
		public void SendCmd(BaseClient cmdclient, string cmdLine)
		{
			this.m_currentCmdClient = cmdclient;
			if (cmdLine.Length > 0 && cmdLine[0] == '/')
			{
				cmdLine = cmdLine.Remove(0, 1);
				cmdLine = cmdLine.Insert(0, "&");
			}
			GSPacketIn gspacketIn = new GSPacketIn(11);
			gspacketIn.WriteString(cmdLine);
			this.SendTCP(gspacketIn);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000024A1 File Offset: 0x000006A1
		public ServerClient(CenterServer svr)
			: base(new byte[8192], new byte[8192])
		{
			this._svr = svr;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000024C4 File Offset: 0x000006C4
		public void HandleMessage(GSPacketIn packet)
		{
			if (this.m_currentCmdClient != null)
			{
				this.m_currentCmdClient.DisplayMessage(string.Format("{0}:{1}", this.Info.Name, packet.ReadString()));
			}
		}

		// Token: 0x04000073 RID: 115
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000074 RID: 116
		private RSACryptoServiceProvider _rsa;

		// Token: 0x04000075 RID: 117
		private CenterServer _svr;

		// Token: 0x04000076 RID: 118
		private BaseClient m_currentCmdClient;

		// Token: 0x04000077 RID: 119
		public bool IsManager;

		// Token: 0x04000078 RID: 120
		public bool NeedSyncMacroDrop;

		// Token: 0x04000079 RID: 121
		public static readonly string MANAGER_KEY = "3sdfi792kklishu290l-z:)XiaoPY(*";
	}
}
