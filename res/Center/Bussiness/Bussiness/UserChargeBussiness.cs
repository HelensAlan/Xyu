using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SqlDataProvider.SqlDataProvider.Data;

namespace Bussiness.Bussiness
{
	// Token: 0x0200001B RID: 27
	public class UserChargeBussiness : BaseBussiness
	{
		// Token: 0x0600019D RID: 413 RVA: 0x0001E6BC File Offset: 0x0001C8BC
		public List<UserChargeMoneyInfo> GetAllUserChargeMoneyInfo()
		{
			SqlDataReader sqlDataReader = null;
			List<UserChargeMoneyInfo> list = new List<UserChargeMoneyInfo>();
			try
			{
				this.db.FillSqlDataReader(ref sqlDataReader, "SELECT * FROM User_Charge_Money");
				while (sqlDataReader.Read())
				{
					list.Add(new UserChargeMoneyInfo
					{
						ID = (int)sqlDataReader["ID"],
						UserName = ((sqlDataReader["UserName"] == null) ? "" : sqlDataReader["UserName"].ToString()),
						Money = (int)sqlDataReader["Money"],
						IsExist = (bool)sqlDataReader["IsExist"]
					});
				}
			}
			catch (Exception e)
			{
				BaseBussiness.log.Error(e);
			}
			finally
			{
				if (sqlDataReader != null && !sqlDataReader.IsClosed)
				{
					sqlDataReader.Close();
				}
			}
			return list;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0001E7AC File Offset: 0x0001C9AC
		public List<UserChargeMoneyInfo> GetAllUserChargeMoneyInfoNotCharge()
		{
			SqlDataReader sqlDataReader = null;
			List<UserChargeMoneyInfo> list = new List<UserChargeMoneyInfo>();
			try
			{
				this.db.FillSqlDataReader(ref sqlDataReader, "SELECT * FROM User_Charge_Money WHERE IsExist=0");
				while (sqlDataReader.Read())
				{
					list.Add(new UserChargeMoneyInfo
					{
						ID = (int)sqlDataReader["ID"],
						UserName = ((sqlDataReader["UserName"] == null) ? "" : sqlDataReader["UserName"].ToString()),
						Money = (int)sqlDataReader["Money"],
						IsExist = (bool)sqlDataReader["IsExist"]
					});
				}
			}
			catch (Exception e)
			{
				BaseBussiness.log.Error(e);
			}
			finally
			{
				if (sqlDataReader != null && !sqlDataReader.IsClosed)
				{
					sqlDataReader.Close();
				}
			}
			return list;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0001E89C File Offset: 0x0001CA9C
		public List<UserChargeMoneyInfo> GetUserChargeMoneyInfoByUserName(string userName)
		{
			SqlDataReader sqlDataReader = null;
			List<UserChargeMoneyInfo> list = new List<UserChargeMoneyInfo>();
			try
			{
				this.db.FillSqlDataReader(ref sqlDataReader, string.Format("SELECT * FROM User_Charge_Money WHERE UserName='{0}'", userName));
				while (sqlDataReader.Read())
				{
					list.Add(new UserChargeMoneyInfo
					{
						ID = (int)sqlDataReader["ID"],
						UserName = ((sqlDataReader["UserName"] == null) ? "" : sqlDataReader["UserName"].ToString()),
						Money = (int)sqlDataReader["Money"],
						IsExist = (bool)sqlDataReader["IsExist"]
					});
				}
			}
			catch (Exception e)
			{
				BaseBussiness.log.Error(e);
			}
			finally
			{
				if (sqlDataReader != null && !sqlDataReader.IsClosed)
				{
					sqlDataReader.Close();
				}
			}
			return list;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0001E990 File Offset: 0x0001CB90
		public bool UpdateUserChargeMoneyInfo(int id)
		{
			bool result = false;
			try
			{
				result = this.db.Exesqlcomm(string.Format("UPDATE User_Charge_Money SET IsExist=1 WHERE ID={0}", id));
			}
			catch (Exception e)
			{
				BaseBussiness.log.Error(e);
			}
			return result;
		}
	}
}
