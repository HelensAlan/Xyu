using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SqlDataProvider.Data;

namespace Bussiness
{
	// Token: 0x02000004 RID: 4
	public class ActiveBussiness : BaseBussiness
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00003244 File Offset: 0x00001444
		public ActiveInfo[] GetAllActives()
		{
			List<ActiveInfo> infos = new List<ActiveInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Active_All");
				while (reader.Read())
				{
					infos.Add(this.InitActiveInfo(reader));
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

		// Token: 0x06000026 RID: 38 RVA: 0x000032D8 File Offset: 0x000014D8
		public ActiveInfo GetSingleActives(int activeID)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", SqlDbType.Int, 4)
				};
				para[0].Value = activeID;
				this.db.GetReader(ref reader, "SP_Active_Single", para);
				if (reader.Read())
				{
					return this.InitActiveInfo(reader);
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

		// Token: 0x06000027 RID: 39 RVA: 0x00003384 File Offset: 0x00001584
		public ActiveInfo InitActiveInfo(SqlDataReader reader)
		{
			ActiveInfo info = new ActiveInfo
			{
				ActiveID = (int)reader["ActiveID"],
				Description = ((reader["Description"] == null) ? "" : reader["Description"].ToString()),
				Content = ((reader["Content"] == null) ? "" : reader["Content"].ToString()),
				AwardContent = ((reader["AwardContent"] == null) ? "" : reader["AwardContent"].ToString()),
				HasKey = (int)reader["HasKey"]
			};
			if (!string.IsNullOrEmpty(reader["EndDate"].ToString()))
			{
				info.EndDate = (DateTime)reader["EndDate"];
			}
			info.IsOnly = (bool)reader["IsOnly"];
			info.StartDate = (DateTime)reader["StartDate"];
			info.Title = reader["Title"].ToString();
			info.Type = (int)reader["Type"];
			info.ActiveType = (int)reader["ActiveType"];
			info.ActionTimeContent = ((reader["ActionTimeContent"] == null) ? "" : reader["ActionTimeContent"].ToString());
			info.IsAdvance = (bool)reader["IsAdvance"];
			info.GoodsExchangeTypes = ((reader["GoodsExchangeTypes"] == null) ? "" : reader["GoodsExchangeTypes"].ToString());
			info.GoodsExchangeNum = ((reader["GoodsExchangeNum"] == null) ? "" : reader["GoodsExchangeNum"].ToString());
			info.limitType = ((reader["limitType"] == null) ? "" : reader["limitType"].ToString());
			info.limitValue = ((reader["limitValue"] == null) ? "" : reader["limitValue"].ToString());
			info.IsShow = (bool)reader["IsShow"];
			return info;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000035DC File Offset: 0x000017DC
		public int PullDown(int activeID, string awardID, int userID, ref string msg)
		{
			int result = 1;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ActiveID", activeID),
					new SqlParameter("@AwardID", awardID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				if (this.db.RunProcedure("SP_Active_PullDown", para))
				{
					result = (int)para[3].Value;
					switch (result)
					{
					case 0:
						msg = "ActiveBussiness.Msg0";
						break;
					case 1:
						msg = "ActiveBussiness.Msg1";
						break;
					case 2:
						msg = "ActiveBussiness.Msg2";
						break;
					case 3:
						msg = "ActiveBussiness.Msg3";
						break;
					case 4:
						msg = "ActiveBussiness.Msg4";
						break;
					case 5:
						msg = "ActiveBussiness.Msg5";
						break;
					case 6:
						msg = "ActiveBussiness.Msg6";
						break;
					case 7:
						msg = "ActiveBussiness.Msg7";
						break;
					case 8:
						msg = "ActiveBussiness.Msg8";
						break;
					default:
						msg = "ActiveBussiness.Msg9";
						break;
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
	}
}
