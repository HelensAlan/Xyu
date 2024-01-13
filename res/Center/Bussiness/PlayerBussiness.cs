using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Bussiness.CenterService;
using Bussiness.Managers;
using SqlDataProvider.Data;

namespace Bussiness
{
	// Token: 0x02000012 RID: 18
	public class PlayerBussiness : BaseBussiness
	{
		// Token: 0x060000B9 RID: 185 RVA: 0x0000C3C4 File Offset: 0x0000A5C4
		public bool ActivePlayer(ref PlayerInfo player, string userName, string passWord, bool sex, int gold, int money, int giftToken, string IP, string site)
		{
			bool result = false;
			try
			{
				player = new PlayerInfo
				{
					Agility = 0,
					Attack = 0,
					Colors = ",,,,,,",
					Skin = "",
					ConsortiaID = 0,
					Defence = 0,
					Gold = gold,
					GP = 1,
					Grade = 1,
					ID = 0,
					Luck = 0,
					Money = money,
					GiftToken = giftToken,
					NickName = "",
					Sex = sex,
					State = 0,
					Style = ",,,,,,",
					Hide = 1111111111
				};
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int)
					{
						Direction = ParameterDirection.Output
					},
					new SqlParameter("@Attack", player.Attack),
					new SqlParameter("@Colors", player.Colors ?? ""),
					new SqlParameter("@ConsortiaID", player.ConsortiaID),
					new SqlParameter("@Defence", player.Defence),
					new SqlParameter("@Gold", player.Gold),
					new SqlParameter("@GP", player.GP),
					new SqlParameter("@Grade", player.Grade),
					new SqlParameter("@Luck", player.Luck),
					new SqlParameter("@Money", player.Money),
					new SqlParameter("@Style", player.Style ?? ""),
					new SqlParameter("@Agility", player.Agility),
					new SqlParameter("@State", player.State),
					new SqlParameter("@UserName", userName),
					new SqlParameter("@PassWord", passWord),
					new SqlParameter("@Sex", sex),
					new SqlParameter("@Hide", player.Hide),
					new SqlParameter("@ActiveIP", IP),
					new SqlParameter("@Skin", player.Skin ?? ""),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@Site", site),
					new SqlParameter("@GiftToken", player.GiftToken)
				};
				if (this.db.RunProcedure("SP_Users_Active", para))
				{
					player.ID = (int)para[0].Value;
					result = (int)para[19].Value == 0;
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000C6F8 File Offset: 0x0000A8F8
		public bool RegisterPlayer(string userName, string passWord, string nickName, string bStyle, string gStyle, string armColor, string hairColor, string faceColor, string clothColor, int sex, ref string msg, int validDate)
		{
			bool result = false;
			try
			{
				string[] bStyles = bStyle.Split(new char[] { ',' });
				string[] gStyles = gStyle.Split(new char[] { ',' });
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", userName),
					new SqlParameter("@PassWord", passWord),
					new SqlParameter("@NickName", nickName),
					new SqlParameter("@BArmID", bStyles[0]),
					new SqlParameter("@BHairID", bStyles[1]),
					new SqlParameter("@BFaceID", bStyles[2]),
					new SqlParameter("@BClothID", bStyles[3]),
					new SqlParameter("@GArmID", gStyles[0]),
					new SqlParameter("@GHairID", gStyles[1]),
					new SqlParameter("@GFaceID", gStyles[2]),
					new SqlParameter("@GClothID", gStyles[3]),
					new SqlParameter("@ArmColor", armColor ?? ""),
					new SqlParameter("@HairColor", hairColor ?? ""),
					new SqlParameter("@FaceColor", faceColor ?? ""),
					new SqlParameter("@ClothColor", clothColor ?? ""),
					new SqlParameter("@Sex", sex),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@StyleDate", validDate)
				};
				result = this.db.RunProcedure("SP_Users_RegisterNotValidate", para);
				int returnValue = (int)para[16].Value;
				result = returnValue == 0;
				if (returnValue != 2)
				{
					if (returnValue == 3)
					{
						msg = LanguageMgr.GetTranslation("PlayerBussiness.RegisterPlayer.Msg3", new object[0]);
					}
				}
				else
				{
					msg = LanguageMgr.GetTranslation("PlayerBussiness.RegisterPlayer.Msg2", new object[0]);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000C924 File Offset: 0x0000AB24
		public bool RenameNick(string userName, string nickName, string newNickName, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", userName),
					new SqlParameter("@NickName", nickName),
					new SqlParameter("@NewNickName", newNickName),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				result = this.db.RunProcedure("SP_Users_RenameNick", para);
				int returnValue = (int)para[3].Value;
				result = returnValue == 0;
				if (returnValue - 4 <= 1)
				{
					msg = LanguageMgr.GetTranslation("PlayerBussiness.RenameNick.Msg4", new object[0]);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("RenameNick", e);
				}
			}
			return result;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000C9EC File Offset: 0x0000ABEC
		public bool RenameByCard(string userName, string nickName, string newNickName, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", userName),
					new SqlParameter("@NickName", nickName),
					new SqlParameter("@NewNickName", newNickName),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				result = this.db.RunProcedure("SP_Users_RenameByCard", para);
				int returnValue = (int)para[3].Value;
				result = returnValue == 0;
				if (returnValue - 4 <= 1)
				{
					msg = LanguageMgr.GetTranslation("PlayerBussiness.RenameNick.Msg4", new object[0]);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("RenameNick", e);
				}
			}
			return result;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000CAB4 File Offset: 0x0000ACB4
		public bool RenameConsortiaName(string userName, string nickName, string consortiaName, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", userName),
					new SqlParameter("@NickName", nickName),
					new SqlParameter("@ConsortiaName", consortiaName),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				result = this.db.RunProcedure("SP_Users_RenameConsortiaName", para);
				int returnValue = (int)para[3].Value;
				result = returnValue == 0;
				if (returnValue - 4 <= 1)
				{
					msg = LanguageMgr.GetTranslation("PlayerBussiness.SP_Users_RenameConsortiaName.Msg4", new object[0]);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("RenameNick", e);
				}
			}
			return result;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000CB7C File Offset: 0x0000AD7C
		public bool RenameConsortiaNameByCard(string userName, string nickName, string consortiaName, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", userName),
					new SqlParameter("@NickName", nickName),
					new SqlParameter("@ConsortiaName", consortiaName),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				result = this.db.RunProcedure("SP_Users_RenameConsortiaNameByCard", para);
				int returnValue = (int)para[3].Value;
				result = returnValue == 0;
				if (returnValue - 4 <= 1)
				{
					msg = LanguageMgr.GetTranslation("PlayerBussiness.SP_Users_RenameConsortiaName.Msg4", new object[0]);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("RenameNick", e);
				}
			}
			return result;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000CC44 File Offset: 0x0000AE44
		public bool UpdatePassWord(int userID, string password)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Password", password)
				};
				result = this.db.RunProcedure("SP_Users_UpdatePassword", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000CCC0 File Offset: 0x0000AEC0
		public bool UpdatePasswordInfo(int userID, string PasswordQuestion1, string PasswordAnswer1, string PasswordQuestion2, string PasswordAnswer2, int Count)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", userID),
					new SqlParameter("@PasswordQuestion1", PasswordQuestion1),
					new SqlParameter("@PasswordAnswer1", PasswordAnswer1),
					new SqlParameter("@PasswordQuestion2", PasswordQuestion2),
					new SqlParameter("@PasswordAnswer2", PasswordAnswer2),
					new SqlParameter("@FailedPasswordAttemptCount", Count)
				};
				result = this.db.RunProcedure("SP_Users_Password_Add", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000CD7C File Offset: 0x0000AF7C
		public void GetPasswordInfo(int userID, ref string PasswordQuestion1, ref string PasswordAnswer1, ref string PasswordQuestion2, ref string PasswordAnswer2, ref int Count)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", userID)
				};
				this.db.GetReader(ref reader, "SP_Users_PasswordInfo", para);
				while (reader.Read())
				{
					PasswordQuestion1 = ((reader["PasswordQuestion1"] == null) ? "" : reader["PasswordQuestion1"].ToString());
					PasswordAnswer1 = ((reader["PasswordAnswer1"] == null) ? "" : reader["PasswordAnswer1"].ToString());
					PasswordQuestion2 = ((reader["PasswordQuestion2"] == null) ? "" : reader["PasswordQuestion2"].ToString());
					PasswordAnswer2 = ((reader["PasswordAnswer2"] == null) ? "" : reader["PasswordAnswer2"].ToString());
					if ((DateTime)reader["LastFindDate"] == DateTime.Today)
					{
						Count = (int)reader["FailedPasswordAttemptCount"];
					}
					else
					{
						Count = 5;
					}
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000CF00 File Offset: 0x0000B100
		public bool UpdatePasswordTwo(int userID, string passwordTwo)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", userID),
					new SqlParameter("@PasswordTwo", passwordTwo)
				};
				result = this.db.RunProcedure("SP_Users_UpdatePasswordTwo", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000CF7C File Offset: 0x0000B17C
		public PlayerInfo[] GetUserLoginList(string userName)
		{
			List<PlayerInfo> infos = new List<PlayerInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", SqlDbType.NVarChar, 200)
				};
				para[0].Value = userName;
				this.db.GetReader(ref reader, "SP_Users_LoginList", para);
				while (reader.Read())
				{
					infos.Add(this.InitPlayerInfo(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return infos.ToArray();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000D038 File Offset: 0x0000B238
		public PlayerInfo LoginGame(string username, ref int isFirst, ref bool isExist, ref bool isError, bool firstValidate, ref DateTime forbidDate, string nickname)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", username),
					new SqlParameter("@Password", ""),
					new SqlParameter("@FirstValidate", firstValidate),
					new SqlParameter("@Nickname", nickname)
				};
				if (this.db.GetReader(ref reader, "SP_Users_LoginWeb", para) && reader.Read())
				{
					isFirst = (int)reader["IsFirst"];
					isExist = (bool)reader["IsExist"];
					forbidDate = (DateTime)reader["ForbidDate"];
					if (isFirst > 1)
					{
						isFirst--;
					}
					return this.InitPlayerInfo(reader);
				}
			}
			catch (Exception e)
			{
				isError = true;
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000D154 File Offset: 0x0000B354
		public PlayerInfo LoginGame(string username, string password)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", username),
					new SqlParameter("@Password", password)
				};
				if (this.db.GetReader(ref reader, "SP_Users_Login", para) && reader.Read())
				{
					return this.InitPlayerInfo(reader);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000D200 File Offset: 0x0000B400
		public bool UpdatePlayer(PlayerInfo player)
		{
			bool result = false;
			try
			{
				if (player.Grade < 1)
				{
					return result;
				}
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", player.ID),
					new SqlParameter("@Attack", player.Attack),
					new SqlParameter("@Colors", player.Colors ?? ""),
					new SqlParameter("@ConsortiaID", player.ConsortiaID),
					new SqlParameter("@Defence", player.Defence),
					new SqlParameter("@Gold", player.Gold),
					new SqlParameter("@GP", player.GP),
					new SqlParameter("@Honor", player.Honor),
					new SqlParameter("@Grade", player.Grade),
					new SqlParameter("@Luck", player.Luck),
					new SqlParameter("@Money", player.Money),
					new SqlParameter("@Style", player.Style ?? ""),
					new SqlParameter("@Agility", player.Agility),
					new SqlParameter("@State", player.State),
					new SqlParameter("@Hide", player.Hide),
					new SqlParameter("@ExpendDate", (player.ExpendDate == null) ? "" : player.ExpendDate.ToString()),
					new SqlParameter("@Win", player.Win),
					new SqlParameter("@Total", player.Total),
					new SqlParameter("@Escape", player.Escape),
					new SqlParameter("@Skin", player.Skin ?? ""),
					new SqlParameter("@Offer", player.Offer),
					new SqlParameter("@AntiAddiction", player.AntiAddiction)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@RichesOffer", player.RichesOffer),
					new SqlParameter("@RichesRob", player.RichesRob),
					new SqlParameter("@CheckCount", player.CheckCount)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@MarryInfoID", player.MarryInfoID),
					new SqlParameter("@DayLoginCount", player.DayLoginCount),
					new SqlParameter("@Nimbus", player.Nimbus),
					new SqlParameter("@LastAward", player.LastAward),
					new SqlParameter("@GiftToken", player.GiftToken),
					new SqlParameter("@QuestSite", player.QuestSite),
					new SqlParameter("@PvePermission", player.PvePermission),
					new SqlParameter("@FightPower", player.FightPower),
					new SqlParameter("@AnswerSite", player.AnswerSite),
					new SqlParameter("@LastAuncherAward", player.LastAuncherAward),
					new SqlParameter("@ChatCount", player.ChatCount),
					new SqlParameter("@SpaPubGoldRoomLimit", player.SpaPubGoldRoomLimit),
					new SqlParameter("@LastSpaDate", player.LastSpaDate),
					new SqlParameter("@AchievementPoint", player.AchievementPoint),
					new SqlParameter("@Rank", player.Rank),
					new SqlParameter("@FightLabPermission", player.FightLabPermission),
					new SqlParameter("@SpaPubMoneyRoomLimit", player.SpaPubMoneyRoomLimit),
					new SqlParameter("@IsInSpaPubGoldToday", player.IsInSpaPubGoldToday),
					new SqlParameter("@IsInSpaPubMoneyToday", player.IsInSpaPubMoneyToday),
					new SqlParameter("@Blood", player.Blood),
					new SqlParameter("@WeaklessGuildProgressStr", player.WeaklessGuildProgressStr),
					new SqlParameter("@LastVIPAward", player.LastVIPAward),
					new SqlParameter("@MysteriousSPAR", player.MysteriousSPAR),
					new SqlParameter("@LotteryScore", player.LotteryScore),
					new SqlParameter("@AcademyDungeon", player.AcademyDungeon),
					new SqlParameter("@LastAcademyDungeon", player.LastAcademyDungeon)
				};
				if (this.db.RunProcedure("SP_Users_Update", para))
				{
					result = (int)para[21].Value == 0;
					if (result)
					{
						player.AntiAddiction = (int)para[20].Value;
						player.CheckCount = (int)para[24].Value;
					}
					player.IsDirty = false;
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000D7E4 File Offset: 0x0000B9E4
		public bool UpdatePlayerMarry(PlayerInfo player)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", player.ID),
					new SqlParameter("@IsMarried", player.IsMarried),
					new SqlParameter("@SpouseID", player.SpouseID),
					new SqlParameter("@SpouseName", player.SpouseName),
					new SqlParameter("@IsCreatedMarryRoom", player.IsCreatedMarryRoom),
					new SqlParameter("@SelfMarryRoomID", player.SelfMarryRoomID),
					new SqlParameter("@IsGotRing", player.IsGotRing)
				};
				result = this.db.RunProcedure("SP_Users_Marry", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("UpdatePlayerMarry", e);
				}
			}
			return result;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000D8E4 File Offset: 0x0000BAE4
		public bool UpdatePlayerLastAward(int id)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", id)
				};
				result = this.db.RunProcedure("SP_Users_LastAward", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("UpdatePlayerAward", e);
				}
			}
			return result;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000D954 File Offset: 0x0000BB54
		public bool UpdatePlayerLastAuncherAward(int id)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", id)
				};
				result = this.db.RunProcedure("SP_Users_LastAuncherAward", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("UpdatePlayerLastAuncherAward", e);
				}
			}
			return result;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000D9C4 File Offset: 0x0000BBC4
		public PlayerInfo GetUserSingleByUserID(int UserID)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
				};
				para[0].Value = UserID;
				this.db.GetReader(ref reader, "SP_Users_SingleByUserID", para);
				if (reader.Read())
				{
					return this.InitPlayerInfo(reader);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000DA70 File Offset: 0x0000BC70
		public PlayerInfo GetUserSingleAllUserID(int UserID)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
				};
				para[0].Value = UserID;
				this.db.GetReader(ref reader, "SP_Users_SingleAllUserID", para);
				if (reader.Read())
				{
					return this.InitPlayerInfo(reader);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000DB1C File Offset: 0x0000BD1C
		public PlayerInfo GetUserSingleByUserName(string userName)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", SqlDbType.VarChar, 200)
				};
				para[0].Value = userName;
				this.db.GetReader(ref reader, "SP_Users_SingleByUserName", para);
				if (reader.Read())
				{
					return this.InitPlayerInfo(reader);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000DBC8 File Offset: 0x0000BDC8
		public PlayerInfo GetUserSingleByNickName(string nickName)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@NickName", SqlDbType.NVarChar, 200)
				};
				para[0].Value = nickName;
				this.db.GetReader(ref reader, "SP_Users_SingleByNickName", para);
				if (reader.Read())
				{
					return this.InitPlayerInfo(reader);
				}
			}
			catch
			{
				throw new Exception();
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000DC5C File Offset: 0x0000BE5C
		public bool GetUserCheckByNickName(string nickName)
		{
			bool result = false;
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@NickName", SqlDbType.NVarChar, 200)
				};
				para[0].Value = nickName;
				if (this.db.GetReader(ref reader, "SP_Users_CheckByNickName", para))
				{
					while (reader.Read())
					{
						result = true;
					}
				}
			}
			catch
			{
				result = true;
				throw new Exception();
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return result;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000DCEC File Offset: 0x0000BEEC
		public bool GetConsortiaCheckByConsortiaName(string consortiaName)
		{
			bool result = false;
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaName", SqlDbType.NVarChar, 200)
				};
				para[0].Value = consortiaName;
				if (this.db.GetReader(ref reader, "SP_Consortia_CheckByConsortiaName", para))
				{
					while (reader.Read())
					{
						result = true;
					}
				}
			}
			catch
			{
				result = true;
				throw new Exception();
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return result;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000DD7C File Offset: 0x0000BF7C
		public PlayerInfo InitPlayerInfo(SqlDataReader reader)
		{
			PlayerInfo player = new PlayerInfo
			{
				IsConsortia = (bool)reader["IsConsortia"],
				Agility = (int)reader["Agility"],
				Attack = (int)reader["Attack"],
				Colors = ((reader["Colors"] == null) ? "" : reader["Colors"].ToString()),
				ConsortiaID = (int)reader["ConsortiaID"],
				Defence = (int)reader["Defence"],
				Gold = (int)reader["Gold"],
				GP = (int)reader["GP"],
				Honor = ((reader["Honor"] == null) ? "" : reader["Honor"].ToString()),
				Grade = (int)reader["Grade"],
				ID = (int)reader["UserID"],
				Luck = (int)reader["Luck"],
				Money = (int)reader["Money"],
				NickName = ((reader["NickName"] == null) ? "" : reader["NickName"].ToString()),
				Sex = (bool)reader["Sex"],
				State = (int)reader["State"],
				Style = ((reader["Style"] == null) ? "" : reader["Style"].ToString()),
				Hide = (int)reader["Hide"],
				Repute = (int)reader["Repute"],
				UserName = ((reader["UserName"] == null) ? "" : reader["UserName"].ToString()),
				ConsortiaName = ((reader["ConsortiaName"] == null) ? "" : reader["ConsortiaName"].ToString()),
				Offer = (int)reader["Offer"],
				Win = (int)reader["Win"],
				Total = (int)reader["Total"],
				Escape = (int)reader["Escape"],
				Skin = ((reader["Skin"] == null) ? "" : reader["Skin"].ToString()),
				IsBanChat = (bool)reader["IsBanChat"],
				ReputeOffer = (int)reader["ReputeOffer"],
				ConsortiaRepute = (int)reader["ConsortiaRepute"],
				ConsortiaLevel = (int)reader["ConsortiaLevel"],
				StoreLevel = (int)reader["StoreLevel"],
				ShopLevel = (int)reader["ShopLevel"],
				SmithLevel = (int)reader["SmithLevel"],
				BufferLevel = (int)reader["BufferLevel"],
				ConsortiaHonor = (int)reader["ConsortiaHonor"],
				RichesOffer = (int)reader["RichesOffer"],
				RichesRob = (int)reader["RichesRob"],
				AntiAddiction = (int)reader["AntiAddiction"],
				DutyLevel = (int)reader["DutyLevel"],
				DutyName = ((reader["DutyName"] == null) ? "" : reader["DutyName"].ToString()),
				Right = (int)reader["Right"],
				ChairmanName = ((reader["ChairmanName"] == null) ? "" : reader["ChairmanName"].ToString()),
				AddDayGP = (int)reader["AddDayGP"],
				AddDayOffer = (int)reader["AddDayOffer"],
				AddWeekGP = (int)reader["AddWeekGP"],
				AddWeekOffer = (int)reader["AddWeekOffer"],
				ConsortiaRiches = (int)reader["ConsortiaRiches"],
				CheckCount = (int)reader["CheckCount"],
				IsMarried = (bool)reader["IsMarried"],
				SpouseID = (int)reader["SpouseID"],
				SpouseName = ((reader["SpouseName"] == null) ? "" : reader["SpouseName"].ToString()),
				MarryInfoID = (int)reader["MarryInfoID"],
				IsCreatedMarryRoom = (bool)reader["IsCreatedMarryRoom"],
				DayLoginCount = (int)reader["DayLoginCount"],
				PasswordTwo = ((reader["PasswordTwo"] == null) ? "" : reader["PasswordTwo"].ToString()),
				SelfMarryRoomID = (int)reader["SelfMarryRoomID"],
				IsGotRing = (bool)reader["IsGotRing"],
				Rename = (bool)reader["Rename"],
				ConsortiaRename = (bool)reader["ConsortiaRename"],
				IsDirty = false,
				IsFirst = (int)reader["IsFirst"],
				Nimbus = (int)reader["Nimbus"],
				LastAward = (DateTime)reader["LastAward"],
				LastAuncherAward = (DateTime)reader["LastAuncherAward"],
				LastVIPAward = (DateTime)reader["LastVIPAward"],
				GiftToken = (int)reader["GiftToken"],
				QuestSite = ((reader["QuestSite"] == null) ? new byte[2000] : ((byte[])reader["QuestSite"])),
				PvePermission = ((reader["PvePermission"] == null) ? "" : reader["PvePermission"].ToString()),
				FightLabPermission = ((reader["FightLabPermission"] == null) ? "" : reader["FightLabPermission"].ToString()),
				FightPower = (int)reader["FightPower"],
				PasswordQuest1 = ((reader["PasswordQuestion1"] == null) ? "" : reader["PasswordQuestion1"].ToString()),
				PasswordQuest2 = ((reader["PasswordQuestion2"] == null) ? "" : reader["PasswordQuestion2"].ToString()),
				LastDate = ((reader["LastDate"] == null || reader["LastDate"].ToString() == "") ? DateTime.Now : ((DateTime)reader["LastDate"])),
				ChatCount = ((reader["ChatCount"] == null) ? 0 : ((int)reader["ChatCount"])),
				OnlineTime = (int)reader["OnlineTime"],
				BoxProgression = (int)reader["BoxProgression"],
				GetBoxLevel = (int)reader["GetBoxLevel"],
				SpaPubGoldRoomLimit = (int)reader["SpaPubGoldRoomLimit"],
				LastSpaDate = (DateTime)reader["LastSpaDate"],
				AchievementPoint = (int)reader["AchievementPoint"],
				Rank = (int)reader["Rank"],
				AddDayAchievementPoint = (int)reader["AddDayAchievementPoint"],
				AddWeekAchievementPoint = (int)reader["AddWeekAchievementPoint"],
				SpaPubMoneyRoomLimit = (int)reader["SpaPubMoneyRoomLimit"],
				AddGPLastDate = (DateTime)reader["AddGPLastDate"],
				BoxGetDate = (DateTime)reader["BoxGetDate"],
				IsInSpaPubGoldToday = (bool)reader["IsInSpaPubGoldToday"],
				IsInSpaPubMoneyToday = (bool)reader["IsInSpaPubMoneyToday"],
				AlreadyGetBox = (int)reader["AlreadyGetBox"],
				TypeVIP = (int)reader["TypeVIP"],
				VIPLevel = (int)reader["VIPLevel"],
				VIPExp = (int)reader["VIPExp"],
				VIPExpireDay = (DateTime)reader["VIPExpireDay"],
				BadgeID = (int)reader["BadgeID"],
				Blood = (int)reader["Blood"],
				WeaklessGuildProgressStr = (string)reader["WeaklessGuildProgressStr"],
				MysteriousSPAR = (int)reader["MysteriousSPAR"],
				LotteryScore = (int)reader["LotteryScore"],
				AcademyDungeon = ((reader["AcademyDungeon"] == null) ? "" : reader["AcademyDungeon"].ToString()),
				LastAcademyDungeon = (DateTime)reader["LastAcademyDungeon"],
				AreaName = (string)reader["AreaName"]
			};
			if ((DateTime)reader["LastFindDate"] != DateTime.Today.Date)
			{
				player.FailedPasswordAttemptCount = 5;
			}
			else
			{
				player.FailedPasswordAttemptCount = (int)reader["FailedPasswordAttemptCount"];
			}
			player.AnswerSite = (int)reader["AnswerSite"];
			return player;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000E824 File Offset: 0x0000CA24
		public PlayerInfo[] GetPlayerPage(int page, int size, ref int total, int order, int userID, ref bool resultValue)
		{
			List<PlayerInfo> infos = new List<PlayerInfo>();
			try
			{
				string sWhere = " IsExist=1 and IsFirst<> 0 ";
				if (userID != -1)
				{
					object obj = sWhere;
					sWhere = string.Concat(new object[] { obj, " and UserID =", userID, " " });
				}
				string sOrder = "GP desc,AddGPLastDate asc";
				switch (order)
				{
				case 1:
					sOrder = "Offer desc";
					break;
				case 2:
					sOrder = "AddDayGP desc";
					break;
				case 3:
					sOrder = "AddWeekGP desc";
					break;
				case 4:
					sOrder = "AddDayOffer desc";
					break;
				case 5:
					sOrder = "AddWeekOffer desc";
					break;
				case 6:
					sOrder = "FightPower desc";
					break;
				case 7:
					sOrder = "AddDayAchievementPoint desc";
					break;
				case 8:
					sOrder = "AddWeekAchievementPoint desc";
					break;
				}
				sOrder += ",UserID";
				foreach (object obj2 in base.GetPage("V_Sys_Users_Detail", sWhere, page, size, "*", sOrder, "UserID", ref total).Rows)
				{
					DataRow dr = (DataRow)obj2;
					infos.Add(new PlayerInfo
					{
						Agility = (int)dr["Agility"],
						Attack = (int)dr["Attack"],
						Colors = ((dr["Colors"] == null) ? "" : dr["Colors"].ToString()),
						ConsortiaID = (int)dr["ConsortiaID"],
						Defence = (int)dr["Defence"],
						Gold = (int)dr["Gold"],
						GP = (int)dr["GP"],
						Grade = (int)dr["Grade"],
						ID = (int)dr["UserID"],
						Luck = (int)dr["Luck"],
						Money = (int)dr["Money"],
						NickName = ((dr["NickName"] == null) ? "" : dr["NickName"].ToString()),
						Sex = (bool)dr["Sex"],
						State = (int)dr["State"],
						Style = ((dr["Style"] == null) ? "" : dr["Style"].ToString()),
						Hide = (int)dr["Hide"],
						Repute = (int)dr["Repute"],
						UserName = ((dr["UserName"] == null) ? "" : dr["UserName"].ToString()),
						ConsortiaName = ((dr["ConsortiaName"] == null) ? "" : dr["ConsortiaName"].ToString()),
						Offer = (int)dr["Offer"],
						Skin = ((dr["Skin"] == null) ? "" : dr["Skin"].ToString()),
						IsBanChat = (bool)dr["IsBanChat"],
						ReputeOffer = (int)dr["ReputeOffer"],
						ConsortiaRepute = (int)dr["ConsortiaRepute"],
						ConsortiaLevel = (int)dr["ConsortiaLevel"],
						StoreLevel = (int)dr["StoreLevel"],
						ShopLevel = (int)dr["ShopLevel"],
						SmithLevel = (int)dr["SmithLevel"],
						BufferLevel = (int)dr["BufferLevel"],
						ConsortiaHonor = (int)dr["ConsortiaHonor"],
						RichesOffer = (int)dr["RichesOffer"],
						RichesRob = (int)dr["RichesRob"],
						DutyLevel = (int)dr["DutyLevel"],
						DutyName = ((dr["DutyName"] == null) ? "" : dr["DutyName"].ToString()),
						Right = (int)dr["Right"],
						ChairmanName = ((dr["ChairmanName"] == null) ? "" : dr["ChairmanName"].ToString()),
						Win = (int)dr["Win"],
						Total = (int)dr["Total"],
						Escape = (int)dr["Escape"],
						AddDayGP = (int)dr["AddDayGP"],
						AddDayOffer = (int)dr["AddDayOffer"],
						AddWeekGP = (int)dr["AddWeekGP"],
						AddWeekOffer = (int)dr["AddWeekOffer"],
						ConsortiaRiches = (int)dr["ConsortiaRiches"],
						CheckCount = (int)dr["CheckCount"],
						Nimbus = (int)dr["Nimbus"],
						GiftToken = (int)dr["GiftToken"],
						QuestSite = ((dr["QuestSite"] == null) ? new byte[2000] : ((byte[])dr["QuestSite"])),
						PvePermission = ((dr["PvePermission"] == null) ? "" : dr["PvePermission"].ToString()),
						FightLabPermission = ((dr["FightLabPermission"] == null) ? "" : dr["FightLabPermission"].ToString()),
						FightPower = (int)dr["FightPower"],
						AchievementPoint = (int)dr["AchievementPoint"],
						Honor = ((dr["Honor"] == null) ? "" : dr["Honor"].ToString()),
						AddDayAchievementPoint = (int)dr["AddDayAchievementPoint"],
						AddWeekAchievementPoint = (int)dr["AddWeekAchievementPoint"],
						ChatCount = ((dr["ChatCount"] == null) ? 0 : ((int)dr["ChatCount"])),
						SpaPubGoldRoomLimit = (int)dr["SpaPubGoldRoomLimit"],
						SpaPubMoneyRoomLimit = (int)dr["SpaPubMoneyRoomLimit"],
						BadgeID = (int)dr["BadgeID"],
						AreaName = (string)dr["AreaName"]
					});
				}
				resultValue = true;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return infos.ToArray();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000F028 File Offset: 0x0000D228
		public ItemInfo[] GetUserItem(int UserID)
		{
			List<ItemInfo> items = new List<ItemInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
				};
				para[0].Value = UserID;
				this.db.GetReader(ref reader, "SP_Users_Items_All", para);
				while (reader.Read())
				{
					items.Add(this.InitItem(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return items.ToArray();
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000F0E4 File Offset: 0x0000D2E4
		public ItemInfo[] GetUserBagByType(int UserID, int bagType)
		{
			List<ItemInfo> items = new List<ItemInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
					{
						Value = UserID
					},
					new SqlParameter("@BagType", bagType)
				};
				this.db.GetReader(ref reader, "SP_Users_BagByType", para);
				while (reader.Read())
				{
					items.Add(this.InitItem(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return items.ToArray();
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000F1B0 File Offset: 0x0000D3B0
		public List<ItemInfo> GetUserEuqip(int UserID)
		{
			List<ItemInfo> items = new List<ItemInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
				};
				para[0].Value = UserID;
				if (this.db.GetReader(ref reader, "SP_Users_Items_Equip", para))
				{
					while (reader.Read())
					{
						items.Add(this.InitItem(reader));
					}
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return items;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000F268 File Offset: 0x0000D468
		public ItemInfo GetUserItemSingle(int itemID)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", SqlDbType.Int, 4)
				};
				para[0].Value = itemID;
				this.db.GetReader(ref reader, "SP_Users_Items_Single", para);
				if (reader.Read())
				{
					return this.InitItem(reader);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000F314 File Offset: 0x0000D514
		public ItemInfo InitItem(SqlDataReader reader)
		{
			ItemInfo item = ItemInfo.CreateWithoutInit(ItemMgr.FindItemTemplate((int)reader["TemplateID"]));
			item.AgilityCompose = (int)reader["AgilityCompose"];
			item.AttackCompose = (int)reader["AttackCompose"];
			item.Color = reader["Color"].ToString();
			item.Count = (int)reader["Count"];
			item.DefendCompose = (int)reader["DefendCompose"];
			item.ItemID = (int)reader["ItemID"];
			item.LuckCompose = (int)reader["LuckCompose"];
			item.Place = (int)reader["Place"];
			item.Hole1 = (int)reader["Hole1"];
			item.Hole2 = (int)reader["Hole2"];
			item.Hole3 = (int)reader["Hole3"];
			item.Hole4 = (int)reader["Hole4"];
			item.Hole5 = (int)reader["Hole5"];
			item.Hole6 = (int)reader["Hole6"];
			item.StrengthenLevel = (int)reader["StrengthenLevel"];
			item.TemplateID = (int)reader["TemplateID"];
			item.UserID = (int)reader["UserID"];
			item.ValidDate = (int)reader["ValidDate"];
			item.IsDirty = false;
			item.IsExist = (bool)reader["IsExist"];
			item.IsBinds = (bool)reader["IsBinds"];
			item.IsUsed = (bool)reader["IsUsed"];
			item.BeginDate = (DateTime)reader["BeginDate"];
			item.IsJudge = (bool)reader["IsJudge"];
			item.BagType = (int)reader["BagType"];
			item.Skin = reader["Skin"].ToString();
			item.RemoveDate = (DateTime)reader["RemoveDate"];
			item.RemoveType = (int)reader["RemoveType"];
			item.Hole5Level = (int)reader["Hole5Level"];
			item.Hole5Exp = (int)reader["Hole5Exp"];
			item.Hole6Level = (int)reader["Hole6Level"];
			item.Hole6Exp = (int)reader["Hole6Exp"];
			item.GoldBeginTime = (DateTime)reader["GoldBeginTime"];
			item.GoldValidDate = (int)reader["GoldValidDate"];
			item.IsGold = (bool)reader["IsGold"];
			item.IsDirty = false;
			if (item.IsGold)
			{
				GoldEquipInfo equipInfo = GoldMgr.FindNewTemplate(item.Template.TemplateID);
				if (equipInfo != null)
				{
					item.GoldTemplate = ItemMgr.FindItemTemplate(equipInfo.NewTemplateId);
				}
			}
			return item;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000F664 File Offset: 0x0000D864
		public bool AddGoods(ItemInfo item)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ItemID", item.ItemID)
					{
						Direction = ParameterDirection.Output
					},
					new SqlParameter("@UserID", item.UserID),
					new SqlParameter("@TemplateID", item.TemplateID),
					new SqlParameter("@Place", item.Place),
					new SqlParameter("@AgilityCompose", item.AgilityCompose),
					new SqlParameter("@AttackCompose", item.AttackCompose),
					new SqlParameter("@BeginDate", item.BeginDate),
					new SqlParameter("@Color", item.Color ?? ""),
					new SqlParameter("@Count", item.Count),
					new SqlParameter("@DefendCompose", item.DefendCompose),
					new SqlParameter("@IsBinds", item.IsBinds),
					new SqlParameter("@IsExist", item.IsExist),
					new SqlParameter("@IsJudge", item.IsJudge),
					new SqlParameter("@LuckCompose", item.LuckCompose),
					new SqlParameter("@StrengthenLevel", item.StrengthenLevel),
					new SqlParameter("@ValidDate", item.ValidDate),
					new SqlParameter("@BagType", item.BagType),
					new SqlParameter("@Skin", item.Skin ?? ""),
					new SqlParameter("@IsUsed", item.IsUsed),
					new SqlParameter("@RemoveType", item.RemoveType),
					new SqlParameter("@Hole1", item.Hole1),
					new SqlParameter("@Hole2", item.Hole2),
					new SqlParameter("@Hole3", item.Hole3),
					new SqlParameter("@Hole4", item.Hole4),
					new SqlParameter("@Hole5", item.Hole5),
					new SqlParameter("@Hole6", item.Hole6),
					new SqlParameter("@Hole5Level", item.Hole5Level),
					new SqlParameter("@Hole5Exp", item.Hole5Exp),
					new SqlParameter("@Hole6Level", item.Hole6Level),
					new SqlParameter("@Hole6Exp", item.Hole6Exp),
					new SqlParameter("@IsGold", item.IsGold),
					new SqlParameter("@GoldValidDate", item.GoldValidDate),
					new SqlParameter("@GoldBeginTime", item.GoldBeginTime)
				};
				result = this.db.RunProcedure("SP_Users_Items_Add", para);
				item.ItemID = (int)para[0].Value;
				item.IsDirty = false;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000FA24 File Offset: 0x0000DC24
		public bool UpdateGoods(ItemInfo item)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ItemID", item.ItemID),
					new SqlParameter("@UserID", item.UserID),
					new SqlParameter("@TemplateID", item.TemplateID),
					new SqlParameter("@Place", item.Place),
					new SqlParameter("@AgilityCompose", item.AgilityCompose),
					new SqlParameter("@AttackCompose", item.AttackCompose),
					new SqlParameter("@BeginDate", item.BeginDate),
					new SqlParameter("@Color", item.Color ?? ""),
					new SqlParameter("@Count", item.Count),
					new SqlParameter("@DefendCompose", item.DefendCompose),
					new SqlParameter("@IsBinds", item.IsBinds),
					new SqlParameter("@IsExist", item.IsExist),
					new SqlParameter("@IsJudge", item.IsJudge),
					new SqlParameter("@LuckCompose", item.LuckCompose),
					new SqlParameter("@StrengthenLevel", item.StrengthenLevel),
					new SqlParameter("@ValidDate", item.ValidDate),
					new SqlParameter("@BagType", item.BagType),
					new SqlParameter("@Skin", item.Skin),
					new SqlParameter("@IsUsed", item.IsUsed),
					new SqlParameter("@RemoveDate", item.RemoveDate),
					new SqlParameter("@RemoveType", item.RemoveType),
					new SqlParameter("@Hole1", item.Hole1),
					new SqlParameter("@Hole2", item.Hole2),
					new SqlParameter("@Hole3", item.Hole3),
					new SqlParameter("@Hole4", item.Hole4),
					new SqlParameter("@Hole5", item.Hole5),
					new SqlParameter("@Hole6", item.Hole6),
					new SqlParameter("@Hole5Exp", item.Hole5Exp),
					new SqlParameter("@Hole5Level", item.Hole5Level),
					new SqlParameter("@Hole6Exp", item.Hole6Exp),
					new SqlParameter("@Hole6Level", item.Hole6Level),
					new SqlParameter("@IsGold", item.IsGold),
					new SqlParameter("@GoldValidDate", item.GoldValidDate),
					new SqlParameter("@GoldBeginTime", item.GoldBeginTime)
				};
				result = this.db.RunProcedure("SP_Users_Items_Update", para);
				item.IsDirty = false;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000FDDC File Offset: 0x0000DFDC
		public bool DeleteGoods(int itemID)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", itemID)
				};
				result = this.db.RunProcedure("SP_Users_Items_Delete", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000FE4C File Offset: 0x0000E04C
		public BestEquipInfo[] GetCelebByDayBestEquip()
		{
			List<BestEquipInfo> infos = new List<BestEquipInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Users_BestEquip");
				while (reader.Read())
				{
					infos.Add(new BestEquipInfo
					{
						Date = (DateTime)reader["RemoveDate"],
						GP = (int)reader["GP"],
						Grade = (int)reader["Grade"],
						ItemName = ((reader["Name"] == null) ? "" : reader["Name"].ToString()),
						NickName = ((reader["NickName"] == null) ? "" : reader["NickName"].ToString()),
						Sex = (bool)reader["Sex"],
						Strengthenlevel = (int)reader["Strengthenlevel"],
						UserName = ((reader["UserName"] == null) ? "" : reader["UserName"].ToString())
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return infos.ToArray();
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000FFE8 File Offset: 0x0000E1E8
		public MailInfo InitMail(SqlDataReader reader)
		{
			return new MailInfo
			{
				Annex1 = reader["Annex1"].ToString(),
				Annex2 = reader["Annex2"].ToString(),
				Content = reader["Content"].ToString(),
				Gold = (int)reader["Gold"],
				ID = (int)reader["ID"],
				IsExist = (bool)reader["IsExist"],
				Money = (int)reader["Money"],
				Receiver = reader["Receiver"].ToString(),
				ReceiverID = (int)reader["ReceiverID"],
				Sender = reader["Sender"].ToString(),
				SenderID = (int)reader["SenderID"],
				Title = reader["Title"].ToString(),
				Type = (int)reader["Type"],
				ValidDate = (int)reader["ValidDate"],
				IsRead = (bool)reader["IsRead"],
				SendTime = (DateTime)reader["SendTime"],
				Annex1Name = ((reader["Annex1Name"] == null) ? "" : reader["Annex1Name"].ToString()),
				Annex2Name = ((reader["Annex2Name"] == null) ? "" : reader["Annex2Name"].ToString()),
				Annex3 = reader["Annex3"].ToString(),
				Annex4 = reader["Annex4"].ToString(),
				Annex5 = reader["Annex5"].ToString(),
				Annex3Name = ((reader["Annex3Name"] == null) ? "" : reader["Annex3Name"].ToString()),
				Annex4Name = ((reader["Annex4Name"] == null) ? "" : reader["Annex4Name"].ToString()),
				Annex5Name = ((reader["Annex5Name"] == null) ? "" : reader["Annex5Name"].ToString()),
				AnnexRemark = ((reader["AnnexRemark"] == null) ? "" : reader["AnnexRemark"].ToString()),
				GiftToken = (int)reader["GiftToken"]
			};
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000102B0 File Offset: 0x0000E4B0
		public MailInfo[] GetMailByUserID(int userID)
		{
			List<MailInfo> items = new List<MailInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
				};
				para[0].Value = userID;
				this.db.GetReader(ref reader, "SP_Mail_ByUserID", para);
				while (reader.Read())
				{
					items.Add(this.InitMail(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return items.ToArray();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0001036C File Offset: 0x0000E56C
		public MailInfo[] GetMailBySenderID(int userID)
		{
			List<MailInfo> items = new List<MailInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
				};
				para[0].Value = userID;
				this.db.GetReader(ref reader, "SP_Mail_BySenderID", para);
				while (reader.Read())
				{
					items.Add(this.InitMail(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return items.ToArray();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00010428 File Offset: 0x0000E628
		public MailInfo GetMailSingle(int UserID, int mailID)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", mailID),
					new SqlParameter("@UserID", UserID)
				};
				this.db.GetReader(ref reader, "SP_Mail_Single", para);
				if (reader.Read())
				{
					return this.InitMail(reader);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000104DC File Offset: 0x0000E6DC
		public bool SendMail(MailInfo mail)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", mail.ID)
					{
						Direction = ParameterDirection.Output
					},
					new SqlParameter("@Annex1", mail.Annex1 ?? ""),
					new SqlParameter("@Annex2", mail.Annex2 ?? ""),
					new SqlParameter("@Content", mail.Content ?? ""),
					new SqlParameter("@Gold", mail.Gold),
					new SqlParameter("@IsExist", true),
					new SqlParameter("@Money", mail.Money),
					new SqlParameter("@Receiver", mail.Receiver ?? ""),
					new SqlParameter("@ReceiverID", mail.ReceiverID),
					new SqlParameter("@Sender", mail.Sender ?? ""),
					new SqlParameter("@SenderID", mail.SenderID),
					new SqlParameter("@Title", mail.Title ?? ""),
					new SqlParameter("@IfDelS", false),
					new SqlParameter("@IsDelete", false),
					new SqlParameter("@IsDelR", false),
					new SqlParameter("@IsRead", false),
					new SqlParameter("@SendTime", DateTime.Now),
					new SqlParameter("@Type", mail.Type),
					new SqlParameter("@Annex1Name", mail.Annex1Name ?? ""),
					new SqlParameter("@Annex2Name", mail.Annex2Name ?? ""),
					new SqlParameter("@Annex3", mail.Annex3 ?? ""),
					new SqlParameter("@Annex4", mail.Annex4 ?? ""),
					new SqlParameter("@Annex5", mail.Annex5 ?? ""),
					new SqlParameter("@Annex3Name", mail.Annex3Name ?? ""),
					new SqlParameter("@Annex4Name", mail.Annex4Name ?? ""),
					new SqlParameter("@Annex5Name", mail.Annex5Name ?? ""),
					new SqlParameter("@ValidDate", mail.ValidDate),
					new SqlParameter("@AnnexRemark", mail.AnnexRemark ?? ""),
					new SqlParameter("@GiftToken", mail.GiftToken)
				};
				result = this.db.RunProcedure("SP_Mail_Send", para);
				mail.ID = (int)para[0].Value;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0001084C File Offset: 0x0000EA4C
		public bool DeleteMail(int UserID, int mailID, out int senderID)
		{
			bool result = false;
			senderID = 0;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", mailID),
					new SqlParameter("@UserID", UserID),
					new SqlParameter("@SenderID", SqlDbType.Int)
					{
						Value = senderID,
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				result = this.db.RunProcedure("SP_Mail_Delete", para);
				if ((int)para[3].Value == 0)
				{
					result = true;
					senderID = (int)para[2].Value;
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00010928 File Offset: 0x0000EB28
		public bool UpdateMail(MailInfo mail, int oldMoney)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", mail.ID),
					new SqlParameter("@Annex1", mail.Annex1 ?? ""),
					new SqlParameter("@Annex2", mail.Annex2 ?? ""),
					new SqlParameter("@Content", mail.Content ?? ""),
					new SqlParameter("@Gold", mail.Gold),
					new SqlParameter("@IsExist", mail.IsExist),
					new SqlParameter("@Money", mail.Money),
					new SqlParameter("@Receiver", mail.Receiver ?? ""),
					new SqlParameter("@ReceiverID", mail.ReceiverID),
					new SqlParameter("@Sender", mail.Sender ?? ""),
					new SqlParameter("@SenderID", mail.SenderID),
					new SqlParameter("@Title", mail.Title ?? ""),
					new SqlParameter("@IfDelS", false),
					new SqlParameter("@IsDelete", false),
					new SqlParameter("@IsDelR", false),
					new SqlParameter("@IsRead", mail.IsRead),
					new SqlParameter("@SendTime", mail.SendTime),
					new SqlParameter("@Type", mail.Type),
					new SqlParameter("@OldMoney", oldMoney),
					new SqlParameter("@ValidDate", mail.ValidDate),
					new SqlParameter("@Annex1Name", mail.Annex1Name),
					new SqlParameter("@Annex2Name", mail.Annex2Name),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@Annex3", mail.Annex3 ?? ""),
					new SqlParameter("@Annex4", mail.Annex4 ?? ""),
					new SqlParameter("@Annex5", mail.Annex5 ?? ""),
					new SqlParameter("@Annex3Name", mail.Annex3Name ?? ""),
					new SqlParameter("@Annex4Name", mail.Annex4Name ?? ""),
					new SqlParameter("@Annex5Name", mail.Annex5Name ?? ""),
					new SqlParameter("@GiftToken", mail.GiftToken)
				};
				this.db.RunProcedure("SP_Mail_Update", para);
				result = (int)para[22].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00010C98 File Offset: 0x0000EE98
		public bool CancelPaymentMail(int userid, int mailID, ref int senderID)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@userid", userid),
					new SqlParameter("@mailID", mailID),
					new SqlParameter("@senderID", SqlDbType.Int)
					{
						Value = senderID,
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				this.db.RunProcedure("SP_Mail_PaymentCancel", para);
				result = (int)para[3].Value == 0;
				if (result)
				{
					senderID = (int)para[2].Value;
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00010D74 File Offset: 0x0000EF74
		public bool ScanMail(ref string noticeUserID)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@NoticeUserID", SqlDbType.NVarChar, 4000)
				};
				para[0].Direction = ParameterDirection.Output;
				this.db.RunProcedure("SP_Mail_Scan", para);
				noticeUserID = para[0].Value.ToString();
				result = true;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00010DFC File Offset: 0x0000EFFC
		public bool SendMailAndItem(MailInfo mail, ItemInfo item, ref int returnValue)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ItemID", item.ItemID),
					new SqlParameter("@UserID", item.UserID),
					new SqlParameter("@TemplateID", item.TemplateID),
					new SqlParameter("@Place", item.Place),
					new SqlParameter("@AgilityCompose", item.AgilityCompose),
					new SqlParameter("@AttackCompose", item.AttackCompose),
					new SqlParameter("@BeginDate", item.BeginDate),
					new SqlParameter("@Color", item.Color ?? ""),
					new SqlParameter("@Count", item.Count),
					new SqlParameter("@DefendCompose", item.DefendCompose),
					new SqlParameter("@IsBinds", item.IsBinds),
					new SqlParameter("@IsExist", item.IsExist),
					new SqlParameter("@IsJudge", item.IsJudge),
					new SqlParameter("@LuckCompose", item.LuckCompose),
					new SqlParameter("@StrengthenLevel", item.StrengthenLevel),
					new SqlParameter("@ValidDate", item.ValidDate),
					new SqlParameter("@BagType", item.BagType),
					new SqlParameter("@ID", mail.ID)
					{
						Direction = ParameterDirection.Output
					},
					new SqlParameter("@Annex1", mail.Annex1 ?? ""),
					new SqlParameter("@Annex2", mail.Annex2 ?? ""),
					new SqlParameter("@Content", mail.Content ?? ""),
					new SqlParameter("@Gold", mail.Gold),
					new SqlParameter("@Money", mail.Money),
					new SqlParameter("@Receiver", mail.Receiver ?? ""),
					new SqlParameter("@ReceiverID", mail.ReceiverID),
					new SqlParameter("@Sender", mail.Sender ?? ""),
					new SqlParameter("@SenderID", mail.SenderID),
					new SqlParameter("@Title", mail.Title ?? ""),
					new SqlParameter("@IfDelS", false),
					new SqlParameter("@IsDelete", false),
					new SqlParameter("@IsDelR", false),
					new SqlParameter("@IsRead", false),
					new SqlParameter("@SendTime", DateTime.Now),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				result = this.db.RunProcedure("SP_Admin_SendUserItem", para);
				returnValue = (int)para[33].Value;
				result = returnValue == 0;
				if (result)
				{
					using (CenterServiceClient client = new CenterServiceClient())
					{
						client.MailNotice(mail.ReceiverID);
					}
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00011208 File Offset: 0x0000F408
		public bool SendMailAndMoney(MailInfo mail, ref int returnValue)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", mail.ID)
					{
						Direction = ParameterDirection.Output
					},
					new SqlParameter("@Annex1", mail.Annex1 ?? ""),
					new SqlParameter("@Annex2", mail.Annex2 ?? ""),
					new SqlParameter("@Content", mail.Content ?? ""),
					new SqlParameter("@Gold", mail.Gold),
					new SqlParameter("@IsExist", true),
					new SqlParameter("@Money", mail.Money),
					new SqlParameter("@Receiver", mail.Receiver ?? ""),
					new SqlParameter("@ReceiverID", mail.ReceiverID),
					new SqlParameter("@Sender", mail.Sender ?? ""),
					new SqlParameter("@SenderID", mail.SenderID),
					new SqlParameter("@Title", mail.Title ?? ""),
					new SqlParameter("@IfDelS", false),
					new SqlParameter("@IsDelete", false),
					new SqlParameter("@IsDelR", false),
					new SqlParameter("@IsRead", false),
					new SqlParameter("@SendTime", DateTime.Now),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				result = this.db.RunProcedure("SP_Admin_SendUserMoney", para);
				returnValue = (int)para[17].Value;
				result = returnValue == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00011440 File Offset: 0x0000F640
		public int SendMailAndItem(string title, string content, int UserID, int templateID, int count, int validDate, int gold, int money, int StrengthenLevel, int AttackCompose, int DefendCompose, int AgilityCompose, int LuckCompose, bool isBinds)
		{
			MailInfo message = new MailInfo
			{
				Annex1 = "",
				Content = title,
				Gold = gold,
				Money = money,
				Receiver = "",
				ReceiverID = UserID,
				Sender = "Administrators",
				SenderID = 0,
				Title = content
			};
			ItemInfo userGoods = ItemInfo.CreateWithoutInit(null);
			userGoods.TemplateID = templateID;
			userGoods.AgilityCompose = AgilityCompose;
			userGoods.AttackCompose = AttackCompose;
			userGoods.BeginDate = DateTime.Now;
			userGoods.Color = "";
			userGoods.DefendCompose = DefendCompose;
			userGoods.IsDirty = false;
			userGoods.IsExist = true;
			userGoods.IsJudge = true;
			userGoods.LuckCompose = LuckCompose;
			userGoods.StrengthenLevel = StrengthenLevel;
			userGoods.ValidDate = validDate;
			userGoods.Count = count;
			userGoods.IsBinds = isBinds;
			int returnValue = 1;
			this.SendMailAndItem(message, userGoods, ref returnValue);
			return returnValue;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00011528 File Offset: 0x0000F728
		public int SendMailAndItemByUserName(string title, string content, string userName, int templateID, int count, int validDate, int gold, int money, int StrengthenLevel, int AttackCompose, int DefendCompose, int AgilityCompose, int LuckCompose, bool isBinds)
		{
			PlayerInfo player = this.GetUserSingleByUserName(userName);
			int result;
			if (player != null)
			{
				result = this.SendMailAndItem(title, content, player.ID, templateID, count, validDate, gold, money, StrengthenLevel, AttackCompose, DefendCompose, AgilityCompose, LuckCompose, isBinds);
			}
			else
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0001156C File Offset: 0x0000F76C
		public int SendMailAndItemByNickName(string title, string content, string NickName, int templateID, int count, int validDate, int gold, int money, int StrengthenLevel, int AttackCompose, int DefendCompose, int AgilityCompose, int LuckCompose, bool isBinds)
		{
			PlayerInfo player = this.GetUserSingleByNickName(NickName);
			int result;
			if (player != null)
			{
				result = this.SendMailAndItem(title, content, player.ID, templateID, count, validDate, gold, money, StrengthenLevel, AttackCompose, DefendCompose, AgilityCompose, LuckCompose, isBinds);
			}
			else
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000115B0 File Offset: 0x0000F7B0
		public int SendMailAndItem(string title, string content, int userID, int gold, int money, int giftToken, string param, bool isNotice = true)
		{
			int returnValue = 1;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Title", title),
					new SqlParameter("@Content", content),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Gold", gold),
					new SqlParameter("@Money", money),
					new SqlParameter("@GiftToken", giftToken),
					new SqlParameter("@Param", param),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[7].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Admin_SendAllItem", para);
				returnValue = (int)para[7].Value;
				if (returnValue == 0 && isNotice)
				{
					using (CenterServiceClient client = new CenterServiceClient())
					{
						client.MailNotice(userID);
					}
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return returnValue;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000116D8 File Offset: 0x0000F8D8
		public int SendMailAndItemByUserName(string title, string content, string userName, int gold, int money, int giftToken, string param)
		{
			PlayerInfo player = this.GetUserSingleByUserName(userName);
			int result;
			if (player != null)
			{
				result = this.SendMailAndItem(title, content, player.ID, gold, money, giftToken, param, true);
			}
			else
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00011710 File Offset: 0x0000F910
		public int SendMailAndItemByNickName(string title, string content, string nickName, int gold, int money, int giftToken, string param)
		{
			PlayerInfo player = this.GetUserSingleByNickName(nickName);
			int result;
			if (player != null)
			{
				result = this.SendMailAndItem(title, content, player.ID, gold, money, giftToken, param, true);
			}
			else
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00011748 File Offset: 0x0000F948
		public Dictionary<int, int> GetFriendsIDAll(int UserID)
		{
			Dictionary<int, int> info = new Dictionary<int, int>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
				};
				para[0].Value = UserID;
				this.db.GetReader(ref reader, "SP_Users_Friends_All", para);
				while (reader.Read())
				{
					if (!info.ContainsKey((int)reader["FriendID"]))
					{
						info.Add((int)reader["FriendID"], (int)reader["Relation"]);
					}
					else
					{
						info[(int)reader["FriendID"]] = (int)reader["Relation"];
					}
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return info;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00011858 File Offset: 0x0000FA58
		public bool AddFriends(FriendInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", info.ID),
					new SqlParameter("@AddDate", DateTime.Now),
					new SqlParameter("@FriendID", info.FriendID),
					new SqlParameter("@IsExist", true),
					new SqlParameter("@Remark", info.Remark ?? ""),
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@Relation", info.Relation)
				};
				result = this.db.RunProcedure("SP_Users_Friends_Add", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00011958 File Offset: 0x0000FB58
		public bool DeleteFriends(int UserID, int FriendID)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", FriendID),
					new SqlParameter("@UserID", UserID)
				};
				result = this.db.RunProcedure("SP_Users_Friends_Delete", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000119D8 File Offset: 0x0000FBD8
		public FriendInfo[] GetFriendsAll(int UserID)
		{
			List<FriendInfo> infos = new List<FriendInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
				};
				para[0].Value = UserID;
				this.db.GetReader(ref reader, "SP_Users_Friends", para);
				while (reader.Read())
				{
					infos.Add(new FriendInfo
					{
						AddDate = (DateTime)reader["AddDate"],
						Colors = ((reader["Colors"] == null) ? "" : reader["Colors"].ToString()),
						FriendID = (int)reader["FriendID"],
						Grade = (int)reader["Grade"],
						Hide = (int)reader["Hide"],
						ID = (int)reader["ID"],
						IsExist = (bool)reader["IsExist"],
						NickName = ((reader["NickName"] == null) ? "" : reader["NickName"].ToString()),
						Remark = ((reader["Remark"] == null) ? "" : reader["Remark"].ToString()),
						Sex = (((bool)reader["Sex"]) ? 1 : 0),
						State = (int)reader["State"],
						Style = ((reader["Style"] == null) ? "" : reader["Style"].ToString()),
						UserID = (int)reader["UserID"],
						ConsortiaName = ((reader["ConsortiaName"] == null) ? "" : reader["ConsortiaName"].ToString()),
						Offer = (int)reader["Offer"],
						Win = (int)reader["Win"],
						Total = (int)reader["Total"],
						Escape = (int)reader["Escape"],
						Relation = (int)reader["Relation"],
						Repute = (int)reader["Repute"],
						UserName = ((reader["UserName"] == null) ? "" : reader["UserName"].ToString()),
						DutyName = ((reader["DutyName"] == null) ? "" : reader["DutyName"].ToString()),
						Nimbus = (int)reader["Nimbus"],
						AchievementPoint = (int)reader["AchievementPoint"],
						Honor = ((reader["Rank"] == null) ? "" : reader["Rank"].ToString()),
						FightPower = (int)reader["FightPower"],
						TypeVIP = (int)reader["TypeVIP"],
						VIPLevel = (int)reader["VIPLevel"],
						IsMarried = (bool)reader["IsMarried"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return infos.ToArray();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00011DD4 File Offset: 0x0000FFD4
		public ArrayList GetFriendsGood(string UserName)
		{
			ArrayList friends = new ArrayList();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", SqlDbType.NVarChar)
				};
				para[0].Value = UserName;
				this.db.GetReader(ref reader, "SP_Users_Friends_Good", para);
				while (reader.Read())
				{
					friends.Add((reader["UserName"] == null) ? "" : reader["UserName"].ToString());
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return friends;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00011EA4 File Offset: 0x000100A4
		public FriendInfo[] GetFriendsBbs(string condictArray)
		{
			List<FriendInfo> infos = new List<FriendInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@SearchUserName", SqlDbType.NVarChar, 4000)
				};
				para[0].Value = condictArray;
				this.db.GetReader(ref reader, "SP_Users_FriendsBbs", para);
				while (reader.Read())
				{
					infos.Add(new FriendInfo
					{
						NickName = ((reader["NickName"] == null) ? "" : reader["NickName"].ToString()),
						UserID = (int)reader["UserID"],
						UserName = ((reader["UserName"] == null) ? "" : reader["UserName"].ToString()),
						IsExist = ((int)reader["UserID"] > 0)
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return infos.ToArray();
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00011FE4 File Offset: 0x000101E4
		public QuestDataInfo[] GetUserQuest(int userID)
		{
			List<QuestDataInfo> infos = new List<QuestDataInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
				};
				para[0].Value = userID;
				this.db.GetReader(ref reader, "SP_QuestData_All", para);
				while (reader.Read())
				{
					infos.Add(new QuestDataInfo
					{
						CompletedDate = (DateTime)reader["CompletedDate"],
						IsComplete = (bool)reader["IsComplete"],
						Condition1 = (int)reader["Condition1"],
						Condition2 = (int)reader["Condition2"],
						Condition3 = (int)reader["Condition3"],
						Condition4 = (int)reader["Condition4"],
						QuestID = (int)reader["QuestID"],
						UserID = (int)reader["UserId"],
						IsExist = (bool)reader["IsExist"],
						RandDobule = (int)reader["RandDobule"],
						RepeatFinish = (int)reader["RepeatFinish"],
						IsDirty = false
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return infos.ToArray();
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000121B4 File Offset: 0x000103B4
		public bool UpdateDbQuestDataInfo(QuestDataInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@QuestID", info.QuestID),
					new SqlParameter("@CompletedDate", info.CompletedDate),
					new SqlParameter("@IsComplete", info.IsComplete),
					new SqlParameter("@Condition1", info.Condition1),
					new SqlParameter("@Condition2", info.Condition2),
					new SqlParameter("@Condition3", info.Condition3),
					new SqlParameter("@Condition4", info.Condition4),
					new SqlParameter("@IsExist", info.IsExist),
					new SqlParameter("@RepeatFinish", info.RepeatFinish),
					new SqlParameter("@RandDobule", info.RandDobule)
				};
				result = this.db.RunProcedure("SP_QuestData_Add", para);
				info.IsDirty = false;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0001232C File Offset: 0x0001052C
		public List<AchievementDataInfo> GetUserAchievementData(int userID)
		{
			List<AchievementDataInfo> infos = new List<AchievementDataInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
				};
				para[0].Value = userID;
				this.db.GetReader(ref reader, "SP_Achievement_Data_All", para);
				while (reader.Read())
				{
					infos.Add(new AchievementDataInfo
					{
						UserID = (int)reader["UserID"],
						AchievementID = (int)reader["AchievementID"],
						IsComplete = (bool)reader["IsComplete"],
						CompletedDate = (DateTime)reader["CompletedDate"],
						IsDirty = false
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init_GetUserAchievement", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return infos;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00012440 File Offset: 0x00010640
		public bool UpdateDbAchievementDataInfo(AchievementDataInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@AchievementID", info.AchievementID),
					new SqlParameter("@IsComplete", info.IsComplete),
					new SqlParameter("@CompletedDate", info.CompletedDate)
				};
				result = this.db.RunProcedure("SP_Achievement_Data_Add", para);
				info.IsDirty = false;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init_UpdateDbAchievementDataInfo", e);
				}
			}
			return result;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00012504 File Offset: 0x00010704
		public List<UsersRecordInfo> GetUserRecord(int userID)
		{
			List<UsersRecordInfo> infos = new List<UsersRecordInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
				};
				para[0].Value = userID;
				this.db.GetReader(ref reader, "SP_Users_Record_All", para);
				while (reader.Read())
				{
					infos.Add(new UsersRecordInfo
					{
						UserID = (int)reader["UserID"],
						RecordID = (int)reader["RecordID"],
						Total = (int)reader["Total"],
						IsDirty = false
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init_GetUserRecord", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return infos;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00012600 File Offset: 0x00010800
		public bool UpdateDbUserRecord(UsersRecordInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@RecordID", info.RecordID),
					new SqlParameter("@Total", info.Total)
				};
				result = this.db.RunProcedure("SP_Users_Record_Add", para);
				info.IsDirty = false;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init_UpdateDbUserRecord", e);
				}
			}
			return result;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000126AC File Offset: 0x000108AC
		public BufferInfo[] GetUserBuffer(int userID)
		{
			List<BufferInfo> infos = new List<BufferInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
				};
				para[0].Value = userID;
				this.db.GetReader(ref reader, "SP_User_Buff_All", para);
				while (reader.Read())
				{
					infos.Add(new BufferInfo
					{
						BeginDate = (DateTime)reader["BeginDate"],
						Data = ((reader["Data"] == null) ? "" : reader["Data"].ToString()),
						Type = (int)reader["Type"],
						UserID = (int)reader["UserID"],
						ValidDate = (int)reader["ValidDate"],
						Value = (int)reader["Value"],
						ValidCount = (int)reader["ValidCount"],
						IsExist = (bool)reader["IsExist"],
						IsDirty = false
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return infos.ToArray();
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0001284C File Offset: 0x00010A4C
		public bool SaveBuffer(BufferInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@Type", info.Type),
					new SqlParameter("@BeginDate", info.BeginDate),
					new SqlParameter("@Data", info.Data ?? ""),
					new SqlParameter("@IsExist", info.IsExist),
					new SqlParameter("@ValidDate", info.ValidDate),
					new SqlParameter("@Value", info.Value),
					new SqlParameter("@ValidCount", info.ValidCount)
				};
				result = this.db.RunProcedure("SP_User_Buff_Add", para);
				info.IsDirty = false;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00012974 File Offset: 0x00010B74
		public bool AddChargeMoney(string chargeID, string userName, int money, string payWay, decimal needMoney, out int userID, ref int isResult, DateTime date, string IP, string nickName)
		{
			bool result = false;
			userID = 0;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ChargeID", chargeID),
					new SqlParameter("@UserName", userName),
					new SqlParameter("@Money", money),
					new SqlParameter("@Date", date.ToString("yyyy-MM-dd HH:mm:ss")),
					new SqlParameter("@PayWay", payWay),
					new SqlParameter("@NeedMoney", needMoney),
					new SqlParameter("@UserID", userID)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@IP", IP),
					new SqlParameter("@NickName", nickName)
				};
				result = this.db.RunProcedure("SP_Charge_Money_Add", para);
				userID = (int)para[6].Value;
				isResult = (int)para[7].Value;
				result = isResult == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00012AB8 File Offset: 0x00010CB8
		public bool AddChargeMoneyForId(string chargeID, string userName, int money, string payWay, decimal needMoney, out int userID, ref int isResult, DateTime date, string IP, int sourceUserId)
		{
			bool result = false;
			userID = 0;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ChargeID", chargeID),
					new SqlParameter("@UserName", userName),
					new SqlParameter("@Money", money),
					new SqlParameter("@Date", date.ToString("yyyy-MM-dd HH:mm:ss")),
					new SqlParameter("@PayWay", payWay),
					new SqlParameter("@NeedMoney", needMoney),
					new SqlParameter("@UserID", userID)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@IP", IP),
					new SqlParameter("@SourceUserID", sourceUserId)
				};
				if (this.db.RunProcedure("SP_Charge_Money_UserId_Add", para))
				{
					userID = (int)para[6].Value;
					isResult = (int)para[7].Value;
					result = isResult == 0;
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00012C0C File Offset: 0x00010E0C
		public bool ChargeToUser(string userName, ref int money, string nickName)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", userName),
					new SqlParameter("@money", SqlDbType.Int)
					{
						Direction = ParameterDirection.Output
					},
					new SqlParameter("@NickName", nickName)
				};
				result = this.db.RunProcedure("SP_Charge_To_User", para);
				money = (int)para[1].Value;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00012CA8 File Offset: 0x00010EA8
		public ChargeRecordInfo[] GetChargeRecordInfo(DateTime date, int SaveRecordSecond)
		{
			List<ChargeRecordInfo> list = new List<ChargeRecordInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Date", date.ToString("yyyy-MM-dd HH:mm:ss")),
					new SqlParameter("@Second", SaveRecordSecond)
				};
				this.db.GetReader(ref reader, "SP_Charge_Record", para);
				while (reader.Read())
				{
					list.Add(new ChargeRecordInfo
					{
						BoyTotalPay = (int)reader["BoyTotalPay"],
						GirlTotalPay = (int)reader["GirlTotalPay"],
						PayWay = ((reader["PayWay"] == null) ? "" : reader["PayWay"].ToString()),
						TotalBoy = (int)reader["TotalBoy"],
						TotalGirl = (int)reader["TotalGirl"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return list.ToArray();
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00012E10 File Offset: 0x00011010
		public AuctionInfo GetAuctionSingle(int auctionID)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@AuctionID", auctionID)
				};
				this.db.GetReader(ref reader, "SP_Auction_Single", para);
				if (reader.Read())
				{
					return this.InitAuctionInfo(reader);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00012EB4 File Offset: 0x000110B4
		public bool AddAuction(AuctionInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@AuctionID", info.AuctionID)
					{
						Direction = ParameterDirection.Output
					},
					new SqlParameter("@AuctioneerID", info.AuctioneerID),
					new SqlParameter("@AuctioneerName", info.AuctioneerName ?? ""),
					new SqlParameter("@BeginDate", info.BeginDate),
					new SqlParameter("@BuyerID", info.BuyerID),
					new SqlParameter("@BuyerName", info.BuyerName ?? ""),
					new SqlParameter("@IsExist", info.IsExist),
					new SqlParameter("@ItemID", info.ItemID),
					new SqlParameter("@Mouthful", info.Mouthful),
					new SqlParameter("@PayType", info.PayType),
					new SqlParameter("@Price", info.Price),
					new SqlParameter("@Rise", info.Rise),
					new SqlParameter("@ValidDate", info.ValidDate),
					new SqlParameter("@TemplateID", info.TemplateID),
					new SqlParameter("Name", info.Name),
					new SqlParameter("Category", info.Category),
					new SqlParameter("Random", info.Random)
				};
				result = this.db.RunProcedure("SP_Auction_Add", para);
				info.AuctionID = (int)para[0].Value;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000130D8 File Offset: 0x000112D8
		public bool UpdateAuction(AuctionInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@AuctionID", info.AuctionID),
					new SqlParameter("@AuctioneerID", info.AuctioneerID),
					new SqlParameter("@AuctioneerName", info.AuctioneerName ?? ""),
					new SqlParameter("@BeginDate", info.BeginDate),
					new SqlParameter("@BuyerID", info.BuyerID),
					new SqlParameter("@BuyerName", info.BuyerName ?? ""),
					new SqlParameter("@IsExist", info.IsExist),
					new SqlParameter("@ItemID", info.ItemID),
					new SqlParameter("@Mouthful", info.Mouthful),
					new SqlParameter("@PayType", info.PayType),
					new SqlParameter("@Price", info.Price),
					new SqlParameter("@Rise", info.Rise),
					new SqlParameter("@ValidDate", info.ValidDate),
					new SqlParameter("Name", info.Name),
					new SqlParameter("Category", info.Category),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[15].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Auction_Update", para);
				result = (int)para[15].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000132DC File Offset: 0x000114DC
		public bool DeleteAuction(int auctionID, int userID, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@AuctionID", auctionID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[2].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Auction_Delete", para);
				int returnValue = (int)para[2].Value;
				result = returnValue == 0;
				switch (returnValue)
				{
				case 0:
					msg = LanguageMgr.GetTranslation("PlayerBussiness.DeleteAuction.Msg1", new object[0]);
					break;
				case 1:
					msg = LanguageMgr.GetTranslation("PlayerBussiness.DeleteAuction.Msg2", new object[0]);
					break;
				case 2:
					msg = LanguageMgr.GetTranslation("PlayerBussiness.DeleteAuction.Msg3", new object[0]);
					break;
				default:
					msg = LanguageMgr.GetTranslation("PlayerBussiness.DeleteAuction.Msg4", new object[0]);
					break;
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000133E8 File Offset: 0x000115E8
		public AuctionInfo[] GetAuctionPage(int page, string name, int type, int pay, ref int total, int userID, int buyID, int order, bool sort, int size, string AuctionIDs)
		{
			List<AuctionInfo> infos = new List<AuctionInfo>();
			try
			{
				string sWhere = " IsExist=1 ";
				if (!string.IsNullOrEmpty(name))
				{
					sWhere = sWhere + " and Name like '%" + name + "%' ";
				}
				if (type != -1)
				{
					switch (type)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 13:
					case 14:
					case 15:
					case 16:
					case 17:
					{
						object obj = sWhere;
						sWhere = string.Concat(new object[] { obj, " and Category =", type, " " });
						break;
					}
					case 18:
					case 19:
					case 20:
						break;
					case 21:
						sWhere += " and Category in(1,2,5,8,9) ";
						break;
					case 22:
						sWhere += " and Category in(13,15,6,4,3) ";
						break;
					case 23:
						sWhere += " and Category in(16,11,10) ";
						break;
					case 24:
						sWhere += " and Category in(8,9) ";
						break;
					case 25:
						sWhere += " and Category in (7,17) ";
						break;
					case 26:
						sWhere += " and TemplateId>=311000 and TemplateId<=313999";
						break;
					case 27:
						sWhere += " and TemplateId>=311000 and TemplateId<=311999 ";
						break;
					case 28:
						sWhere += " and TemplateId>=313000 and TempLateId<=313999";
						break;
					case 29:
						sWhere += " and TemplateId>=312000 and TemplateId<=312999 ";
						break;
					default:
						switch (type)
						{
						case 1100:
							sWhere += " and TemplateID in (11019,11021,11022,11023,11024) ";
							break;
						case 1101:
							sWhere += " and TemplateID='11019' ";
							break;
						case 1102:
							sWhere += " and TemplateID='11021' ";
							break;
						case 1103:
							sWhere += " and TemplateID='11022' ";
							break;
						case 1104:
							sWhere += " and TemplateID='11023' ";
							break;
						case 1105:
							sWhere += " and TemplateID in (11001,11002,11003,11004,11005,11006,11007,11008,11009,11010,11011,11012,11013,11014,11015,11016) ";
							break;
						case 1106:
							sWhere += " and TemplateID in (11001,11002,11003,11004) ";
							break;
						case 1107:
							sWhere += " and TemplateID in (11005,11006,11007,11008) ";
							break;
						case 1108:
							sWhere += " and TemplateID in (11009,11010,11011,11012) ";
							break;
						case 1109:
							sWhere += " and TemplateID in (11013,11014,11015,11016) ";
							break;
						case 1110:
							sWhere += " and TemplateID='11024' ";
							break;
						}
						break;
					}
				}
				if (pay != -1)
				{
					object obj2 = sWhere;
					sWhere = string.Concat(new object[] { obj2, " and PayType =", pay, " " });
				}
				if (userID != -1)
				{
					object obj3 = sWhere;
					sWhere = string.Concat(new object[] { obj3, " and AuctioneerID =", userID, " " });
				}
				if (buyID != -1)
				{
					object obj4 = sWhere;
					sWhere = string.Concat(new object[] { obj4, " and (BuyerID =", buyID, " or AuctionID in (", AuctionIDs, ")) " });
				}
				string sOrder = "Category,Name,Price,dd,AuctioneerID";
				switch (order)
				{
				case 0:
					sOrder = "Name";
					break;
				case 2:
					sOrder = "dd";
					break;
				case 3:
					sOrder = "AuctioneerName";
					break;
				case 4:
					sOrder = "Price";
					break;
				case 5:
					sOrder = "BuyerName";
					break;
				}
				sOrder += (sort ? " desc" : "");
				sOrder += ",AuctionID ";
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@QueryStr", "V_Auction_Scan"),
					new SqlParameter("@QueryWhere", sWhere),
					new SqlParameter("@PageSize", size),
					new SqlParameter("@PageCurrent", page),
					new SqlParameter("@FdShow", "*"),
					new SqlParameter("@FdOrder", sOrder),
					new SqlParameter("@FdKey", "AuctionID"),
					new SqlParameter("@TotalRow", total)
				};
				para[7].Direction = ParameterDirection.Output;
				DataTable dataTable = this.db.GetDataTable("Auction", "SP_CustomPage", para);
				total = (int)para[7].Value;
				foreach (object obj5 in dataTable.Rows)
				{
					DataRow dr = (DataRow)obj5;
					infos.Add(new AuctionInfo
					{
						AuctioneerID = (int)dr["AuctioneerID"],
						AuctioneerName = dr["AuctioneerName"].ToString(),
						AuctionID = (int)dr["AuctionID"],
						BeginDate = (DateTime)dr["BeginDate"],
						BuyerID = (int)dr["BuyerID"],
						BuyerName = dr["BuyerName"].ToString(),
						Category = (int)dr["Category"],
						IsExist = (bool)dr["IsExist"],
						ItemID = (int)dr["ItemID"],
						Name = dr["Name"].ToString(),
						Mouthful = (int)dr["Mouthful"],
						PayType = (int)dr["PayType"],
						Price = (int)dr["Price"],
						Rise = (int)dr["Rise"],
						ValidDate = (int)dr["ValidDate"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return infos.ToArray();
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00013A28 File Offset: 0x00011C28
		public AuctionInfo InitAuctionInfo(SqlDataReader reader)
		{
			return new AuctionInfo
			{
				AuctioneerID = (int)reader["AuctioneerID"],
				AuctioneerName = ((reader["AuctioneerName"] == null) ? "" : reader["AuctioneerName"].ToString()),
				AuctionID = (int)reader["AuctionID"],
				BeginDate = (DateTime)reader["BeginDate"],
				BuyerID = (int)reader["BuyerID"],
				BuyerName = ((reader["BuyerName"] == null) ? "" : reader["BuyerName"].ToString()),
				IsExist = (bool)reader["IsExist"],
				ItemID = (int)reader["ItemID"],
				Mouthful = (int)reader["Mouthful"],
				PayType = (int)reader["PayType"],
				Price = (int)reader["Price"],
				Rise = (int)reader["Rise"],
				ValidDate = (int)reader["ValidDate"],
				Name = reader["Name"].ToString(),
				Category = (int)reader["Category"]
			};
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00013BAC File Offset: 0x00011DAC
		public bool ScanAuction(ref string noticeUserID)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@NoticeUserID", SqlDbType.NVarChar, 4000)
				};
				para[0].Direction = ParameterDirection.Output;
				this.db.RunProcedure("SP_Auction_Scan", para);
				noticeUserID = para[0].Value.ToString();
				result = true;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00013C34 File Offset: 0x00011E34
		public bool AddMarryInfo(MarryInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", info.ID)
					{
						Direction = ParameterDirection.Output
					},
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@IsPublishEquip", info.IsPublishEquip),
					new SqlParameter("@Introduction", info.Introduction),
					new SqlParameter("@RegistTime", info.RegistTime)
				};
				result = this.db.RunProcedure("SP_MarryInfo_Add", para);
				info.ID = (int)para[0].Value;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("AddMarryInfo", e);
				}
			}
			return result;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00013D1C File Offset: 0x00011F1C
		public bool DeleteMarryInfo(int ID, int userID, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", ID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[2].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_MarryInfo_Delete", para);
				int num = (int)para[2].Value;
				result = num == 0;
				if (num == 0)
				{
					msg = LanguageMgr.GetTranslation("PlayerBussiness.DeleteAuction.Succeed", new object[0]);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("DeleteAuction", e);
				}
			}
			return result;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00013DDC File Offset: 0x00011FDC
		public MarryInfo GetMarryInfoSingle(int ID)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", ID)
				};
				this.db.GetReader(ref reader, "SP_MarryInfo_Single", para);
				if (reader.Read())
				{
					return new MarryInfo
					{
						ID = (int)reader["ID"],
						UserID = (int)reader["UserID"],
						IsPublishEquip = (bool)reader["IsPublishEquip"],
						Introduction = reader["Introduction"].ToString(),
						RegistTime = (DateTime)reader["RegistTime"]
					};
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetMarryInfoSingle", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00013EEC File Offset: 0x000120EC
		public bool UpdateMarryInfo(MarryInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", info.ID),
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@IsPublishEquip", info.IsPublishEquip),
					new SqlParameter("@Introduction", info.Introduction),
					new SqlParameter("@RegistTime", info.RegistTime),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[5].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_MarryInfo_Update", para);
				result = (int)para[5].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00013FE4 File Offset: 0x000121E4
		public MarryInfo[] GetMarryInfoPage(int page, string name, bool sex, int size, ref int total)
		{
			List<MarryInfo> infos = new List<MarryInfo>();
			try
			{
				string sWhere;
				if (sex)
				{
					sWhere = " IsExist=1 and Sex=1 and UserExist=1";
				}
				else
				{
					sWhere = " IsExist=1 and Sex=0 and UserExist=1";
				}
				if (!string.IsNullOrEmpty(name))
				{
					sWhere = sWhere + " and NickName like '%" + name + "%' ";
				}
				string sOrder = "State desc,IsMarried";
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@QueryStr", "V_Sys_Marry_Info"),
					new SqlParameter("@QueryWhere", sWhere),
					new SqlParameter("@PageSize", size),
					new SqlParameter("@PageCurrent", page),
					new SqlParameter("@FdShow", "*"),
					new SqlParameter("@FdOrder", sOrder),
					new SqlParameter("@FdKey", "ID"),
					new SqlParameter("@TotalRow", total)
				};
				para[7].Direction = ParameterDirection.Output;
				DataTable dataTable = this.db.GetDataTable("V_Sys_Marry_Info", "SP_CustomPage", para);
				total = (int)para[7].Value;
				foreach (object obj in dataTable.Rows)
				{
					DataRow dr = (DataRow)obj;
					infos.Add(new MarryInfo
					{
						ID = (int)dr["ID"],
						UserID = (int)dr["UserID"],
						IsPublishEquip = (bool)dr["IsPublishEquip"],
						Introduction = dr["Introduction"].ToString(),
						NickName = dr["NickName"].ToString(),
						IsConsortia = (bool)dr["IsConsortia"],
						ConsortiaID = (int)dr["ConsortiaID"],
						Sex = (bool)dr["Sex"],
						Win = (int)dr["Win"],
						Total = (int)dr["Total"],
						Escape = (int)dr["Escape"],
						GP = (int)dr["GP"],
						Honor = dr["Honor"].ToString(),
						Style = dr["Style"].ToString(),
						Colors = dr["Colors"].ToString(),
						Hide = (int)dr["Hide"],
						Grade = (int)dr["Grade"],
						State = (int)dr["State"],
						Repute = (int)dr["Repute"],
						Skin = dr["Skin"].ToString(),
						Offer = (int)dr["Offer"],
						IsMarried = (bool)dr["IsMarried"],
						ConsortiaName = dr["ConsortiaName"].ToString(),
						DutyName = dr["DutyName"].ToString(),
						Nimbus = (int)dr["Nimbus"],
						FightPower = (int)dr["FightPower"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return infos.ToArray();
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000143EC File Offset: 0x000125EC
		public MarryInfo[] GetMarryInfoPages(int page, string name, bool sex, int size, ref int total)
		{
			List<MarryInfo> infos = new List<MarryInfo>();
			try
			{
				string sWhere;
				if (sex)
				{
					sWhere = " IsExist=1 and Sex=1 and UserExist=1";
				}
				else
				{
					sWhere = " IsExist=1 and Sex=0 and UserExist=1";
				}
				if (!string.IsNullOrEmpty(name))
				{
					sWhere = sWhere + " and NickName like '%" + name + "%' ";
				}
				string sOrder = "State desc,IsMarried";
				foreach (object obj in base.GetFetch_List(page, size, sOrder, sWhere, "V_Sys_Marry_Info", ref total).Rows)
				{
					DataRow dr = (DataRow)obj;
					infos.Add(new MarryInfo
					{
						ID = (int)dr["ID"],
						UserID = (int)dr["UserID"],
						IsPublishEquip = (bool)dr["IsPublishEquip"],
						Introduction = dr["Introduction"].ToString(),
						NickName = dr["NickName"].ToString(),
						IsConsortia = (bool)dr["IsConsortia"],
						ConsortiaID = (int)dr["ConsortiaID"],
						Sex = (bool)dr["Sex"],
						Win = (int)dr["Win"],
						Total = (int)dr["Total"],
						Escape = (int)dr["Escape"],
						GP = (int)dr["GP"],
						Honor = dr["Honor"].ToString(),
						Style = dr["Style"].ToString(),
						Colors = dr["Colors"].ToString(),
						Hide = (int)dr["Hide"],
						Grade = (int)dr["Grade"],
						State = (int)dr["State"],
						Repute = (int)dr["Repute"],
						Skin = dr["Skin"].ToString(),
						Offer = (int)dr["Offer"],
						IsMarried = (bool)dr["IsMarried"],
						ConsortiaName = dr["ConsortiaName"].ToString(),
						DutyName = dr["DutyName"].ToString(),
						Nimbus = (int)dr["Nimbus"],
						FightPower = (int)dr["FightPower"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return infos.ToArray();
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00014740 File Offset: 0x00012940
		public bool InsertPlayerMarryApply(MarryApplyInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@ApplyUserID", info.ApplyUserID),
					new SqlParameter("@ApplyUserName", info.ApplyUserName),
					new SqlParameter("@ApplyType", info.ApplyType),
					new SqlParameter("@ApplyResult", info.ApplyResult),
					new SqlParameter("@LoveProclamation", info.LoveProclamation),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[6].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Insert_Marry_Apply", para);
				result = (int)para[6].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("InsertPlayerMarryApply", e);
				}
			}
			return result;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00014848 File Offset: 0x00012A48
		public bool UpdatePlayerMarryApply(int UserID, string loveProclamation, bool isExist)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", UserID),
					new SqlParameter("@LoveProclamation", loveProclamation),
					new SqlParameter("@isExist", isExist),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Update_Marry_Apply", para);
				result = (int)para[3].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("UpdatePlayerMarryApply", e);
				}
			}
			return result;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00014900 File Offset: 0x00012B00
		public MarryApplyInfo[] GetPlayerMarryApply(int UserID)
		{
			SqlDataReader reader = null;
			List<MarryApplyInfo> infos = new List<MarryApplyInfo>();
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", UserID)
				};
				this.db.GetReader(ref reader, "SP_Get_Marry_Apply", para);
				while (reader.Read())
				{
					infos.Add(new MarryApplyInfo
					{
						UserID = (int)reader["UserID"],
						ApplyUserID = (int)reader["ApplyUserID"],
						ApplyUserName = reader["ApplyUserName"].ToString(),
						ApplyType = (int)reader["ApplyType"],
						ApplyResult = (bool)reader["ApplyResult"],
						LoveProclamation = reader["LoveProclamation"].ToString(),
						ID = (int)reader["Id"]
					});
				}
				return infos.ToArray();
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetPlayerMarryApply", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00014A6C File Offset: 0x00012C6C
		public bool InsertMarryRoomInfo(MarryRoomInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", info.ID)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@Name", info.Name),
					new SqlParameter("@PlayerID", info.PlayerID),
					new SqlParameter("@PlayerName", info.PlayerName),
					new SqlParameter("@GroomID", info.GroomID),
					new SqlParameter("@GroomName", info.GroomName),
					new SqlParameter("@BrideID", info.BrideID),
					new SqlParameter("@BrideName", info.BrideName),
					new SqlParameter("@Pwd", info.Pwd),
					new SqlParameter("@AvailTime", info.AvailTime),
					new SqlParameter("@MaxCount", info.MaxCount),
					new SqlParameter("@GuestInvite", info.GuestInvite),
					new SqlParameter("@MapIndex", info.MapIndex),
					new SqlParameter("@BeginTime", info.BeginTime),
					new SqlParameter("@BreakTime", info.BreakTime),
					new SqlParameter("@RoomIntroduction", info.RoomIntroduction),
					new SqlParameter("@ServerID", info.ServerID),
					new SqlParameter("@IsHymeneal", info.IsHymeneal),
					new SqlParameter("@IsGunsaluteUsed", info.IsGunsaluteUsed),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				this.db.RunProcedure("SP_Insert_Marry_Room_Info", para);
				result = (int)para[19].Value == 0;
				if (result)
				{
					info.ID = (int)para[0].Value;
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("InsertMarryRoomInfo", e);
				}
			}
			return result;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00014CCC File Offset: 0x00012ECC
		public bool UpdateMarryRoomInfo(MarryRoomInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", info.ID),
					new SqlParameter("@AvailTime", info.AvailTime),
					new SqlParameter("@BreakTime", info.BreakTime),
					new SqlParameter("@roomIntroduction", info.RoomIntroduction),
					new SqlParameter("@isHymeneal", info.IsHymeneal),
					new SqlParameter("@Name", info.Name),
					new SqlParameter("@Pwd", info.Pwd),
					new SqlParameter("@IsGunsaluteUsed", info.IsGunsaluteUsed),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[8].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Update_Marry_Room_Info", para);
				result = (int)para[8].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("UpdateMarryRoomInfo", e);
				}
			}
			return result;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00014E00 File Offset: 0x00013000
		public bool DisposeMarryRoomInfo(int ID)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", ID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[1].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Dispose_Marry_Room_Info", para);
				result = (int)para[1].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("DisposeMarryRoomInfo", e);
				}
			}
			return result;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00014E98 File Offset: 0x00013098
		public MarryRoomInfo[] GetMarryRoomInfo()
		{
			SqlDataReader reader = null;
			List<MarryRoomInfo> infos = new List<MarryRoomInfo>();
			try
			{
				this.db.GetReader(ref reader, "SP_Get_Marry_Room_Info");
				while (reader.Read())
				{
					infos.Add(new MarryRoomInfo
					{
						ID = (int)reader["ID"],
						Name = reader["Name"].ToString(),
						PlayerID = (int)reader["PlayerID"],
						PlayerName = reader["PlayerName"].ToString(),
						GroomID = (int)reader["GroomID"],
						GroomName = reader["GroomName"].ToString(),
						BrideID = (int)reader["BrideID"],
						BrideName = reader["BrideName"].ToString(),
						Pwd = reader["Pwd"].ToString(),
						AvailTime = (int)reader["AvailTime"],
						MaxCount = (int)reader["MaxCount"],
						GuestInvite = (bool)reader["GuestInvite"],
						MapIndex = (int)reader["MapIndex"],
						BeginTime = (DateTime)reader["BeginTime"],
						BreakTime = (DateTime)reader["BreakTime"],
						RoomIntroduction = reader["RoomIntroduction"].ToString(),
						ServerID = (int)reader["ServerID"],
						IsHymeneal = (bool)reader["IsHymeneal"],
						IsGunsaluteUsed = (bool)reader["IsGunsaluteUsed"]
					});
				}
				return infos.ToArray();
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetMarryRoomInfo", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000150F0 File Offset: 0x000132F0
		public MarryRoomInfo GetMarryRoomInfoSingle(int id)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", id)
				};
				this.db.GetReader(ref reader, "SP_Get_Marry_Room_Info_Single", para);
				if (reader.Read())
				{
					return new MarryRoomInfo
					{
						ID = (int)reader["ID"],
						Name = reader["Name"].ToString(),
						PlayerID = (int)reader["PlayerID"],
						PlayerName = reader["PlayerName"].ToString(),
						GroomID = (int)reader["GroomID"],
						GroomName = reader["GroomName"].ToString(),
						BrideID = (int)reader["BrideID"],
						BrideName = reader["BrideName"].ToString(),
						Pwd = reader["Pwd"].ToString(),
						AvailTime = (int)reader["AvailTime"],
						MaxCount = (int)reader["MaxCount"],
						GuestInvite = (bool)reader["GuestInvite"],
						MapIndex = (int)reader["MapIndex"],
						BeginTime = (DateTime)reader["BeginTime"],
						BreakTime = (DateTime)reader["BreakTime"],
						RoomIntroduction = reader["RoomIntroduction"].ToString(),
						ServerID = (int)reader["ServerID"],
						IsHymeneal = (bool)reader["IsHymeneal"],
						IsGunsaluteUsed = (bool)reader["IsGunsaluteUsed"]
					};
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetMarryRoomInfo", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0001534C File Offset: 0x0001354C
		public bool UpdateBreakTimeWhereServerStop()
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[0].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Update_Marry_Room_Info_Sever_Stop", para);
				result = (int)para[0].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("UpdateBreakTimeWhereServerStop", e);
				}
			}
			return result;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000153D0 File Offset: 0x000135D0
		public MarryProp GetMarryProp(int id)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", id)
				};
				this.db.GetReader(ref reader, "SP_Select_Marry_Prop", para);
				if (reader.Read())
				{
					return new MarryProp
					{
						IsMarried = (bool)reader["IsMarried"],
						SpouseID = (int)reader["SpouseID"],
						SpouseName = reader["SpouseName"].ToString(),
						IsCreatedMarryRoom = (bool)reader["IsCreatedMarryRoom"],
						SelfMarryRoomID = (int)reader["SelfMarryRoomID"],
						IsGotRing = (bool)reader["IsGotRing"]
					};
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetMarryProp", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000154F8 File Offset: 0x000136F8
		public bool SavePlayerMarryNotice(MarryApplyInfo info, int answerId, ref int id)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@ApplyUserID", info.ApplyUserID),
					new SqlParameter("@ApplyUserName", info.ApplyUserName),
					new SqlParameter("@ApplyType", info.ApplyType),
					new SqlParameter("@ApplyResult", info.ApplyResult),
					new SqlParameter("@LoveProclamation", info.LoveProclamation),
					new SqlParameter("@AnswerId", answerId),
					new SqlParameter("@ouototal", SqlDbType.Int)
					{
						Direction = ParameterDirection.Output
					},
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				this.db.RunProcedure("SP_Insert_Marry_Notice", para);
				id = (int)para[7].Value;
				result = (int)para[8].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("SavePlayerMarryNotice", e);
				}
			}
			return result;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00015638 File Offset: 0x00013838
		public bool UpdatePlayerGotRingProp(int groomID, int brideID)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@GroomID", groomID),
					new SqlParameter("@BrideID", brideID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[2].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Update_GotRing_Prop", para);
				result = (int)para[2].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("UpdatePlayerGotRingProp", e);
				}
			}
			return result;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000156E0 File Offset: 0x000138E0
		public RebateChargeInfo[] GetChargeInfo(string UserName, string NickName, ref DateTime firstChargeDate)
		{
			List<SqlParameter> para = new List<SqlParameter>();
			List<RebateChargeInfo> allChargeInfo = new List<RebateChargeInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter outPara = new SqlParameter("FirstChargeDate", SqlDbType.DateTime)
				{
					Direction = ParameterDirection.Output
				};
				para.Add(outPara);
				para.Add(new SqlParameter("UserName", UserName));
				para.Add(new SqlParameter("NickName", NickName));
				if (this.db.GetReader(ref reader, "SP_Charge_Reward_ChargeInfo", para.ToArray()))
				{
					while (reader.Read())
					{
						allChargeInfo.Add(new RebateChargeInfo
						{
							ChargeID = (string)reader["ChargeID"],
							UserName = (string)reader["UserName"],
							NickName = (string)reader["NickName"],
							Money = (int)reader["Money"],
							Date = (DateTime)reader["Date"]
						});
					}
					reader.Close();
					firstChargeDate = (DateTime)outPara.Value;
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return allChargeInfo.ToArray();
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0001582C File Offset: 0x00013A2C
		public RebateItemInfo[] GetChargeRewardItemsInfo(int chargeMoney, DateTime chargeDate)
		{
			List<SqlParameter> para = new List<SqlParameter>();
			List<RebateItemInfo> allItemsInfo = new List<RebateItemInfo>();
			SqlDataReader reader = null;
			try
			{
				para.Add(new SqlParameter("Money", chargeMoney));
				para.Add(new SqlParameter("ChargeDate", chargeDate));
				if (this.db.GetReader(ref reader, "SP_Charge_Reward_RewardInfo", para.ToArray()))
				{
					while (reader.Read())
					{
						allItemsInfo.Add(new RebateItemInfo
						{
							GiftPackageID = (int)reader["GiftPackageID"],
							RewardItemID = (int)reader["RewardItemID"],
							Money = (int)reader["Money"],
							Gold = (int)reader["Gold"],
							GiftToken = (int)reader["GiftToken"],
							ItemTemplateID = (int)reader["ItemTemplateID"],
							Count = (int)reader["Count"],
							ValidDate = (int)reader["ValidDate"],
							StrengthLevel = (int)reader["StrengthLevel"],
							AttackCompose = (int)reader["AttackCompose"],
							DefendCompose = (int)reader["DefendCompose"],
							LuckCompose = (int)reader["LuckCompose"],
							AgilityCompose = (int)reader["AgilityCompose"],
							IsBind = (bool)reader["IsBind"],
							NeedSex = (int)reader["NeedSex"],
							FirstChargeNeeded = (bool)reader["FirstChargeNeeded"]
						});
					}
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return allItemsInfo.ToArray();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00015A50 File Offset: 0x00013C50
		public bool DoChargeReward(int userID, RebateChargeInfo chargeInfo, int rewardMoney, int rewardGold, int rewardGiftToken, string rewardITems, string rewardInfo)
		{
			bool result = false;
			try
			{
				List<SqlParameter> para = new List<SqlParameter>();
				string title = LanguageMgr.GetTranslation("PlayerBussiness.DoChargeReward.Title", new object[0]);
				string content = LanguageMgr.GetTranslation("PlayerBussiness.DoChargeReward.Content", new object[0]);
				para.Add(new SqlParameter("Title", title));
				para.Add(new SqlParameter("Content", content));
				para.Add(new SqlParameter("UserID", userID));
				para.Add(new SqlParameter("ChargeID", chargeInfo.ChargeID));
				para.Add(new SqlParameter("ChargeMoney", chargeInfo.Money));
				para.Add(new SqlParameter("Money", rewardMoney));
				para.Add(new SqlParameter("Gold", rewardGold));
				para.Add(new SqlParameter("GiftToken", rewardGiftToken));
				para.Add(new SqlParameter("RewardInfo", rewardInfo));
				para.Add(new SqlParameter("RewardItems", rewardITems));
				result = this.db.RunProcedure("SP_Charge_Reward_DoReward", para.ToArray());
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00015BB0 File Offset: 0x00013DB0
		public bool Test(string DutyName)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DutyName", DutyName)
				};
				result = this.db.RunProcedure("SP_Test1", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00015C18 File Offset: 0x00013E18
		public SpaRoomInfo GetSpaRoomInfoSingle(int id)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@RoomID", id)
				};
				this.db.GetReader(ref reader, "SP_Get_Spa_Room_Info_Single", para);
				if (reader.Read())
				{
					return new SpaRoomInfo
					{
						RoomID = (int)reader["RoomID"],
						RoomName = reader["RoomName"].ToString(),
						PlayerID = (int)reader["PlayerID"],
						PlayerName = reader["PlayerName"].ToString(),
						Pwd = reader["Pwd"].ToString(),
						AvailTime = (int)reader["AvailTime"],
						MaxCount = (int)reader["MaxCount"],
						MapIndex = (int)reader["MapIndex"],
						BeginTime = (DateTime)reader["BeginTime"],
						BreakTime = (DateTime)reader["BreakTime"],
						RoomIntroduction = reader["RoomIntroduction"].ToString(),
						RoomType = (int)reader["RoomType"],
						ServerID = (int)reader["ServerID"],
						RoomNumber = (int)reader["RoomNumber"]
					};
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetSpaRoomInfo", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00015E08 File Offset: 0x00014008
		public bool UpdateSpaRoomInfo(SpaRoomInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@RoomID", info.RoomID),
					new SqlParameter("@RoomName", info.RoomName),
					new SqlParameter("@Pwd", info.Pwd),
					new SqlParameter("@AvailTime", info.AvailTime),
					new SqlParameter("@BreakTime", info.BreakTime),
					new SqlParameter("@roomIntroduction", info.RoomIntroduction),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[6].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Update_Spa_Room_Info", para);
				result = (int)para[6].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("UpdateSpaRoomInfo", e);
				}
			}
			return result;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00015F0C File Offset: 0x0001410C
		public bool DisposeSpaRoomInfo(int RoomID)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@RoomID", RoomID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[1].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Dispose_Spa_Room_Info", para);
				result = (int)para[1].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("DisposeSpaRoomInfo", e);
				}
			}
			return result;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00015FA4 File Offset: 0x000141A4
		public SpaRoomInfo[] GetSpaRoomInfo(int id)
		{
			return null;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00015FA8 File Offset: 0x000141A8
		public SpaRoomInfo[] GetSpaRoomInfo()
		{
			SqlDataReader reader = null;
			List<SpaRoomInfo> infos = new List<SpaRoomInfo>();
			try
			{
				this.db.GetReader(ref reader, "SP_Get_Spa_Room_Info");
				while (reader.Read())
				{
					infos.Add(new SpaRoomInfo
					{
						RoomID = (int)reader["RoomID"],
						RoomName = ((reader["RoomName"] == null) ? "" : reader["RoomName"].ToString()),
						PlayerID = (int)reader["PlayerID"],
						PlayerName = ((reader["PlayerName"] == null) ? "" : reader["PlayerName"].ToString()),
						Pwd = (reader["Pwd"].ToString() ?? ""),
						AvailTime = (int)reader["AvailTime"],
						MaxCount = (int)reader["MaxCount"],
						BeginTime = (DateTime)reader["BeginTime"],
						BreakTime = (DateTime)reader["BreakTime"],
						RoomIntroduction = ((reader["RoomIntroduction"] == null) ? "" : reader["RoomIntroduction"].ToString()),
						RoomType = (int)reader["RoomType"],
						ServerID = (int)reader["ServerID"],
						RoomNumber = (int)reader["RoomNumber"]
					});
				}
				return infos.ToArray();
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetSpaRoomInfo", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return null;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000161C0 File Offset: 0x000143C0
		public bool InsertSpaPubRoomInfo(SpaRoomInfo info)
		{
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@RoomName", info.RoomName),
					new SqlParameter("@AvailTime", info.AvailTime),
					new SqlParameter("@MaxCount", info.MaxCount),
					new SqlParameter("@MapIndex", info.MapIndex),
					new SqlParameter("@BeginTime", info.BeginTime),
					new SqlParameter("@BreakTime", info.BreakTime),
					new SqlParameter("@RoomIntroduction", info.RoomIntroduction),
					new SqlParameter("@RoomType", info.RoomType),
					new SqlParameter("@ServerID", info.ServerID),
					new SqlParameter("@RoomNumber", info.RoomNumber),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[10].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Insert_Spa_PubRoom_Info", para);
				if ((int)para[10].Value > 0)
				{
					info.RoomID = (int)para[10].Value;
					return true;
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("InsertSpaRoomInfo", e);
				}
			}
			return false;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00016350 File Offset: 0x00014550
		public bool InsertSpaRoomInfo(SpaRoomInfo info)
		{
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@RoomName", info.RoomName),
					new SqlParameter("@PlayerID", info.PlayerID),
					new SqlParameter("@PlayerName", info.PlayerName),
					new SqlParameter("@Pwd", info.Pwd),
					new SqlParameter("@AvailTime", info.AvailTime),
					new SqlParameter("@MaxCount", info.MaxCount),
					new SqlParameter("@MapIndex", info.MapIndex),
					new SqlParameter("@BeginTime", info.BeginTime),
					new SqlParameter("@BreakTime", info.BreakTime),
					new SqlParameter("@RoomIntroduction", info.RoomIntroduction),
					new SqlParameter("@RoomType", info.RoomType),
					new SqlParameter("@ServerID", info.ServerID),
					new SqlParameter("@RoomNumber", info.RoomNumber),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[13].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Insert_Spa_Room_Info", para);
				if ((int)para[13].Value > 0)
				{
					info.RoomID = (int)para[13].Value;
					return true;
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("InsertSpaRoomInfo", e);
				}
			}
			return false;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00016524 File Offset: 0x00014724
		public bool UpdateBreakTimeWhereSpaServerStop()
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[0].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Update_Spa_Room_Info_Sever_Stop", para);
				result = (int)para[0].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Spa_UpdateBreakTimeWhereServerStop", e);
				}
			}
			return result;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000165A8 File Offset: 0x000147A8
		public bool UpdateRenames()
		{
			bool result = false;
			try
			{
				result = this.db.RunProcedure("Sp_Renames_Batch");
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("UpdateRenames", e);
				}
			}
			return result;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000165FC File Offset: 0x000147FC
		public UsersRankInfo[] GetUserRankSingle(int UserID)
		{
			SqlDataReader reader = null;
			List<UsersRankInfo> result = new List<UsersRankInfo>();
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", UserID)
				};
				this.db.GetReader(ref reader, "SP_Users_Rank_Single", para);
				while (reader.Read())
				{
					result.Add(new UsersRankInfo
					{
						UserID = (int)reader["UserID"],
						Name = (string)reader["Name"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return result.ToArray();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000166D8 File Offset: 0x000148D8
		public bool AddUserRank(int UserID, string Name)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", UserID),
					new SqlParameter("@Name", Name)
				};
				result = this.db.RunProcedure("SP_Users_Rank_Add", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00016754 File Offset: 0x00014954
		public VIPInfo GetUserVIPSingle(int UserID)
		{
			SqlDataReader reader = null;
			VIPInfo result = new VIPInfo();
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", UserID)
				};
				this.db.GetReader(ref reader, "SP_Users_VIP_Single", para);
				if (reader.Read())
				{
					result = new VIPInfo
					{
						UserID = (int)reader["UserID"],
						TypeVIP = (int)reader["TypeVIP"],
						VIPLevel = (int)reader["VIPLevel"],
						VIPExp = (int)reader["VIPExp"],
						VIPExpireDay = (DateTime)reader["VIPExpireDay"]
					};
					if (result.TypeVIP >= 1 && result.VIPLevel < int.Parse(GameProperties.VIPMaxLevel))
					{
						result.VIPNextLevelDaysNeeded = (int.Parse(GameProperties.VIPExpNeededForEachLv.Split(new char[] { '|' })[result.VIPLevel]) - result.VIPExp) / ((result.TypeVIP == 1) ? 10 : 15);
					}
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return result;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000168D8 File Offset: 0x00014AD8
		public bool UpdateUserVIP(int UserID, int TypeVIP, int VIPLevel, int VIPExp, DateTime VIPExpireDay)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", UserID),
					new SqlParameter("@TypeVIP", TypeVIP),
					new SqlParameter("@VIPLevel", VIPLevel),
					new SqlParameter("@VIPExp", VIPExp),
					new SqlParameter("@VIPExpireDay", VIPExpireDay)
				};
				result = this.db.RunProcedure("SP_Users_VIP_Update", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00016994 File Offset: 0x00014B94
		public TexpInfo GetUserTexpSingle(int UserID)
		{
			SqlDataReader reader = null;
			TexpInfo result = new TexpInfo();
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", UserID)
				};
				this.db.GetReader(ref reader, "SP_Users_Texp_Single", para);
				if (reader.Read())
				{
					result = new TexpInfo
					{
						UserID = (int)reader["UserID"],
						SpdTexpExp = (int)reader["SpdTexpExp"],
						AttTexpExp = (int)reader["AttTexpExp"],
						DefTexpExp = (int)reader["DefTexpExp"],
						HpTexpExp = (int)reader["HpTexpExp"],
						LukTexpExp = (int)reader["LukTexpExp"],
						TexpTaskCount = (int)reader["TexpTaskCount"],
						TexpCount = (int)reader["TexpCount"]
					};
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return result;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00016B00 File Offset: 0x00014D00
		public bool UpdateUserTexp(TexpInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@SpdTexpExp", info.SpdTexpExp),
					new SqlParameter("@AttTexpExp", info.AttTexpExp),
					new SqlParameter("@DefTexpExp", info.DefTexpExp),
					new SqlParameter("@HpTexpExp", info.HpTexpExp),
					new SqlParameter("@LukTexpExp", info.LukTexpExp),
					new SqlParameter("@TexpTaskCount", info.TexpTaskCount),
					new SqlParameter("@TexpCount", info.TexpCount)
				};
				result = this.db.RunProcedure("SP_Users_Texp_Update", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00016C1C File Offset: 0x00014E1C
		public DailyLog GetUserDailyLogSingle(int UserID)
		{
			SqlDataReader reader = null;
			DailyLog result = new DailyLog();
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", UserID)
				};
				this.db.GetReader(ref reader, "SP_Users_Daily_Log_Single", para);
				if (reader.Read())
				{
					result = new DailyLog
					{
						UserID = (int)reader["UserID"],
						UserAwardLog = (int)reader["UserAwardLog"],
						DayLog = (string)reader["DayLog"]
					};
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return result;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00016D00 File Offset: 0x00014F00
		public bool UpdateUserDailyLog(DailyLog info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@UserAwardLog", info.UserAwardLog),
					new SqlParameter("@DayLog", info.DayLog)
				};
				result = this.db.RunProcedure("SP_Users_Daily_Log_Update", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00016DA0 File Offset: 0x00014FA0
		public CardInfo[] GetUserCardsSingle(int UserID)
		{
			List<CardInfo> items = new List<CardInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", SqlDbType.Int, 4)
					{
						Value = UserID
					}
				};
				this.db.GetReader(ref reader, "SP_Users_Cards_Single", para);
				while (reader.Read())
				{
					items.Add(this.InitCard(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return items.ToArray();
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00016E58 File Offset: 0x00015058
		public CardInfo InitCard(SqlDataReader reader)
		{
			return new CardInfo
			{
				CardID = (int)reader["CardID"],
				UserID = (int)reader["UserID"],
				Count = (int)reader["Count"],
				Place = (int)reader["Place"],
				TemplateID = (int)reader["TemplateID"],
				Attack = (int)reader["Attack"],
				Defence = (int)reader["Defence"],
				Agility = (int)reader["Agility"],
				Luck = (int)reader["Luck"],
				Damage = (int)reader["Damage"],
				Guard = (int)reader["Guard"],
				Level = (int)reader["Level"],
				CardGP = (int)reader["CardGP"],
				IsFirstGet = (bool)reader["IsFirstGet"]
			};
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00016FA0 File Offset: 0x000151A0
		public bool AddCards(CardInfo card)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CardID", card.CardID)
					{
						Direction = ParameterDirection.Output
					},
					new SqlParameter("@UserID", card.UserID),
					new SqlParameter("@Count", card.Count),
					new SqlParameter("@Place", card.Place),
					new SqlParameter("@TemplateID", card.TemplateID),
					new SqlParameter("@Attack", card.Attack),
					new SqlParameter("@Defence", card.Defence),
					new SqlParameter("@Agility", card.Agility),
					new SqlParameter("@Luck", card.Luck),
					new SqlParameter("@Damage", card.Damage),
					new SqlParameter("@Guard", card.Guard),
					new SqlParameter("@Level", card.Level),
					new SqlParameter("@CardGP", card.CardGP),
					new SqlParameter("@IsFirstGet", card.IsFirstGet)
				};
				result = this.db.RunProcedure("SP_Users_Cards_Add", para);
				card.CardID = (int)para[0].Value;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00017178 File Offset: 0x00015378
		public bool UpdateCards(CardInfo card)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CardID", card.CardID),
					new SqlParameter("@UserID", card.UserID),
					new SqlParameter("@Count", card.Count),
					new SqlParameter("@Place", card.Place),
					new SqlParameter("@TemplateID", card.TemplateID),
					new SqlParameter("@Attack", card.Attack),
					new SqlParameter("@Defence", card.Defence),
					new SqlParameter("@Agility", card.Agility),
					new SqlParameter("@Luck", card.Luck),
					new SqlParameter("@Damage", card.Damage),
					new SqlParameter("@Guard", card.Guard),
					new SqlParameter("@Level", card.Level),
					new SqlParameter("@CardGP", card.CardGP),
					new SqlParameter("@IsFirstGet", card.IsFirstGet)
				};
				result = this.db.RunProcedure("SP_Users_Cards_Update", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00017334 File Offset: 0x00015534
		public PlayerInfo[] GeUserInfoAll()
		{
			SqlDataReader reader = null;
			List<PlayerInfo> result = new List<PlayerInfo>();
			try
			{
				this.db.FillSqlDataReader(ref reader, "select * from V_Sys_Users_Detail");
				while (reader.Read())
				{
					result.Add(this.InitPlayerInfo(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return result.ToArray();
		}

		// Token: 0x06000131 RID: 305 RVA: 0x000173C8 File Offset: 0x000155C8
		public PetInfo[] GetUserPetsByUserID(int userID)
		{
			List<PetInfo> infos = new List<PetInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", userID)
				};
				this.db.GetReader(ref reader, "SP_Users_Pets_All", para);
				while (reader.Read())
				{
					PetInfo petInfo = new PetInfo(PetMgr.FindPetTemplate((int)reader["TemplateID"]));
					petInfo.Agility = (int)reader["Agility"];
					petInfo.AgilityGrow = (int)reader["AgilityGrow"];
					petInfo.Attack = (int)reader["Attack"];
					petInfo.AttackGrow = (int)reader["AttackGrow"];
					petInfo.BreakAgility = (int)reader["BreakAgility"];
					object obj = reader["BaseProp"];
					petInfo.BaseProp = ((obj != null) ? obj.ToString() : null);
					petInfo.Blood = (int)reader["Blood"];
					petInfo.BloodGrow = (int)reader["BloodGrow"];
					petInfo.BreakAttack = (int)reader["BreakAttack"];
					petInfo.BreakBlood = (int)reader["BreakBlood"];
					petInfo.BreakDefence = (int)reader["BreakDefence"];
					petInfo.BreakGrade = (int)reader["BreakGrade"];
					petInfo.BreakLuck = (int)reader["BreakLuck"];
					petInfo.CurrentStarExp = (int)reader["CurrentStarExp"];
					petInfo.Damage = (int)reader["Damage"];
					petInfo.DamageGrow = (int)reader["DamageGrow"];
					petInfo.Defence = (int)reader["Defence"];
					petInfo.DefenceGrow = (int)reader["DefenceGrow"];
					object obj2 = reader["EQPets"];
					petInfo.EQPets = ((obj2 != null) ? obj2.ToString() : null);
					petInfo.GP = (int)reader["GP"];
					petInfo.Guard = (int)reader["Guard"];
					petInfo.GuardGrow = (int)reader["GuardGrow"];
					petInfo.Hunger = (int)reader["Hunger"];
					petInfo.ID = (int)reader["ID"];
					petInfo.IsEquip = (bool)reader["IsEquip"];
					petInfo.IsExist = (bool)reader["IsExist"];
					petInfo.Level = (int)reader["Level"];
					petInfo.Luck = (int)reader["Luck"];
					petInfo.LuckGrow = (int)reader["LuckGrow"];
					petInfo.MaxGP = (int)reader["MaxGP"];
					petInfo.MP = (int)reader["MP"];
					object obj3 = reader["Name"];
					petInfo.Name = ((obj3 != null) ? obj3.ToString() : null);
					petInfo.PetHappyStar = (int)reader["PetHappyStar"];
					petInfo.Place = (int)reader["Place"];
					object obj4 = reader["Skill"];
					petInfo.Skill = ((obj4 != null) ? obj4.ToString() : null);
					object obj5 = reader["SkillEquip"];
					petInfo.SkillEquip = ((obj5 != null) ? obj5.ToString() : null);
					petInfo.UserID = (int)reader["UserID"];
					PetInfo pet = petInfo;
					pet.IsDirty = false;
					infos.Add(pet);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return infos.ToArray();
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00017804 File Offset: 0x00015A04
		public bool UpdatePet(PetInfo pet)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PetID", pet.ID),
					new SqlParameter("@UserID", pet.UserID),
					new SqlParameter("@TemplateID", pet.TemplateID),
					new SqlParameter("@Name", pet.Name),
					new SqlParameter("@Attack", pet.Attack),
					new SqlParameter("@Defence", pet.Defence),
					new SqlParameter("@Luck", pet.Luck),
					new SqlParameter("@Agility", pet.Agility),
					new SqlParameter("@Blood", pet.Blood),
					new SqlParameter("@Damage", pet.Damage),
					new SqlParameter("@Guard", pet.Guard),
					new SqlParameter("@AttackGrow", pet.AttackGrow),
					new SqlParameter("@DefenceGrow", pet.DefenceGrow),
					new SqlParameter("@LuckGrow", pet.LuckGrow),
					new SqlParameter("@AgilityGrow", pet.AgilityGrow),
					new SqlParameter("@BloodGrow", pet.BloodGrow),
					new SqlParameter("@DamageGrow", pet.DamageGrow),
					new SqlParameter("@GuardGrow", pet.GuardGrow),
					new SqlParameter("@Level", pet.Level),
					new SqlParameter("@GP", pet.GP),
					new SqlParameter("@MaxGP", pet.MaxGP),
					new SqlParameter("@Hunger", pet.Hunger),
					new SqlParameter("@PetHappyStar", pet.PetHappyStar),
					new SqlParameter("@MP", pet.MP),
					new SqlParameter("@IsEquip", pet.IsEquip),
					new SqlParameter("@Place", pet.Place),
					new SqlParameter("@IsExist", pet.IsExist),
					new SqlParameter("@Skill", pet.Skill),
					new SqlParameter("@SkillEquip", pet.SkillEquip),
					new SqlParameter("@CurrentStarExp", pet.CurrentStarExp),
					new SqlParameter("@BreakGrade", pet.BreakGrade),
					new SqlParameter("@BreakAttack", pet.BreakAttack),
					new SqlParameter("@BreakDefence", pet.BreakDefence),
					new SqlParameter("@BreakAgility", pet.BreakAgility),
					new SqlParameter("@BreakLuck", pet.BreakLuck),
					new SqlParameter("@BreakBlood", pet.BreakBlood),
					new SqlParameter("@EQPets", pet.EQPets),
					new SqlParameter("@BaseProp", pet.BaseProp)
				};
				result = this.db.RunProcedure("SP_Users_Pets_Update", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00017C00 File Offset: 0x00015E00
		public bool AddPet(PetInfo pet)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PetID", pet.ID)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@UserID", pet.UserID),
					new SqlParameter("@TemplateID", pet.TemplateID),
					new SqlParameter("@Name", pet.Name),
					new SqlParameter("@Attack", pet.Attack),
					new SqlParameter("@Defence", pet.Defence),
					new SqlParameter("@Luck", pet.Luck),
					new SqlParameter("@Agility", pet.Agility),
					new SqlParameter("@Blood", pet.Blood),
					new SqlParameter("@Damage", pet.Damage),
					new SqlParameter("@Guard", pet.Guard),
					new SqlParameter("@AttackGrow", pet.AttackGrow),
					new SqlParameter("@DefenceGrow", pet.DefenceGrow),
					new SqlParameter("@LuckGrow", pet.LuckGrow),
					new SqlParameter("@AgilityGrow", pet.AgilityGrow),
					new SqlParameter("@BloodGrow", pet.BloodGrow),
					new SqlParameter("@DamageGrow", pet.DamageGrow),
					new SqlParameter("@GuardGrow", pet.GuardGrow),
					new SqlParameter("@Level", pet.Level),
					new SqlParameter("@GP", pet.GP),
					new SqlParameter("@MaxGP", pet.MaxGP),
					new SqlParameter("@Hunger", pet.Hunger),
					new SqlParameter("@PetHappyStar", pet.PetHappyStar),
					new SqlParameter("@MP", pet.MP),
					new SqlParameter("@IsEquip", pet.IsEquip),
					new SqlParameter("@Place", pet.Place),
					new SqlParameter("@IsExist", pet.IsExist),
					new SqlParameter("@Skill", pet.Skill),
					new SqlParameter("@SkillEquip", pet.SkillEquip),
					new SqlParameter("@CurrentStarExp", pet.CurrentStarExp),
					new SqlParameter("@BreakGrade", pet.BreakGrade),
					new SqlParameter("@BreakAttack", pet.BreakAttack),
					new SqlParameter("@BreakDefence", pet.BreakDefence),
					new SqlParameter("@BreakAgility", pet.BreakAgility),
					new SqlParameter("@BreakLuck", pet.BreakLuck),
					new SqlParameter("@BreakBlood", pet.BreakBlood),
					new SqlParameter("@EQPets", pet.EQPets),
					new SqlParameter("@BaseProp", pet.BaseProp)
				};
				result = this.db.RunProcedure("SP_Users_Pets_Add", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}
	}
}
