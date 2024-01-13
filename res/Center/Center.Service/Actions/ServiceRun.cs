using System;
using System.Collections;
using System.ServiceProcess;

namespace Center.Service.Actions
{
	// Token: 0x02000005 RID: 5
	public class ServiceRun : IAction
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000015 RID: 21 RVA: 0x0000243A File Offset: 0x0000063A
		public string Name
		{
			get
			{
				return "--servicerun";
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002441 File Offset: 0x00000641
		public string Syntax
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002444 File Offset: 0x00000644
		public string Description
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002447 File Offset: 0x00000647
		public void OnAction(Hashtable parameters)
		{
			ServiceBase.Run(new CenterServerService());
		}
	}
}
