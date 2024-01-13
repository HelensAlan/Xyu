using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using log4net;

namespace Bussiness
{
	// Token: 0x0200000E RID: 14
	public class LanguageMgr
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600009A RID: 154 RVA: 0x0000B67F File Offset: 0x0000987F
		private static string LanguageFile
		{
			get
			{
				return ConfigurationManager.AppSettings["LanguagePath"];
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000B690 File Offset: 0x00009890
		public static bool Setup(string path)
		{
			return LanguageMgr.Reload(path);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000B698 File Offset: 0x00009898
		public static bool Reload(string path)
		{
			try
			{
				Hashtable temp = LanguageMgr.LoadLanguage(path);
				if (temp.Count > 0)
				{
					Interlocked.Exchange<Hashtable>(ref LanguageMgr.LangsSentences, temp);
					return true;
				}
			}
			catch (Exception ex)
			{
				LanguageMgr.log.Error("Load language file error:", ex);
			}
			return false;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000B6F0 File Offset: 0x000098F0
		private static Hashtable LoadLanguage(string path)
		{
			Hashtable list = new Hashtable();
			string filePath = path + LanguageMgr.LanguageFile;
			if (!File.Exists(filePath))
			{
				LanguageMgr.log.Error("Language file : " + filePath + " not found !");
			}
			else
			{
				foreach (object obj in ((IEnumerable)new ArrayList(File.ReadAllLines(filePath, Encoding.UTF8))))
				{
					string line = (string)obj;
					if (!line.StartsWith("#") && line.IndexOf(':') != -1)
					{
						string[] splitted = new string[]
						{
							line.Substring(0, line.IndexOf(':')),
							line.Substring(line.IndexOf(':') + 1)
						};
						splitted[1] = splitted[1].Replace("\t", "");
						list[splitted[0]] = splitted[1];
					}
				}
			}
			return list;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000B7F4 File Offset: 0x000099F4
		public static string GetTranslation(string translateId, params object[] args)
		{
			string result;
			if (LanguageMgr.LangsSentences.ContainsKey(translateId))
			{
				string translated = (string)LanguageMgr.LangsSentences[translateId];
				try
				{
					translated = string.Format(translated, args);
				}
				catch (Exception ex)
				{
					LanguageMgr.log.Error(string.Concat(new object[] { "Parameters number error, ID: ", translateId, " (Arg count=", args.Length, ")" }), ex);
				}
				result = translated ?? translateId;
			}
			else
			{
				result = translateId;
			}
			return result;
		}

		// Token: 0x0400009C RID: 156
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x0400009D RID: 157
		private static Hashtable LangsSentences = new Hashtable();
	}
}
