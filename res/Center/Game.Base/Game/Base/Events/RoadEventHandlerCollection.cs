using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Threading;
using log4net;

namespace Game.Base.Events
{
	// Token: 0x02000023 RID: 35
	public class RoadEventHandlerCollection
	{
		// Token: 0x06000123 RID: 291 RVA: 0x000067CD File Offset: 0x000049CD
		public RoadEventHandlerCollection()
		{
			this.m_lock = new ReaderWriterLock();
			this.m_events = new HybridDictionary();
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000067EC File Offset: 0x000049EC
		public void AddHandler(RoadEvent e, RoadEventHandler del)
		{
			try
			{
				this.m_lock.AcquireWriterLock(3000);
				try
				{
					WeakMulticastDelegate deleg = (WeakMulticastDelegate)this.m_events[e];
					if (deleg == null)
					{
						this.m_events[e] = new WeakMulticastDelegate(del);
					}
					else
					{
						this.m_events[e] = WeakMulticastDelegate.Combine(deleg, del);
					}
				}
				finally
				{
					this.m_lock.ReleaseWriterLock();
				}
			}
			catch (ApplicationException ex)
			{
				if (RoadEventHandlerCollection.log.IsErrorEnabled)
				{
					RoadEventHandlerCollection.log.Error("Failed to add event handler!", ex);
				}
			}
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00006890 File Offset: 0x00004A90
		public void AddHandlerUnique(RoadEvent e, RoadEventHandler del)
		{
			try
			{
				this.m_lock.AcquireWriterLock(3000);
				try
				{
					WeakMulticastDelegate deleg = (WeakMulticastDelegate)this.m_events[e];
					if (deleg == null)
					{
						this.m_events[e] = new WeakMulticastDelegate(del);
					}
					else
					{
						this.m_events[e] = WeakMulticastDelegate.CombineUnique(deleg, del);
					}
				}
				finally
				{
					this.m_lock.ReleaseWriterLock();
				}
			}
			catch (ApplicationException ex)
			{
				if (RoadEventHandlerCollection.log.IsErrorEnabled)
				{
					RoadEventHandlerCollection.log.Error("Failed to add event handler!", ex);
				}
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00006934 File Offset: 0x00004B34
		public void RemoveHandler(RoadEvent e, RoadEventHandler del)
		{
			try
			{
				this.m_lock.AcquireWriterLock(3000);
				try
				{
					WeakMulticastDelegate deleg = (WeakMulticastDelegate)this.m_events[e];
					if (deleg != null)
					{
						deleg = WeakMulticastDelegate.Remove(deleg, del);
						if (deleg == null)
						{
							this.m_events.Remove(e);
						}
						else
						{
							this.m_events[e] = deleg;
						}
					}
				}
				finally
				{
					this.m_lock.ReleaseWriterLock();
				}
			}
			catch (ApplicationException ex)
			{
				if (RoadEventHandlerCollection.log.IsErrorEnabled)
				{
					RoadEventHandlerCollection.log.Error("Failed to remove event handler!", ex);
				}
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000069D8 File Offset: 0x00004BD8
		public void RemoveAllHandlers(RoadEvent e)
		{
			try
			{
				this.m_lock.AcquireWriterLock(3000);
				try
				{
					this.m_events.Remove(e);
				}
				finally
				{
					this.m_lock.ReleaseWriterLock();
				}
			}
			catch (ApplicationException ex)
			{
				if (RoadEventHandlerCollection.log.IsErrorEnabled)
				{
					RoadEventHandlerCollection.log.Error("Failed to remove event handlers!", ex);
				}
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00006A4C File Offset: 0x00004C4C
		public void RemoveAllHandlers()
		{
			try
			{
				this.m_lock.AcquireWriterLock(3000);
				try
				{
					this.m_events.Clear();
				}
				finally
				{
					this.m_lock.ReleaseWriterLock();
				}
			}
			catch (ApplicationException ex)
			{
				if (RoadEventHandlerCollection.log.IsErrorEnabled)
				{
					RoadEventHandlerCollection.log.Error("Failed to remove all event handlers!", ex);
				}
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00006AC0 File Offset: 0x00004CC0
		public void Notify(RoadEvent e)
		{
			this.Notify(e, null, null);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00006ACB File Offset: 0x00004CCB
		public void Notify(RoadEvent e, object sender)
		{
			this.Notify(e, sender, null);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00006AD6 File Offset: 0x00004CD6
		public void Notify(RoadEvent e, EventArgs args)
		{
			this.Notify(e, null, args);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00006AE4 File Offset: 0x00004CE4
		public void Notify(RoadEvent e, object sender, EventArgs eArgs)
		{
			try
			{
				this.m_lock.AcquireReaderLock(3000);
				WeakMulticastDelegate eventDelegate;
				try
				{
					eventDelegate = (WeakMulticastDelegate)this.m_events[e];
				}
				finally
				{
					this.m_lock.ReleaseReaderLock();
				}
				if (eventDelegate != null)
				{
					eventDelegate.InvokeSafe(new object[] { e, sender, eArgs });
				}
			}
			catch (ApplicationException ex)
			{
				if (RoadEventHandlerCollection.log.IsErrorEnabled)
				{
					RoadEventHandlerCollection.log.Error("Failed to notify event handler!", ex);
				}
			}
		}

		// Token: 0x04000076 RID: 118
		protected const int TIMEOUT = 3000;

		// Token: 0x04000077 RID: 119
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000078 RID: 120
		protected readonly ReaderWriterLock m_lock;

		// Token: 0x04000079 RID: 121
		protected readonly HybridDictionary m_events;
	}
}
