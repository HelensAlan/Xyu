using System;
using System.IO;
using System.Reflection;

namespace Game.Base
{
	// Token: 0x02000014 RID: 20
	public class ResourceUtil
	{
		// Token: 0x060000B8 RID: 184 RVA: 0x00004BFC File Offset: 0x00002DFC
		public static Stream GetResourceStream(string fileName, Assembly assem)
		{
			fileName = fileName.ToLower();
			foreach (string name in assem.GetManifestResourceNames())
			{
				if (name.ToLower().EndsWith(fileName))
				{
					return assem.GetManifestResourceStream(name);
				}
			}
			return null;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00004C41 File Offset: 0x00002E41
		public static void ExtractResource(string fileName, Assembly assembly)
		{
			ResourceUtil.ExtractResource(fileName, fileName, assembly);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004C4C File Offset: 0x00002E4C
		public static void ExtractResource(string resourceName, string fileName, Assembly assembly)
		{
			FileInfo finfo = new FileInfo(fileName);
			if (!finfo.Directory.Exists)
			{
				finfo.Directory.Create();
			}
			using (StreamReader reader = new StreamReader(ResourceUtil.GetResourceStream(resourceName, assembly)))
			{
				using (StreamWriter writer = new StreamWriter(File.Create(fileName)))
				{
					writer.Write(reader.ReadToEnd());
				}
			}
		}
	}
}
