using System;
using System.Collections.Generic;

namespace Road.Base
{
	// Token: 0x02000002 RID: 2
	public class QueueMgr<T>
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public QueueMgr(QueueMgr<T>.Exectue exec)
		{
			this._queue = new Queue<T>();
			this._executing = false;
			this._exectue = exec;
			this._syncRoot = new object();
			this._asynExecute = new QueueMgr<T>.AsynExecute(this.Exectuing);
			this._asynCallBack = new AsyncCallback(this.AsynCallBack);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020AC File Offset: 0x000002AC
		public void ExecuteQueue(T info)
		{
			object syncRoot = this._syncRoot;
			lock (syncRoot)
			{
				if (this._executing)
				{
					this._queue.Enqueue(info);
					return;
				}
				this._executing = true;
			}
			this._asynExecute.BeginInvoke(info, this._asynCallBack, this._asynExecute);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000211C File Offset: 0x0000031C
		private void AsynCallBack(IAsyncResult ar)
		{
			((QueueMgr<T>.AsynExecute)ar.AsyncState).EndInvoke(ar);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002130 File Offset: 0x00000330
		private void Exectuing(T info)
		{
			this._exectue(info);
			object syncRoot = this._syncRoot;
			T newInfo;
			lock (syncRoot)
			{
				if (this._queue.Count <= 0)
				{
					this._executing = false;
					return;
				}
				newInfo = this._queue.Peek();
				this._queue.Dequeue();
			}
			this.Exectuing(newInfo);
		}

		// Token: 0x04000001 RID: 1
		private Queue<T> _queue;

		// Token: 0x04000002 RID: 2
		private bool _executing;

		// Token: 0x04000003 RID: 3
		private QueueMgr<T>.Exectue _exectue;

		// Token: 0x04000004 RID: 4
		private object _syncRoot;

		// Token: 0x04000005 RID: 5
		private QueueMgr<T>.AsynExecute _asynExecute;

		// Token: 0x04000006 RID: 6
		private AsyncCallback _asynCallBack;

		// Token: 0x02000030 RID: 48
		// (Invoke) Token: 0x0600015A RID: 346
		public delegate void Exectue(T msg);

		// Token: 0x02000031 RID: 49
		// (Invoke) Token: 0x0600015E RID: 350
		public delegate void AsynExecute(T info);
	}
}
