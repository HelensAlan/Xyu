using System;
using System.Collections.Generic;
using System.ServiceModel;
using Center.GMService.DataContracts;

namespace Center.GMService.ServiceContracts
{
	// Token: 0x02000006 RID: 6
	[ServiceContract]
	public interface IConsortiaService
	{
		// Token: 0x06000019 RID: 25
		[OperationContract]
		CommonReturnData GMCreateConsortium(string consortiumName, int chairmanID);

		// Token: 0x0600001A RID: 26
		[OperationContract]
		CommonReturnData GMTransferConsortium(int consortiumID, int newChairmanID);

		// Token: 0x0600001B RID: 27
		[OperationContract]
		bool GMIsConsortiumExisted(string consortiumName);

		// Token: 0x0600001C RID: 28
		[OperationContract]
		List<ConsortiumData> GMGetSystemConsortiumList();

		// Token: 0x0600001D RID: 29
		[OperationContract]
		List<ConsortiumUserData> GMGetConsortiumUserListByName(string consortiumName, int page, int size, out int total, int order, int state);

		// Token: 0x0600001E RID: 30
		[OperationContract]
		List<ConsortiumUserData> GMGetConsortiumUserListByID(int consortiumID, int page, int size, out int total, int order, int state);

		// Token: 0x0600001F RID: 31
		[OperationContract]
		List<ConsortiumUserData> GMGetCanTransferUserList(int consortiumID);

		// Token: 0x06000020 RID: 32
		[OperationContract]
		CommonReturnData GMQuitConsortium(int userID, int consortiumID);
	}
}
