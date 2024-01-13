using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using Bussiness.CenterService;
using log4net;
using Lsj.Util.Encrypt;
using SqlDataProvider.Data;

namespace Bussiness.Interface
{
	// Token: 0x02000027 RID: 39
	public abstract class BaseInterface
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00021283 File Offset: 0x0001F483
		public static string GetInterName
		{
			get
			{
				return ConfigurationManager.AppSettings["InterName"].ToLower();
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000206 RID: 518 RVA: 0x00021299 File Offset: 0x0001F499
		public static string GetLoginKey
		{
			get
			{
				return ConfigurationManager.AppSettings["LoginKey"];
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000207 RID: 519 RVA: 0x000212AA File Offset: 0x0001F4AA
		public static string GetChargeKey
		{
			get
			{
				return ConfigurationManager.AppSettings["ChargeKey"];
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000208 RID: 520 RVA: 0x000212BB File Offset: 0x0001F4BB
		public static string LoginUrl
		{
			get
			{
				return ConfigurationManager.AppSettings["LoginUrl"];
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000209 RID: 521 RVA: 0x000212CC File Offset: 0x0001F4CC
		public virtual int ActiveGold
		{
			get
			{
				return int.Parse(ConfigurationManager.AppSettings["DefaultGold"]);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600020A RID: 522 RVA: 0x000212E2 File Offset: 0x0001F4E2
		public virtual int ActiveMoney
		{
			get
			{
				return int.Parse(ConfigurationManager.AppSettings["DefaultMoney"]);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600020B RID: 523 RVA: 0x000212F8 File Offset: 0x0001F4F8
		public virtual int ActiveGiftToken
		{
			get
			{
				return int.Parse(ConfigurationManager.AppSettings["DefaultGiftToken"]);
			}
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0002130E File Offset: 0x0001F50E
		public static string GetNameBySite(string user, string site)
		{
			if (!string.IsNullOrEmpty(site) && !string.IsNullOrEmpty(ConfigurationManager.AppSettings[string.Format("LoginKey_{0}", site)]))
			{
				user = string.Format("{0}_{1}", site, user);
			}
			return user;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00021344 File Offset: 0x0001F544
		public static DateTime ConvertIntDateTime(double d)
		{
			DateTime minValue = DateTime.MinValue;
			return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(d);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00021378 File Offset: 0x0001F578
		public static int ConvertDateTimeInt(DateTime time)
		{
			DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			return (int)(time - startTime).TotalSeconds;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x000213AC File Offset: 0x0001F5AC
		public static string md5(string str)
		{
			return MD5.GetMD5String(str).ToLower();
		}

		// Token: 0x06000210 RID: 528 RVA: 0x000213B9 File Offset: 0x0001F5B9
		public static string RequestContent(string Url)
		{
			return BaseInterface.RequestContent(Url, 2560);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x000213C8 File Offset: 0x0001F5C8
		public static string RequestContent(string Url, int byteLength)
		{
			byte[] buf = new byte[byteLength];
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
			httpWebRequest.ContentType = "text/plain";
			Stream resStream = ((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream();
			int count = resStream.Read(buf, 0, buf.Length);
			string @string = Encoding.UTF8.GetString(buf, 0, count);
			resStream.Close();
			return @string;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00021424 File Offset: 0x0001F624
		public static string RequestContent(string Url, string param, string code)
		{
			Encoding encoding = Encoding.GetEncoding(code);
			byte[] bs = encoding.GetBytes(param);
			encoding.GetString(bs);
			byte[] buf = new byte[2560];
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
			req.ServicePoint.Expect100Continue = false;
			req.Method = "POST";
			req.ContentType = "application/x-www-form-urlencoded";
			req.ContentLength = (long)bs.Length;
			using (Stream reqStream = req.GetRequestStream())
			{
				reqStream.Write(bs, 0, bs.Length);
			}
			string result2;
			using (WebResponse wr = req.GetResponse())
			{
				int count = ((HttpWebResponse)wr).GetResponseStream().Read(buf, 0, buf.Length);
				result2 = Encoding.UTF8.GetString(buf, 0, count);
			}
			return result2;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00021508 File Offset: 0x0001F708
		public static BaseInterface CreateInterface()
		{
			string getInterName = BaseInterface.GetInterName;
			if (getInterName != null)
			{
				if (getInterName == "qunying")
				{
					return new QYInterface();
				}
				if (getInterName == "sevenroad")
				{
					return new SRInterface();
				}
				if (getInterName == "duowan")
				{
					return new DWInterface();
				}
			}
			return null;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00021558 File Offset: 0x0001F758
		public virtual PlayerInfo CreateLogin(string name, string password, ref string message, ref int isFirst, string IP, ref bool isError, bool firstValidate, ref bool isActive, string site, string nickname)
		{
			try
			{
				using (PlayerBussiness db = new PlayerBussiness())
				{
					bool isExist = true;
					DateTime forbidDate = DateTime.Now;
					PlayerInfo info = db.LoginGame(name, ref isFirst, ref isExist, ref isError, firstValidate, ref forbidDate, nickname);
					if (info == null)
					{
						if (!db.ActivePlayer(ref info, name, password, true, this.ActiveGold, this.ActiveMoney, this.ActiveGiftToken, IP, site))
						{
							info = null;
							message = LanguageMgr.GetTranslation("BaseInterface.LoginAndUpdate.Fail", new object[0]);
							goto IL_126;
						}
						isActive = true;
						using (CenterServiceClient client = new CenterServiceClient())
						{
							client.ActivePlayer(true);
							goto IL_126;
						}
					}
					if (!isExist)
					{
						message = LanguageMgr.GetTranslation("ManageBussiness.Forbid1", new object[] { forbidDate.Year, forbidDate.Month, forbidDate.Day, forbidDate.Hour, forbidDate.Minute });
						return null;
					}
					using (CenterServiceClient client2 = new CenterServiceClient())
					{
						if (!client2.CreatePlayer(info.ID, name, password, isFirst == 0))
						{
							BaseInterface.log.Error("发送中心服务器失败");
						}
					}
					IL_126:
					return info;
				}
			}
			catch (Exception ex)
			{
				BaseInterface.log.Error("LoginAndUpdate", ex);
			}
			return null;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00021718 File Offset: 0x0001F918
		public virtual PlayerInfo LoginGame(string name, string pass, ref bool isFirst)
		{
			try
			{
				using (CenterServiceClient client = new CenterServiceClient())
				{
					int userID = 0;
					if (client.ValidateLoginAndGetID(name, pass, ref userID, ref isFirst))
					{
						return new PlayerInfo
						{
							ID = userID,
							UserName = name
						};
					}
				}
			}
			catch (Exception ex)
			{
				BaseInterface.log.Error("LoginGame", ex);
			}
			return null;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00021790 File Offset: 0x0001F990
		public virtual string[] UnEncryptLogin(string content, ref int result, string site)
		{
			try
			{
				string key = string.Empty;
				if (!string.IsNullOrEmpty(site))
				{
					key = ConfigurationManager.AppSettings[string.Format("LoginKey_{0}", site)];
				}
				if (string.IsNullOrEmpty(key))
				{
					key = BaseInterface.GetLoginKey;
				}
				if (!string.IsNullOrEmpty(key))
				{
					string[] str = content.Split(new char[] { '|' });
					if (str.Length > 3)
					{
						if (BaseInterface.md5(str[0] + str[1] + str[2] + key) == str[3].ToLower())
						{
							return str;
						}
						result = 5;
					}
					else
					{
						result = 2;
					}
				}
				else
				{
					result = 4;
				}
			}
			catch (Exception ex)
			{
				BaseInterface.log.Error("UnEncryptLogin", ex);
			}
			return new string[0];
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00021850 File Offset: 0x0001FA50
		public virtual string[] UnEncryptCharge(string content, ref int result, string site)
		{
			try
			{
				string key = string.Empty;
				if (!string.IsNullOrEmpty(site))
				{
					key = ConfigurationManager.AppSettings[string.Format("ChargeKey_{0}", site)];
				}
				if (string.IsNullOrEmpty(key))
				{
					key = BaseInterface.GetChargeKey;
				}
				if (!string.IsNullOrEmpty(key))
				{
					string[] str = content.Split(new char[] { '|' });
					string v = BaseInterface.md5(string.Concat(new string[]
					{
						str[0],
						str[1],
						str[2],
						str[3],
						str[4],
						key
					}));
					if (str.Length > 5)
					{
						if (v == str[5].ToLower())
						{
							return str;
						}
						result = 7;
					}
					else
					{
						result = 8;
					}
				}
				else
				{
					result = 6;
				}
			}
			catch (Exception ex)
			{
				BaseInterface.log.Error("UnEncryptCharge", ex);
			}
			return new string[0];
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00021934 File Offset: 0x0001FB34
		public virtual string[] UnEncryptSentReward(string content, ref int result, string key)
		{
			try
			{
				string[] str = content.Split(new char[] { '#' });
				if (str.Length == 8)
				{
					string str_spanTime = ConfigurationManager.AppSettings["SentRewardTimeSpan"];
					int int_spantime = int.Parse(string.IsNullOrEmpty(str_spanTime) ? "1" : str_spanTime);
					TimeSpan timeSpan = (string.IsNullOrEmpty(str[6]) ? new TimeSpan(1, 1, 1) : (DateTime.Now - BaseInterface.ConvertIntDateTime(double.Parse(str[6]))));
					if (timeSpan.Days == 0 && timeSpan.Hours == 0 && timeSpan.Minutes < int_spantime)
					{
						if (string.IsNullOrEmpty(key))
						{
							return str;
						}
						if (BaseInterface.md5(string.Concat(new string[]
						{
							str[2],
							str[3],
							str[4],
							str[5],
							str[6],
							key
						})) == str[7].ToLower())
						{
							return str;
						}
						result = 5;
					}
					else
					{
						result = 7;
					}
				}
				else
				{
					result = 6;
				}
			}
			catch (Exception ex)
			{
				BaseInterface.log.Error("UnEncryptSentReward", ex);
			}
			return new string[0];
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00021A5C File Offset: 0x0001FC5C
		public virtual bool GameServerSendAreaBigBugle(int userid, int areaid, string nickName, string message, string areaName)
		{
			try
			{
				using (CenterServiceClient client = new CenterServiceClient())
				{
					if (client.GameServerSendAreaBigBugle(userid, areaid, nickName, message, areaName))
					{
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				BaseInterface.log.Error("SendAreaBigBugle", ex);
			}
			return false;
		}

		// Token: 0x040000E6 RID: 230
		protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
	}
}
