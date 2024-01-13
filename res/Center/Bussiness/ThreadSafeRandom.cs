using System;

namespace Bussiness
{
	// Token: 0x02000017 RID: 23
	public class ThreadSafeRandom
	{
		// Token: 0x0600018F RID: 399 RVA: 0x0001E234 File Offset: 0x0001C434
		public int Next()
		{
			Random obj = this.random;
			int result;
			lock (obj)
			{
				result = this.random.Next();
			}
			return result;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0001E27C File Offset: 0x0001C47C
		public int Next(int maxValue)
		{
			Random obj = this.random;
			int result;
			lock (obj)
			{
				result = this.random.Next(maxValue);
			}
			return result;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0001E2C4 File Offset: 0x0001C4C4
		public int Next(int minValue, int maxValue)
		{
			Random obj = this.random;
			int result;
			lock (obj)
			{
				result = this.random.Next(minValue, maxValue);
			}
			return result;
		}

		// Token: 0x0400009F RID: 159
		private Random random = new Random();
	}
}
