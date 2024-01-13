using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Bussiness
{
	// Token: 0x0200001A RID: 26
	public static class XmlExtends
	{
		// Token: 0x0600019C RID: 412 RVA: 0x0001E65C File Offset: 0x0001C85C
		public static string ToString(this XElement node, bool check)
		{
			StringBuilder sb = new StringBuilder();
			using (XmlWriter xw = XmlWriter.Create(sb, new XmlWriterSettings
			{
				CheckCharacters = check,
				OmitXmlDeclaration = true,
				Indent = true
			}))
			{
				node.WriteTo(xw);
			}
			return sb.ToString();
		}
	}
}
