using System;
using System.IO;
using System.Text;
using ComponentAce.Compression.Libs.zlib;

namespace Game.Base
{
	// Token: 0x02000012 RID: 18
	public class Marshal
	{
		// Token: 0x0600007A RID: 122 RVA: 0x00003DF0 File Offset: 0x00001FF0
		public static string ConvertToString(byte[] cstyle)
		{
			string result;
			if (cstyle == null)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < cstyle.Length; i++)
				{
					if (cstyle[i] == 0)
					{
						return Encoding.Default.GetString(cstyle, 0, i);
					}
				}
				result = Encoding.Default.GetString(cstyle);
			}
			return result;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003E34 File Offset: 0x00002034
		public static int ConvertToInt32(byte[] val)
		{
			return Marshal.ConvertToInt32(val, 0);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003E3D File Offset: 0x0000203D
		public static int ConvertToInt32(byte[] val, int startIndex)
		{
			return Marshal.ConvertToInt32(val[startIndex], val[startIndex + 1], val[startIndex + 2], val[startIndex + 3]);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003E56 File Offset: 0x00002056
		public static int ConvertToInt32(byte v1, byte v2, byte v3, byte v4)
		{
			return ((int)v1 << 24) | ((int)v2 << 16) | ((int)v3 << 8) | (int)v4;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003E67 File Offset: 0x00002067
		public static uint ConvertToUInt32(byte[] val)
		{
			return Marshal.ConvertToUInt32(val, 0);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003E70 File Offset: 0x00002070
		public static uint ConvertToUInt32(byte[] val, int startIndex)
		{
			return Marshal.ConvertToUInt32(val[startIndex], val[startIndex + 1], val[startIndex + 2], val[startIndex + 3]);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003E89 File Offset: 0x00002089
		public static uint ConvertToUInt32(byte v1, byte v2, byte v3, byte v4)
		{
			return (uint)(((int)v1 << 24) | ((int)v2 << 16) | ((int)v3 << 8) | (int)v4);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003E9A File Offset: 0x0000209A
		public static short ConvertToInt16(byte[] val)
		{
			return Marshal.ConvertToInt16(val, 0);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003EA3 File Offset: 0x000020A3
		public static short ConvertToInt16(byte[] val, int startIndex)
		{
			return Marshal.ConvertToInt16(val[startIndex], val[startIndex + 1]);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003EB2 File Offset: 0x000020B2
		public static short ConvertToInt16(byte v1, byte v2)
		{
			return (short)(((int)v1 << 8) | (int)v2);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003EBA File Offset: 0x000020BA
		public static ushort ConvertToUInt16(byte[] val)
		{
			return Marshal.ConvertToUInt16(val, 0);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003EC3 File Offset: 0x000020C3
		public static ushort ConvertToUInt16(byte[] val, int startIndex)
		{
			return Marshal.ConvertToUInt16(val[startIndex], val[startIndex + 1]);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003ED2 File Offset: 0x000020D2
		public static ushort ConvertToUInt16(byte v1, byte v2)
		{
			return (ushort)((int)v2 | ((int)v1 << 8));
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003EDA File Offset: 0x000020DA
		public static string ToHexDump(string description, byte[] dump)
		{
			return Marshal.ToHexDump(description, dump, 0, dump.Length);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003EE8 File Offset: 0x000020E8
		public static string ToHexDump(string description, byte[] dump, int start, int count)
		{
			StringBuilder hexDump = new StringBuilder();
			if (description != null)
			{
				hexDump.Append(description).Append("\n");
			}
			int end = start + count;
			for (int i = start; i < end; i += 16)
			{
				StringBuilder text = new StringBuilder();
				StringBuilder hex = new StringBuilder();
				hex.Append(i.ToString("X4"));
				hex.Append(": ");
				for (int j = 0; j < 16; j++)
				{
					if (j + i < end)
					{
						byte val = dump[j + i];
						hex.Append(dump[j + i].ToString("X2"));
						hex.Append(" ");
						if (val >= 32 && val <= 127)
						{
							text.Append((char)val);
						}
						else
						{
							text.Append(".");
						}
					}
					else
					{
						hex.Append("   ");
						text.Append(" ");
					}
				}
				hex.Append("  ");
				hex.Append(text.ToString());
				hex.Append('\n');
				hexDump.Append(hex.ToString());
			}
			return hexDump.ToString();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004018 File Offset: 0x00002218
		public static byte[] Compress(byte[] src)
		{
			return Marshal.Compress(src, 0, src.Length);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00004024 File Offset: 0x00002224
		public static byte[] Compress(byte[] src, int offset, int length)
		{
			MemoryStream memoryStream = new MemoryStream();
			ZOutputStream zoutputStream = new ZOutputStream(memoryStream, 9);
			zoutputStream.Write(src, offset, length);
			zoutputStream.Close();
			return memoryStream.ToArray();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00004046 File Offset: 0x00002246
		public static byte[] Uncompress(byte[] src)
		{
			MemoryStream memoryStream = new MemoryStream();
			ZOutputStream zoutputStream = new ZOutputStream(memoryStream);
			zoutputStream.Write(src, 0, src.Length);
			zoutputStream.Close();
			return memoryStream.ToArray();
		}
	}
}
