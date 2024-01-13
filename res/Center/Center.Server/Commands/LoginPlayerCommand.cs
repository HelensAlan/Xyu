using System;
using System.Linq;
using Game.Base;

namespace Center.Server.Commands
{
	// Token: 0x02000018 RID: 24
	[Cmd("&player", ePrivLevel.Admin, "获取当前登录玩家的相关数据.", new string[] { "eg:    /player -l     :获取当前玩家信息列表.", "       /player -n [nickname]    :通过昵称获取当前玩家信息.", "       /player -i [userid]      :通过玩家id获取当前玩家信息." })]
	public class LoginPlayerCommand : AbstractCommandHandler, ICommandHandler
	{
		// Token: 0x060000F6 RID: 246 RVA: 0x00006D20 File Offset: 0x00004F20
		public bool OnCommand(BaseClient client, string[] args)
		{
			if (args.Length > 1)
			{
				string text = args[1];
				if (text != null)
				{
					if (text == "-l")
					{
						this.DisplayMessage(client, "-------------------------------");
						this.DisplayMessage(client, "loginplayer infomation list : ");
						Player[] allPlayer = LoginMgr.GetAllPlayer();
						foreach (Player player in allPlayer)
						{
							this.DisplayMessage(client, string.Concat(new string[]
							{
								"    id : ",
								player.Id.ToString(),
								" name : ",
								player.Name,
								" password : ",
								player.Password,
								" state : ",
								player.State.ToString()
							}));
						}
						this.DisplayMessage(client, "-------------------------------");
						this.DisplayMessage(client, "total count is " + allPlayer.Count<Player>().ToString());
						return true;
					}
					if (text == "-n")
					{
						if (args.Count<string>() != 3)
						{
							this.DisplayMessage(client, "-------------------------------");
							this.DisplayMessage(client, "input in the wrong way ! ");
							return true;
						}
						this.DisplayMessage(client, "-------------------------------");
						this.DisplayMessage(client, "get loginplayer infomation from the nickname");
						Player playerByName = LoginMgr.GetPlayerByName(string.Format(args[2], new object[0]));
						if (playerByName != null)
						{
							this.DisplayMessage(client, string.Concat(new string[]
							{
								"    id : ",
								playerByName.Id.ToString(),
								" name : ",
								playerByName.Name,
								" password : ",
								playerByName.Password,
								" state : ",
								playerByName.State.ToString()
							}));
							return true;
						}
						this.DisplayMessage(client, "-------------------------------");
						this.DisplayMessage(client, "cannot find the player ! ");
						return true;
					}
					else if (text == "-i")
					{
						if (args.Count<string>() != 3)
						{
							this.DisplayMessage(client, "-------------------------------");
							this.DisplayMessage(client, "input in the wrong way ! ");
							return true;
						}
						this.DisplayMessage(client, "-------------------------------");
						this.DisplayMessage(client, "get loginplayer infomation from the userid");
						Player player2 = null;
						try
						{
							player2 = LoginMgr.GetPlayer(Convert.ToInt32(args[2]));
						}
						catch (Exception ex)
						{
							this.DisplayMessage(client, "-------------------------------");
							this.DisplayMessage(client, ex.ToString());
							return true;
						}
						if (player2 != null)
						{
							this.DisplayMessage(client, string.Concat(new string[]
							{
								"    id : ",
								player2.Id.ToString(),
								" name : ",
								player2.Name,
								" password : ",
								player2.Password,
								" state : ",
								player2.State.ToString()
							}));
							return true;
						}
						this.DisplayMessage(client, "-------------------------------");
						this.DisplayMessage(client, "cannot find the player ! ");
						return true;
					}
				}
				this.DisplaySyntax(client);
			}
			else
			{
				this.DisplaySyntax(client);
			}
			return true;
		}
	}
}
