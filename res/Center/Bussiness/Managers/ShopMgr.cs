using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using log4net;
using SqlDataProvider.Data;

namespace Bussiness.Managers
{
	// Token: 0x02000026 RID: 38
	public static class ShopMgr
	{
		// Token: 0x060001ED RID: 493 RVA: 0x000206ED File Offset: 0x0001E8ED
		public static bool Init()
		{
			return ShopMgr.ReLoad();
		}

		// Token: 0x060001EE RID: 494 RVA: 0x000206F4 File Offset: 0x0001E8F4
		public static bool ReLoad()
		{
			try
			{
				Dictionary<int, ShopItemInfo> tempShop = ShopMgr.LoadFromDatabase();
				Dictionary<int, int> tempMaxLimit = new Dictionary<int, int>();
				Dictionary<int, List<int>> tempNoticeInfos = new Dictionary<int, List<int>>();
				foreach (int key in tempShop.Keys)
				{
					if (!tempMaxLimit.ContainsKey(key))
					{
						tempMaxLimit.Add(key, tempShop[key].LimitCount);
					}
					if (!tempNoticeInfos.ContainsKey(key) && tempShop[key].LimitCount != -1)
					{
						tempNoticeInfos.Add(key, ShopMgr.InitNotice());
					}
				}
				if (tempShop.Count > 0)
				{
					Interlocked.Exchange<Dictionary<int, ShopItemInfo>>(ref ShopMgr.m_shop, tempShop);
					Interlocked.Exchange<Dictionary<int, int>>(ref ShopMgr.m_LimitCount, tempMaxLimit);
					Interlocked.Exchange<Dictionary<int, List<int>>>(ref ShopMgr.m_isNoticeInfos, tempNoticeInfos);
				}
				return true;
			}
			catch (Exception e)
			{
				ShopMgr.log.Error("ShopInfoMgr", e);
			}
			return false;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x000207F0 File Offset: 0x0001E9F0
		private static Dictionary<int, ShopItemInfo> LoadFromDatabase()
		{
			Dictionary<int, ShopItemInfo> list = new Dictionary<int, ShopItemInfo>();
			using (ProduceBussiness db = new ProduceBussiness())
			{
				foreach (ShopItemInfo info in db.GetALllShop())
				{
					if (!list.ContainsKey(info.ID))
					{
						list.Add(info.ID, info);
					}
				}
			}
			return list;
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00020860 File Offset: 0x0001EA60
		public static void RefreshLimitCount()
		{
			try
			{
				Dictionary<int, ShopItemInfo> tempShop = ShopMgr.m_shop;
				Dictionary<int, int> tempMaxLimit = new Dictionary<int, int>();
				int[] keys = tempShop.Keys.ToArray<int>();
				for (int i = 0; i < keys.Length; i++)
				{
					if (!tempMaxLimit.ContainsKey(keys[i]))
					{
						tempMaxLimit.Add(keys[i], tempShop[keys[i]].LimitCount);
					}
				}
				if (tempMaxLimit.Count > 0)
				{
					Interlocked.Exchange<Dictionary<int, int>>(ref ShopMgr.m_LimitCount, tempMaxLimit);
					ShopMgr.InitNotice();
				}
			}
			catch (Exception e)
			{
				ShopMgr.log.Error("ShopInfoMgr", e);
			}
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x000208F8 File Offset: 0x0001EAF8
		public static ShopItemInfo GetShopItemInfoById(int id)
		{
			ShopItemInfo result;
			if (ShopMgr.m_shop.ContainsKey(id))
			{
				result = ShopMgr.m_shop[id];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00020923 File Offset: 0x0001EB23
		public static Dictionary<int, int> GetLimitShopItemInfo()
		{
			return ShopMgr.m_LimitCount;
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0002092A File Offset: 0x0001EB2A
		public static int GetLimitMax(int id)
		{
			return ShopMgr.m_shop[id].LimitCount;
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0002093C File Offset: 0x0001EB3C
		public static void SubtractShopLimit(int id)
		{
			Dictionary<int, int> limitCount3 = ShopMgr.m_LimitCount;
			lock (limitCount3)
			{
				Dictionary<int, int> limitCount2;
				(limitCount2 = ShopMgr.m_LimitCount)[id] = limitCount2[id] - 1;
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0002098C File Offset: 0x0001EB8C
		public static void UpdateLimitCount(Dictionary<int, int> info)
		{
			Dictionary<int, int> limitCount = ShopMgr.m_LimitCount;
			lock (limitCount)
			{
				foreach (int key in info.Keys)
				{
					if (info[key] < ShopMgr.m_LimitCount[key])
					{
						ShopMgr.m_LimitCount[key] = info[key];
					}
				}
			}
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00020A24 File Offset: 0x0001EC24
		public static void UpdateNotice(Dictionary<int, List<int>> notice)
		{
			Dictionary<int, List<int>> isNoticeInfos = ShopMgr.m_isNoticeInfos;
			lock (isNoticeInfos)
			{
				foreach (int key in notice.Keys)
				{
					for (int i = 0; i < notice[key].Count; i++)
					{
						if (notice[key][i] != ShopMgr.m_isNoticeInfos[key][i])
						{
							ShopMgr.m_isNoticeInfos[key][i] = notice[key][i];
						}
					}
				}
			}
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00020AF4 File Offset: 0x0001ECF4
		public static void CloseNotice(int id, int index)
		{
			Dictionary<int, List<int>> isNoticeInfos = ShopMgr.m_isNoticeInfos;
			lock (isNoticeInfos)
			{
				if (ShopMgr.m_isNoticeInfos.ContainsKey(id))
				{
					ShopMgr.m_isNoticeInfos[id][index] = 0;
				}
			}
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00020B4C File Offset: 0x0001ED4C
		public static int GetLimitCountByID(int id)
		{
			return ShopMgr.m_LimitCount[id];
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00020B59 File Offset: 0x0001ED59
		public static int GetIsNotice(int id, int index)
		{
			return ShopMgr.m_isNoticeInfos[id][index];
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00020B6C File Offset: 0x0001ED6C
		public static bool CanBuy(int shopID, int consortiaShopLevel, ref bool isBinds, int cousortiaID, int playerRiches)
		{
			bool result = false;
			using (ConsortiaBussiness csbs = new ConsortiaBussiness())
			{
				switch (shopID)
				{
				case 1:
					result = true;
					isBinds = false;
					break;
				case 2:
					result = true;
					isBinds = false;
					break;
				case 3:
					result = true;
					isBinds = false;
					break;
				case 4:
					result = true;
					isBinds = false;
					break;
				case 11:
				{
					ConsortiaEquipControlInfo cecInfo = csbs.GetConsortiaEuqipRiches(cousortiaID, 1, 1);
					if (consortiaShopLevel >= cecInfo.Level && playerRiches >= cecInfo.Riches)
					{
						result = true;
						isBinds = true;
					}
					break;
				}
				case 12:
				{
					ConsortiaEquipControlInfo cecInfo2 = csbs.GetConsortiaEuqipRiches(cousortiaID, 2, 1);
					if (consortiaShopLevel >= cecInfo2.Level && playerRiches >= cecInfo2.Riches)
					{
						result = true;
						isBinds = true;
					}
					break;
				}
				case 13:
				{
					ConsortiaEquipControlInfo cecInfo3 = csbs.GetConsortiaEuqipRiches(cousortiaID, 3, 1);
					if (consortiaShopLevel >= cecInfo3.Level && playerRiches >= cecInfo3.Riches)
					{
						result = true;
						isBinds = true;
					}
					break;
				}
				case 14:
				{
					ConsortiaEquipControlInfo cecInfo4 = csbs.GetConsortiaEuqipRiches(cousortiaID, 4, 1);
					if (consortiaShopLevel >= cecInfo4.Level && playerRiches >= cecInfo4.Riches)
					{
						result = true;
						isBinds = true;
					}
					break;
				}
				case 15:
				{
					ConsortiaEquipControlInfo cecInfo5 = csbs.GetConsortiaEuqipRiches(cousortiaID, 5, 1);
					if (consortiaShopLevel >= cecInfo5.Level && playerRiches >= cecInfo5.Riches)
					{
						result = true;
						isBinds = true;
					}
					break;
				}
				}
			}
			return result;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00020CE4 File Offset: 0x0001EEE4
		public static int FindItemTemplateID(int id)
		{
			int result;
			if (ShopMgr.m_shop.ContainsKey(id))
			{
				result = ShopMgr.m_shop[id].TemplateID;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00020D14 File Offset: 0x0001EF14
		public static List<ShopItemInfo> FindShopbyTemplatID(int TemplatID)
		{
			List<ShopItemInfo> shopItem = new List<ShopItemInfo>();
			foreach (ShopItemInfo shop in ShopMgr.m_shop.Values)
			{
				if (shop.TemplateID == TemplatID)
				{
					shopItem.Add(shop);
				}
			}
			return shopItem;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00020D7C File Offset: 0x0001EF7C
		public static List<ShopItemInfo> FindShopByGroupID(int GroupID)
		{
			List<ShopItemInfo> shopItem = new List<ShopItemInfo>();
			foreach (ShopItemInfo shop in ShopMgr.m_shop.Values)
			{
				if (shop.GroupID == GroupID && shop.ShopID == 22)
				{
					shopItem.Add(shop);
				}
			}
			return shopItem;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00020DF0 File Offset: 0x0001EFF0
		public static List<ShopItemInfo> FindShopByID(int ID)
		{
			List<ShopItemInfo> shopItem = new List<ShopItemInfo>();
			foreach (ShopItemInfo shop in ShopMgr.m_shop.Values)
			{
				if (shop.ID == ID)
				{
					shopItem.Add(shop);
				}
			}
			return shopItem;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00020E58 File Offset: 0x0001F058
		public static List<int> GetShopItemBuyConditions(ShopItemInfo shop, int type, ref int gold, ref int money, ref int offer, ref int gifttoken)
		{
			int iTemplateID = 0;
			int iCount = 0;
			gold = 0;
			money = 0;
			offer = 0;
			gifttoken = 0;
			List<int> itemsInfo = new List<int>();
			if (!ShopMgr.isTypeIn(shop, type))
			{
				throw new ArgumentNullException("type isn't in!");
			}
			if (type == 1)
			{
				ShopMgr.GetItemPrice(shop.APrice1, shop.AValue1, shop.Beat, ref gold, ref money, ref offer, ref gifttoken, ref iTemplateID, ref iCount);
				if (iTemplateID > 0)
				{
					itemsInfo.Add(iTemplateID);
					itemsInfo.Add(iCount);
				}
				ShopMgr.GetItemPrice(shop.APrice2, shop.AValue2, shop.Beat, ref gold, ref money, ref offer, ref gifttoken, ref iTemplateID, ref iCount);
				if (iTemplateID > 0)
				{
					itemsInfo.Add(iTemplateID);
					itemsInfo.Add(iCount);
				}
				ShopMgr.GetItemPrice(shop.APrice3, shop.AValue3, shop.Beat, ref gold, ref money, ref offer, ref gifttoken, ref iTemplateID, ref iCount);
				if (iTemplateID > 0)
				{
					itemsInfo.Add(iTemplateID);
					itemsInfo.Add(iCount);
				}
			}
			if (type == 2)
			{
				ShopMgr.GetItemPrice(shop.BPrice1, shop.BValue1, shop.Beat, ref gold, ref money, ref offer, ref gifttoken, ref iTemplateID, ref iCount);
				if (iTemplateID > 0)
				{
					itemsInfo.Add(iTemplateID);
					itemsInfo.Add(iCount);
				}
				ShopMgr.GetItemPrice(shop.BPrice2, shop.BValue2, shop.Beat, ref gold, ref money, ref offer, ref gifttoken, ref iTemplateID, ref iCount);
				if (iTemplateID > 0)
				{
					itemsInfo.Add(iTemplateID);
					itemsInfo.Add(iCount);
				}
				ShopMgr.GetItemPrice(shop.BPrice3, shop.BValue3, shop.Beat, ref gold, ref money, ref offer, ref gifttoken, ref iTemplateID, ref iCount);
				if (iTemplateID > 0)
				{
					itemsInfo.Add(iTemplateID);
					itemsInfo.Add(iCount);
				}
			}
			if (type == 3)
			{
				ShopMgr.GetItemPrice(shop.CPrice1, shop.CValue1, shop.Beat, ref gold, ref money, ref offer, ref gifttoken, ref iTemplateID, ref iCount);
				if (iTemplateID > 0)
				{
					itemsInfo.Add(iTemplateID);
					itemsInfo.Add(iCount);
				}
				ShopMgr.GetItemPrice(shop.CPrice2, shop.CValue2, shop.Beat, ref gold, ref money, ref offer, ref gifttoken, ref iTemplateID, ref iCount);
				if (iTemplateID > 0)
				{
					itemsInfo.Add(iTemplateID);
					itemsInfo.Add(iCount);
				}
				ShopMgr.GetItemPrice(shop.CPrice3, shop.CValue3, shop.Beat, ref gold, ref money, ref offer, ref gifttoken, ref iTemplateID, ref iCount);
				if (iTemplateID > 0)
				{
					itemsInfo.Add(iTemplateID);
					itemsInfo.Add(iCount);
				}
			}
			return itemsInfo;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00021074 File Offset: 0x0001F274
		public static void GetItemPrice(int Prices, int Values, decimal beat, ref int gold, ref int money, ref int offer, ref int gifttoken, ref int iTemplateID, ref int iCount)
		{
			iTemplateID = 0;
			iCount = 0;
			switch (Prices)
			{
			case -4:
				gifttoken += (int)(Values * beat);
				return;
			case -3:
				offer += (int)(Values * beat);
				return;
			case -2:
				gold += (int)(Values * beat);
				return;
			case -1:
				money += (int)(Values * beat);
				return;
			default:
				if (Prices > 0)
				{
					iTemplateID = Prices;
					iCount = Values;
				}
				return;
			}
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00021114 File Offset: 0x0001F314
		public static ItemInfo CreateItem(ShopItemInfo shopItem, int addtype, int valuetype, string color, string skin, bool isBinding)
		{
			if (shopItem == null)
			{
				throw new ArgumentNullException("shopItem");
			}
			ItemInfo item = ItemInfo.CreateFromTemplate(ItemMgr.FindItemTemplate(shopItem.TemplateID), 1, addtype);
			if (shopItem.BuyType == 0)
			{
				if (1 == valuetype)
				{
					item.ValidDate = shopItem.AUnit;
				}
				if (2 == valuetype)
				{
					item.ValidDate = shopItem.BUnit;
				}
				if (3 == valuetype)
				{
					item.ValidDate = shopItem.CUnit;
				}
			}
			else
			{
				if (1 == valuetype)
				{
					item.Count = shopItem.AUnit;
				}
				if (2 == valuetype)
				{
					item.Count = shopItem.BUnit;
				}
				if (3 == valuetype)
				{
					item.Count = shopItem.CUnit;
				}
			}
			item.Color = color ?? "";
			item.Skin = skin ?? "";
			if (isBinding)
			{
				item.IsBinds = true;
			}
			else
			{
				item.IsBinds = Convert.ToBoolean(shopItem.IsBind);
			}
			return item;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x000211EC File Offset: 0x0001F3EC
		public static bool isTypeIn(ShopItemInfo shopItem, int type)
		{
			return (type == 1 && shopItem.AUnit != -1) || (type == 2 && shopItem.BUnit != -1) || (type == 3 && shopItem.CUnit != -1);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0002121C File Offset: 0x0001F41C
		private static List<int> InitNotice()
		{
			List<int> temp = new List<int>();
			for (int i = 0; i < 4; i++)
			{
				temp.Add(i + 1);
			}
			return temp;
		}

		// Token: 0x040000E1 RID: 225
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x040000E2 RID: 226
		private static Dictionary<int, ShopItemInfo> m_shop = new Dictionary<int, ShopItemInfo>();

		// Token: 0x040000E3 RID: 227
		private static Dictionary<int, int> m_LimitCount = new Dictionary<int, int>();

		// Token: 0x040000E4 RID: 228
		private static Dictionary<int, List<int>> m_isNoticeInfos = new Dictionary<int, List<int>>();

		// Token: 0x040000E5 RID: 229
		private static ReaderWriterLock m_lock = new ReaderWriterLock();
	}
}
