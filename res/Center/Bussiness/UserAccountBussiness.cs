using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using log4net;
using SqlDataProvider.BaseClass;

namespace Bussiness
{
	// Token: 0x02000018 RID: 24
	public class UserAccountBussiness : IDisposable
	{
		// Token: 0x06000193 RID: 403 RVA: 0x0001E323 File Offset: 0x0001C523
		public UserAccountBussiness()
		{
			this.db = new Sql_DbObject("AppConfig", "conString");
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0001E340 File Offset: 0x0001C540
		public bool Login(string username, string password)
		{
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@UserName", username),
				new SqlParameter("@PassWord", password),
				new SqlParameter("@Result", SqlDbType.Int)
			};
			para[2].Direction = ParameterDirection.ReturnValue;
			bool result = this.db.RunProcedure("SP_User_Login", para);
			if (result)
			{
				result = (int)para[2].Value != -1;
			}
			return result;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0001E3B4 File Offset: 0x0001C5B4
		public bool Register(string username, string password, string email, string ip)
		{
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@UserName", username),
				new SqlParameter("@PassWord", password),
				new SqlParameter("@Email", email),
				new SqlParameter("@ActiveIP", ip),
				new SqlParameter("@Result", SqlDbType.Int)
			};
			para[4].Direction = ParameterDirection.ReturnValue;
			bool result = this.db.RunProcedure("SP_User_Register", para);
			if (result)
			{
				result = (int)para[4].Value != -1;
			}
			return result;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0001E444 File Offset: 0x0001C644
		public void AddScore(string username, string ip)
		{
			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@UserName", username),
				new SqlParameter("@ActiveIP", ip)
			};
			this.db.RunProcedure("SP_User_AddScore", para);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0001E486 File Offset: 0x0001C686
		public void Dispose()
		{
			this.db.Dispose();
			GC.SuppressFinalize(this);
		}

		// Token: 0x040000A0 RID: 160
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x040000A1 RID: 161
		protected Sql_DbObject db;
	}
}
