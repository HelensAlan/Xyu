using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Threading;
using log4net;

namespace Game.Base.Events
{
	// Token: 0x0200001D RID: 29
	public sealed class GameEventMgr
	{
		// Token: 0x06000105 RID: 261 RVA: 0x000060B4 File Offset: 0x000042B4
		public static void RegisterGlobalEvents(Assembly asm, Type attribute, RoadEvent e)
		{
			if (asm == null)
			{
				throw new ArgumentNullException("asm", "No assembly given to search for global event handlers!");
			}
			if (attribute == null)
			{
				throw new ArgumentNullException("attribute", "No attribute given!");
			}
			if (e == null)
			{
				throw new ArgumentNullException("e", "No event type given!");
			}
			foreach (Type type in asm.GetTypes())
			{
				if (type.IsClass)
				{
					foreach (MethodInfo mInfo in type.GetMethods(BindingFlags.Static | BindingFlags.Public))
					{
						if (mInfo.GetCustomAttributes(attribute, false).Length != 0)
						{
							try
							{
								GameEventMgr.m_GlobalHandlerCollection.AddHandler(e, (RoadEventHandler)Delegate.CreateDelegate(typeof(RoadEventHandler), mInfo));
							}
							catch (Exception ex)
							{
								if (GameEventMgr.log.IsErrorEnabled)
								{
									GameEventMgr.log.Error("Error registering global event. Method: " + type.FullName + "." + mInfo.Name, ex);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x000061C8 File Offset: 0x000043C8
		public static void AddHandler(RoadEvent e, RoadEventHandler del)
		{
			GameEventMgr.AddHandler(e, del, false);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000061D2 File Offset: 0x000043D2
		public static void AddHandlerUnique(RoadEvent e, RoadEventHandler del)
		{
			GameEventMgr.AddHandler(e, del, true);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000061DC File Offset: 0x000043DC
		private static void AddHandler(RoadEvent e, RoadEventHandler del, bool unique)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e", "No event type given!");
			}
			if (del == null)
			{
				throw new ArgumentNullException("del", "No event handler given!");
			}
			if (unique)
			{
				GameEventMgr.m_GlobalHandlerCollection.AddHandlerUnique(e, del);
				return;
			}
			GameEventMgr.m_GlobalHandlerCollection.AddHandler(e, del);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000622B File Offset: 0x0000442B
		public static void AddHandler(object obj, RoadEvent e, RoadEventHandler del)
		{
			GameEventMgr.AddHandler(obj, e, del, false);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00006236 File Offset: 0x00004436
		public static void AddHandlerUnique(object obj, RoadEvent e, RoadEventHandler del)
		{
			GameEventMgr.AddHandler(obj, e, del, true);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00006244 File Offset: 0x00004444
		private static void AddHandler(object obj, RoadEvent e, RoadEventHandler del, bool unique)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj", "No object given!");
			}
			if (e == null)
			{
				throw new ArgumentNullException("e", "No event type given!");
			}
			if (del == null)
			{
				throw new ArgumentNullException("del", "No event handler given!");
			}
			if (!e.IsValidFor(obj))
			{
				throw new ArgumentException("Object is not valid for this event type", "obj");
			}
			try
			{
				GameEventMgr.m_lock.AcquireReaderLock(3000);
				try
				{
					RoadEventHandlerCollection col = (RoadEventHandlerCollection)GameEventMgr.m_GameObjectEventCollections[obj];
					if (col == null)
					{
						col = new RoadEventHandlerCollection();
						LockCookie lc = GameEventMgr.m_lock.UpgradeToWriterLock(3000);
						try
						{
							GameEventMgr.m_GameObjectEventCollections[obj] = col;
						}
						finally
						{
							GameEventMgr.m_lock.DowngradeFromWriterLock(ref lc);
						}
					}
					if (unique)
					{
						col.AddHandlerUnique(e, del);
					}
					else
					{
						col.AddHandler(e, del);
					}
				}
				finally
				{
					GameEventMgr.m_lock.ReleaseReaderLock();
				}
			}
			catch (ApplicationException ex)
			{
				if (GameEventMgr.log.IsErrorEnabled)
				{
					GameEventMgr.log.Error("Failed to add local event handler!", ex);
				}
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00006364 File Offset: 0x00004564
		public static void RemoveHandler(RoadEvent e, RoadEventHandler del)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e", "No event type given!");
			}
			if (del == null)
			{
				throw new ArgumentNullException("del", "No event handler given!");
			}
			GameEventMgr.m_GlobalHandlerCollection.RemoveHandler(e, del);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00006398 File Offset: 0x00004598
		public static void RemoveHandler(object obj, RoadEvent e, RoadEventHandler del)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj", "No object given!");
			}
			if (e == null)
			{
				throw new ArgumentNullException("e", "No event type given!");
			}
			if (del == null)
			{
				throw new ArgumentNullException("del", "No event handler given!");
			}
			try
			{
				GameEventMgr.m_lock.AcquireReaderLock(3000);
				try
				{
					RoadEventHandlerCollection col = (RoadEventHandlerCollection)GameEventMgr.m_GameObjectEventCollections[obj];
					if (col != null)
					{
						col.RemoveHandler(e, del);
					}
				}
				finally
				{
					GameEventMgr.m_lock.ReleaseReaderLock();
				}
			}
			catch (ApplicationException ex)
			{
				if (GameEventMgr.log.IsErrorEnabled)
				{
					GameEventMgr.log.Error("Failed to remove local event handler!", ex);
				}
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00006454 File Offset: 0x00004654
		public static void RemoveAllHandlers(RoadEvent e, bool deep)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e", "No event type given!");
			}
			if (deep)
			{
				try
				{
					GameEventMgr.m_lock.AcquireReaderLock(3000);
					try
					{
						foreach (object obj in GameEventMgr.m_GameObjectEventCollections.Values)
						{
							((RoadEventHandlerCollection)obj).RemoveAllHandlers(e);
						}
					}
					finally
					{
						GameEventMgr.m_lock.ReleaseReaderLock();
					}
				}
				catch (ApplicationException ex)
				{
					if (GameEventMgr.log.IsErrorEnabled)
					{
						GameEventMgr.log.Error("Failed to add local event handlers!", ex);
					}
				}
			}
			GameEventMgr.m_GlobalHandlerCollection.RemoveAllHandlers(e);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00006528 File Offset: 0x00004728
		public static void RemoveAllHandlers(object obj, RoadEvent e)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj", "No object given!");
			}
			if (e == null)
			{
				throw new ArgumentNullException("e", "No event type given!");
			}
			try
			{
				GameEventMgr.m_lock.AcquireReaderLock(3000);
				try
				{
					RoadEventHandlerCollection col = (RoadEventHandlerCollection)GameEventMgr.m_GameObjectEventCollections[obj];
					if (col != null)
					{
						col.RemoveAllHandlers(e);
					}
				}
				finally
				{
					GameEventMgr.m_lock.ReleaseReaderLock();
				}
			}
			catch (ApplicationException ex)
			{
				if (GameEventMgr.log.IsErrorEnabled)
				{
					GameEventMgr.log.Error("Failed to remove local event handlers!", ex);
				}
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000065D0 File Offset: 0x000047D0
		public static void RemoveAllHandlers(bool deep)
		{
			if (deep)
			{
				try
				{
					GameEventMgr.m_lock.AcquireWriterLock(3000);
					try
					{
						GameEventMgr.m_GameObjectEventCollections.Clear();
					}
					finally
					{
						GameEventMgr.m_lock.ReleaseWriterLock();
					}
				}
				catch (ApplicationException ex)
				{
					if (GameEventMgr.log.IsErrorEnabled)
					{
						GameEventMgr.log.Error("Failed to remove all local event handlers!", ex);
					}
				}
			}
			GameEventMgr.m_GlobalHandlerCollection.RemoveAllHandlers();
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00006650 File Offset: 0x00004850
		public static void Notify(RoadEvent e)
		{
			GameEventMgr.Notify(e, null, null);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000665A File Offset: 0x0000485A
		public static void Notify(RoadEvent e, object sender)
		{
			GameEventMgr.Notify(e, sender, null);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00006664 File Offset: 0x00004864
		public static void Notify(RoadEvent e, EventArgs args)
		{
			GameEventMgr.Notify(e, null, args);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00006670 File Offset: 0x00004870
		public static void Notify(RoadEvent e, object sender, EventArgs eArgs)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e", "No event type given!");
			}
			if (sender != null)
			{
				try
				{
					RoadEventHandlerCollection col = null;
					GameEventMgr.m_lock.AcquireReaderLock(3000);
					try
					{
						col = (RoadEventHandlerCollection)GameEventMgr.m_GameObjectEventCollections[sender];
					}
					finally
					{
						GameEventMgr.m_lock.ReleaseReaderLock();
					}
					if (col != null)
					{
						col.Notify(e, sender, eArgs);
					}
				}
				catch (ApplicationException ex)
				{
					if (GameEventMgr.log.IsErrorEnabled)
					{
						GameEventMgr.log.Error("Failed to notify local event handler!", ex);
					}
				}
			}
			GameEventMgr.m_GlobalHandlerCollection.Notify(e, sender, eArgs);
		}

		// Token: 0x0400006D RID: 109
		private const int TIMEOUT = 3000;

		// Token: 0x0400006E RID: 110
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x0400006F RID: 111
		private static readonly HybridDictionary m_GameObjectEventCollections = new HybridDictionary();

		// Token: 0x04000070 RID: 112
		private static readonly ReaderWriterLock m_lock = new ReaderWriterLock();

		// Token: 0x04000071 RID: 113
		private static RoadEventHandlerCollection m_GlobalHandlerCollection = new RoadEventHandlerCollection();
	}
}
