using System;
using System.Collections.Generic;
using System.Linq;

namespace Center.Server
{
	// Token: 0x0200000F RID: 15
	public class LoginMgr
	{
		// Token: 0x06000073 RID: 115 RVA: 0x00004C20 File Offset: 0x00002E20
		public static void CreatePlayer(Player player)
		{
			Player player2 = null;
			object obj = LoginMgr.syc_obj;
			lock (obj)
			{
				player.LastTime = DateTime.Now.Ticks;
				if (LoginMgr.m_players.ContainsKey(player.Id))
				{
					player2 = LoginMgr.m_players[player.Id];
					player.State = player2.State;
					player.CurrentServer = player2.CurrentServer;
					LoginMgr.m_players[player.Id] = player;
				}
				else
				{
					player2 = LoginMgr.GetPlayerByName(player.Name);
					if (player2 != null && LoginMgr.m_players.ContainsKey(player2.Id))
					{
						LoginMgr.m_players.Remove(player2.Id);
					}
					player.State = ePlayerState.NotLogin;
					LoginMgr.m_players.Add(player.Id, player);
				}
			}
			if (player2 != null && player2.CurrentServer != null)
			{
				player2.CurrentServer.SendKitoffUser(player2.Id);
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00004D24 File Offset: 0x00002F24
		public static bool TryLoginPlayer(int id, ServerClient server)
		{
			object obj = LoginMgr.syc_obj;
			bool result;
			lock (obj)
			{
				if (LoginMgr.m_players.ContainsKey(id))
				{
					Player player = LoginMgr.m_players[id];
					if (player.CurrentServer == null)
					{
						player.CurrentServer = server;
						player.State = ePlayerState.Logining;
						result = true;
					}
					else
					{
						if (player.State == ePlayerState.Play)
						{
							player.CurrentServer.SendKitoffUser(id);
						}
						result = false;
					}
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00004DAC File Offset: 0x00002FAC
		public static void PlayerLogined(int id, ServerClient server)
		{
			object obj = LoginMgr.syc_obj;
			lock (obj)
			{
				if (LoginMgr.m_players.ContainsKey(id))
				{
					Player player = LoginMgr.m_players[id];
					if (player != null)
					{
						player.CurrentServer = server;
						player.State = ePlayerState.Play;
					}
				}
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00004E10 File Offset: 0x00003010
		public static void PlayerLoginOut(int id, ServerClient server)
		{
			object obj = LoginMgr.syc_obj;
			lock (obj)
			{
				if (LoginMgr.m_players.ContainsKey(id))
				{
					Player player = LoginMgr.m_players[id];
					if (player != null && player.CurrentServer == server)
					{
						player.CurrentServer = null;
						player.State = ePlayerState.NotLogin;
					}
				}
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00004E7C File Offset: 0x0000307C
		public static Player GetPlayerByName(string name)
		{
			Player[] allPlayer = LoginMgr.GetAllPlayer();
			if (allPlayer != null)
			{
				foreach (Player player in allPlayer)
				{
					if (player.Name == name)
					{
						return player;
					}
				}
			}
			return null;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00004EB8 File Offset: 0x000030B8
		public static Player[] GetAllPlayer()
		{
			object obj = LoginMgr.syc_obj;
			Player[] result;
			lock (obj)
			{
				result = LoginMgr.m_players.Values.ToArray<Player>();
			}
			return result;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00004F04 File Offset: 0x00003104
		public static void RemovePlayer(int playerId)
		{
			object obj = LoginMgr.syc_obj;
			lock (obj)
			{
				if (LoginMgr.m_players.ContainsKey(playerId))
				{
					LoginMgr.m_players.Remove(playerId);
				}
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00004F58 File Offset: 0x00003158
		public static void RemovePlayer(List<Player> players)
		{
			object obj = LoginMgr.syc_obj;
			lock (obj)
			{
				foreach (Player player in players)
				{
					LoginMgr.m_players.Remove(player.Id);
				}
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00004FD8 File Offset: 0x000031D8
		public static Player GetPlayer(int playerId)
		{
			object obj = LoginMgr.syc_obj;
			lock (obj)
			{
				if (LoginMgr.m_players.ContainsKey(playerId))
				{
					return LoginMgr.m_players[playerId];
				}
			}
			return null;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00005030 File Offset: 0x00003230
		public static ServerClient GetServerClient(int playerId)
		{
			Player player = LoginMgr.GetPlayer(playerId);
			ServerClient result;
			if (player != null)
			{
				result = player.CurrentServer;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00005054 File Offset: 0x00003254
		public static int GetOnlineCount()
		{
			Player[] allPlayer = LoginMgr.GetAllPlayer();
			int num = 0;
			Player[] array = allPlayer;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].State != ePlayerState.NotLogin)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00005088 File Offset: 0x00003288
		public static Dictionary<int, int> GetOnlineForLine()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (Player player in LoginMgr.GetAllPlayer())
			{
				if (player.CurrentServer != null)
				{
					if (dictionary.ContainsKey(player.CurrentServer.Info.ID))
					{
						Dictionary<int, int> dictionary2;
						int id;
						(dictionary2 = dictionary)[id = player.CurrentServer.Info.ID] = dictionary2[id] + 1;
					}
					else
					{
						dictionary.Add(player.CurrentServer.Info.ID, 1);
					}
				}
			}
			return dictionary;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00005114 File Offset: 0x00003314
		public static List<Player> GetServerPlayers(ServerClient server)
		{
			List<Player> list = new List<Player>();
			foreach (Player player in LoginMgr.GetAllPlayer())
			{
				if (player.CurrentServer == server)
				{
					list.Add(player);
				}
			}
			return list;
		}

		// Token: 0x0400006A RID: 106
		private static Dictionary<int, Player> m_players = new Dictionary<int, Player>();

		// Token: 0x0400006B RID: 107
		private static object syc_obj = new object();
	}
}
