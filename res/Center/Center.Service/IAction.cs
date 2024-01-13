using System;
using System.Collections;

namespace Center.Service
{
	// Token: 0x02000003 RID: 3
	internal interface IAction
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000009 RID: 9
		string Name { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10
		string Syntax { get; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000B RID: 11
		string Description { get; }

		// Token: 0x0600000C RID: 12
		void OnAction(Hashtable parameters);
	}
}
