using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SqlDataProvider.Data;

namespace Bussiness
{
	// Token: 0x02000015 RID: 21
	public class ServiceBussiness : BaseBussiness
	{
		// Token: 0x0600017D RID: 381 RVA: 0x0001D144 File Offset: 0x0001B344
		public ServerInfo GetServiceSingle(int ID)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", SqlDbType.Int, 4)
				};
				para[0].Value = ID;
				this.db.GetReader(ref reader, "SP_Service_Single", para);
				if (reader.Read())
				{
					return new ServerInfo
					{
						ID = (int)reader["ID"],
						IP = reader["IP"].ToString(),
						Name = reader["Name"].ToString(),
						Online = (int)reader["Online"],
						Port = (int)reader["Port"],
						Remark = reader["Remark"].ToString(),
						Room = (int)reader["Room"],
						State = (int)reader["State"],
						Total = (int)reader["Total"],
						RSA = reader["RSA"].ToString(),
						NewerServer = (bool)reader["NewerServer"]
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
			return null;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0001D2FC File Offset: 0x0001B4FC
		public ServerInfo[] GetServiceByIP(string IP)
		{
			List<ServerInfo> infos = new List<ServerInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@IP", SqlDbType.NVarChar, 50)
				};
				para[0].Value = IP;
				this.db.GetReader(ref reader, "SP_Service_ListByIP", para);
				while (reader.Read())
				{
					infos.Add(new ServerInfo
					{
						ID = (int)reader["ID"],
						IP = reader["IP"].ToString(),
						Name = reader["Name"].ToString(),
						Online = (int)reader["Online"],
						Port = (int)reader["Port"],
						Remark = reader["Remark"].ToString(),
						Room = (int)reader["Room"],
						State = (int)reader["State"],
						Total = (int)reader["Total"],
						RSA = reader["RSA"].ToString()
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

		// Token: 0x0600017F RID: 383 RVA: 0x0001D4AC File Offset: 0x0001B6AC
		public ServerInfo[] GetServerList()
		{
			List<ServerInfo> infos = new List<ServerInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Service_List");
				while (reader.Read())
				{
					infos.Add(new ServerInfo
					{
						ID = (int)reader["ID"],
						IP = reader["IP"].ToString(),
						Name = reader["Name"].ToString(),
						Online = (int)reader["Online"],
						Port = (int)reader["Port"],
						Remark = reader["Remark"].ToString(),
						Room = (int)reader["Room"],
						State = (int)reader["State"],
						Total = (int)reader["Total"],
						RSA = reader["RSA"].ToString(),
						MustLevel = (int)reader["MustLevel"],
						LowestLevel = (int)reader["LowestLevel"]
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

		// Token: 0x06000180 RID: 384 RVA: 0x0001D664 File Offset: 0x0001B864
		public Dictionary<int, string> GetAreaServerIP()
		{
			Dictionary<int, string> list = new Dictionary<int, string>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_GetAreaServerIP");
				while (reader.Read())
				{
					list.Add((int)reader["ID"], (reader["IP"] == null) ? "" : reader["IP"].ToString());
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAreaServerIP", e);
				}
			}
			return list;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0001D704 File Offset: 0x0001B904
		public RecordInfo GetRecordInfo(DateTime date, int SaveRecordSecond)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Date", date.ToString("yyyy-MM-dd HH:mm:ss")),
					new SqlParameter("@Second", SaveRecordSecond)
				};
				this.db.GetReader(ref reader, "SP_Server_Record", para);
				if (reader.Read())
				{
					return new RecordInfo
					{
						ActiveExpendBoy = (int)reader["ActiveExpendBoy"],
						ActiveExpendGirl = (int)reader["ActiveExpendGirl"],
						ActviePayBoy = (int)reader["ActviePayBoy"],
						ActviePayGirl = (int)reader["ActviePayGirl"],
						ExpendBoy = (int)reader["ExpendBoy"],
						ExpendGirl = (int)reader["ExpendGirl"],
						OnlineBoy = (int)reader["OnlineBoy"],
						OnlineGirl = (int)reader["OnlineGirl"],
						TotalBoy = (int)reader["TotalBoy"],
						TotalGirl = (int)reader["TotalGirl"],
						ActiveOnlineBoy = (int)reader["ActiveOnlineBoy"],
						ActiveOnlineGirl = (int)reader["ActiveOnlineGirl"]
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
			return null;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0001D8E0 File Offset: 0x0001BAE0
		public bool UpdateService(ServerInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", info.ID),
					new SqlParameter("@Online", info.Online),
					new SqlParameter("@State", info.State)
				};
				result = this.db.RunProcedure("SP_Service_Update", para);
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

		// Token: 0x06000183 RID: 387 RVA: 0x0001D984 File Offset: 0x0001BB84
		public bool UpdateRSA(int ID, string RSA)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", ID),
					new SqlParameter("@RSA", RSA)
				};
				result = this.db.RunProcedure("SP_Service_UpdateRSA", para);
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

		// Token: 0x06000184 RID: 388 RVA: 0x0001DA00 File Offset: 0x0001BC00
		public Dictionary<string, string> GetServerConfig()
		{
			Dictionary<string, string> infos = new Dictionary<string, string>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Server_Config");
				while (reader.Read())
				{
					if (!infos.ContainsKey(reader["Name"].ToString()))
					{
						infos.Add(reader["Name"].ToString(), reader["Value"].ToString());
					}
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetServerConfig", e);
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

		// Token: 0x06000185 RID: 389 RVA: 0x0001DAC0 File Offset: 0x0001BCC0
		public ServerProperty GetServerPropertyByKey(string key)
		{
			ServerProperty serverProperty = null;
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Key", key)
				};
				this.db.GetReader(ref reader, "SP_Server_Config_Single", para);
				while (reader.Read())
				{
					serverProperty = new ServerProperty
					{
						Key = reader["Name"].ToString(),
						Value = reader["Value"].ToString()
					};
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetServerConfig", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return serverProperty;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0001DB88 File Offset: 0x0001BD88
		public bool UpdateServerPropertyByKey(string key, string value)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Key", key),
					new SqlParameter("@Value", value)
				};
				result = this.db.RunProcedure("SP_Server_Config_Update", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Exception in GameProperties Update", e);
				}
			}
			return result;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0001DC00 File Offset: 0x0001BE00
		public ArrayList GetRate(int serverId)
		{
			SqlDataReader reader = null;
			try
			{
				ArrayList arrryList = new ArrayList();
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ServerID", serverId)
				};
				this.db.GetReader(ref reader, "SP_Rate", para);
				while (reader.Read())
				{
					arrryList.Add(new RateInfo
					{
						ServerID = (int)reader["ServerID"],
						Rate = (float)((decimal)reader["Rate"]),
						BeginDay = (DateTime)reader["BeginDay"],
						EndDay = (DateTime)reader["EndDay"],
						BeginTime = (DateTime)reader["BeginTime"],
						EndTime = (DateTime)reader["EndTime"],
						Type = (int)reader["Type"]
					});
				}
				arrryList.TrimToSize();
				return arrryList;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetRates", e);
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

		// Token: 0x06000188 RID: 392 RVA: 0x0001DD74 File Offset: 0x0001BF74
		public RateInfo GetRateWithType(int serverId, int type)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ServerID", serverId),
					new SqlParameter("@Type", type)
				};
				this.db.GetReader(ref reader, "SP_Rate_WithType", para);
				if (reader.Read())
				{
					return new RateInfo
					{
						ServerID = (int)reader["ServerID"],
						Type = type,
						Rate = (float)reader["Rate"],
						BeginDay = (DateTime)reader["BeginDay"],
						EndDay = (DateTime)reader["EndDay"],
						BeginTime = (DateTime)reader["BeginTime"],
						EndTime = (DateTime)reader["EndTime"]
					};
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetRate type: " + type.ToString(), e);
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

		// Token: 0x06000189 RID: 393 RVA: 0x0001DED8 File Offset: 0x0001C0D8
		public FightRateInfo[] GetFightRate(int serverId)
		{
			SqlDataReader reader = null;
			List<FightRateInfo> infos = new List<FightRateInfo>();
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ServerID", serverId)
				};
				this.db.GetReader(ref reader, "SP_Fight_Rate", para);
				if (reader.Read())
				{
					infos.Add(new FightRateInfo
					{
						ID = (int)reader["ID"],
						ServerID = (int)reader["ServerID"],
						Rate = (int)reader["Rate"],
						BeginDay = (DateTime)reader["BeginDay"],
						EndDay = (DateTime)reader["EndDay"],
						BeginTime = (DateTime)reader["BeginTime"],
						EndTime = (DateTime)reader["EndTime"],
						SelfCue = ((reader["SelfCue"] == null) ? "" : reader["SelfCue"].ToString()),
						EnemyCue = ((reader["EnemyCue"] == null) ? "" : reader["EnemyCue"].ToString()),
						BoyTemplateID = (int)reader["BoyTemplateID"],
						GirlTemplateID = (int)reader["GirlTemplateID"],
						Name = ((reader["Name"] == null) ? "" : reader["Name"].ToString())
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetFightRate", e);
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

		// Token: 0x0600018A RID: 394 RVA: 0x0001E0E4 File Offset: 0x0001C2E4
		public string GetGameEquip()
		{
			string equip = string.Empty;
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Server_Equip");
				if (reader.Read())
				{
					equip = ((reader["value"] == null) ? "" : reader["value"].ToString());
					return equip;
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
			return equip;
		}
	}
}
