using System;
using System.Threading;

namespace Game.Base.Packets
{
	// Token: 0x02000019 RID: 25
	internal class EmptyAsyncResult : IAsyncResult
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00005451 File Offset: 0x00003651
		public object AsyncState
		{
			get
			{
				return this.m_asyncState;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00005459 File Offset: 0x00003659
		public WaitHandle AsyncWaitHandle
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00005460 File Offset: 0x00003660
		public bool CompletedSynchronously
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00005467 File Offset: 0x00003667
		public bool IsCompleted
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000546E File Offset: 0x0000366E
		public EmptyAsyncResult(object state)
		{
			this.m_asyncState = state;
		}

		// Token: 0x04000058 RID: 88
		private object m_asyncState;
	}
}
