using System;
using System.ServiceModel;
using Center.GMService.DataContracts;

namespace Center.GMService.ServiceContracts
{
	// Token: 0x02000008 RID: 8
	[ServiceContract]
	public interface IUserService
	{
		// Token: 0x06000021 RID: 33
		[OperationContract]
		CommonReturnData GMCreatePlayer(string userName, string nickName, int grade, int sex);

		// Token: 0x06000022 RID: 34
		[OperationContract]
		bool GMIsPlayerExist(string nickName);
	}
}
