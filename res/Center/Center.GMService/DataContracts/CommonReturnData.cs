using System;
using System.Runtime.Serialization;

namespace Center.GMService.DataContracts
{
	// Token: 0x0200000B RID: 11
	[DataContract]
	public class CommonReturnData
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00004005 File Offset: 0x00002205
		// (set) Token: 0x0600004E RID: 78 RVA: 0x0000400D File Offset: 0x0000220D
		[DataMember]
		public int OperationResult { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00004016 File Offset: 0x00002216
		// (set) Token: 0x06000050 RID: 80 RVA: 0x0000401E File Offset: 0x0000221E
		[DataMember]
		public int ID { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00004027 File Offset: 0x00002227
		// (set) Token: 0x06000052 RID: 82 RVA: 0x0000402F File Offset: 0x0000222F
		[DataMember]
		public string NotifyMsg { get; set; }

		// Token: 0x06000053 RID: 83 RVA: 0x00004038 File Offset: 0x00002238
		public CommonReturnData()
		{
			this.OperationResult = 0;
			this.ID = 0;
			this.NotifyMsg = "";
		}
	}
}
