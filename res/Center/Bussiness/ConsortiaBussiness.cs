using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SqlDataProvider.Data;

namespace Bussiness
{
	// Token: 0x02000008 RID: 8
	public class ConsortiaBussiness : BaseBussiness
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00004284 File Offset: 0x00002484
		public bool AddConsortia(ConsortiaInfo info, ref string msg, ref ConsortiaDutyInfo dutyInfo)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", info.ConsortiaID)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@BuildDate", info.BuildDate),
					new SqlParameter("@CelebCount", info.CelebCount),
					new SqlParameter("@ChairmanID", info.ChairmanID),
					new SqlParameter("@ChairmanName", info.ChairmanName ?? ""),
					new SqlParameter("@ConsortiaName", info.ConsortiaName ?? ""),
					new SqlParameter("@CreatorID", info.CreatorID),
					new SqlParameter("@CreatorName", info.CreatorName ?? ""),
					new SqlParameter("@Description", info.Description),
					new SqlParameter("@Honor", info.Honor),
					new SqlParameter("@IP", info.IP),
					new SqlParameter("@IsExist", info.IsExist),
					new SqlParameter("@Level", info.Level),
					new SqlParameter("@MaxCount", info.MaxCount),
					new SqlParameter("@Placard", info.Placard),
					new SqlParameter("@Port", info.Port),
					new SqlParameter("@Repute", info.Repute),
					new SqlParameter("@Count", info.Count),
					new SqlParameter("@Riches", info.Riches),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@tempDutyLevel", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = dutyInfo.Level
					},
					new SqlParameter("@tempDutyName", SqlDbType.VarChar, 100)
					{
						Direction = ParameterDirection.InputOutput,
						Value = ""
					},
					new SqlParameter("@tempRight", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = dutyInfo.Right
					},
					new SqlParameter("@IsSystemCreate", info.IsSystemCreate),
					new SqlParameter("@IsActive", info.IsActive)
				};
				result = this.db.RunProcedure("SP_Consortia_Add", para);
				int num = (int)para[19].Value;
				result = num == 0;
				if (result)
				{
					info.ConsortiaID = (int)para[0].Value;
					dutyInfo.Level = (int)para[20].Value;
					dutyInfo.DutyName = para[21].Value.ToString();
					dutyInfo.Right = (int)para[22].Value;
				}
				if (num == 2)
				{
					msg = "ConsortiaBussiness.AddConsortia.Msg2";
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

		// Token: 0x0600003C RID: 60 RVA: 0x000045F0 File Offset: 0x000027F0
		public bool DeleteConsortia(int consortiaID, int userID, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[2].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Consortia_Delete", para);
				int returnValue = ((para[2].Value == null) ? 2 : ((int)para[2].Value));
				result = returnValue == 0;
				if (returnValue != 2)
				{
					if (returnValue == 3)
					{
						msg = "ConsortiaBussiness.DeleteConsortia.Msg3";
					}
				}
				else
				{
					msg = "ConsortiaBussiness.DeleteConsortia.Msg2";
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

		// Token: 0x0600003D RID: 61 RVA: 0x000046C4 File Offset: 0x000028C4
		public ConsortiaInfo[] GetConsortiaPage(int page, int size, ref int total, int order, string name, int consortiaID, int level, int openApply)
		{
			List<ConsortiaInfo> infos = new List<ConsortiaInfo>();
			try
			{
				string sWhere = " IsExist=1 ";
				if (!string.IsNullOrEmpty(name))
				{
					sWhere = sWhere + " and ConsortiaName like '%" + name + "%' ";
				}
				if (consortiaID == -2)
				{
					sWhere += " and IsSystemCreate=0 ";
				}
				else if (consortiaID != -1)
				{
					object obj = sWhere;
					sWhere = string.Concat(new object[] { obj, " and ConsortiaID =", consortiaID, " " });
				}
				if (level != -1)
				{
					object obj2 = sWhere;
					sWhere = string.Concat(new object[] { obj2, " and Level =", level, " " });
				}
				if (openApply != -1)
				{
					object obj3 = sWhere;
					sWhere = string.Concat(new object[] { obj3, " and OpenApply =", openApply, " " });
				}
				string sOrder = "ConsortiaName";
				switch (order)
				{
				case 1:
					sOrder = "ReputeSort";
					break;
				case 2:
					sOrder = "ChairmanName";
					break;
				case 3:
					sOrder = "Count desc";
					break;
				case 4:
					sOrder = "Level desc";
					break;
				case 5:
					sOrder = "Honor desc";
					break;
				case 10:
					sOrder = "LastDayRiches desc";
					break;
				case 11:
					sOrder = "AddDayRiches desc";
					break;
				case 12:
					sOrder = "AddWeekRiches desc";
					break;
				case 13:
					sOrder = "LastDayHonor desc";
					break;
				case 14:
					sOrder = "AddDayHonor desc";
					break;
				case 15:
					sOrder = "AddWeekHonor desc";
					break;
				case 16:
					sOrder = "level desc,LastDayRiches desc";
					break;
				case 17:
					sOrder = "FightPower desc";
					break;
				}
				sOrder += ",ConsortiaID ";
				foreach (object obj4 in base.GetPage("V_Consortia", sWhere, page, size, "*", sOrder, "ConsortiaID", ref total).Rows)
				{
					DataRow dr = (DataRow)obj4;
					infos.Add(new ConsortiaInfo
					{
						ConsortiaID = (int)dr["ConsortiaID"],
						BuildDate = (DateTime)dr["BuildDate"],
						CelebCount = (int)dr["CelebCount"],
						ChairmanID = (int)dr["ChairmanID"],
						ChairmanName = dr["ChairmanName"].ToString(),
						ConsortiaName = dr["ConsortiaName"].ToString(),
						CreatorID = (int)dr["CreatorID"],
						CreatorName = dr["CreatorName"].ToString(),
						Description = dr["Description"].ToString(),
						Honor = (int)dr["Honor"],
						IsExist = (bool)dr["IsExist"],
						Level = (int)dr["Level"],
						MaxCount = (int)dr["MaxCount"],
						Placard = dr["Placard"].ToString(),
						IP = dr["IP"].ToString(),
						Port = (int)dr["Port"],
						Repute = (int)dr["Repute"],
						Count = (int)dr["Count"],
						Riches = (int)dr["Riches"],
						DeductDate = (DateTime)dr["DeductDate"],
						AddDayHonor = (int)dr["AddDayHonor"],
						AddDayRiches = (int)dr["AddDayRiches"],
						AddWeekHonor = (int)dr["AddWeekHonor"],
						AddWeekRiches = (int)dr["AddWeekRiches"],
						LastDayRiches = (int)dr["LastDayRiches"],
						OpenApply = (bool)dr["OpenApply"],
						StoreLevel = (int)dr["StoreLevel"],
						SmithLevel = (int)dr["SmithLevel"],
						ShopLevel = (int)dr["ShopLevel"],
						BufferLevel = (int)dr["BufferLevel"],
						FightPower = (int)dr["FightPower"],
						IsSystemCreate = (bool)dr["IsSystemCreate"],
						IsActive = (bool)dr["IsActive"],
						BadgeID = (int)dr["BadgeID"],
						BadgeBuyTime = (DateTime)dr["BadgeBuyTime"],
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

		// Token: 0x0600003E RID: 62 RVA: 0x00004C6C File Offset: 0x00002E6C
		public bool UpdateConsortiaDescription(int consortiaID, int userID, string description, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Description", description),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				result = this.db.RunProcedure("SP_ConsortiaDescription_Update", para);
				int num = (int)para[3].Value;
				result = num == 0;
				if (num == 2)
				{
					msg = "ConsortiaBussiness.UpdateConsortiaDescription.Msg2";
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

		// Token: 0x0600003F RID: 63 RVA: 0x00004D30 File Offset: 0x00002F30
		public bool UpdateConsortiaPlacard(int consortiaID, int userID, string placard, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Placard", placard),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				result = this.db.RunProcedure("SP_ConsortiaPlacard_Update", para);
				int num = (int)para[3].Value;
				result = num == 0;
				if (num == 2)
				{
					msg = "ConsortiaBussiness.UpdateConsortiaPlacard.Msg2";
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

		// Token: 0x06000040 RID: 64 RVA: 0x00004DF4 File Offset: 0x00002FF4
		public bool UpdateConsortiaChairman(string nickName, int consortiaID, int userID, ref string msg, ref ConsortiaDutyInfo info, ref int tempUserID, ref string tempUserName)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@NickName", nickName),
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@tempUserID", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = tempUserID
					},
					new SqlParameter("@tempUserName", SqlDbType.NVarChar, 100)
					{
						Direction = ParameterDirection.InputOutput,
						Value = tempUserName
					},
					new SqlParameter("@tempDutyLevel", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Level
					},
					new SqlParameter("@tempDutyName", SqlDbType.NVarChar, 100)
					{
						Direction = ParameterDirection.InputOutput,
						Value = ""
					},
					new SqlParameter("@tempRight", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Right
					}
				};
				result = this.db.RunProcedure("SP_ConsortiaChangeChairman", para);
				int returnValue = (int)para[3].Value;
				result = returnValue == 0;
				if (result)
				{
					tempUserID = (int)para[4].Value;
					tempUserName = para[5].Value.ToString();
					info.Level = (int)para[6].Value;
					info.DutyName = para[7].Value.ToString();
					info.Right = (int)para[8].Value;
				}
				if (returnValue != 1)
				{
					if (returnValue == 2)
					{
						msg = "ConsortiaBussiness.UpdateConsortiaChairman.Msg2";
					}
				}
				else
				{
					msg = "ConsortiaBussiness.UpdateConsortiaChairman.Msg3";
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

		// Token: 0x06000041 RID: 65 RVA: 0x00004FEC File Offset: 0x000031EC
		public bool UpGradeConsortia(int consortiaID, int userID, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[2].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Consortia_UpGrade", para);
				int returnValue = (int)para[2].Value;
				result = returnValue == 0;
				switch (returnValue)
				{
				case 2:
					msg = "ConsortiaBussiness.UpGradeConsortia.Msg2";
					break;
				case 3:
					msg = "ConsortiaBussiness.UpGradeConsortia.Msg3";
					break;
				case 4:
					msg = "ConsortiaBussiness.UpGradeConsortia.Msg4";
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

		// Token: 0x06000042 RID: 66 RVA: 0x000050C8 File Offset: 0x000032C8
		public bool UpGradeShopConsortia(int consortiaID, int userID, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[2].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Consortia_Shop_UpGrade", para);
				int returnValue = (int)para[2].Value;
				result = returnValue == 0;
				switch (returnValue)
				{
				case 2:
					msg = "ConsortiaBussiness.UpGradeShopConsortia.Msg2";
					break;
				case 3:
					msg = "ConsortiaBussiness.UpGradeShopConsortia.Msg3";
					break;
				case 4:
					msg = "ConsortiaBussiness.UpGradeShopConsortia.Msg4";
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

		// Token: 0x06000043 RID: 67 RVA: 0x000051A4 File Offset: 0x000033A4
		public bool UpGradeStoreConsortia(int consortiaID, int userID, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[2].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Consortia_Store_UpGrade", para);
				int returnValue = (int)para[2].Value;
				result = returnValue == 0;
				switch (returnValue)
				{
				case 2:
					msg = "ConsortiaBussiness.UpGradeStoreConsortia.Msg2";
					break;
				case 3:
					msg = "ConsortiaBussiness.UpGradeStoreConsortia.Msg3";
					break;
				case 4:
					msg = "ConsortiaBussiness.UpGradeStoreConsortia.Msg4";
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

		// Token: 0x06000044 RID: 68 RVA: 0x00005280 File Offset: 0x00003480
		public bool UpGradeSmithConsortia(int consortiaID, int userID, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[2].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Consortia_Smith_UpGrade", para);
				int returnValue = (int)para[2].Value;
				result = returnValue == 0;
				switch (returnValue)
				{
				case 2:
					msg = "ConsortiaBussiness.UpGradeSmithConsortia.Msg2";
					break;
				case 3:
					msg = "ConsortiaBussiness.UpGradeSmithConsortia.Msg3";
					break;
				case 4:
					msg = "ConsortiaBussiness.UpGradeSmithConsortia.Msg4";
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

		// Token: 0x06000045 RID: 69 RVA: 0x0000535C File Offset: 0x0000355C
		public bool UpGradeBufferConsortia(int consortiaID, int userID, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[2].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Consortia_Buffer_UpGrade", para);
				int returnValue = (int)para[2].Value;
				result = returnValue == 0;
				switch (returnValue)
				{
				case 2:
					msg = "你没有此权限.";
					break;
				case 3:
					msg = "公会等级不够,不能再升级.";
					break;
				case 4:
					msg = "公会财富不足.";
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

		// Token: 0x06000046 RID: 70 RVA: 0x00005438 File Offset: 0x00003638
		public ConsortiaInfo[] GetAllSystemConsortia()
		{
			SqlDataReader reader = null;
			List<ConsortiaInfo> infos = new List<ConsortiaInfo>();
			try
			{
				this.db.GetReader(ref reader, "SP_Consortia_System_All");
				while (reader.Read())
				{
					infos.Add(new ConsortiaInfo
					{
						ConsortiaID = (int)reader["ConsortiaID"],
						BuildDate = (DateTime)reader["BuildDate"],
						CelebCount = (int)reader["CelebCount"],
						ChairmanID = (int)reader["ChairmanID"],
						ChairmanName = reader["ChairmanName"].ToString(),
						ConsortiaName = reader["ConsortiaName"].ToString(),
						CreatorID = (int)reader["CreatorID"],
						CreatorName = reader["CreatorName"].ToString(),
						Description = reader["Description"].ToString(),
						Honor = (int)reader["Honor"],
						IsExist = (bool)reader["IsExist"],
						Level = (int)reader["Level"],
						MaxCount = (int)reader["MaxCount"],
						Placard = reader["Placard"].ToString(),
						IP = reader["IP"].ToString(),
						Port = (int)reader["Port"],
						Repute = (int)reader["Repute"],
						Count = (int)reader["Count"],
						Riches = (int)reader["Riches"],
						DeductDate = (DateTime)reader["DeductDate"],
						AddDayHonor = (int)reader["AddDayHonor"],
						AddDayRiches = (int)reader["AddDayRiches"],
						AddWeekHonor = (int)reader["AddWeekHonor"],
						AddWeekRiches = (int)reader["AddWeekRiches"],
						LastDayRiches = (int)reader["LastDayRiches"],
						OpenApply = (bool)reader["OpenApply"],
						StoreLevel = (int)reader["StoreLevel"],
						SmithLevel = (int)reader["SmithLevel"],
						ShopLevel = (int)reader["ShopLevel"],
						BufferLevel = (int)reader["BufferLevel"],
						FightPower = (int)reader["FightPower"],
						IsSystemCreate = (bool)reader["IsSystemCreate"],
						IsActive = (bool)reader["IsActive"],
						BadgeID = (int)reader["BadgeID"],
						BadgeBuyTime = (DateTime)reader["BadgeBuyTime"],
						ValidDate = (int)reader["ValidDate"]
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

		// Token: 0x06000047 RID: 71 RVA: 0x00005800 File Offset: 0x00003A00
		public ConsortiaInfo[] GetConsortiaAll()
		{
			List<ConsortiaInfo> infos = new List<ConsortiaInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Consortia_All");
				while (reader.Read())
				{
					infos.Add(new ConsortiaInfo
					{
						ConsortiaID = (int)reader["ConsortiaID"],
						ChairmanName = ((reader["ChairmanName"] == null) ? "" : reader["ChairmanName"].ToString()),
						Honor = (int)reader["Honor"],
						Level = (int)reader["Level"],
						Riches = (int)reader["Riches"],
						MaxCount = (int)reader["MaxCount"],
						BuildDate = (DateTime)reader["BuildDate"],
						IsExist = (bool)reader["IsExist"],
						DeductDate = (DateTime)reader["DeductDate"],
						StoreLevel = (int)reader["StoreLevel"],
						SmithLevel = (int)reader["SmithLevel"],
						ShopLevel = (int)reader["ShopLevel"],
						BufferLevel = (int)reader["BufferLevel"],
						ConsortiaName = ((reader["ConsortiaName"] == null) ? "" : reader["ConsortiaName"].ToString()),
						IsDirty = false,
						IsSystemCreate = (bool)reader["IsSystemCreate"],
						IsActive = (bool)reader["IsActive"],
						BadgeID = (int)reader["BadgeID"],
						BadgeBuyTime = (DateTime)reader["BadgeBuyTime"],
						ValidDate = (int)reader["ValidDate"]
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

		// Token: 0x06000048 RID: 72 RVA: 0x00005A84 File Offset: 0x00003C84
		public ConsortiaInfo GetConsortiaSingle(int id)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", id)
				};
				this.db.GetReader(ref reader, "SP_Consortia_Single", para);
				if (reader.Read())
				{
					return new ConsortiaInfo
					{
						ConsortiaID = (int)reader["ConsortiaID"],
						BuildDate = (DateTime)reader["BuildDate"],
						CelebCount = (int)reader["CelebCount"],
						ChairmanID = (int)reader["ChairmanID"],
						ChairmanName = reader["ChairmanName"].ToString(),
						ConsortiaName = reader["ConsortiaName"].ToString(),
						CreatorID = (int)reader["CreatorID"],
						CreatorName = reader["CreatorName"].ToString(),
						Description = reader["Description"].ToString(),
						Honor = (int)reader["Honor"],
						IsExist = (bool)reader["IsExist"],
						Level = (int)reader["Level"],
						MaxCount = (int)reader["MaxCount"],
						Placard = reader["Placard"].ToString(),
						IP = reader["IP"].ToString(),
						Port = (int)reader["Port"],
						Repute = (int)reader["Repute"],
						Count = (int)reader["Count"],
						Riches = (int)reader["Riches"],
						DeductDate = (DateTime)reader["DeductDate"],
						StoreLevel = (int)reader["StoreLevel"],
						SmithLevel = (int)reader["SmithLevel"],
						ShopLevel = (int)reader["ShopLevel"],
						BufferLevel = (int)reader["BufferLevel"],
						IsSystemCreate = (bool)reader["IsSystemCreate"],
						IsActive = (bool)reader["IsActive"],
						BadgeID = (int)reader["BadgeID"],
						BadgeBuyTime = (DateTime)reader["BadgeBuyTime"],
						ValidDate = (int)reader["ValidDate"]
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

		// Token: 0x06000049 RID: 73 RVA: 0x00005DBC File Offset: 0x00003FBC
		public ConsortiaInfo GetConsortiaSingleByName(string consortiumName)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaName", consortiumName)
				};
				this.db.GetReader(ref reader, "SP_Consortia_Single_By_Name", para);
				if (reader.Read())
				{
					return new ConsortiaInfo
					{
						ConsortiaID = (int)reader["ConsortiaID"],
						BuildDate = (DateTime)reader["BuildDate"],
						CelebCount = (int)reader["CelebCount"],
						ChairmanID = (int)reader["ChairmanID"],
						ChairmanName = reader["ChairmanName"].ToString(),
						ConsortiaName = reader["ConsortiaName"].ToString(),
						CreatorID = (int)reader["CreatorID"],
						CreatorName = reader["CreatorName"].ToString(),
						Description = reader["Description"].ToString(),
						Honor = (int)reader["Honor"],
						IsExist = (bool)reader["IsExist"],
						Level = (int)reader["Level"],
						MaxCount = (int)reader["MaxCount"],
						Placard = reader["Placard"].ToString(),
						IP = reader["IP"].ToString(),
						Port = (int)reader["Port"],
						Repute = (int)reader["Repute"],
						Count = (int)reader["Count"],
						Riches = (int)reader["Riches"],
						DeductDate = (DateTime)reader["DeductDate"],
						StoreLevel = (int)reader["StoreLevel"],
						SmithLevel = (int)reader["SmithLevel"],
						ShopLevel = (int)reader["ShopLevel"],
						BufferLevel = (int)reader["BufferLevel"],
						IsSystemCreate = (bool)reader["IsSystemCreate"],
						IsActive = (bool)reader["IsActive"],
						BadgeID = (int)reader["BadgeID"],
						BadgeBuyTime = (DateTime)reader["BadgeBuyTime"],
						ValidDate = (int)reader["ValidDate"]
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

		// Token: 0x0600004A RID: 74 RVA: 0x000060F0 File Offset: 0x000042F0
		public bool ConsortiaFight(int consortiWin, int consortiaLose, int playerCount, out int riches, int state, int totalKillHealth, float richesRate)
		{
			bool result = false;
			riches = 0;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaWin", consortiWin),
					new SqlParameter("@ConsortiaLose", consortiaLose),
					new SqlParameter("@PlayerCount", playerCount),
					new SqlParameter("@Riches", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = riches
					},
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@State", state),
					new SqlParameter("@TotalKillHealth", totalKillHealth),
					new SqlParameter("@RichesRate", richesRate)
				};
				result = this.db.RunProcedure("SP_Consortia_Fight", para);
				riches = (int)para[3].Value;
				result = (int)para[4].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("ConsortiaFight", e);
				}
			}
			return result;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000621C File Offset: 0x0000441C
		public bool ConsortiaRichAdd(int consortiID, ref int riches)
		{
			return this.ConsortiaRichAdd(consortiID, ref riches, 0, "");
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000622C File Offset: 0x0000442C
		public bool ConsortiaRichAdd(int consortiID, ref int riches, int type, string username)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiID),
					new SqlParameter("@Riches", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = riches
					},
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@Type", type),
					new SqlParameter("@UserName", username)
				};
				result = this.db.RunProcedure("SP_Consortia_Riches_Add", para);
				riches = (int)para[1].Value;
				result = (int)para[2].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("ConsortiaRichAdd", e);
				}
			}
			return result;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00006314 File Offset: 0x00004514
		public bool ConsortiaRichRemove(int consortiID, int riches)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiID),
					new SqlParameter("@Riches", riches),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				result = this.db.RunProcedure("SP_Consortia_Riches_Remove", para);
				result = (int)para[2].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("ConsortiaRichRemove", e);
				}
			}
			return result;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000063BC File Offset: 0x000045BC
		public bool ScanConsortia(ref string noticeID)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@NoticeID", SqlDbType.VarChar, -1)
					{
						Direction = ParameterDirection.Output
					},
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				result = this.db.RunProcedure("SP_Consortia_Scan", para);
				result = (int)para[1].Value == 0;
				if (result)
				{
					noticeID = para[0].Value.ToString();
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

		// Token: 0x0600004F RID: 79 RVA: 0x00006468 File Offset: 0x00004668
		public bool UpdateConsotiaApplyState(int consortiaID, int userID, bool state, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@State", state),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Consortia_Apply_State", para);
				int num = (int)para[3].Value;
				result = num == 0;
				if (num == 2)
				{
					msg = "ConsortiaBussiness.UpdateConsotiaApplyState.Msg2";
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

		// Token: 0x06000050 RID: 80 RVA: 0x00006530 File Offset: 0x00004730
		public bool AddConsortiaApplyUsers(ConsortiaApplyUserInfo info, ref string msg)
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
					new SqlParameter("@ApplyDate", info.ApplyDate),
					new SqlParameter("@ConsortiaID", info.ConsortiaID),
					new SqlParameter("@ConsortiaName", info.ConsortiaName ?? ""),
					new SqlParameter("@IsExist", info.IsExist),
					new SqlParameter("@Remark", info.Remark ?? ""),
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@UserName", info.UserName ?? ""),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				result = this.db.RunProcedure("SP_ConsortiaApplyUser_Add", para);
				info.ID = (int)para[0].Value;
				int num2 = ((para[8].Value == null) ? 7 : ((int)para[8].Value));
				result = num2 == 0;
				int num = num2;
				if (num != 2)
				{
					if (num != 6)
					{
						if (num == 7)
						{
							msg = "ConsortiaBussiness.AddConsortiaApplyUsers.Msg7";
						}
					}
					else
					{
						msg = "ConsortiaBussiness.AddConsortiaApplyUsers.Msg6";
					}
				}
				else
				{
					msg = "ConsortiaBussiness.AddConsortiaApplyUsers.Msg2";
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

		// Token: 0x06000051 RID: 81 RVA: 0x000066DC File Offset: 0x000048DC
		public bool DeleteConsortiaApplyUsers(int applyID, int userID, int consortiaID, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", applyID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_ConsortiaApplyUser_Delete", para);
				int returnValue = (int)para[3].Value;
				result = returnValue == 0 || returnValue == 3;
				if (returnValue == 2)
				{
					msg = "ConsortiaBussiness.DeleteConsortiaApplyUsers.Msg2";
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

		// Token: 0x06000052 RID: 82 RVA: 0x000067AC File Offset: 0x000049AC
		public bool PassConsortiaApplyUsers(int applyID, int userID, string userName, int consortiaID, ref string msg, ConsortiaUserInfo info, ref int consortiaRepute)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", applyID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@UserName", userName),
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@tempID", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.UserID
					},
					new SqlParameter("@tempName", SqlDbType.NVarChar, 100)
					{
						Direction = ParameterDirection.InputOutput,
						Value = ""
					},
					new SqlParameter("@tempDutyID", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.DutyID
					},
					new SqlParameter("@tempDutyName", SqlDbType.NVarChar, 100)
					{
						Direction = ParameterDirection.InputOutput,
						Value = ""
					},
					new SqlParameter("@tempOffer", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Offer
					},
					new SqlParameter("@tempRichesOffer", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.RichesOffer
					},
					new SqlParameter("@tempRichesRob", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.RichesRob
					},
					new SqlParameter("@tempLastDate", SqlDbType.DateTime)
					{
						Direction = ParameterDirection.InputOutput,
						Value = DateTime.Now
					},
					new SqlParameter("@tempWin", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Win
					},
					new SqlParameter("@tempTotal", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Total
					},
					new SqlParameter("@tempEscape", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Escape
					},
					new SqlParameter("@tempGrade", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Grade
					},
					new SqlParameter("@tempLevel", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Level
					},
					new SqlParameter("@tempCUID", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.ID
					},
					new SqlParameter("@tempState", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.State
					},
					new SqlParameter("@tempSex", SqlDbType.Bit)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Sex
					},
					new SqlParameter("@tempDutyRight", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Right
					},
					new SqlParameter("@tempConsortiaRepute", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = consortiaRepute
					},
					new SqlParameter("@tempLoginName", SqlDbType.NVarChar, 200)
					{
						Direction = ParameterDirection.InputOutput,
						Value = consortiaRepute
					},
					new SqlParameter("@tempFightPower", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.FightPower
					}
				};
				this.db.RunProcedure("SP_ConsortiaApplyUser_Pass", para);
				int returnValue = (int)para[4].Value;
				result = returnValue == 0;
				if (result)
				{
					info.UserID = (int)para[5].Value;
					info.UserName = para[6].Value.ToString();
					info.DutyID = (int)para[7].Value;
					info.DutyName = para[8].Value.ToString();
					info.Offer = (int)para[9].Value;
					info.RichesOffer = (int)para[10].Value;
					info.RichesRob = (int)para[11].Value;
					info.LastDate = (DateTime)para[12].Value;
					info.Win = (int)para[13].Value;
					info.Total = (int)para[14].Value;
					info.Escape = (int)para[15].Value;
					info.Grade = (int)para[16].Value;
					info.Level = (int)para[17].Value;
					info.ID = (int)para[18].Value;
					info.State = (int)para[19].Value;
					info.Sex = (bool)para[20].Value;
					info.Right = (int)para[21].Value;
					consortiaRepute = (int)para[22].Value;
					info.LoginName = para[23].Value.ToString();
					info.FightPower = (int)para[24].Value;
				}
				switch (returnValue)
				{
				case 2:
					msg = "ConsortiaBussiness.PassConsortiaApplyUsers.Msg2";
					break;
				case 3:
					msg = "ConsortiaBussiness.PassConsortiaApplyUsers.Msg3";
					break;
				case 6:
					msg = "ConsortiaBussiness.PassConsortiaApplyUsers.Msg6";
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

		// Token: 0x06000053 RID: 83 RVA: 0x00006D70 File Offset: 0x00004F70
		public ConsortiaApplyUserInfo[] GetConsortiaApplyUserPage(int page, int size, ref int total, int order, int consortiaID, int applyID, int userID)
		{
			List<ConsortiaApplyUserInfo> infos = new List<ConsortiaApplyUserInfo>();
			try
			{
				string sWhere = " IsExist=1 ";
				if (consortiaID != -1)
				{
					object obj = sWhere;
					sWhere = string.Concat(new object[] { obj, " and ConsortiaID =", consortiaID, " " });
				}
				if (applyID != -1)
				{
					object obj2 = sWhere;
					sWhere = string.Concat(new object[] { obj2, " and ID =", applyID, " " });
				}
				if (userID != -1)
				{
					object obj3 = sWhere;
					sWhere = string.Concat(new object[] { obj3, " and UserID ='", userID, "' " });
				}
				string sOrder = "ID";
				if (order != 1)
				{
					if (order == 2)
					{
						sOrder = "ApplyDate,ID";
					}
				}
				else
				{
					sOrder = "UserName,ID";
				}
				foreach (object obj4 in base.GetPage("V_Consortia_Apply_Users", sWhere, page, size, "*", sOrder, "ID", ref total).Rows)
				{
					DataRow dr = (DataRow)obj4;
					ConsortiaApplyUserInfo info = new ConsortiaApplyUserInfo
					{
						ID = (int)dr["ID"],
						ApplyDate = (DateTime)dr["ApplyDate"],
						ConsortiaID = (int)dr["ConsortiaID"],
						ConsortiaName = dr["ConsortiaName"].ToString()
					};
					info.ID = (int)dr["ID"];
					info.IsExist = (bool)dr["IsExist"];
					info.Remark = dr["Remark"].ToString();
					info.UserID = (int)dr["UserID"];
					info.UserName = dr["UserName"].ToString();
					info.UserLevel = (int)dr["Grade"];
					info.Win = (int)dr["Win"];
					info.Total = (int)dr["Total"];
					info.Repute = (int)dr["Repute"];
					info.FightPower = (int)dr["FightPower"];
					infos.Add(info);
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

		// Token: 0x06000054 RID: 84 RVA: 0x00007054 File Offset: 0x00005254
		public bool AddConsortiaInviteUsers(ConsortiaInviteUserInfo info, ref string msg)
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
					new SqlParameter("@ConsortiaID", info.ConsortiaID),
					new SqlParameter("@ConsortiaName", info.ConsortiaName ?? ""),
					new SqlParameter("@InviteDate", info.InviteDate),
					new SqlParameter("@InviteID", info.InviteID),
					new SqlParameter("@InviteName", info.InviteName ?? ""),
					new SqlParameter("@IsExist", info.IsExist),
					new SqlParameter("@Remark", info.Remark ?? ""),
					new SqlParameter("@UserID", info.UserID)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@UserName", info.UserName ?? ""),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				result = this.db.RunProcedure("SP_ConsortiaInviteUser_Add", para);
				info.ID = (int)para[0].Value;
				info.UserID = (int)para[8].Value;
				int returnValue = (int)para[10].Value;
				result = returnValue == 0;
				switch (returnValue)
				{
				case 2:
					msg = "ConsortiaBussiness.AddConsortiaInviteUsers.Msg2";
					break;
				case 4:
					msg = "ConsortiaBussiness.AddConsortiaInviteUsers.Msg4";
					break;
				case 5:
					msg = "ConsortiaBussiness.AddConsortiaInviteUsers.Msg5";
					break;
				case 6:
					msg = "ConsortiaBussiness.AddConsortiaInviteUsers.Msg6";
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

		// Token: 0x06000055 RID: 85 RVA: 0x0000725C File Offset: 0x0000545C
		public bool DeleteConsortiaInviteUsers(int intiveID, int userID)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", intiveID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[2].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_ConsortiaInviteUser_Delete", para);
				result = (int)para[2].Value == 0;
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

		// Token: 0x06000056 RID: 86 RVA: 0x00007304 File Offset: 0x00005504
		public bool PassConsortiaInviteUsers(int inviteID, int userID, string userName, ref int consortiaID, ref string consortiaName, ref string msg, ConsortiaUserInfo info, ref int tempID, ref string tempName, ref int consortiaRepute)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", inviteID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@UserName", userName),
					new SqlParameter("@ConsortiaID", consortiaID)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@ConsortiaName", SqlDbType.NVarChar, 100)
					{
						Value = consortiaName,
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@tempName", SqlDbType.NVarChar, 100)
					{
						Direction = ParameterDirection.InputOutput,
						Value = tempName
					},
					new SqlParameter("@tempDutyID", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.DutyID
					},
					new SqlParameter("@tempDutyName", SqlDbType.NVarChar, 100)
					{
						Direction = ParameterDirection.InputOutput,
						Value = ""
					},
					new SqlParameter("@tempOffer", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Offer
					},
					new SqlParameter("@tempRichesOffer", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.RichesOffer
					},
					new SqlParameter("@tempRichesRob", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.RichesRob
					},
					new SqlParameter("@tempLastDate", SqlDbType.DateTime)
					{
						Direction = ParameterDirection.InputOutput,
						Value = DateTime.Now
					},
					new SqlParameter("@tempWin", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Win
					},
					new SqlParameter("@tempTotal", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Total
					},
					new SqlParameter("@tempEscape", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Escape
					},
					new SqlParameter("@tempID", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = tempID
					},
					new SqlParameter("@tempGrade", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Level
					},
					new SqlParameter("@tempLevel", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Level
					},
					new SqlParameter("@tempCUID", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.ID
					},
					new SqlParameter("@tempState", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.State
					},
					new SqlParameter("@tempSex", SqlDbType.Bit)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Sex
					},
					new SqlParameter("@tempRight", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Right
					},
					new SqlParameter("@tempConsortiaRepute", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = consortiaRepute
					}
				};
				this.db.RunProcedure("SP_ConsortiaInviteUser_Pass", para);
				int num2 = (int)para[5].Value;
				result = num2 == 0;
				if (result)
				{
					consortiaID = (int)para[3].Value;
					consortiaName = para[4].Value.ToString();
					tempName = para[6].Value.ToString();
					info.DutyID = (int)para[7].Value;
					info.DutyName = para[8].Value.ToString();
					info.Offer = (int)para[9].Value;
					info.RichesOffer = (int)para[10].Value;
					info.RichesRob = (int)para[11].Value;
					info.LastDate = (DateTime)para[12].Value;
					info.Win = (int)para[13].Value;
					info.Total = (int)para[14].Value;
					info.Escape = (int)para[15].Value;
					tempID = (int)para[16].Value;
					info.Grade = (int)para[17].Value;
					info.Level = (int)para[18].Value;
					info.ID = (int)para[19].Value;
					info.State = (int)para[20].Value;
					info.Sex = (bool)para[21].Value;
					info.Right = (int)para[22].Value;
					consortiaRepute = (int)para[23].Value;
				}
				int num = num2;
				if (num != 3)
				{
					if (num == 6)
					{
						msg = "ConsortiaBussiness.PassConsortiaInviteUsers.Msg6";
					}
				}
				else
				{
					msg = "ConsortiaBussiness.PassConsortiaInviteUsers.Msg3";
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

		// Token: 0x06000057 RID: 87 RVA: 0x00007868 File Offset: 0x00005A68
		public ConsortiaInviteUserInfo[] GetConsortiaInviteUserPage(int page, int size, ref int total, int order, int userID, int inviteID)
		{
			List<ConsortiaInviteUserInfo> infos = new List<ConsortiaInviteUserInfo>();
			try
			{
				string sWhere = " IsExist=1 ";
				if (userID != -1)
				{
					object obj = sWhere;
					sWhere = string.Concat(new object[] { obj, " and UserID =", userID, " " });
				}
				if (inviteID != -1)
				{
					object obj2 = sWhere;
					sWhere = string.Concat(new object[] { obj2, " and UserID =", inviteID, " " });
				}
				string sOrder = "ConsortiaName";
				switch (order)
				{
				case 1:
					sOrder = "Repute";
					break;
				case 2:
					sOrder = "ChairmanName";
					break;
				case 3:
					sOrder = "Count";
					break;
				case 4:
					sOrder = "CelebCount";
					break;
				case 5:
					sOrder = "Honor";
					break;
				}
				sOrder += ",ID ";
				foreach (object obj3 in base.GetPage("V_Consortia_Invite", sWhere, page, size, "*", sOrder, "ID", ref total).Rows)
				{
					DataRow dr = (DataRow)obj3;
					infos.Add(new ConsortiaInviteUserInfo
					{
						ID = (int)dr["ID"],
						CelebCount = (int)dr["CelebCount"],
						ChairmanName = dr["ChairmanName"].ToString(),
						ConsortiaID = (int)dr["ConsortiaID"],
						ConsortiaName = dr["ConsortiaName"].ToString(),
						Count = (int)dr["Count"],
						Honor = (int)dr["Honor"],
						InviteDate = (DateTime)dr["InviteDate"],
						InviteID = (int)dr["InviteID"],
						InviteName = dr["InviteName"].ToString(),
						IsExist = (bool)dr["IsExist"],
						Remark = dr["Remark"].ToString(),
						Repute = (int)dr["Repute"],
						UserID = (int)dr["UserID"],
						UserName = dr["UserName"].ToString()
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

		// Token: 0x06000058 RID: 88 RVA: 0x00007B5C File Offset: 0x00005D5C
		public bool DeleteConsortiaUser(int userID, int kickUserID, int consortiaID, ref string msg, ref string nickName)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", userID),
					new SqlParameter("@KickUserID", kickUserID),
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@NickName", SqlDbType.NVarChar, 200)
					{
						Direction = ParameterDirection.InputOutput,
						Value = nickName
					}
				};
				this.db.RunProcedure("SP_ConsortiaUser_Delete", para);
				int returnValue = (int)para[3].Value;
				if (returnValue == 0)
				{
					result = true;
					nickName = para[4].Value.ToString();
				}
				switch (returnValue)
				{
				case 2:
					msg = "ConsortiaBussiness.DeleteConsortiaUser.Msg2";
					break;
				case 3:
					msg = "ConsortiaBussiness.DeleteConsortiaUser.Msg3";
					break;
				case 4:
					msg = "ConsortiaBussiness.DeleteConsortiaUser.Msg4";
					break;
				case 5:
					msg = "ConsortiaBussiness.DeleteConsortiaUser.Msg5";
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

		// Token: 0x06000059 RID: 89 RVA: 0x00007C8C File Offset: 0x00005E8C
		public bool UpdateConsortiaIsBanChat(int banUserID, int consortiaID, int userID, bool isBanChat, ref int tempID, ref string tempName, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", banUserID),
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@IsBanChat", isBanChat),
					new SqlParameter("@TempID", tempID)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@TempName", SqlDbType.NVarChar, 100)
					{
						Value = tempName,
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				result = this.db.RunProcedure("SP_ConsortiaIsBanChat_Update", para);
				int returnValue = (int)para[6].Value;
				tempID = (int)para[4].Value;
				tempName = para[5].Value.ToString();
				result = returnValue == 0;
				if (returnValue != 2)
				{
					if (returnValue == 3)
					{
						msg = "ConsortiaBussiness.UpdateConsortiaIsBanChat.Msg3";
					}
				}
				else
				{
					msg = "ConsortiaBussiness.UpdateConsortiaIsBanChat.Msg2";
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

		// Token: 0x0600005A RID: 90 RVA: 0x00007DE0 File Offset: 0x00005FE0
		public bool UpdateConsortiaUserRemark(int id, int consortiaID, int userID, string remark, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", id),
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Remark", remark),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[4].Direction = ParameterDirection.ReturnValue;
				result = this.db.RunProcedure("SP_ConsortiaUserRemark_Update", para);
				int num = (int)para[4].Value;
				result = num == 0;
				if (num == 2)
				{
					msg = "ConsortiaBussiness.UpdateConsortiaUserRemark.Msg2";
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

		// Token: 0x0600005B RID: 91 RVA: 0x00007EB8 File Offset: 0x000060B8
		public bool UpdateConsortiaUserGrade(int id, int consortiaID, int userID, bool upGrade, ref string msg, ref ConsortiaDutyInfo info, ref string tempUserName)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", id),
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@UpGrade", upGrade),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					},
					new SqlParameter("@tempUserName", SqlDbType.NVarChar, 100)
					{
						Direction = ParameterDirection.InputOutput,
						Value = tempUserName
					},
					new SqlParameter("@tempDutyLevel", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Level
					},
					new SqlParameter("@tempDutyName", SqlDbType.NVarChar, 100)
					{
						Direction = ParameterDirection.InputOutput,
						Value = ""
					},
					new SqlParameter("@tempRight", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Right
					}
				};
				result = this.db.RunProcedure("SP_ConsortiaUserGrade_Update", para);
				int returnValue = (int)para[4].Value;
				result = returnValue == 0;
				if (result)
				{
					tempUserName = para[5].Value.ToString();
					info.Level = (int)para[6].Value;
					info.DutyName = para[7].Value.ToString();
					info.Right = (int)para[8].Value;
				}
				switch (returnValue)
				{
				case 2:
					msg = "ConsortiaBussiness.UpdateConsortiaUserGrade.Msg2";
					break;
				case 3:
					msg = (upGrade ? "ConsortiaBussiness.UpdateConsortiaUserGrade.Msg3" : "ConsortiaBussiness.UpdateConsortiaUserGrade.Msg10");
					break;
				case 4:
					msg = "ConsortiaBussiness.UpdateConsortiaUserGrade.Msg4";
					break;
				case 5:
					msg = "ConsortiaBussiness.UpdateConsortiaUserGrade.Msg5";
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

		// Token: 0x0600005C RID: 92 RVA: 0x000080C8 File Offset: 0x000062C8
		public ConsortiaUserInfo[] GetConsortiaUsersPage(int page, int size, ref int total, int order, int consortiaID, int userID, int state)
		{
			List<ConsortiaUserInfo> infos = new List<ConsortiaUserInfo>();
			try
			{
				string sWhere = " IsExist=1 ";
				if (consortiaID != -1)
				{
					object obj = sWhere;
					sWhere = string.Concat(new object[] { obj, " and ConsortiaID =", consortiaID, " " });
				}
				if (userID != -1)
				{
					object obj2 = sWhere;
					sWhere = string.Concat(new object[] { obj2, " and UserID =", userID, " " });
				}
				if (state != -1)
				{
					object obj3 = sWhere;
					sWhere = string.Concat(new object[] { obj3, " and state =", state, " " });
				}
				string sOrder = "UserName";
				switch (order)
				{
				case 1:
					sOrder = "DutyID";
					break;
				case 2:
					sOrder = "Grade";
					break;
				case 3:
					sOrder = "Repute";
					break;
				case 4:
					sOrder = "GP";
					break;
				case 5:
					sOrder = "State";
					break;
				case 6:
					sOrder = "Offer";
					break;
				}
				sOrder += ",ID ";
				foreach (object obj4 in base.GetPage("V_Consortia_Users", sWhere, page, size, "*", sOrder, "ID", ref total).Rows)
				{
					DataRow dr = (DataRow)obj4;
					ConsortiaUserInfo info = new ConsortiaUserInfo
					{
						ID = (int)dr["ID"],
						ConsortiaID = (int)dr["ConsortiaID"],
						DutyID = (int)dr["DutyID"],
						DutyName = dr["DutyName"].ToString(),
						IsExist = (bool)dr["IsExist"],
						RatifierID = (int)dr["RatifierID"],
						RatifierName = dr["RatifierName"].ToString(),
						Remark = dr["Remark"].ToString(),
						UserID = (int)dr["UserID"],
						UserName = dr["UserName"].ToString(),
						Grade = (int)dr["Grade"],
						GP = (int)dr["GP"],
						Repute = (int)dr["Repute"],
						State = (int)dr["State"],
						Right = (int)dr["Right"],
						Offer = (int)dr["Offer"],
						Colors = dr["Colors"].ToString(),
						Style = dr["Style"].ToString(),
						Hide = (int)dr["Hide"]
					};
					info.Skin = ((dr["Skin"] == null) ? "" : info.Skin);
					info.Level = (int)dr["Level"];
					info.LastDate = (DateTime)dr["LastDate"];
					info.Sex = (bool)dr["Sex"];
					info.IsBanChat = (bool)dr["IsBanChat"];
					info.Win = (int)dr["Win"];
					info.Total = (int)dr["Total"];
					info.Escape = (int)dr["Escape"];
					info.RichesOffer = (int)dr["RichesOffer"];
					info.RichesRob = (int)dr["RichesRob"];
					info.LoginName = ((dr["LoginName"] == null) ? "" : dr["LoginName"].ToString());
					info.Nimbus = (int)dr["Nimbus"];
					info.Honor = ((dr["Honor"] == null) ? "" : dr["Honor"].ToString());
					info.AchievementPoint = (int)dr["AchievementPoint"];
					info.FightPower = (int)dr["FightPower"];
					info.TypeVIP = (int)dr["TypeVIP"];
					info.VIPLevel = (int)dr["VIPLevel"];
					info.LastWeekRichesOffer = (int)dr["LastWeekOffer"];
					infos.Add(info);
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

		// Token: 0x0600005D RID: 93 RVA: 0x00008640 File Offset: 0x00006840
		public ConsortiaUserInfo GetConsortiaUsersByUserID(int userID)
		{
			int total = 0;
			ConsortiaUserInfo[] infos = this.GetConsortiaUsersPage(1, 1, ref total, -1, -1, userID, -1);
			ConsortiaUserInfo result;
			if (infos.Length == 1)
			{
				result = infos[0];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00008670 File Offset: 0x00006870
		public bool UpdateRobotChairman()
		{
			bool result;
			try
			{
				result = this.db.RunProcedure("SP_Update_Robot_Chairman");
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000086C4 File Offset: 0x000068C4
		public bool ActiveConsortia()
		{
			bool result;
			try
			{
				result = this.db.RunProcedure("SP_Active_Consortia");
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Active", e);
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00008718 File Offset: 0x00006918
		public bool AddConsortiaDuty(ConsortiaDutyInfo info, int userID, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DutyID", info.DutyID)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@ConsortiaID", info.ConsortiaID),
					new SqlParameter("@DutyName", info.DutyName),
					new SqlParameter("@Level", info.Level),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Right", info.Right),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				result = this.db.RunProcedure("SP_ConsortiaDuty_Add", para);
				info.DutyID = (int)para[0].Value;
				int returnValue = (int)para[6].Value;
				result = returnValue == 0;
				if (returnValue != 2)
				{
					if (returnValue == 3)
					{
						msg = "ConsortiaBussiness.AddConsortiaDuty.Msg3";
					}
				}
				else
				{
					msg = "ConsortiaBussiness.AddConsortiaDuty.Msg2";
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

		// Token: 0x06000061 RID: 97 RVA: 0x00008854 File Offset: 0x00006A54
		public bool DeleteConsortiaDuty(int dutyID, int userID, int consortiaID, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", userID),
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@DutyID", dutyID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_ConsortiaDuty_Delete", para);
				int returnValue = (int)para[3].Value;
				result = returnValue == 0;
				if (returnValue != 2)
				{
					if (returnValue == 3)
					{
						msg = "ConsortiaBussiness.DeleteConsortiaDuty.Msg3";
					}
				}
				else
				{
					msg = "ConsortiaBussiness.DeleteConsortiaDuty.Msg2";
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

		// Token: 0x06000062 RID: 98 RVA: 0x00008930 File Offset: 0x00006B30
		public bool UpdateConsortiaDuty(ConsortiaDutyInfo info, int userID, int updateType, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DutyID", info.DutyID)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@ConsortiaID", info.ConsortiaID),
					new SqlParameter("@DutyName", SqlDbType.NVarChar, 100)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.DutyName
					},
					new SqlParameter("@Right", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Right
					},
					new SqlParameter("@Level", SqlDbType.Int)
					{
						Direction = ParameterDirection.InputOutput,
						Value = info.Level
					},
					new SqlParameter("@UserID", userID),
					new SqlParameter("@UpdateType", updateType),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				result = this.db.RunProcedure("SP_ConsortiaDuty_Update", para);
				int returnValue = (int)para[7].Value;
				result = returnValue == 0;
				if (result)
				{
					info.DutyID = (int)para[0].Value;
					info.DutyName = ((para[2].Value == null) ? "" : para[2].Value.ToString());
					info.Right = (int)para[3].Value;
					info.Level = (int)para[4].Value;
				}
				switch (returnValue)
				{
				case 2:
					msg = "ConsortiaBussiness.UpdateConsortiaDuty.Msg2";
					break;
				case 3:
				case 4:
					msg = "ConsortiaBussiness.UpdateConsortiaDuty.Msg3";
					break;
				case 5:
					msg = "ConsortiaBussiness.DeleteConsortiaDuty.Msg5";
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

		// Token: 0x06000063 RID: 99 RVA: 0x00008B24 File Offset: 0x00006D24
		public ConsortiaDutyInfo[] GetConsortiaDutyPage(int page, int size, ref int total, int order, int consortiaID, int dutyID)
		{
			List<ConsortiaDutyInfo> infos = new List<ConsortiaDutyInfo>();
			try
			{
				string sWhere = " IsExist=1 ";
				if (consortiaID != -1)
				{
					object obj = sWhere;
					sWhere = string.Concat(new object[] { obj, " and ConsortiaID =", consortiaID, " " });
				}
				if (dutyID != -1)
				{
					object obj2 = sWhere;
					sWhere = string.Concat(new object[] { obj2, " and DutyID =", dutyID, " " });
				}
				string sOrder = "Level";
				if (order == 1)
				{
					sOrder = "DutyName";
				}
				sOrder += ",DutyID ";
				foreach (object obj3 in base.GetPage("Consortia_Duty", sWhere, page, size, "*", sOrder, "DutyID", ref total).Rows)
				{
					DataRow dr = (DataRow)obj3;
					ConsortiaDutyInfo info = new ConsortiaDutyInfo
					{
						DutyID = (int)dr["DutyID"],
						ConsortiaID = (int)dr["ConsortiaID"]
					};
					info.DutyID = (int)dr["DutyID"];
					info.DutyName = dr["DutyName"].ToString();
					info.IsExist = (bool)dr["IsExist"];
					info.Right = (int)dr["Right"];
					info.Level = (int)dr["Level"];
					infos.Add(info);
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

		// Token: 0x06000064 RID: 100 RVA: 0x00008D2C File Offset: 0x00006F2C
		public int[] GetConsortiaByAllyByState(int consortiaID, int state)
		{
			List<int> infos = new List<int>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@State", state)
				};
				this.db.GetReader(ref reader, "SP_Consortia_AllyByState", para);
				while (reader.Read())
				{
					infos.Add((int)reader["Consortia2ID"]);
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

		// Token: 0x06000065 RID: 101 RVA: 0x00008DF8 File Offset: 0x00006FF8
		public bool AddConsortiaApplyAlly(ConsortiaApplyAllyInfo info, int userID, ref string msg)
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
					new SqlParameter("@Consortia1ID", info.Consortia1ID),
					new SqlParameter("@Consortia2ID", info.Consortia2ID),
					new SqlParameter("@Date", info.Date),
					new SqlParameter("@Remark", info.Remark),
					new SqlParameter("@IsExist", info.IsExist),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@State", info.State),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				result = this.db.RunProcedure("SP_ConsortiaApplyAlly_Add", para);
				info.ID = (int)para[0].Value;
				int returnValue = (int)para[8].Value;
				result = returnValue == 0;
				switch (returnValue)
				{
				case 2:
					msg = "ConsortiaBussiness.AddConsortiaApplyAlly.Msg2";
					break;
				case 3:
					msg = "ConsortiaBussiness.AddConsortiaApplyAlly.Msg3";
					break;
				case 4:
					msg = "ConsortiaBussiness.AddConsortiaApplyAlly.Msg4";
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

		// Token: 0x06000066 RID: 102 RVA: 0x00008F88 File Offset: 0x00007188
		public bool DeleteConsortiaApplyAlly(int applyID, int userID, int consortiaID, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", applyID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[3].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_ConsortiaApplyAlly_Delete", para);
				int num = (int)para[3].Value;
				result = num == 0;
				if (num == 2)
				{
					msg = "ConsortiaBussiness.DeleteConsortiaApplyAlly.Msg2";
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

		// Token: 0x06000067 RID: 103 RVA: 0x00009050 File Offset: 0x00007250
		public bool PassConsortiaApplyAlly(int applyID, int userID, int consortiaID, ref int tempID, ref int state, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", applyID),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@tempID", tempID)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@State", state)
					{
						Direction = ParameterDirection.InputOutput
					},
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				this.db.RunProcedure("SP_ConsortiaApplyAlly_Pass", para);
				int returnValue = (int)para[5].Value;
				if (returnValue == 0)
				{
					result = true;
					tempID = (int)para[3].Value;
					state = (int)para[4].Value;
				}
				if (returnValue != 2)
				{
					if (returnValue == 3)
					{
						msg = "ConsortiaBussiness.PassConsortiaApplyAlly.Msg3";
					}
				}
				else
				{
					msg = "ConsortiaBussiness.PassConsortiaApplyAlly.Msg2";
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

		// Token: 0x06000068 RID: 104 RVA: 0x00009180 File Offset: 0x00007380
		public ConsortiaApplyAllyInfo[] GetConsortiaApplyAllyPage(int page, int size, ref int total, int order, int consortiaID, int applyID, int state)
		{
			List<ConsortiaApplyAllyInfo> infos = new List<ConsortiaApplyAllyInfo>();
			try
			{
				string sWhere = " IsExist=1 ";
				if (consortiaID != -1)
				{
					object obj = sWhere;
					sWhere = string.Concat(new object[] { obj, " and Consortia2ID =", consortiaID, " " });
				}
				if (applyID != -1)
				{
					object obj2 = sWhere;
					sWhere = string.Concat(new object[] { obj2, " and ID =", applyID, " " });
				}
				if (state != -1)
				{
					object obj3 = sWhere;
					sWhere = string.Concat(new object[] { obj3, " and State =", state, " " });
				}
				string sOrder = "ConsortiaName";
				switch (order)
				{
				case 1:
					sOrder = "Repute";
					break;
				case 2:
					sOrder = "ChairmanName";
					break;
				case 3:
					sOrder = "Count";
					break;
				case 4:
					sOrder = "Level";
					break;
				case 5:
					sOrder = "Honor";
					break;
				}
				sOrder += ",ID ";
				foreach (object obj4 in base.GetPage("V_Consortia_Apply_Ally", sWhere, page, size, "*", sOrder, "ID", ref total).Rows)
				{
					DataRow dr = (DataRow)obj4;
					infos.Add(new ConsortiaApplyAllyInfo
					{
						ID = (int)dr["ID"],
						CelebCount = (int)dr["CelebCount"],
						ChairmanName = dr["ChairmanName"].ToString(),
						Consortia1ID = (int)dr["Consortia1ID"],
						Consortia2ID = (int)dr["Consortia2ID"],
						ConsortiaName = dr["ConsortiaName"].ToString(),
						Count = (int)dr["Count"],
						Date = (DateTime)dr["Date"],
						Honor = (int)dr["Honor"],
						IsExist = (bool)dr["IsExist"],
						Remark = dr["Remark"].ToString(),
						Repute = (int)dr["Repute"],
						State = (int)dr["State"],
						Level = (int)dr["Level"],
						Description = ((dr["Description"] == null) ? "" : dr["Description"].ToString())
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

		// Token: 0x06000069 RID: 105 RVA: 0x000094BC File Offset: 0x000076BC
		public Dictionary<int, int> GetConsortiaByAlly(int consortiaID)
		{
			Dictionary<int, int> consortiaIDs = new Dictionary<int, int>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiaID)
				};
				this.db.GetReader(ref reader, "SP_Consortia_Ally_Neutral", para);
				while (reader.Read())
				{
					if ((int)reader["Consortia1ID"] != consortiaID)
					{
						consortiaIDs.Add((int)reader["Consortia1ID"], (int)reader["State"]);
					}
					else
					{
						consortiaIDs.Add((int)reader["Consortia2ID"], (int)reader["State"]);
					}
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetConsortiaByAlly", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return consortiaIDs;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000095BC File Offset: 0x000077BC
		public bool AddConsortiaAlly(ConsortiaAllyInfo info, int userID, ref string msg)
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
					new SqlParameter("@Consortia1ID", info.Consortia1ID),
					new SqlParameter("@Consortia2ID", info.Consortia2ID),
					new SqlParameter("@State", info.State),
					new SqlParameter("@Date", info.Date),
					new SqlParameter("@ValidDate", info.ValidDate),
					new SqlParameter("@IsExist", info.IsExist),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Result", SqlDbType.Int)
					{
						Direction = ParameterDirection.ReturnValue
					}
				};
				this.db.RunProcedure("SP_ConsortiaAlly_Add", para);
				int returnValue = (int)para[8].Value;
				result = returnValue == 0;
				if (returnValue != 2)
				{
					if (returnValue == 3)
					{
						msg = "ConsortiaBussiness.AddConsortiaAlly.Msg3";
					}
				}
				else
				{
					msg = "ConsortiaBussiness.AddConsortiaAlly.Msg2";
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

		// Token: 0x0600006B RID: 107 RVA: 0x00009728 File Offset: 0x00007928
		public ConsortiaAllyInfo[] GetConsortiaAllyPage(int page, int size, ref int total, int order, int consortiaID, int state, string name)
		{
			List<ConsortiaAllyInfo> infos = new List<ConsortiaAllyInfo>();
			string sWhere = " IsExist=1 and ConsortiaID<>" + consortiaID.ToString();
			Dictionary<int, int> consortiaIDs = this.GetConsortiaByAlly(consortiaID);
			try
			{
				if (state != -1)
				{
					string ids = string.Empty;
					foreach (int id in consortiaIDs.Keys)
					{
						ids = ids + id.ToString() + ",";
					}
					ids += 0.ToString();
					if (state == 0)
					{
						sWhere = sWhere + " and ConsortiaID not in (" + ids + ") ";
					}
					else
					{
						sWhere = sWhere + " and ConsortiaID in (" + ids + ") ";
					}
				}
				if (!string.IsNullOrEmpty(name))
				{
					sWhere = sWhere + " and ConsortiaName like '%" + name + "%' ";
				}
				foreach (object obj in base.GetPage("Consortia", sWhere, page, size, "*", "ConsortiaID", "ConsortiaID", ref total).Rows)
				{
					DataRow dr = (DataRow)obj;
					ConsortiaAllyInfo info = new ConsortiaAllyInfo
					{
						Consortia1ID = (int)dr["ConsortiaID"],
						ConsortiaName1 = ((dr["ConsortiaName"] == null) ? "" : dr["ConsortiaName"].ToString()),
						ConsortiaName2 = "",
						Count1 = (int)dr["Count"],
						Repute1 = (int)dr["Repute"],
						ChairmanName1 = ((dr["ChairmanName"] == null) ? "" : dr["ChairmanName"].ToString()),
						ChairmanName2 = "",
						Level1 = (int)dr["Level"],
						Honor1 = (int)dr["Honor"],
						Description1 = ((dr["Description"] == null) ? "" : dr["Description"].ToString()),
						Description2 = "",
						Riches1 = (int)dr["Riches"],
						Date = DateTime.Now,
						IsExist = true
					};
					if (consortiaIDs.ContainsKey(info.Consortia1ID))
					{
						info.State = consortiaIDs[info.Consortia1ID];
					}
					info.ValidDate = 0;
					infos.Add(info);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetConsortiaAllyPage", e);
				}
			}
			return infos.ToArray();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00009A50 File Offset: 0x00007C50
		public ConsortiaAllyInfo[] GetConsortiaAllyAll()
		{
			List<ConsortiaAllyInfo> infos = new List<ConsortiaAllyInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_ConsortiaAlly_All");
				while (reader.Read())
				{
					infos.Add(new ConsortiaAllyInfo
					{
						Consortia1ID = (int)reader["Consortia1ID"],
						Consortia2ID = (int)reader["Consortia2ID"],
						Date = (DateTime)reader["Date"],
						ID = (int)reader["ID"],
						State = (int)reader["State"],
						ValidDate = (int)reader["ValidDate"],
						IsExist = (bool)reader["IsExist"]
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

		// Token: 0x0600006D RID: 109 RVA: 0x00009B84 File Offset: 0x00007D84
		public ConsortiaEventInfo[] GetConsortiaEventPage(int page, int size, ref int total, int order, int consortiaID)
		{
			List<ConsortiaEventInfo> infos = new List<ConsortiaEventInfo>();
			try
			{
				string sWhere = " IsExist=1 ";
				if (consortiaID != -1)
				{
					object obj = sWhere;
					sWhere = string.Concat(new object[] { obj, " and ConsortiaID =", consortiaID, " " });
				}
				string sOrder = " ID desc ";
				foreach (object obj2 in base.GetFetch_List(page, size, sOrder, sWhere, "Consortia_Event", ref total).Rows)
				{
					DataRow dr = (DataRow)obj2;
					infos.Add(new ConsortiaEventInfo
					{
						ID = (int)dr["ID"],
						ConsortiaID = (int)dr["ConsortiaID"],
						Date = (DateTime)dr["Date"],
						IsExist = (bool)dr["IsExist"],
						Remark = dr["Remark"].ToString(),
						Type = (int)dr["Type"],
						NickName = dr["NickName"].ToString(),
						EventValue = (int)dr["EventValue"],
						ManagerName = dr["ManagerName"].ToString()
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

		// Token: 0x0600006E RID: 110 RVA: 0x00009D60 File Offset: 0x00007F60
		public ConsortiaEventInfo[] GetConsortiaEventPages(int page, int size, ref int total, int order, int consortiaID)
		{
			List<ConsortiaEventInfo> infos = new List<ConsortiaEventInfo>();
			try
			{
				string sWhere = " IsExist=1 ";
				if (consortiaID != -1)
				{
					object obj = sWhere;
					sWhere = string.Concat(new object[] { obj, " and ConsortiaID =", consortiaID, " " });
				}
				string sOrder = "Date desc,ID ";
				foreach (object obj2 in base.GetPage("Consortia_Event", sWhere, page, size, "*", sOrder, "ID", ref total).Rows)
				{
					DataRow dr = (DataRow)obj2;
					infos.Add(new ConsortiaEventInfo
					{
						ID = (int)dr["ID"],
						ConsortiaID = (int)dr["ConsortiaID"],
						Date = (DateTime)dr["Date"],
						IsExist = (bool)dr["IsExist"],
						Remark = dr["Remark"].ToString(),
						Type = (int)dr["Type"],
						NickName = dr["NickName"].ToString(),
						EventValue = (int)dr["EventValue"],
						ManagerName = dr["ManagerName"].ToString()
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

		// Token: 0x0600006F RID: 111 RVA: 0x00009F44 File Offset: 0x00008144
		public ConsortiaLevelInfo[] GetAllConsortiaLevel()
		{
			List<ConsortiaLevelInfo> infos = new List<ConsortiaLevelInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Consortia_Level_All");
				while (reader.Read())
				{
					infos.Add(new ConsortiaLevelInfo
					{
						Count = (int)reader["Count"],
						Deduct = (int)reader["Deduct"],
						Level = (int)reader["Level"],
						NeedGold = (int)reader["NeedGold"],
						NeedItem = (int)reader["NeedItem"],
						Reward = (int)reader["Reward"],
						Riches = (int)reader["Riches"],
						ShopRiches = (int)reader["ShopRiches"],
						SmithRiches = (int)reader["SmithRiches"],
						StoreRiches = (int)reader["StoreRiches"],
						BufferRiches = (int)reader["BufferRiches"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllConsortiaLevel", e);
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

		// Token: 0x06000070 RID: 112 RVA: 0x0000A0E8 File Offset: 0x000082E8
		public bool AddAndUpdateConsortiaEuqipControl(ConsortiaEquipControlInfo info, int userID, ref string msg)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", info.ConsortiaID),
					new SqlParameter("@Level", info.Level),
					new SqlParameter("@Type", info.Type),
					new SqlParameter("@Riches", info.Riches),
					new SqlParameter("@UserID", userID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[5].Direction = ParameterDirection.ReturnValue;
				result = this.db.RunProcedure("SP_Consortia_Equip_Control_Add", para);
				int num = (int)para[2].Value;
				result = num == 0;
				if (num == 2)
				{
					msg = "ConsortiaBussiness.AddAndUpdateConsortiaEuqipControl.Msg2";
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

		// Token: 0x06000071 RID: 113 RVA: 0x0000A1E8 File Offset: 0x000083E8
		public ConsortiaEquipControlInfo GetConsortiaEuqipRiches(int consortiaID, int Level, int type)
		{
			ConsortiaEquipControlInfo info = null;
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@Level", Level),
					new SqlParameter("@Type", type)
				};
				this.db.GetReader(ref reader, "SP_Consortia_Equip_Control_Single", para);
				if (reader.Read())
				{
					info = new ConsortiaEquipControlInfo
					{
						ConsortiaID = (int)reader["ConsortiaID"],
						Level = (int)reader["Level"],
						Riches = (int)reader["Riches"],
						Type = (int)reader["Type"]
					};
					return info;
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllConsortiaLevel", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			if (info == null)
			{
				info = new ConsortiaEquipControlInfo
				{
					ConsortiaID = consortiaID,
					Level = Level,
					Riches = 100,
					Type = type
				};
			}
			return info;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000A334 File Offset: 0x00008534
		public ConsortiaEquipControlInfo[] GetConsortiaEquipControlPage(int page, int size, ref int total, int order, int consortiaID, int level, int type)
		{
			List<ConsortiaEquipControlInfo> infos = new List<ConsortiaEquipControlInfo>();
			try
			{
				string sWhere = " IsExist=1 ";
				if (consortiaID != -1)
				{
					object obj = sWhere;
					sWhere = string.Concat(new object[] { obj, " and ConsortiaID =", consortiaID, " " });
				}
				if (level != -1)
				{
					object obj2 = sWhere;
					sWhere = string.Concat(new object[] { obj2, " and Level =", level, " " });
				}
				if (type != -1)
				{
					object obj3 = sWhere;
					sWhere = string.Concat(new object[] { obj3, " and Type =", type, " " });
				}
				string sOrder = "ConsortiaID ";
				foreach (object obj4 in base.GetPage("Consortia_Equip_Control", sWhere, page, size, "*", sOrder, "ConsortiaID", ref total).Rows)
				{
					DataRow dr = (DataRow)obj4;
					infos.Add(new ConsortiaEquipControlInfo
					{
						ConsortiaID = (int)dr["ConsortiaID"],
						Level = (int)dr["Level"],
						Riches = (int)dr["Riches"],
						Type = (int)dr["Type"]
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

		// Token: 0x06000073 RID: 115 RVA: 0x0000A504 File Offset: 0x00008704
		public bool UpdateConsortiaBadge(int consortiaID, int badgeID)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConsortiaID", consortiaID),
					new SqlParameter("@BadgeID", badgeID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[2].Direction = ParameterDirection.ReturnValue;
				result = this.db.RunProcedure("SP_ConsortiaBadge_Update", para);
				result = (int)para[2].Value == 0;
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

		// Token: 0x06000074 RID: 116 RVA: 0x0000A5AC File Offset: 0x000087AC
		public ConsortiaSkillInfo[] GetAllConsortiaSkill()
		{
			List<ConsortiaSkillInfo> infos = new List<ConsortiaSkillInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Consortia_Skill_All");
				while (reader.Read())
				{
					infos.Add(new ConsortiaSkillInfo
					{
						Description = (string)reader["Description"],
						Group = (int)reader["Group"],
						ID = (int)reader["ID"],
						Level = (int)reader["Level"],
						Metal = (int)reader["Metal"],
						Name = (string)reader["Name"],
						Pic = (int)reader["Pic"],
						Riches = (int)reader["Riches"],
						Type = (int)reader["Type"],
						Value = (int)reader["Value"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllConsortiaSkill", e);
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
	}
}
