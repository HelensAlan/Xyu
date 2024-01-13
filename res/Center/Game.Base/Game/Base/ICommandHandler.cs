using System;

namespace Game.Base
{
	// Token: 0x02000010 RID: 16
	public interface ICommandHandler
	{
		// Token: 0x06000076 RID: 118
		bool OnCommand(BaseClient client, string[] args);
	}
}
