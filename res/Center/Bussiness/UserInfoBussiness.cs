using System;
using System.Data;
using System.Data.SqlClient;

namespace Bussiness
{
	// Token: 0x02000019 RID: 25
	public class UserInfoBussiness : BaseBussiness
	{
		// Token: 0x06000199 RID: 409 RVA: 0x0001E4B0 File Offset: 0x0001C6B0
		public bool GetFromDbByUid(string uid, ref string userName, ref string portrait)
		{
			SqlDataReader reader = null;
			bool result;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Uid", uid)
				};
				this.db.GetReader(ref reader, "SP_User_Info_QueryByUid", para);
				while (reader.Read())
				{
					userName = ((reader["UserName"] == null) ? "" : reader["UserName"].ToString());
					portrait = ((reader["Portrait"] == null) ? "" : reader["Portrait"].ToString());
				}
				result = !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(portrait);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
				result = false;
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

		// Token: 0x0600019A RID: 410 RVA: 0x0001E5A8 File Offset: 0x0001C7A8
		public bool AddUserInfo(string uid, string userName, string portrait)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Uid", uid),
					new SqlParameter("@UserName", userName),
					new SqlParameter("@Portrait", portrait),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_User_Info_Insert", para);
				result = (int)para[3].Value == 0;
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
