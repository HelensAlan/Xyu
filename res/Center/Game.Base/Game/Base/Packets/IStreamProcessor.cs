using System;

namespace Game.Base.Packets
{
	// Token: 0x0200001B RID: 27
	public interface IStreamProcessor
	{
		// Token: 0x060000F4 RID: 244
		void SetFsm(int adder, int muliter);

		// Token: 0x060000F5 RID: 245
		void SendTCP(GSPacketIn pkg);

		// Token: 0x060000F6 RID: 246
		void ReceiveBytes(int numBytes);

		// Token: 0x060000F7 RID: 247
		void Dispose();
	}
}
