using System;
using System.Data;
using System.Data.SqlClient;

namespace Bussiness
{
	// Token: 0x02000011 RID: 17
	public class OrderBussiness : BaseBussiness
	{
		// Token: 0x060000B6 RID: 182 RVA: 0x0000C208 File Offset: 0x0000A408
		public bool AddOrder(string order, double amount, string username, string payWay, string serverId)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Order", order),
					new SqlParameter("@Amount", amount),
					new SqlParameter("@Username", username),
					new SqlParameter("@PayWay", payWay),
					new SqlParameter("@ServerId", serverId),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[5].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Charge_Order", para);
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

		// Token: 0x060000B7 RID: 183 RVA: 0x0000C2D8 File Offset: 0x0000A4D8
		public string GetOrderToName(string order, ref string serverId)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Order", order)
				};
				this.db.GetReader(ref reader, "SP_Charge_Order_Single", para);
				if (reader.Read())
				{
					serverId = ((reader["ServerId"] == null) ? "" : reader["ServerId"].ToString());
					return (reader["UserName"] == null) ? "" : reader["UserName"].ToString();
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
			return "";
		}
	}
}
