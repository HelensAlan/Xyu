using System;

namespace Bussiness
{
	// Token: 0x02000005 RID: 5
	public class Base64
	{
		// Token: 0x0600002A RID: 42 RVA: 0x00003738 File Offset: 0x00001938
		public static string encodeByteArray(byte[] data)
		{
			string output = "";
			byte[] outputBuffer = new byte[4];
			for (int i = 0; i < data.Length; i += 4)
			{
				byte[] dataBuffer = new byte[3];
				for (int j = 0; j < data.Length; j++)
				{
					if (j < 3)
					{
						if (j + i > data.Length)
						{
							break;
						}
						dataBuffer[j] = data[j + i];
					}
				}
				outputBuffer[0] = (byte)((dataBuffer[0] & 252) >> 2);
				outputBuffer[1] = (byte)(((int)(dataBuffer[0] & 3) << 4) | (dataBuffer[1] >> 4));
				outputBuffer[2] = (byte)(((int)(dataBuffer[1] & 15) << 2) | (dataBuffer[2] >> 6));
				outputBuffer[3] = dataBuffer[2] & 63;
				for (int k = dataBuffer.Length; k < 3; k++)
				{
					outputBuffer[k + 1] = 64;
				}
				for (int l = 0; l < outputBuffer.Length; l++)
				{
					output += Base64.BASE64_CHARS.Substring((int)outputBuffer[l], 1);
				}
			}
			output = output.Substring(0, data.Length - 1);
			return output + "=";
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003830 File Offset: 0x00001A30
		public static byte[] decodeToByteArray(string data)
		{
			byte[] output = new byte[data.Length];
			byte[] dataBuffer = new byte[4];
			byte[] outputBuffer = new byte[3];
			for (int i = 0; i < data.Length; i += 4)
			{
				int j = 0;
				while (j < 4 && i + j < data.Length)
				{
					dataBuffer[j] = (byte)Base64.BASE64_CHARS.IndexOf(data.Substring(i + j, 1));
					j++;
				}
				outputBuffer[0] = (byte)(((int)dataBuffer[0] << 2) + ((dataBuffer[1] & 48) >> 4));
				outputBuffer[1] = (byte)(((int)(dataBuffer[1] & 15) << 4) + ((dataBuffer[2] & 60) >> 2));
				outputBuffer[2] = (byte)(((int)(dataBuffer[2] & 3) << 6) + (int)dataBuffer[3]);
				int k = 0;
				while (k < outputBuffer.Length && dataBuffer[k + 1] != 64)
				{
					output[i + k] = outputBuffer[k];
					k++;
				}
			}
			return output;
		}

		// Token: 0x04000010 RID: 16
		public static string version = "1.0.0";

		// Token: 0x04000011 RID: 17
		private static string BASE64_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
	}
}
