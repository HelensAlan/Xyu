using System;
using System.Data;
using System.Data.SqlClient;

namespace Bussiness
{
	// Token: 0x02000009 RID: 9
	public class CookieInfoBussiness : BaseBussiness
	{
		// Token: 0x06000076 RID: 118 RVA: 0x0000A740 File Offset: 0x00008940
		public bool GetFromDbByUser(string bdSigUser, ref string bdSigPortrait, ref string bdSigSessionKey)
		{
			SqlDataReader reader = null;
			bool result;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BdSigUser", bdSigUser)
				};
				this.db.GetReader(ref reader, "SP_Cookie_Info_QueryByUser", para);
				while (reader.Read())
				{
					bdSigPortrait = ((reader["BdSigPortrait"] == null) ? "" : reader["BdSigPortrait"].ToString());
					bdSigSessionKey = ((reader["BdSigSessionKey"] == null) ? "" : reader["BdSigSessionKey"].ToString());
				}
				result = !string.IsNullOrEmpty(bdSigPortrait) && !string.IsNullOrEmpty(bdSigSessionKey);
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

		// Token: 0x06000077 RID: 119 RVA: 0x0000A838 File Offset: 0x00008A38
		public bool AddCookieInfo(string bdSigUser, string bdSigPortrait, string bdSigSessionKey)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BdSigUser", bdSigUser),
					new SqlParameter("@BdSigPortrait", bdSigPortrait),
					new SqlParameter("@BdSigSessionKey", bdSigSessionKey),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Cookie_Info_Insert", para);
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
