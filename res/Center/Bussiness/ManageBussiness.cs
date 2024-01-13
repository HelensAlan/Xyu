using System;
using System.Data;
using System.Data.SqlClient;
using Bussiness.CenterService;
using SqlDataProvider.Data;

namespace Bussiness
{
	// Token: 0x0200000F RID: 15
	public class ManageBussiness : BaseBussiness
	{
		// Token: 0x060000A1 RID: 161 RVA: 0x0000B8B0 File Offset: 0x00009AB0
		public int KitoffUserByUserName(string name, string msg)
		{
			int result = 1;
			using (PlayerBussiness db = new PlayerBussiness())
			{
				PlayerInfo player = db.GetUserSingleByUserName(name);
				if (player == null)
				{
					return 2;
				}
				result = this.KitoffUser(player.ID, msg);
			}
			return result;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000B904 File Offset: 0x00009B04
		public int KitoffUserByNickName(string name, string msg)
		{
			int result = 1;
			using (PlayerBussiness db = new PlayerBussiness())
			{
				PlayerInfo player = db.GetUserSingleByNickName(name);
				if (player == null)
				{
					return 2;
				}
				result = this.KitoffUser(player.ID, msg);
			}
			return result;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000B958 File Offset: 0x00009B58
		public int KitoffUser(int id, string msg)
		{
			int result;
			try
			{
				using (CenterServiceClient temp = new CenterServiceClient())
				{
					if (temp.KitoffUser(id, msg))
					{
						result = 0;
					}
					else
					{
						result = 3;
					}
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("KitoffUser", e);
				}
				result = 1;
			}
			return result;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000B9C8 File Offset: 0x00009BC8
		public bool SystemNotice(string msg)
		{
			bool result = false;
			try
			{
				if (!string.IsNullOrEmpty(msg))
				{
					using (CenterServiceClient temp = new CenterServiceClient())
					{
						if (temp.SystemNotice(msg))
						{
							result = true;
						}
					}
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("SystemNotice", e);
				}
			}
			return result;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000BA3C File Offset: 0x00009C3C
		private bool ForbidPlayer(string userName, string nickName, int userID, DateTime forbidDate, bool isExist)
		{
			return this.ForbidPlayer(userName, nickName, userID, forbidDate, isExist, "");
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000BA50 File Offset: 0x00009C50
		private bool ForbidPlayer(string userName, string nickName, int userID, DateTime forbidDate, bool isExist, string ForbidReason)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", userName),
					new SqlParameter("@NickName", nickName),
					new SqlParameter("@UserID", userID)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@ForbidDate", forbidDate),
					new SqlParameter("@IsExist", isExist),
					new SqlParameter("@ForbidReason", ForbidReason)
				};
				this.db.RunProcedure("SP_Admin_ForbidUser", para);
				userID = (int)para[2].Value;
				if (userID > 0)
				{
					result = true;
					if (!isExist)
					{
						this.KitoffUser(userID, "You are kicking out by GM!!");
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

		// Token: 0x060000A7 RID: 167 RVA: 0x0000BB40 File Offset: 0x00009D40
		public bool ForbidPlayerByUserName(string userName, DateTime date, bool isExist)
		{
			return this.ForbidPlayer(userName, "", 0, date, isExist);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000BB51 File Offset: 0x00009D51
		public bool ForbidPlayerByNickName(string nickName, DateTime date, bool isExist)
		{
			return this.ForbidPlayer("", nickName, 0, date, isExist);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000BB62 File Offset: 0x00009D62
		public bool ForbidPlayerByUserID(int userID, DateTime date, bool isExist)
		{
			return this.ForbidPlayer("", "", userID, date, isExist);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000BB77 File Offset: 0x00009D77
		public bool ForbidPlayerByUserName(string userName, DateTime date, bool isExist, string ForbidReason)
		{
			return this.ForbidPlayer(userName, "", 0, date, isExist, ForbidReason);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000BB8A File Offset: 0x00009D8A
		public bool ForbidPlayerByNickName(string nickName, DateTime date, bool isExist, string ForbidReason)
		{
			return this.ForbidPlayer("", nickName, 0, date, isExist, ForbidReason);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000BB9D File Offset: 0x00009D9D
		public bool ForbidPlayerByUserID(int userID, DateTime date, bool isExist, string ForbidReason)
		{
			return this.ForbidPlayer("", "", userID, date, isExist, ForbidReason);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000BBB4 File Offset: 0x00009DB4
		public bool ReLoadServerList()
		{
			bool result = false;
			try
			{
				using (CenterServiceClient temp = new CenterServiceClient())
				{
					if (temp.ReLoadServerList())
					{
						result = true;
					}
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("ReLoadServerList", e);
				}
			}
			return result;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000BC20 File Offset: 0x00009E20
		public int GetConfigState(int type)
		{
			int result = 2;
			try
			{
				using (CenterServiceClient temp = new CenterServiceClient())
				{
					return temp.GetConfigState(type);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetConfigState", e);
				}
			}
			return result;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000BC88 File Offset: 0x00009E88
		public bool UpdateConfigState(int type, bool state)
		{
			bool result = false;
			try
			{
				using (CenterServiceClient temp = new CenterServiceClient())
				{
					return temp.UpdateConfigState(type, state);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("UpdateConfigState", e);
				}
			}
			return result;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000BCF0 File Offset: 0x00009EF0
		public bool Reload(string type)
		{
			bool result = false;
			try
			{
				using (CenterServiceClient temp = new CenterServiceClient())
				{
					return temp.Reload(type);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Reload", e);
				}
			}
			return result;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000BD58 File Offset: 0x00009F58
		public bool SendAreaBigBugle(int playerID, int areaID, string nickName, string msg, string areaName)
		{
			bool result = false;
			try
			{
				using (CenterServiceClient temp = new CenterServiceClient())
				{
					return temp.SendAreaBigBugle(playerID, areaID, nickName, msg, areaName);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("SendAreaBigBugle", e);
				}
			}
			return result;
		}
	}
}
