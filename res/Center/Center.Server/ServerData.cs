using System;
using System.Runtime.Serialization;

namespace Center.Server
{
	// Token: 0x02000012 RID: 18
	[DataContract]
	public class ServerData
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00002514 File Offset: 0x00000714
		// (set) Token: 0x060000BB RID: 187 RVA: 0x0000251C File Offset: 0x0000071C
		[DataMember]
		public int Id { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00002525 File Offset: 0x00000725
		// (set) Token: 0x060000BD RID: 189 RVA: 0x0000252D File Offset: 0x0000072D
		[DataMember]
		public string Name { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00002536 File Offset: 0x00000736
		// (set) Token: 0x060000BF RID: 191 RVA: 0x0000253E File Offset: 0x0000073E
		[DataMember]
		public string Ip { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00002547 File Offset: 0x00000747
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x0000254F File Offset: 0x0000074F
		[DataMember]
		public int Port { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00002558 File Offset: 0x00000758
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x00002560 File Offset: 0x00000760
		[DataMember]
		public int State { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00002569 File Offset: 0x00000769
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00002571 File Offset: 0x00000771
		[DataMember]
		public int MustLevel { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x0000257A File Offset: 0x0000077A
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x00002582 File Offset: 0x00000782
		[DataMember]
		public int LowestLevel { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x0000258B File Offset: 0x0000078B
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x00002593 File Offset: 0x00000793
		[DataMember]
		public int Online { get; set; }
	}
}
