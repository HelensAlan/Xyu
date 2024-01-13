using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using log4net;
using SqlDataProvider.Data;

namespace Bussiness
{
	// Token: 0x02000013 RID: 19
	public class ProduceBussiness : BaseBussiness
	{
		// Token: 0x06000135 RID: 309 RVA: 0x0001800C File Offset: 0x0001620C
		public ItemTemplateInfo[] GetAllGoods()
		{
			List<ItemTemplateInfo> infos = new List<ItemTemplateInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Items_All");
				while (reader.Read())
				{
					infos.Add(this.InitItemTemplateInfo(reader));
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

		// Token: 0x06000136 RID: 310 RVA: 0x000180A0 File Offset: 0x000162A0
		public ItemTemplateInfo GetSingleGoods(int goodsID)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", SqlDbType.Int, 4)
				};
				para[0].Value = goodsID;
				this.db.GetReader(ref reader, "SP_Items_Single", para);
				if (reader.Read())
				{
					return this.InitItemTemplateInfo(reader);
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

		// Token: 0x06000137 RID: 311 RVA: 0x0001814C File Offset: 0x0001634C
		public ItemTemplateInfo[] GetSingleCategory(int CategoryID)
		{
			List<ItemTemplateInfo> infos = new List<ItemTemplateInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CategoryID", SqlDbType.Int, 4)
				};
				para[0].Value = CategoryID;
				this.db.GetReader(ref reader, "SP_Items_Category_Single", para);
				while (reader.Read())
				{
					infos.Add(this.InitItemTemplateInfo(reader));
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

		// Token: 0x06000138 RID: 312 RVA: 0x00018208 File Offset: 0x00016408
		public ItemTemplateInfo InitItemTemplateInfo(SqlDataReader reader)
		{
			return new ItemTemplateInfo
			{
				AddTime = reader["AddTime"].ToString(),
				Agility = (int)reader["Agility"],
				Attack = (int)reader["Attack"],
				CanDelete = (bool)reader["CanDelete"],
				CanDrop = (bool)reader["CanDrop"],
				CanEquip = (bool)reader["CanEquip"],
				CanUse = (bool)reader["CanUse"],
				CategoryID = (int)reader["CategoryID"],
				Colors = reader["Colors"].ToString(),
				Defence = (int)reader["Defence"],
				Description = reader["Description"].ToString(),
				Level = (int)reader["Level"],
				Luck = (int)reader["Luck"],
				MaxCount = (int)reader["MaxCount"],
				Name = reader["Name"].ToString(),
				NeedSex = (int)reader["NeedSex"],
				Pic = reader["Pic"].ToString(),
				Data = ((reader["Data"] == null) ? "" : reader["Data"].ToString()),
				Property1 = (int)reader["Property1"],
				Property2 = (int)reader["Property2"],
				Property3 = (int)reader["Property3"],
				Property4 = (int)reader["Property4"],
				Property5 = (int)reader["Property5"],
				Property6 = (int)reader["Property6"],
				Property7 = (int)reader["Property7"],
				Property8 = (int)reader["Property8"],
				Quality = (int)reader["Quality"],
				Script = reader["Script"].ToString(),
				TemplateID = (int)reader["TemplateID"],
				CanCompose = (bool)reader["CanCompose"],
				CanStrengthen = (bool)reader["CanStrengthen"],
				NeedLevel = (int)reader["NeedLevel"],
				BindType = (int)reader["BindType"],
				FusionType = (int)reader["FusionType"],
				FusionRate = (int)reader["FusionRate"],
				FusionNeedRate = (int)reader["FusionNeedRate"],
				Hole = ((reader["Hole"] == null) ? "" : reader["Hole"].ToString()),
				RefineryLevel = (int)reader["RefineryLevel"],
				IsDirty = false,
				ReclaimValue = (int)reader["ReclaimValue"],
				ReclaimType = (int)reader["ReclaimType"],
				CanRecycle = (int)reader["CanRecycle"]
			};
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000185D0 File Offset: 0x000167D0
		public ItemBoxInfo[] GetItemBoxInfos()
		{
			List<ItemBoxInfo> infos = new List<ItemBoxInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_ItemsBox_All");
				while (reader.Read())
				{
					infos.Add(this.InitItemBoxInfo(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					ILog log = BaseBussiness.log;
					string str = "Init@Shop_Goods_Box：";
					Exception ex = e;
					log.Error(str + ((ex != null) ? ex.ToString() : null));
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

		// Token: 0x0600013A RID: 314 RVA: 0x00018678 File Offset: 0x00016878
		public ItemBoxInfo InitItemBoxInfo(SqlDataReader reader)
		{
			return new ItemBoxInfo
			{
				Id = (int)reader["id"],
				DataId = (int)reader["DataId"],
				TemplateId = (int)reader["TemplateId"],
				IsSelect = (bool)reader["IsSelect"],
				IsBind = (bool)reader["IsBind"],
				ItemValid = (int)reader["ItemValid"],
				ItemCount = (int)reader["ItemCount"],
				StrengthenLevel = (int)reader["StrengthenLevel"],
				AttackCompose = (int)reader["AttackCompose"],
				DefendCompose = (int)reader["DefendCompose"],
				AgilityCompose = (int)reader["AgilityCompose"],
				LuckCompose = (int)reader["LuckCompose"],
				Random = (int)reader["Random"],
				IsTips = (bool)reader["IsTips"],
				IsLogs = (bool)reader["IsLogs"]
			};
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000187D4 File Offset: 0x000169D4
		public DropItem[] GetDropItemForNewRegister()
		{
			List<DropItem> infos = new List<DropItem>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Drop_Item_NewRegister");
				while (reader.Read())
				{
					infos.Add(new DropItem
					{
						Id = (int)reader["Id"],
						DropId = (int)reader["DropId"],
						ItemId = (int)reader["ItemId"],
						ValueDate = (int)reader["ValueDate"],
						IsBind = (bool)reader["IsBind"],
						Random = (int)reader["Random"],
						BeginData = (int)reader["BeginData"],
						EndData = (int)reader["EndData"],
						IsTips = (bool)reader["IsTips"]
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

		// Token: 0x0600013C RID: 316 RVA: 0x0001894C File Offset: 0x00016B4C
		public CategoryInfo[] GetAllCategory()
		{
			List<CategoryInfo> infos = new List<CategoryInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Items_Category_All");
				while (reader.Read())
				{
					infos.Add(new CategoryInfo
					{
						ID = (int)reader["ID"],
						Name = ((reader["Name"] == null) ? "" : reader["Name"].ToString()),
						Place = (int)reader["Place"],
						Remark = ((reader["Remark"] == null) ? "" : reader["Remark"].ToString())
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

		// Token: 0x0600013D RID: 317 RVA: 0x00018A64 File Offset: 0x00016C64
		public PropInfo[] GetAllProp()
		{
			List<PropInfo> infos = new List<PropInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Prop_All");
				while (reader.Read())
				{
					infos.Add(new PropInfo
					{
						AffectArea = (int)reader["AffectArea"],
						AffectTimes = (int)reader["AffectTimes"],
						AttackTimes = (int)reader["AttackTimes"],
						BoutTimes = (int)reader["BoutTimes"],
						BuyGold = (int)reader["BuyGold"],
						BuyMoney = (int)reader["BuyMoney"],
						Category = (int)reader["Category"],
						Delay = (int)reader["Delay"],
						Description = reader["Description"].ToString(),
						Icon = reader["Icon"].ToString(),
						ID = (int)reader["ID"],
						Name = reader["Name"].ToString(),
						Parameter = (int)reader["Parameter"],
						Pic = reader["Pic"].ToString(),
						Property1 = (int)reader["Property1"],
						Property2 = (int)reader["Property2"],
						Property3 = (int)reader["Property3"],
						Random = (int)reader["Random"],
						Script = reader["Script"].ToString()
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

		// Token: 0x0600013E RID: 318 RVA: 0x00018CB8 File Offset: 0x00016EB8
		public BallInfo[] GetAllBall()
		{
			List<BallInfo> infos = new List<BallInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Ball_All");
				while (reader.Read())
				{
					infos.Add(new BallInfo
					{
						Amount = (int)reader["Amount"],
						ID = (int)reader["ID"],
						Name = reader["Name"].ToString(),
						Power = (double)reader["Power"],
						Radii = (int)reader["Radii"],
						BombPartical = reader["BombPartical"].ToString(),
						FlyingPartical = reader["FlyingPartical"].ToString(),
						Crater = reader["Crater"].ToString(),
						AttackResponse = (int)reader["AttackResponse"],
						IsSpin = (bool)reader["IsSpin"],
						Mass = (int)reader["Mass"],
						SpinV = (int)reader["SpinV"],
						SpinVA = (double)reader["SpinVA"],
						Wind = (int)reader["Wind"],
						DragIndex = (int)reader["DragIndex"],
						Weight = (int)reader["Weight"],
						Shake = (bool)reader["Shake"],
						Delay = (int)reader["Delay"],
						ShootSound = ((reader["ShootSound"] == null) ? "" : reader["ShootSound"].ToString()),
						BombSound = ((reader["BombSound"] == null) ? "" : reader["BombSound"].ToString()),
						ActionType = (int)reader["ActionType"],
						HasTunnel = (bool)reader["HasTunnel"]
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

		// Token: 0x0600013F RID: 319 RVA: 0x00018F74 File Offset: 0x00017174
		public ShopItemInfo[] GetALllShop()
		{
			List<ShopItemInfo> infos = new List<ShopItemInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Shop_All");
				while (reader.Read())
				{
					infos.Add(new ShopItemInfo
					{
						ID = (int)reader["ID"],
						ShopID = (int)reader["ShopID"],
						GroupID = (int)reader["GroupID"],
						TemplateID = (int)reader["TemplateID"],
						BuyType = (int)reader["BuyType"],
						IsContinue = (bool)reader["IsContinue"],
						IsBind = (int)reader["IsBind"],
						IsVouch = (int)reader["IsVouch"],
						Label = (float)((int)reader["Label"]),
						Beat = (decimal)reader["Beat"],
						AUnit = (int)reader["AUnit"],
						APrice1 = (int)reader["APrice1"],
						AValue1 = (int)reader["AValue1"],
						APrice2 = (int)reader["APrice2"],
						AValue2 = (int)reader["AValue2"],
						APrice3 = (int)reader["APrice3"],
						AValue3 = (int)reader["AValue3"],
						BUnit = (int)reader["BUnit"],
						BPrice1 = (int)reader["BPrice1"],
						BValue1 = (int)reader["BValue1"],
						BPrice2 = (int)reader["BPrice2"],
						BValue2 = (int)reader["BValue2"],
						BPrice3 = (int)reader["BPrice3"],
						BValue3 = (int)reader["BValue3"],
						CUnit = (int)reader["CUnit"],
						CPrice1 = (int)reader["CPrice1"],
						CValue1 = (int)reader["CValue1"],
						CPrice2 = (int)reader["CPrice2"],
						CValue2 = (int)reader["CValue2"],
						CPrice3 = (int)reader["CPrice3"],
						CValue3 = (int)reader["CValue3"],
						LimitCount = (int)reader["LimitCount"],
						IsCheap = (bool)reader["IsCheap"],
						StartDate = (DateTime)reader["StartDate"],
						EndDate = (DateTime)reader["EndDate"]
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

		// Token: 0x06000140 RID: 320 RVA: 0x00019328 File Offset: 0x00017528
		public FusionInfo[] GetAllFusion()
		{
			List<FusionInfo> infos = new List<FusionInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Fusion_All");
				while (reader.Read())
				{
					infos.Add(new FusionInfo
					{
						FusionID = (int)reader["FusionID"],
						Item1 = (int)reader["Item1"],
						Item2 = (int)reader["Item2"],
						Item3 = (int)reader["Item3"],
						Item4 = (int)reader["Item4"],
						Reward = (int)reader["Reward"],
						IsTips = (bool)reader["IsTips"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllFusion", e);
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

		// Token: 0x06000141 RID: 321 RVA: 0x0001945C File Offset: 0x0001765C
		public StrengthenInfo[] GetAllStrengthen()
		{
			List<StrengthenInfo> infos = new List<StrengthenInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Item_Strengthen_All");
				while (reader.Read())
				{
					infos.Add(new StrengthenInfo
					{
						StrengthenLevel = (int)reader["StrengthenLevel"],
						Random = (int)reader["Random"],
						Rock = (int)reader["Rock"],
						Rock1 = (int)reader["Rock1"],
						Rock2 = (int)reader["Rock2"],
						Rock3 = (int)reader["Rock3"],
						StoneLevelMin = (int)reader["StoneLevelMin"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllStrengthen", e);
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

		// Token: 0x06000142 RID: 322 RVA: 0x00019590 File Offset: 0x00017790
		public StrengthenGoodsInfo[] GetAllStrengthenGoodsInfo()
		{
			List<StrengthenGoodsInfo> infos = new List<StrengthenGoodsInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Item_StrengthenGoodsInfo_All");
				while (reader.Read())
				{
					infos.Add(new StrengthenGoodsInfo
					{
						ID = (int)reader["ID"],
						Level = (int)reader["Level"],
						CurrentEquip = (int)reader["CurrentEquip"],
						GainEquip = (int)reader["GainEquip"],
						OrginEquip = (int)reader["OrginEquip"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllStrengthenGoodsInfo", e);
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

		// Token: 0x06000143 RID: 323 RVA: 0x00019694 File Offset: 0x00017894
		public StrengthenInfo[] GetAllRefineryStrengthen()
		{
			List<StrengthenInfo> infos = new List<StrengthenInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Item_Refinery_Strengthen_All");
				while (reader.Read())
				{
					infos.Add(new StrengthenInfo
					{
						StrengthenLevel = (int)reader["StrengthenLevel"],
						Rock = (int)reader["Rock"],
						Rock1 = (int)reader["Rock1"],
						Rock2 = (int)reader["Rock2"],
						Rock3 = (int)reader["Rock3"],
						StoneLevelMin = (int)reader["StoneLevelMin"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllRefineryStrengthen", e);
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

		// Token: 0x06000144 RID: 324 RVA: 0x000197B0 File Offset: 0x000179B0
		public List<RefineryInfo> GetAllRefineryInfo()
		{
			List<RefineryInfo> infos = new List<RefineryInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Item_Refinery_All");
				while (reader.Read())
				{
					infos.Add(new RefineryInfo
					{
						RefineryID = (int)reader["RefineryID"],
						m_Equip = 
						{
							(int)reader["Equip1"],
							(int)reader["Equip2"],
							(int)reader["Equip3"],
							(int)reader["Equip4"]
						},
						Item1 = (int)reader["Item1"],
						Item2 = (int)reader["Item2"],
						Item3 = (int)reader["Item3"],
						Item1Count = (int)reader["Item1Count"],
						Item2Count = (int)reader["Item2Count"],
						Item3Count = (int)reader["Item3Count"],
						m_Reward = 
						{
							(int)reader["Material1"],
							(int)reader["Operate1"],
							(int)reader["Reward1"],
							(int)reader["Material2"],
							(int)reader["Operate2"],
							(int)reader["Reward2"],
							(int)reader["Material3"],
							(int)reader["Operate3"],
							(int)reader["Reward3"],
							(int)reader["Material4"],
							(int)reader["Operate4"],
							(int)reader["Reward4"]
						}
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllRefineryInfo", e);
				}
			}
			finally
			{
				if (reader != null && reader.IsClosed)
				{
					reader.Close();
				}
			}
			return infos;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00019AA8 File Offset: 0x00017CA8
		public QuestInfo[] GetALlQuest()
		{
			List<QuestInfo> infos = new List<QuestInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Quest_All");
				while (reader.Read())
				{
					infos.Add(this.InitQuest(reader));
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

		// Token: 0x06000146 RID: 326 RVA: 0x00019B3C File Offset: 0x00017D3C
		public QuestAwardInfo[] GetAllQuestGoods()
		{
			List<QuestAwardInfo> infos = new List<QuestAwardInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Quest_Goods_All");
				while (reader.Read())
				{
					infos.Add(this.InitQuestGoods(reader));
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

		// Token: 0x06000147 RID: 327 RVA: 0x00019BD0 File Offset: 0x00017DD0
		public QuestConditionInfo[] GetAllQuestCondiction()
		{
			List<QuestConditionInfo> infos = new List<QuestConditionInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Quest_Condiction_All");
				while (reader.Read())
				{
					infos.Add(this.InitQuestCondiction(reader));
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

		// Token: 0x06000148 RID: 328 RVA: 0x00019C64 File Offset: 0x00017E64
		public QuestInfo GetSingleQuest(int questID)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@QuestID", SqlDbType.Int, 4)
				};
				para[0].Value = questID;
				this.db.GetReader(ref reader, "SP_Quest_Single", para);
				if (reader.Read())
				{
					return this.InitQuest(reader);
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

		// Token: 0x06000149 RID: 329 RVA: 0x00019D10 File Offset: 0x00017F10
		public QuestInfo InitQuest(SqlDataReader reader)
		{
			return new QuestInfo
			{
				ID = (int)reader["ID"],
				QuestID = (int)reader["QuestID"],
				Title = ((reader["Title"] == null) ? "" : reader["Title"].ToString()),
				Detail = ((reader["Detail"] == null) ? "" : reader["Detail"].ToString()),
				Objective = ((reader["Objective"] == null) ? "" : reader["Objective"].ToString()),
				NeedMinLevel = (int)reader["NeedMinLevel"],
				NeedMaxLevel = (int)reader["NeedMaxLevel"],
				PreQuestID = ((reader["PreQuestID"] == null) ? "" : reader["PreQuestID"].ToString()),
				NextQuestID = ((reader["NextQuestID"] == null) ? "" : reader["NextQuestID"].ToString()),
				IsOther = (int)reader["IsOther"],
				CanRepeat = (bool)reader["CanRepeat"],
				RepeatInterval = (int)reader["RepeatInterval"],
				RepeatMax = (int)reader["RepeatMax"],
				RewardGP = (int)reader["RewardGP"],
				RewardGold = (int)reader["RewardGold"],
				RewardGiftToken = (int)reader["RewardGiftToken"],
				RewardOffer = (int)reader["RewardOffer"],
				RewardRiches = (int)reader["RewardRiches"],
				RewardBuffID = (int)reader["RewardBuffID"],
				RewardBuffDate = (int)reader["RewardBuffDate"],
				RewardMoney = (int)reader["RewardMoney"],
				Rands = (decimal)reader["Rands"],
				RandDouble = (int)reader["RandDouble"],
				TimeMode = (bool)reader["TimeMode"],
				StartDate = (DateTime)reader["StartDate"],
				EndDate = (DateTime)reader["EndDate"],
				MapID = (int)reader["MapID"],
				AutoEquip = (bool)reader["AutoEquip"],
				RewardMedal = (int)reader["RewardMedal"],
				Rank = ((reader["Rank"] == null) ? "" : reader["Rank"].ToString()),
				StarLev = (int)reader["StarLev"],
				NotMustCount = (int)reader["NotMustCount"]
			};
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0001A05C File Offset: 0x0001825C
		public QuestAwardInfo InitQuestGoods(SqlDataReader reader)
		{
			return new QuestAwardInfo
			{
				QuestID = (int)reader["QuestID"],
				RewardItemID = (int)reader["RewardItemID"],
				IsSelect = (bool)reader["IsSelect"],
				RewardItemValid = (int)reader["RewardItemValid"],
				RewardItemCount = (int)reader["RewardItemCount"],
				StrengthenLevel = (int)reader["StrengthenLevel"],
				AttackCompose = (int)reader["AttackCompose"],
				DefendCompose = (int)reader["DefendCompose"],
				AgilityCompose = (int)reader["AgilityCompose"],
				LuckCompose = (int)reader["LuckCompose"],
				IsCount = (bool)reader["IsCount"],
				IsBind = (bool)reader["IsBind"]
			};
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0001A178 File Offset: 0x00018378
		public QuestConditionInfo InitQuestCondiction(SqlDataReader reader)
		{
			return new QuestConditionInfo
			{
				QuestID = (int)reader["QuestID"],
				CondictionID = (int)reader["CondictionID"],
				CondictionTitle = ((reader["CondictionTitle"] == null) ? "" : reader["CondictionTitle"].ToString()),
				CondictionType = (int)reader["CondictionType"],
				Para1 = (int)reader["Para1"],
				Para2 = (int)reader["Para2"],
				isOpitional = (bool)reader["isOpitional"]
			};
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0001A238 File Offset: 0x00018438
		public DropCondiction[] GetAllDropCondictions()
		{
			List<DropCondiction> infos = new List<DropCondiction>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Drop_Condiction_All");
				while (reader.Read())
				{
					infos.Add(this.InitDropCondiction(reader));
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

		// Token: 0x0600014D RID: 333 RVA: 0x0001A2CC File Offset: 0x000184CC
		public DropItem[] GetAllDropItems()
		{
			List<DropItem> infos = new List<DropItem>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Drop_Item_All");
				while (reader.Read())
				{
					infos.Add(this.InitDropItem(reader));
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

		// Token: 0x0600014E RID: 334 RVA: 0x0001A360 File Offset: 0x00018560
		public DropCondiction InitDropCondiction(SqlDataReader reader)
		{
			return new DropCondiction
			{
				DropId = (int)reader["DropID"],
				CondictionType = (int)reader["CondictionType"],
				Para1 = (string)reader["Para1"],
				Para2 = (string)reader["Para2"]
			};
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0001A3CC File Offset: 0x000185CC
		public DropItem InitDropItem(SqlDataReader reader)
		{
			return new DropItem
			{
				Id = (int)reader["Id"],
				DropId = (int)reader["DropId"],
				ItemId = (int)reader["ItemId"],
				ValueDate = (int)reader["ValueDate"],
				IsBind = (bool)reader["IsBind"],
				Random = (int)reader["Random"],
				BeginData = (int)reader["BeginData"],
				EndData = (int)reader["EndData"],
				IsTips = (bool)reader["IsTips"],
				IsLogs = (bool)reader["IsLogs"]
			};
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0001A4BC File Offset: 0x000186BC
		public AASInfo[] GetAllAASInfo()
		{
			List<AASInfo> infos = new List<AASInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_AASInfo_All");
				while (reader.Read())
				{
					infos.Add(new AASInfo
					{
						UserID = (int)reader["ID"],
						Name = reader["Name"].ToString(),
						IDNumber = reader["IDNumber"].ToString(),
						State = (int)reader["State"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllAASInfo", e);
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

		// Token: 0x06000151 RID: 337 RVA: 0x0001A5A8 File Offset: 0x000187A8
		public bool AddAASInfo(AASInfo info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@Name", info.Name),
					new SqlParameter("@IDNumber", info.IDNumber),
					new SqlParameter("@State", info.State),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[4].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_ASSInfo_Add", para);
				result = (int)para[4].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("UpdateAASInfo", e);
				}
			}
			return result;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0001A680 File Offset: 0x00018880
		public bool AddAreaBigBugleRecord(int userid, int areaid, string nickname, string message, string ip)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", userid),
					new SqlParameter("@AreaID", areaid),
					new SqlParameter("@NickName", nickname),
					new SqlParameter("@Message", message),
					new SqlParameter("@IP", ip),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[5].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_AreaBigBugle_Record", para);
				result = (int)para[5].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("AddAreaBigBugleRecord", e);
				}
			}
			return result;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0001A754 File Offset: 0x00018954
		public List<BigBugleInfo> GetAllAreaBigBugleRecord()
		{
			SqlDataReader reader = null;
			List<BigBugleInfo> list = new List<BigBugleInfo>();
			try
			{
				this.db.GetReader(ref reader, "SP_Get_AreaBigBugle_Record");
				while (reader.Read())
				{
					list.Add(new BigBugleInfo
					{
						ID = (int)reader["ID"],
						UserID = (int)reader["UserID"],
						AreaID = (int)reader["AreaID"],
						NickName = ((reader["NickName"] == null) ? "" : reader["NickName"].ToString()),
						Message = ((reader["Message"] == null) ? "" : reader["Message"].ToString()),
						State = (bool)reader["State"],
						IP = ((reader["IP"] == null) ? "" : reader["IP"].ToString())
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllAreaBigBugleRecord", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return list;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0001A8D8 File Offset: 0x00018AD8
		public bool UpdateAreaBigBugleRecord(int id)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ID", id),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[1].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Update_AreaBigBugle_Record", para);
				result = (int)para[1].Value == 0;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("SP_Update_AreaBigBugle_Record", e);
				}
			}
			return result;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0001A970 File Offset: 0x00018B70
		public string GetASSInfoSingle(int UserID)
		{
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", UserID)
				};
				this.db.GetReader(ref reader, "SP_ASSInfo_Single", para);
				if (reader.Read())
				{
					return reader["IDNumber"].ToString();
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetASSInfoSingle", e);
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

		// Token: 0x06000156 RID: 342 RVA: 0x0001AA20 File Offset: 0x00018C20
		public DailyAwardInfo[] GetAllDailyAward()
		{
			List<DailyAwardInfo> infos = new List<DailyAwardInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Daily_Award_All");
				while (reader.Read())
				{
					infos.Add(new DailyAwardInfo
					{
						Count = (int)reader["Count"],
						ID = (int)reader["ID"],
						IsBinds = (bool)reader["IsBinds"],
						TemplateID = (int)reader["TemplateID"],
						Type = (int)reader["Type"],
						ValidDate = (int)reader["ValidDate"],
						Sex = (int)reader["Sex"],
						Remark = ((reader["Remark"] == null) ? "" : reader["Remark"].ToString()),
						CountRemark = ((reader["CountRemark"] == null) ? "" : reader["CountRemark"].ToString()),
						GetWay = (int)reader["GetWay"],
						AwardDays = (int)reader["AwardDays"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllDaily", e);
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

		// Token: 0x06000157 RID: 343 RVA: 0x0001ABEC File Offset: 0x00018DEC
		public NpcInfo[] GetAllNPCInfo()
		{
			List<NpcInfo> infos = new List<NpcInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_NPC_Info_All");
				while (reader.Read())
				{
					infos.Add(new NpcInfo
					{
						ID = (int)reader["ID"],
						Name = ((reader["Name"] == null) ? "" : reader["Name"].ToString()),
						Level = (int)reader["Level"],
						Camp = (int)reader["Camp"],
						Type = (int)reader["Type"],
						Blood = (int)reader["Blood"],
						X = (int)reader["X"],
						Y = (int)reader["Y"],
						Width = (int)reader["Width"],
						Height = (int)reader["Height"],
						MoveMin = (int)reader["MoveMin"],
						MoveMax = (int)reader["MoveMax"],
						BaseDamage = (int)reader["BaseDamage"],
						BaseGuard = (int)reader["BaseGuard"],
						Attack = (int)reader["Attack"],
						Defence = (int)reader["Defence"],
						Agility = (int)reader["Agility"],
						Lucky = (int)reader["Lucky"],
						ModelID = ((reader["ModelID"] == null) ? "" : reader["ModelID"].ToString()),
						ResourcesPath = ((reader["ResourcesPath"] == null) ? "" : reader["ResourcesPath"].ToString()),
						DropRate = ((reader["DropRate"] == null) ? 2 : Convert.ToInt32(reader["DropRate"].ToString())),
						Experience = (int)reader["Experience"],
						Delay = (int)reader["Delay"],
						Immunity = (int)reader["Immunity"],
						Alert = (int)reader["Alert"],
						Range = (int)reader["Range"],
						Preserve = (int)reader["Preserve"],
						Script = ((reader["Script"] == null) ? "" : reader["Script"].ToString()),
						FireX = (int)reader["FireX"],
						FireY = (int)reader["FireY"],
						DropId = (int)reader["DropId"],
						MaxBeatDis = (int)reader["MaxBeatDis"],
						Speed = (int)reader["Speed"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllNPCInfo", e);
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

		// Token: 0x06000158 RID: 344 RVA: 0x0001AFD8 File Offset: 0x000191D8
		public MissionInfo[] GetAllMissionInfo()
		{
			List<MissionInfo> infos = new List<MissionInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Mission_Info_All");
				while (reader.Read())
				{
					infos.Add(new MissionInfo
					{
						Id = (int)reader["ID"],
						Name = ((reader["Name"] == null) ? "" : reader["Name"].ToString()),
						TotalCount = (int)reader["TotalCount"],
						TotalTurn = (int)reader["TotalTurn"],
						Script = ((reader["Script"] == null) ? "" : reader["Script"].ToString()),
						Success = ((reader["Success"] == null) ? "" : reader["Success"].ToString()),
						Failure = ((reader["Failure"] == null) ? "" : reader["Failure"].ToString()),
						Description = ((reader["Description"] == null) ? "" : reader["Description"].ToString()),
						IncrementDelay = (int)reader["IncrementDelay"],
						Delay = (int)reader["Delay"],
						Title = ((reader["Title"] == null) ? "" : reader["Title"].ToString()),
						Param1 = (int)reader["Param1"],
						Param2 = (int)reader["Param2"],
						TakeCard = (int)reader["TakeCard"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllMissionInfo", e);
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

		// Token: 0x06000159 RID: 345 RVA: 0x0001B234 File Offset: 0x00019434
		public ItemRecordTypeInfo[] GetAllItemRecordType()
		{
			List<ItemRecordTypeInfo> infos = new List<ItemRecordTypeInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Item_Record_Type_All");
				while (reader.Read())
				{
					infos.Add(this.InitItemRecordType(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllItemRecordType:", e);
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

		// Token: 0x0600015A RID: 346 RVA: 0x0001B2C8 File Offset: 0x000194C8
		public AchievementInfo[] GetALlAchievement()
		{
			List<AchievementInfo> infos = new List<AchievementInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Achievement_All");
				while (reader.Read())
				{
					infos.Add(this.InitAchievement(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetALlAchievement:", e);
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

		// Token: 0x0600015B RID: 347 RVA: 0x0001B35C File Offset: 0x0001955C
		public AchievementConditionInfo[] GetALlAchievementCondition()
		{
			List<AchievementConditionInfo> infos = new List<AchievementConditionInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Achievement_Condition_All");
				while (reader.Read())
				{
					infos.Add(this.InitAchievementCondition(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetALlAchievementCondition:", e);
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

		// Token: 0x0600015C RID: 348 RVA: 0x0001B3F0 File Offset: 0x000195F0
		public AchievementRewardInfo[] GetALlAchievementReward()
		{
			List<AchievementRewardInfo> infos = new List<AchievementRewardInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Achievement_Reward_All");
				while (reader.Read())
				{
					infos.Add(this.InitAchievementReward(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetALlAchievementReward", e);
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

		// Token: 0x0600015D RID: 349 RVA: 0x0001B484 File Offset: 0x00019684
		public AchievementDataInfo[] GetAllAchievementData(int userID)
		{
			List<AchievementDataInfo> infos = new List<AchievementDataInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", userID)
				};
				this.db.GetReader(ref reader, "SP_Achievement_Data_All", para);
				while (reader.Read())
				{
					infos.Add(this.InitAchievementData(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllAchievementData", e);
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

		// Token: 0x0600015E RID: 350 RVA: 0x0001B534 File Offset: 0x00019734
		public UsersRecordInfo[] GetAllUsersRecord(int userID)
		{
			List<UsersRecordInfo> infos = new List<UsersRecordInfo>();
			SqlDataReader reader = null;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", userID)
				};
				this.db.GetReader(ref reader, "SP_Users_Record_All", para);
				while (reader.Read())
				{
					infos.Add(this.InitUsersRecord(reader));
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllUsersRecord", e);
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

		// Token: 0x0600015F RID: 351 RVA: 0x0001B5E4 File Offset: 0x000197E4
		public ItemRecordTypeInfo InitItemRecordType(SqlDataReader reader)
		{
			return new ItemRecordTypeInfo
			{
				RecordID = (int)reader["RecordID"],
				Name = ((reader["Name"] == null) ? "" : reader["Name"].ToString()),
				Description = ((reader["Description"] == null) ? "" : reader["Description"].ToString())
			};
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0001B660 File Offset: 0x00019860
		public AchievementInfo InitAchievement(SqlDataReader reader)
		{
			return new AchievementInfo
			{
				ID = (int)reader["ID"],
				PlaceID = (int)reader["PlaceID"],
				Title = ((reader["Title"] == null) ? "" : reader["Title"].ToString()),
				Detail = ((reader["Detail"] == null) ? "" : reader["Detail"].ToString()),
				NeedMinLevel = (int)reader["NeedMinLevel"],
				NeedMaxLevel = (int)reader["NeedMaxLevel"],
				PreAchievementID = ((reader["PreAchievementID"] == null) ? "" : reader["PreAchievementID"].ToString()),
				IsOther = (int)reader["IsOther"],
				AchievementType = (int)reader["AchievementType"],
				CanHide = (bool)reader["CanHide"],
				StartDate = (DateTime)reader["StartDate"],
				EndDate = (DateTime)reader["EndDate"],
				AchievementPoint = (int)reader["AchievementPoint"],
				PicID = (int)reader["PicID"]
			};
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0001B7E4 File Offset: 0x000199E4
		public AchievementConditionInfo InitAchievementCondition(SqlDataReader reader)
		{
			return new AchievementConditionInfo
			{
				AchievementID = (int)reader["AchievementID"],
				CondictionID = (int)reader["CondictionID"],
				CondictionType = (int)reader["CondictionType"],
				Condiction_Para1 = ((reader["Condiction_Para1"] == null) ? "" : reader["Condiction_Para1"].ToString()),
				Condiction_Para2 = (int)reader["Condiction_Para2"]
			};
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0001B878 File Offset: 0x00019A78
		public AchievementRewardInfo InitAchievementReward(SqlDataReader reader)
		{
			return new AchievementRewardInfo
			{
				AchievementID = (int)reader["AchievementID"],
				RewardType = (int)reader["RewardType"],
				RewardPara = ((reader["RewardPara"] == null) ? "" : reader["RewardPara"].ToString()),
				RewardValueId = (int)reader["RewardValueId"],
				RewardCount = (int)reader["RewardCount"]
			};
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0001B90C File Offset: 0x00019B0C
		public AchievementDataInfo InitAchievementData(SqlDataReader reader)
		{
			return new AchievementDataInfo
			{
				UserID = (int)reader["UserID"],
				AchievementID = (int)reader["AchievementID"],
				IsComplete = (bool)reader["IsComplete"],
				CompletedDate = (DateTime)reader["CompletedDate"]
			};
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0001B978 File Offset: 0x00019B78
		public UsersRecordInfo InitUsersRecord(SqlDataReader reader)
		{
			return new UsersRecordInfo
			{
				UserID = (int)reader["UserID"],
				RecordID = (int)reader["RecordID"],
				Total = (int)reader["Total"]
			};
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0001B9CC File Offset: 0x00019BCC
		public List<BoxInfo> GetAllBoxInfo()
		{
			List<BoxInfo> infos = new List<BoxInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Box_Info");
				while (reader.Read())
				{
					infos.Add(new BoxInfo
					{
						ID = (int)reader["ID"],
						Type = (int)reader["Type"],
						Level = (int)reader["Level"],
						Condition = (int)reader["Condition"],
						Template = ((reader["Template"] == null) ? "" : reader["Template"].ToString())
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllBoxInfo", e);
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

		// Token: 0x06000166 RID: 358 RVA: 0x0001BAE4 File Offset: 0x00019CE4
		public bool UpdateBoxProgression(int userid, int boxProgression, int getBoxLevel, DateTime addGPLastDate, DateTime BoxGetDate, int alreadyBox)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", userid),
					new SqlParameter("@BoxProgression", boxProgression),
					new SqlParameter("@GetBoxLevel", getBoxLevel),
					new SqlParameter("@AddGPLastDate", addGPLastDate),
					new SqlParameter("@BoxGetDate", BoxGetDate),
					new SqlParameter("@AlreadyGetBox", alreadyBox),
					new SqlParameter("@OutPut", SqlDbType.Int)
				};
				para[6].Direction = ParameterDirection.Output;
				this.db.RunProcedure("SP_User_Update_BoxProgression", para);
				result = (int)para[6].Value == 1;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("User_Update_BoxProgression", e);
				}
			}
			return result;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0001BBDC File Offset: 0x00019DDC
		public ActiveConditionInfo[] GetAllActiveConditionInfo()
		{
			List<ActiveConditionInfo> infos = new List<ActiveConditionInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Active_Condition");
				while (reader.Read())
				{
					infos.Add(new ActiveConditionInfo
					{
						ID = (int)reader["ID"],
						ActiveID = (int)reader["ActiveID"],
						Conditiontype = (int)reader["Conditiontype"],
						Condition = (int)reader["Condition"],
						LimitGrade = (reader["LimitGrade"].ToString() ?? ""),
						AwardId = (reader["AwardId"].ToString() ?? ""),
						IsMult = (bool)reader["IsMult"],
						StartTime = (DateTime)reader["StartTime"],
						EndTime = (DateTime)reader["EndTime"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllActiveConditionInfo", e);
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

		// Token: 0x06000168 RID: 360 RVA: 0x0001BD64 File Offset: 0x00019F64
		public ActiveAwardInfo[] GetAllActiveAwardInfo()
		{
			List<ActiveAwardInfo> infos = new List<ActiveAwardInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Active_Award");
				while (reader.Read())
				{
					infos.Add(new ActiveAwardInfo
					{
						ID = (int)reader["ID"],
						ActiveID = (int)reader["ActiveID"],
						AgilityCompose = (int)reader["AgilityCompose"],
						AttackCompose = (int)reader["AttackCompose"],
						Count = (int)reader["Count"],
						DefendCompose = (int)reader["DefendCompose"],
						Gold = (int)reader["Gold"],
						ItemID = (int)reader["ItemID"],
						LuckCompose = (int)reader["LuckCompose"],
						Mark = (int)reader["Mark"],
						Money = (int)reader["Money"],
						Sex = (int)reader["Sex"],
						StrengthenLevel = (int)reader["StrengthenLevel"],
						ValidDate = (int)reader["ValidDate"]
					});
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllActiveAwardInfo", e);
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

		// Token: 0x06000169 RID: 361 RVA: 0x0001BF48 File Offset: 0x0001A148
		public Dictionary<int, int> GetShopLimitCount()
		{
			Dictionary<int, int> infos = new Dictionary<int, int>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Shop_ByLimitCount");
				while (reader.Read())
				{
					infos.Add((int)reader["ID"], (int)reader["LimitCount"]);
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("GetAllMissionInfo", e);
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

		// Token: 0x0600016A RID: 362 RVA: 0x0001BFF0 File Offset: 0x0001A1F0
		public RouletteGoodsInfo[] GetRouletteGoodsInfo(int boxID)
		{
			List<RouletteGoodsInfo> infos = new List<RouletteGoodsInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Roulette_Goods_All");
				while (reader.Read())
				{
					infos.Add(new RouletteGoodsInfo
					{
						TemplateID = (int)reader["TemplateID"],
						IsBind = (bool)reader["IsBind"],
						ItemValid = (int)reader["ItemValid"],
						ItemCount = (int)reader["ItemCount"],
						StrengthenLevel = (int)reader["StrengthenLevel"],
						AttackCompose = (int)reader["AttackCompose"],
						DefendCompose = (int)reader["DefendCompose"],
						AgilityCompose = (int)reader["AgilityCompose"],
						LuckCompose = (int)reader["LuckCompose"],
						Random = (int)reader["Random"],
						IsTip = (bool)reader["IsTip"]
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

		// Token: 0x0600016B RID: 363 RVA: 0x0001C194 File Offset: 0x0001A394
		public LevelInfo[] GetLevelInfo()
		{
			List<LevelInfo> infos = new List<LevelInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Level_Info_All");
				while (reader.Read())
				{
					infos.Add(new LevelInfo
					{
						Grade = (int)reader["Grade"],
						GP = (int)reader["GP"],
						Blood = (int)reader["Blood"]
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

		// Token: 0x0600016C RID: 364 RVA: 0x0001C268 File Offset: 0x0001A468
		public BombConfigInfo[] GetBombConfigInfo()
		{
			List<BombConfigInfo> infos = new List<BombConfigInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Bomb_Config_All");
				while (reader.Read())
				{
					infos.Add(new BombConfigInfo
					{
						TemplateID = (int)reader["TemplateID"],
						Common = (int)reader["Common"],
						CommonAddWound = (int)reader["CommonAddWound"],
						CommonMultiBall = (int)reader["CommonMultiBall"],
						Special = (int)reader["Special"],
						SpecialII = (int)reader["SpecialII"]
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

		// Token: 0x0600016D RID: 365 RVA: 0x0001C384 File Offset: 0x0001A584
		public GoldEquipInfo[] GetGoldEquipInfo()
		{
			List<GoldEquipInfo> infos = new List<GoldEquipInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Gold_Equip_Info_All");
				while (reader.Read())
				{
					infos.Add(new GoldEquipInfo
					{
						ID = (int)reader["ID"],
						OldTemplateId = (int)reader["OldTemplateId"],
						NewTemplateId = (int)reader["NewTemplateId"],
						CategoryID = (int)reader["CategoryID"],
						Strengthen = (int)reader["Strengthen"],
						Attack = (int)reader["Attack"],
						Defence = (int)reader["Defence"],
						Agility = (int)reader["Agility"],
						Luck = (int)reader["Luck"],
						Damage = (int)reader["Damage"],
						Guard = (int)reader["Guard"],
						Boold = (int)reader["Boold"],
						BlessID = (int)reader["BlessID"],
						Pic = (string)reader["Pic"]
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

		// Token: 0x0600016E RID: 366 RVA: 0x0001C568 File Offset: 0x0001A768
		public ExerciseInfo[] GetExerciseInfo()
		{
			List<ExerciseInfo> infos = new List<ExerciseInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Exercise_Info_All");
				while (reader.Read())
				{
					infos.Add(new ExerciseInfo
					{
						Grage = (int)reader["Grage"],
						GP = (int)reader["GP"],
						ExerciseA = (int)reader["ExerciseA"],
						ExerciseAG = (int)reader["ExerciseAG"],
						ExerciseD = (int)reader["ExerciseD"],
						ExerciseH = (int)reader["ExerciseH"],
						ExerciseL = (int)reader["ExerciseL"]
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

		// Token: 0x0600016F RID: 367 RVA: 0x0001C69C File Offset: 0x0001A89C
		public CardUpdateInfo[] GetCardUpdateInfo()
		{
			List<CardUpdateInfo> infos = new List<CardUpdateInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Card_Update_Info_All");
				while (reader.Read())
				{
					infos.Add(new CardUpdateInfo
					{
						Id = (int)reader["Id"],
						Level = (int)reader["Level"],
						Attack = (int)reader["Attack"],
						Defend = (int)reader["Defend"],
						Agility = (int)reader["Agility"],
						Lucky = (int)reader["Lucky"],
						Guard = (int)reader["Guard"],
						Damage = (int)reader["Damage"]
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

		// Token: 0x06000170 RID: 368 RVA: 0x0001C7E4 File Offset: 0x0001A9E4
		public CardUpdateConditionInfo[] GetCardUpdateConditionInfo()
		{
			List<CardUpdateConditionInfo> infos = new List<CardUpdateConditionInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Card_Update_Condition_All");
				while (reader.Read())
				{
					infos.Add(new CardUpdateConditionInfo
					{
						Level = (int)reader["Level"],
						Exp = (int)reader["Exp"],
						MinExp = (int)reader["MinExp"],
						MaxExp = (int)reader["MaxExp"],
						UpdateCardCount = (int)reader["UpdateCardCount"],
						ResetCardCount = (int)reader["ResetCardCount"],
						ResetMoney = (int)reader["ResetMoney"]
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

		// Token: 0x06000171 RID: 369 RVA: 0x0001C918 File Offset: 0x0001AB18
		public ShopGoodsShowInfo[] GetShopGoodsShowInfo()
		{
			List<ShopGoodsShowInfo> infos = new List<ShopGoodsShowInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Shop_Goods_Show_All");
				while (reader.Read())
				{
					infos.Add(new ShopGoodsShowInfo
					{
						Type = (int)reader["Type"],
						ShopId = (int)reader["ShopId"]
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

		// Token: 0x06000172 RID: 370 RVA: 0x0001C9D8 File Offset: 0x0001ABD8
		public PetConfigInfo[] GetAllPetConfig()
		{
			List<PetConfigInfo> infos = new List<PetConfigInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Pet_Config_All");
				while (reader.Read())
				{
					infos.Add(base.InitValue<PetConfigInfo>(reader, null));
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

		// Token: 0x06000173 RID: 371 RVA: 0x0001CA70 File Offset: 0x0001AC70
		public PetLevelInfo[] GetAllPetLevel()
		{
			List<PetLevelInfo> infos = new List<PetLevelInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Pet_Level_Info_All");
				while (reader.Read())
				{
					infos.Add(base.InitValue<PetLevelInfo>(reader, null));
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

		// Token: 0x06000174 RID: 372 RVA: 0x0001CB08 File Offset: 0x0001AD08
		public PetSkillElementInfo[] GetAllPetSkillElementInfo()
		{
			List<PetSkillElementInfo> infos = new List<PetSkillElementInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Pet_Skill_Element_Info_All");
				while (reader.Read())
				{
					infos.Add(base.InitValue<PetSkillElementInfo>(reader, null));
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

		// Token: 0x06000175 RID: 373 RVA: 0x0001CBA0 File Offset: 0x0001ADA0
		public PetSkillInfo[] GetAllPetSkillInfo()
		{
			List<PetSkillInfo> infos = new List<PetSkillInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Pet_Skill_Info_All");
				while (reader.Read())
				{
					infos.Add(base.InitValue<PetSkillInfo>(reader, null));
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

		// Token: 0x06000176 RID: 374 RVA: 0x0001CC38 File Offset: 0x0001AE38
		public PetSkillTemplateInfo[] GetAllPetSkillTemplateInfo()
		{
			List<PetSkillTemplateInfo> infos = new List<PetSkillTemplateInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Pet_Skill_Template_Info_All");
				while (reader.Read())
				{
					infos.Add(base.InitValue<PetSkillTemplateInfo>(reader, null));
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

		// Token: 0x06000177 RID: 375 RVA: 0x0001CCD0 File Offset: 0x0001AED0
		public PetTemplateInfo[] GetAllPetTemplateInfo()
		{
			List<PetTemplateInfo> infos = new List<PetTemplateInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Pet_Template_Info_All");
				while (reader.Read())
				{
					infos.Add(base.InitValue<PetTemplateInfo>(reader, null));
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

		// Token: 0x06000178 RID: 376 RVA: 0x0001CD68 File Offset: 0x0001AF68
		public PetFightPropertyInfo[] GetAllPetFightProperty()
		{
			List<PetFightPropertyInfo> infos = new List<PetFightPropertyInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Pet_Fight_Property_All");
				while (reader.Read())
				{
					infos.Add(base.InitValue<PetFightPropertyInfo>(reader, null));
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

		// Token: 0x06000179 RID: 377 RVA: 0x0001CE00 File Offset: 0x0001B000
		public PetStarExpInfo[] GetAllPetStarExp()
		{
			List<PetStarExpInfo> infos = new List<PetStarExpInfo>();
			SqlDataReader reader = null;
			try
			{
				this.db.GetReader(ref reader, "SP_Pet_Star_Exp_All");
				while (reader.Read())
				{
					infos.Add(base.InitValue<PetStarExpInfo>(reader, null));
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
	}
}
