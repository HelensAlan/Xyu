using System;
using System.Reflection;
using log4net;

namespace Game.Base
{
	// Token: 0x02000011 RID: 17
	public class LogClient : BaseClient
	{
		// Token: 0x06000077 RID: 119 RVA: 0x00003DC1 File Offset: 0x00001FC1
		public LogClient()
			: base(null, null)
		{
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003DCB File Offset: 0x00001FCB
		public override void DisplayMessage(string msg)
		{
			LogClient.log.Info(msg);
		}

		// Token: 0x0400003E RID: 62
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
	}
}
