using System;

namespace Game.Base
{
	// Token: 0x02000005 RID: 5
	public abstract class AbstractCommandHandler
	{
		// Token: 0x06000017 RID: 23 RVA: 0x0000288C File Offset: 0x00000A8C
		public virtual void DisplayMessage(BaseClient client, string format, params object[] args)
		{
			this.DisplayMessage(client, string.Format(format, args));
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000289C File Offset: 0x00000A9C
		public virtual void DisplayMessage(BaseClient client, string message)
		{
			if (client != null)
			{
				client.DisplayMessage(message);
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000028A8 File Offset: 0x00000AA8
		public virtual void DisplaySyntax(BaseClient client)
		{
			if (client != null)
			{
				CmdAttribute[] attrib = (CmdAttribute[])base.GetType().GetCustomAttributes(typeof(CmdAttribute), false);
				if (attrib.Length != 0)
				{
					client.DisplayMessage(attrib[0].Description);
					foreach (string str in attrib[0].Usage)
					{
						client.DisplayMessage(str);
					}
				}
			}
		}
	}
}
