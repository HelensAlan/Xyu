using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SqlDataProvider.Data;

namespace Bussiness
{
	// Token: 0x02000014 RID: 20
	public class PveBussiness : BaseBussiness
	{
		// Token: 0x0600017B RID: 379 RVA: 0x0001CEA0 File Offset: 0x0001B0A0
		public PveInfo[] GetAllPveInfos()
		{
			List<PveInfo> infos = new List<PveInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_PveInfos_All");
				while (reader.Read())
				{
					infos.Add(new PveInfo
					{
						ID = (int)reader["Id"],
						Name = ((reader["Name"] == null) ? "" : reader["Name"].ToString()),
						Type = (int)reader["Type"],
						Ordering = (int)reader["Ordering"],
						LevelLimits = (int)reader["LevelLimits"],
						SimpleTemplateIds = ((reader["SimpleTemplateIds"] == null) ? "" : reader["SimpleTemplateIds"].ToString()),
						NormalTemplateIds = ((reader["NormalTemplateIds"] == null) ? "" : reader["NormalTemplateIds"].ToString()),
						HardTemplateIds = ((reader["HardTemplateIds"] == null) ? "" : reader["HardTemplateIds"].ToString()),
						TerrorTemplateIds = ((reader["TerrorTemplateIds"] == null) ? "" : reader["TerrorTemplateIds"].ToString()),
						Pic = ((reader["Pic"] == null) ? "" : reader["Pic"].ToString()),
						Description = ((reader["Description"] == null) ? "" : reader["Description"].ToString()),
						SimpleGameScript = (reader["SimpleGameScript"] as string),
						NormalGameScript = (reader["NormalGameScript"] as string),
						HardGameScript = (reader["HardGameScript"] as string),
						TerrorGameScript = (reader["TerrorGameScript"] as string),
						AdviceTips = (reader["AdviceTips"] as string)
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllMap", e);
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
