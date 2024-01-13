using System;

namespace Road.Base.Packets
{
	// Token: 0x02000003 RID: 3
	public class FSM
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000021AC File Offset: 0x000003AC
		public int getState()
		{
			return this._state;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021B4 File Offset: 0x000003B4
		public int getAdder()
		{
			return this._adder;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021BC File Offset: 0x000003BC
		public int getMulitper()
		{
			return this._mulitper;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021C4 File Offset: 0x000003C4
		public FSM(int adder, int mulitper, string objname)
		{
			this.name = objname;
			this.count = 0;
			this._adder = adder;
			this._mulitper = mulitper;
			this.UpdateState();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021EF File Offset: 0x000003EF
		public void Setup(int adder, int mulitper)
		{
			this._adder = adder;
			this._mulitper = mulitper;
			this.UpdateState();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002208 File Offset: 0x00000408
		public int UpdateState()
		{
			this._state = (~this._state + this._adder) * this._mulitper;
			this._state ^= this._state >> 16;
			this.count++;
			return this._state;
		}

		// Token: 0x04000007 RID: 7
		private int _adder;

		// Token: 0x04000008 RID: 8
		private int _mulitper;

		// Token: 0x04000009 RID: 9
		private int _state;

		// Token: 0x0400000A RID: 10
		public int count;

		// Token: 0x0400000B RID: 11
		public string name;
	}
}
