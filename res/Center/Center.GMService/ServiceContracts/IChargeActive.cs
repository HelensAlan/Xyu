using System;
using System.ServiceModel;

namespace Center.GMService.ServiceContracts
{
	// Token: 0x02000004 RID: 4
	[ServiceContract]
	public interface IChargeActive
	{
		// Token: 0x06000016 RID: 22
		[OperationContract]
		bool GMSetActiveState(string key, string value);
	}
}
