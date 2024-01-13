using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Bussiness;
using Center.GMService.DataContracts;

namespace Center.GMService
{
	// Token: 0x02000002 RID: 2
	public class GMBussiness : BaseBussiness
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public bool AddChargeReward(ChargeRewardInfo[] rewardInfos)
		{
			bool result = false;
			DataTable dataTable = new DataTable();
			SqlBulkCopy sqlbulk = new SqlBulkCopy(ConfigurationManager.AppSettings["conString"], SqlBulkCopyOptions.UseInternalTransaction);
			try
			{
				dataTable.Columns.Add(new DataColumn("StartTime", typeof(DateTime)));
				dataTable.Columns.Add(new DataColumn("EndTime", typeof(DateTime)));
				dataTable.Columns.Add(new DataColumn("LowerLimit", typeof(int)));
				dataTable.Columns.Add(new DataColumn("UpperLimit", typeof(int)));
				dataTable.Columns.Add(new DataColumn("FirstChargeNeeded", typeof(bool)));
				dataTable.Columns.Add(new DataColumn("GiftPackageID", typeof(int)));
				foreach (ChargeRewardInfo info in rewardInfos)
				{
					DataRow row = dataTable.NewRow();
					row["StartTime"] = info.StartTime;
					row["EndTime"] = info.EndTime;
					row["LowerLimit"] = info.LowerLimit;
					row["UpperLimit"] = info.UpperLimit;
					row["FirstChargeNeeded"] = info.FirstChargeNeeded;
					row["GiftPackageID"] = info.GiftPackageID;
					dataTable.Rows.Add(row);
				}
				sqlbulk.NotifyAfter = dataTable.Rows.Count;
				sqlbulk.DestinationTableName = "Charge_Reward_Config";
				sqlbulk.ColumnMappings.Add("StartTime", "StartTime");
				sqlbulk.ColumnMappings.Add("EndTime", "EndTime");
				sqlbulk.ColumnMappings.Add("LowerLimit", "LowerLimit");
				sqlbulk.ColumnMappings.Add("UpperLimit", "UpperLimit");
				sqlbulk.ColumnMappings.Add("FirstChargeNeeded", "FirstChargeNeeded");
				sqlbulk.ColumnMappings.Add("GiftPackageID", "GiftPackageID");
				sqlbulk.WriteToServer(dataTable);
				result = true;
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
				sqlbulk.Close();
			}
			return result;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000022FC File Offset: 0x000004FC
		public bool AddChargeRewardItems(ChargeRewardItem[] items)
		{
			bool result = false;
			DataTable dataTable = new DataTable();
			SqlBulkCopy sqlbulk = new SqlBulkCopy(ConfigurationManager.AppSettings["conString"], SqlBulkCopyOptions.UseInternalTransaction);
			try
			{
				dataTable.Columns.Add(new DataColumn("ItemTemplateID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Count", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ValidDate", typeof(int)));
				dataTable.Columns.Add(new DataColumn("StrengthLevel", typeof(int)));
				dataTable.Columns.Add(new DataColumn("AttackCompose", typeof(int)));
				dataTable.Columns.Add(new DataColumn("DefendCompose", typeof(int)));
				dataTable.Columns.Add(new DataColumn("LuckCompose", typeof(int)));
				dataTable.Columns.Add(new DataColumn("AgilityCompose", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Money", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Gold", typeof(int)));
				dataTable.Columns.Add(new DataColumn("GiftToken", typeof(int)));
				dataTable.Columns.Add(new DataColumn("IsBind", typeof(bool)));
				dataTable.Columns.Add(new DataColumn("NeedSex", typeof(int)));
				dataTable.Columns.Add(new DataColumn("GiftPackageID", typeof(int)));
				foreach (ChargeRewardItem info in items)
				{
					DataRow row = dataTable.NewRow();
					row["ItemTemplateID"] = info.TemplateID;
					row["Count"] = info.Count;
					row["ValidDate"] = info.ValidDate;
					row["StrengthLevel"] = info.StrengthLevel;
					row["AttackCompose"] = info.AttackCompose;
					row["DefendCompose"] = info.DefendCompose;
					row["LuckCompose"] = info.LuckCompose;
					row["AgilityCompose"] = info.AgilityCompose;
					row["Money"] = info.Money;
					row["Gold"] = info.Gold;
					row["GiftToken"] = info.GiftToken;
					row["IsBind"] = info.IsBind;
					row["NeedSex"] = info.NeedSex;
					row["GiftPackageID"] = info.GiftPackageID;
					dataTable.Rows.Add(row);
				}
				sqlbulk.NotifyAfter = dataTable.Rows.Count;
				sqlbulk.DestinationTableName = "Charge_Reward_Items";
				sqlbulk.ColumnMappings.Add("ItemTemplateID", "ItemTemplateID");
				sqlbulk.ColumnMappings.Add("Count", "Count");
				sqlbulk.ColumnMappings.Add("ValidDate", "ValidDate");
				sqlbulk.ColumnMappings.Add("StrengthLevel", "StrengthLevel");
				sqlbulk.ColumnMappings.Add("AttackCompose", "AttackCompose");
				sqlbulk.ColumnMappings.Add("DefendCompose", "DefendCompose");
				sqlbulk.ColumnMappings.Add("LuckCompose", "LuckCompose");
				sqlbulk.ColumnMappings.Add("AgilityCompose", "AgilityCompose");
				sqlbulk.ColumnMappings.Add("Money", "Money");
				sqlbulk.ColumnMappings.Add("Gold", "Gold");
				sqlbulk.ColumnMappings.Add("GiftToken", "GiftToken");
				sqlbulk.ColumnMappings.Add("IsBind", "IsBind");
				sqlbulk.ColumnMappings.Add("NeedSex", "NeedSex");
				sqlbulk.ColumnMappings.Add("GiftPackageID", "GiftPackageID");
				sqlbulk.WriteToServer(dataTable);
				result = true;
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
				sqlbulk.Close();
			}
			return result;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002810 File Offset: 0x00000A10
		public bool InvalidChargeReward()
		{
			bool result = false;
			try
			{
				result = this.db.RunProcedure("SP_Invalid_Charge_Reward");
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
