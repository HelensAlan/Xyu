using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;

namespace Game.Base.Config
{
	// Token: 0x0200002A RID: 42
	public class XMLConfigFile : ConfigElement
	{
		// Token: 0x0600014B RID: 331 RVA: 0x00006F3B File Offset: 0x0000513B
		public XMLConfigFile()
			: base(null)
		{
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00006F44 File Offset: 0x00005144
		protected XMLConfigFile(ConfigElement parent)
			: base(parent)
		{
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00006F50 File Offset: 0x00005150
		protected bool IsBadXMLElementName(string name)
		{
			return name != null && (name.IndexOf("\\") != -1 || name.IndexOf("/") != -1 || name.IndexOf("<") != -1 || name.IndexOf(">") != -1);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00006FA0 File Offset: 0x000051A0
		protected void SaveElement(XmlTextWriter writer, string name, ConfigElement element)
		{
			bool badName = this.IsBadXMLElementName(name);
			if (element.HasChildren)
			{
				if (name == null)
				{
					name = "root";
				}
				if (badName)
				{
					writer.WriteStartElement("param");
					writer.WriteAttributeString("name", name);
				}
				else
				{
					writer.WriteStartElement(name);
				}
				foreach (object obj in element.Children)
				{
					DictionaryEntry entry = (DictionaryEntry)obj;
					this.SaveElement(writer, (string)entry.Key, (ConfigElement)entry.Value);
				}
				writer.WriteEndElement();
				return;
			}
			if (name != null)
			{
				if (badName)
				{
					writer.WriteStartElement("param");
					writer.WriteAttributeString("name", name);
					writer.WriteString(element.GetString());
					writer.WriteEndElement();
					return;
				}
				writer.WriteElementString(name, element.GetString());
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00007098 File Offset: 0x00005298
		public void Save(FileInfo configFile)
		{
			if (configFile.Exists)
			{
				configFile.Delete();
			}
			XmlTextWriter writer = new XmlTextWriter(configFile.FullName, Encoding.UTF8);
			writer.Formatting = Formatting.Indented;
			writer.WriteStartDocument();
			this.SaveElement(writer, null, this);
			writer.WriteEndDocument();
			writer.Close();
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000070E8 File Offset: 0x000052E8
		public static XMLConfigFile ParseXMLFile(FileInfo configFile)
		{
			XMLConfigFile root = new XMLConfigFile(null);
			XMLConfigFile result;
			if (!configFile.Exists)
			{
				result = root;
			}
			else
			{
				ConfigElement current = root;
				XmlTextReader reader = new XmlTextReader(configFile.OpenRead());
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element)
					{
						if (!(reader.Name == "root"))
						{
							if (reader.Name == "param")
							{
								string name = reader.GetAttribute("name");
								if (name != null && name != "root")
								{
									ConfigElement newElement = new ConfigElement(current);
									current[name] = newElement;
									current = newElement;
								}
							}
							else
							{
								ConfigElement newElement2 = new ConfigElement(current);
								current[reader.Name] = newElement2;
								current = newElement2;
							}
						}
					}
					else if (reader.NodeType == XmlNodeType.Text)
					{
						current.Set(reader.Value);
					}
					else if (reader.NodeType == XmlNodeType.EndElement && reader.Name != "root")
					{
						current = current.Parent;
					}
				}
				reader.Close();
				result = root;
			}
			return result;
		}
	}
}
