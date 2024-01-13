using System;
using System.ServiceModel;

namespace Center.GMService.ServiceContracts
{
	// Token: 0x02000007 RID: 7
	[ServiceContract]
	public interface IGMService : IUserService, IConsortiaService, IChargeReward, IChargeActive
	{
	}
}
