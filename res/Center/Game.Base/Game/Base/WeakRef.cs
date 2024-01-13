using System;

namespace Game.Base
{
	// Token: 0x02000018 RID: 24
	public class WeakRef : WeakReference
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x000053EC File Offset: 0x000035EC
		// (set) Token: 0x060000D3 RID: 211 RVA: 0x0000540B File Offset: 0x0000360B
		public override object Target
		{
			get
			{
				object o = base.Target;
				if (o != WeakRef.NULL)
				{
					return o;
				}
				return null;
			}
			set
			{
				base.Target = ((value == null) ? WeakRef.NULL : value);
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000541E File Offset: 0x0000361E
		public WeakRef(object target)
			: base((target == null) ? WeakRef.NULL : target)
		{
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00005431 File Offset: 0x00003631
		public WeakRef(object target, bool trackResurrection)
			: base((target == null) ? WeakRef.NULL : target, trackResurrection)
		{
		}

		// Token: 0x04000057 RID: 87
		private static readonly WeakRef.NullValue NULL = new WeakRef.NullValue();

		// Token: 0x02000032 RID: 50
		private class NullValue
		{
		}
	}
}
