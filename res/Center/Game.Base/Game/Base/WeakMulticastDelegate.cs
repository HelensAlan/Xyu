using System;
using System.Reflection;
using System.Text;
using log4net;

namespace Game.Base
{
	// Token: 0x02000017 RID: 23
	public class WeakMulticastDelegate
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x00004E6B File Offset: 0x0000306B
		public WeakMulticastDelegate(Delegate realDelegate)
		{
			if (realDelegate.Target != null)
			{
				this.weakRef = new WeakRef(realDelegate.Target);
			}
			this.method = realDelegate.Method;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004E98 File Offset: 0x00003098
		public static WeakMulticastDelegate Combine(WeakMulticastDelegate weakDelegate, Delegate realDelegate)
		{
			WeakMulticastDelegate result;
			if (realDelegate == null)
			{
				result = null;
			}
			else
			{
				result = ((weakDelegate == null) ? new WeakMulticastDelegate(realDelegate) : weakDelegate.Combine(realDelegate));
			}
			return result;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004EC0 File Offset: 0x000030C0
		public static WeakMulticastDelegate CombineUnique(WeakMulticastDelegate weakDelegate, Delegate realDelegate)
		{
			WeakMulticastDelegate result;
			if (realDelegate == null)
			{
				result = null;
			}
			else
			{
				result = ((weakDelegate == null) ? new WeakMulticastDelegate(realDelegate) : weakDelegate.CombineUnique(realDelegate));
			}
			return result;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004EE8 File Offset: 0x000030E8
		private WeakMulticastDelegate Combine(Delegate realDelegate)
		{
			this.prev = new WeakMulticastDelegate(realDelegate)
			{
				prev = this.prev
			};
			return this;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004F04 File Offset: 0x00003104
		protected bool Equals(Delegate realDelegate)
		{
			bool result;
			if (this.weakRef == null)
			{
				result = realDelegate.Target == null && this.method == realDelegate.Method;
			}
			else
			{
				result = this.weakRef.Target == realDelegate.Target && this.method == realDelegate.Method;
			}
			return result;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004F64 File Offset: 0x00003164
		private WeakMulticastDelegate CombineUnique(Delegate realDelegate)
		{
			bool found = this.Equals(realDelegate);
			if (!found && this.prev != null)
			{
				WeakMulticastDelegate curNode = this.prev;
				while (!found && curNode != null)
				{
					if (curNode.Equals(realDelegate))
					{
						found = true;
					}
					curNode = curNode.prev;
				}
			}
			if (!found)
			{
				return this.Combine(realDelegate);
			}
			return this;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004FB1 File Offset: 0x000031B1
		public static WeakMulticastDelegate operator +(WeakMulticastDelegate d, Delegate realD)
		{
			return WeakMulticastDelegate.Combine(d, realD);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00004FBA File Offset: 0x000031BA
		public static WeakMulticastDelegate operator -(WeakMulticastDelegate d, Delegate realD)
		{
			return WeakMulticastDelegate.Remove(d, realD);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004FC4 File Offset: 0x000031C4
		public static WeakMulticastDelegate Remove(WeakMulticastDelegate weakDelegate, Delegate realDelegate)
		{
			WeakMulticastDelegate result;
			if (realDelegate == null || weakDelegate == null)
			{
				result = null;
			}
			else
			{
				result = weakDelegate.Remove(realDelegate);
			}
			return result;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004FE4 File Offset: 0x000031E4
		private WeakMulticastDelegate Remove(Delegate realDelegate)
		{
			WeakMulticastDelegate result;
			if (this.Equals(realDelegate))
			{
				result = this.prev;
			}
			else
			{
				WeakMulticastDelegate current = this.prev;
				WeakMulticastDelegate last = this;
				while (current != null)
				{
					if (current.Equals(realDelegate))
					{
						last.prev = current.prev;
						current.prev = null;
						break;
					}
					last = current;
					current = current.prev;
				}
				result = this;
			}
			return result;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000503C File Offset: 0x0000323C
		public void Invoke(object[] args)
		{
			for (WeakMulticastDelegate current = this; current != null; current = current.prev)
			{
				int start = Environment.TickCount;
				if (current.weakRef == null)
				{
					current.method.Invoke(null, args);
				}
				else if (current.weakRef.IsAlive)
				{
					current.method.Invoke(current.weakRef.Target, args);
				}
				if (Environment.TickCount - start > 500 && WeakMulticastDelegate.log.IsWarnEnabled)
				{
					WeakMulticastDelegate.log.Warn(string.Concat(new object[]
					{
						"Invoke took ",
						Environment.TickCount - start,
						"ms! ",
						current.ToString()
					}));
				}
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000050F8 File Offset: 0x000032F8
		public void InvokeSafe(object[] args)
		{
			for (WeakMulticastDelegate current = this; current != null; current = current.prev)
			{
				int start = Environment.TickCount;
				try
				{
					if (current.weakRef == null)
					{
						current.method.Invoke(null, args);
					}
					else if (current.weakRef.IsAlive)
					{
						current.method.Invoke(current.weakRef.Target, args);
					}
				}
				catch (Exception ex)
				{
					if (WeakMulticastDelegate.log.IsErrorEnabled)
					{
						WeakMulticastDelegate.log.Error("InvokeSafe", ex);
					}
				}
				if (Environment.TickCount - start > 500 && WeakMulticastDelegate.log.IsWarnEnabled)
				{
					WeakMulticastDelegate.log.Warn(string.Concat(new object[]
					{
						"InvokeSafe took ",
						Environment.TickCount - start,
						"ms! ",
						current.ToString()
					}));
				}
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000051E4 File Offset: 0x000033E4
		public string Dump()
		{
			StringBuilder builder = new StringBuilder();
			WeakMulticastDelegate current = this;
			int count = 0;
			while (current != null)
			{
				count++;
				if (current.weakRef == null)
				{
					builder.Append("\t");
					builder.Append(count);
					builder.Append(") ");
					builder.Append(current.method.Name);
					builder.Append(Environment.NewLine);
				}
				else if (current.weakRef.IsAlive)
				{
					builder.Append("\t");
					builder.Append(count);
					builder.Append(") ");
					builder.Append(current.weakRef.Target);
					builder.Append(".");
					builder.Append(current.method.Name);
					builder.Append(Environment.NewLine);
				}
				else
				{
					builder.Append("\t");
					builder.Append(count);
					builder.Append(") INVALID.");
					builder.Append(current.method.Name);
					builder.Append(Environment.NewLine);
				}
				current = current.prev;
			}
			return builder.ToString();
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000530C File Offset: 0x0000350C
		public override string ToString()
		{
			Type declaringType = null;
			if (this.method != null)
			{
				declaringType = this.method.DeclaringType;
			}
			object target = null;
			if (this.weakRef != null && this.weakRef.IsAlive)
			{
				target = this.weakRef.Target;
			}
			return new StringBuilder(64).Append("method: ").Append((declaringType == null) ? "(null)" : declaringType.FullName).Append('.')
				.Append((this.method == null) ? "(null)" : this.method.Name)
				.Append(" target: ")
				.Append((target == null) ? "null" : target.ToString())
				.ToString();
		}

		// Token: 0x04000053 RID: 83
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000054 RID: 84
		private WeakReference weakRef;

		// Token: 0x04000055 RID: 85
		private MethodInfo method;

		// Token: 0x04000056 RID: 86
		private WeakMulticastDelegate prev;
	}
}
