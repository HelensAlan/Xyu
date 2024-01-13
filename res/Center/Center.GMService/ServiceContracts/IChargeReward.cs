using System;
using System.ServiceModel;
using Center.GMService.DataContracts;

namespace Center.GMService.ServiceContracts
{
	// Token: 0x02000005 RID: 5
	[ServiceContract]
	public interface IChargeReward
	{
		// Token: 0x06000017 RID: 23
		[OperationContract]
		CommonReturnData GMSetChargeReward(ChargeRewardInfo[] rewardInfos, ChargeRewardItem[] rewardItems);

		// Token: 0x06000018 RID: 24
		[OperationContract]
		bool GMInvalidChargeReward();
	}
}
