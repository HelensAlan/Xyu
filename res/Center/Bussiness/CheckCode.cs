using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Bussiness
{
	// Token: 0x02000007 RID: 7
	public class CheckCode
	{
		// Token: 0x06000036 RID: 54 RVA: 0x00003DC4 File Offset: 0x00001FC4
		public static byte[] CreateImage(string randomcode)
		{
			int randAngle = 30;
			Bitmap map = new Bitmap(randomcode.Length * 30, 36);
			Graphics graph = Graphics.FromImage(map);
			byte[] result;
			try
			{
				graph.Clear(Color.White);
				int cindex = CheckCode.random.Next(7);
				Brush b = new SolidBrush(CheckCode.c[cindex]);
				for (int i = 0; i < 1; i++)
				{
					int x = CheckCode.random.Next(map.Width / 2);
					int x2 = CheckCode.random.Next(map.Width * 3 / 4, map.Width);
					int y = CheckCode.random.Next(map.Height);
					int y2 = CheckCode.random.Next(map.Height);
					graph.DrawBezier(new Pen(CheckCode.c[cindex], 2f), (float)x, (float)y, (float)((x + x2) / 4), 0f, (float)((x + x2) * 3 / 4), (float)map.Height, (float)x2, (float)y2);
				}
				char[] chars = randomcode.ToCharArray();
				StringFormat format = new StringFormat(StringFormatFlags.NoClip)
				{
					Alignment = StringAlignment.Center,
					LineAlignment = StringAlignment.Center
				};
				for (int j = 0; j < chars.Length; j++)
				{
					int findex = CheckCode.random.Next(5);
					Font f = new Font(CheckCode.font[findex], 22f, FontStyle.Bold);
					Point dot = new Point(16, 16);
					float angle = (float)CheckCode.random.Next(-randAngle, randAngle);
					graph.TranslateTransform((float)dot.X, (float)dot.Y);
					graph.RotateTransform(angle);
					graph.DrawString(chars[j].ToString(), f, b, 1f, 1f, format);
					graph.RotateTransform(-angle);
					graph.TranslateTransform(2f, -(float)dot.Y);
				}
				MemoryStream ms = new MemoryStream();
				map.Save(ms, ImageFormat.Gif);
				result = ms.ToArray();
			}
			finally
			{
				graph.Dispose();
				map.Dispose();
			}
			return result;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003FE8 File Offset: 0x000021E8
		private static string GenerateRandomString(int length, CheckCode.RandomStringMode mode)
		{
			string rndStr = string.Empty;
			string result;
			if (length == 0)
			{
				result = rndStr;
			}
			else
			{
				new int[2];
				switch (mode)
				{
				case CheckCode.RandomStringMode.LowerLetter:
					for (int i = 0; i < length; i++)
					{
						rndStr += CheckCode.lowerLetters[CheckCode.random.Next(0, CheckCode.lowerLetters.Length)].ToString();
					}
					break;
				case CheckCode.RandomStringMode.UpperLetter:
					for (int j = 0; j < length; j++)
					{
						rndStr += CheckCode.upperLetters[CheckCode.random.Next(0, CheckCode.upperLetters.Length)].ToString();
					}
					break;
				case CheckCode.RandomStringMode.Letter:
					for (int k = 0; k < length; k++)
					{
						rndStr += CheckCode.letters[CheckCode.random.Next(0, CheckCode.letters.Length)].ToString();
					}
					break;
				case CheckCode.RandomStringMode.Digital:
					for (int l = 0; l < length; l++)
					{
						rndStr += CheckCode.digitals[CheckCode.random.Next(0, CheckCode.digitals.Length)].ToString();
					}
					break;
				default:
					for (int m = 0; m < length; m++)
					{
						rndStr += CheckCode.mix[CheckCode.random.Next(0, CheckCode.mix.Length)].ToString();
					}
					break;
				}
				result = rndStr;
			}
			return result;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00004148 File Offset: 0x00002348
		public static string GenerateCheckCode()
		{
			return CheckCode.GenerateRandomString(4, CheckCode.RandomStringMode.Digital);
		}

		// Token: 0x04000014 RID: 20
		public static ThreadSafeRandom random = new ThreadSafeRandom();

		// Token: 0x04000015 RID: 21
		private static Color[] c = new Color[]
		{
			Color.Black,
			Color.Red,
			Color.DarkBlue,
			Color.Green,
			Color.Orange,
			Color.Brown,
			Color.DarkCyan,
			Color.Purple
		};

		// Token: 0x04000016 RID: 22
		private static string[] font = new string[] { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };

		// Token: 0x04000017 RID: 23
		private static char[] digitals = new char[] { '2', '3', '4', '6', '7', '8', '9' };

		// Token: 0x04000018 RID: 24
		private static char[] lowerLetters = new char[]
		{
			'a', 'b', 'c', 'd', 'e', 'f', 'h', 'k', 'm', 'n',
			'p', 'q', 'r', 't', 'u', 'w', 'x', 'y', 'z'
		};

		// Token: 0x04000019 RID: 25
		private static char[] upperLetters = new char[]
		{
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'K', 'M',
			'N', 'P', 'Q', 'R', 'T', 'U', 'W', 'X', 'Y', 'Z'
		};

		// Token: 0x0400001A RID: 26
		private static char[] letters = new char[]
		{
			'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
			'k', 'm', 'n', 'p', 'q', 'r', 't', 'u', 'w', 'x',
			'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
			'I', 'J', 'K', 'M', 'N', 'P', 'Q', 'R', 'T', 'U',
			'W', 'X', 'Y', 'Z'
		};

		// Token: 0x0400001B RID: 27
		private static char[] mix = new char[]
		{
			'2', '3', '4', '6', '7', '8', '9', 'a', 'b', 'c',
			'd', 'e', 'f', 'h', 'k', 'm', 'n', 'p', 'q', 'r',
			't', 'u', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D',
			'E', 'F', 'G', 'H', 'K', 'M', 'N', 'P', 'Q', 'R',
			'T', 'U', 'W', 'X', 'Y', 'Z'
		};

		// Token: 0x02000032 RID: 50
		private enum RandomStringMode
		{
			// Token: 0x04000101 RID: 257
			LowerLetter,
			// Token: 0x04000102 RID: 258
			UpperLetter,
			// Token: 0x04000103 RID: 259
			Letter,
			// Token: 0x04000104 RID: 260
			Digital,
			// Token: 0x04000105 RID: 261
			Mix
		}
	}
}
