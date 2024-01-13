using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Bussiness
{
	// Token: 0x0200000D RID: 13
	public class IniReader
	{
		// Token: 0x06000097 RID: 151
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		// Token: 0x06000098 RID: 152 RVA: 0x0000B636 File Offset: 0x00009836
		public IniReader(string _FilePath)
		{
			this.FilePath = _FilePath;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000B648 File Offset: 0x00009848
		public string GetIniString(string Section, string Key)
		{
			StringBuilder temp = new StringBuilder(2550);
			IniReader.GetPrivateProfileString(Section, Key, "", temp, 2550, this.FilePath);
			return temp.ToString();
		}

		// Token: 0x0400009B RID: 155
		private string FilePath;
	}
}
