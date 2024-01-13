using System;
using System.Runtime.Serialization;

namespace Center.GMService.DataContracts
{
	// Token: 0x02000009 RID: 9
	[DataContract]
	public class ChargeRewardInfo
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00003E50 File Offset: 0x00002050
		// (set) Token: 0x06000024 RID: 36 RVA: 0x00003E58 File Offset: 0x00002058
		[DataMember]
		public int LowerLimit { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00003E61 File Offset: 0x00002061
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00003E69 File Offset: 0x00002069
		[DataMember]
		public int UpperLimit { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00003E72 File Offset: 0x00002072
		// (set) Token: 0x06000028 RID: 40 RVA: 0x00003E7A File Offset: 0x0000207A
		[DataMember]
		public DateTime StartTime { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00003E83 File Offset: 0x00002083
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00003E8B File Offset: 0x0000208B
		[DataMember]
		public DateTime EndTime { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00003E94 File Offset: 0x00002094
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00003E9C File Offset: 0x0000209C
		[DataMember]
		public bool FirstChargeNeeded { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00003EA5 File Offset: 0x000020A5
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00003EAD File Offset: 0x000020AD
		[DataMember]
		public int GiftPackageID { get; set; }
	}
}
