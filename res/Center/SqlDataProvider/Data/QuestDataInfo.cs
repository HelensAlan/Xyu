using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000056 RID: 86
	public class QuestDataInfo : DataObject
	{
		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06000928 RID: 2344 RVA: 0x0000874B File Offset: 0x0000694B
		// (set) Token: 0x06000929 RID: 2345 RVA: 0x00008753 File Offset: 0x00006953
		public int UserID
		{
			get
			{
				return this._userID;
			}
			set
			{
				this._userID = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x0600092A RID: 2346 RVA: 0x00008763 File Offset: 0x00006963
		// (set) Token: 0x0600092B RID: 2347 RVA: 0x0000876B File Offset: 0x0000696B
		public int QuestID
		{
			get
			{
				return this._questID;
			}
			set
			{
				this._questID = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x0600092C RID: 2348 RVA: 0x0000877B File Offset: 0x0000697B
		// (set) Token: 0x0600092D RID: 2349 RVA: 0x00008783 File Offset: 0x00006983
		public int Condition1
		{
			get
			{
				return this._condition1;
			}
			set
			{
				this._condition1 = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x0600092E RID: 2350 RVA: 0x00008793 File Offset: 0x00006993
		// (set) Token: 0x0600092F RID: 2351 RVA: 0x0000879B File Offset: 0x0000699B
		public int Condition2
		{
			get
			{
				return this._condition2;
			}
			set
			{
				this._condition2 = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06000930 RID: 2352 RVA: 0x000087AB File Offset: 0x000069AB
		// (set) Token: 0x06000931 RID: 2353 RVA: 0x000087B3 File Offset: 0x000069B3
		public int Condition3
		{
			get
			{
				return this._condition3;
			}
			set
			{
				this._condition3 = value;
				this._isDirty = true;
			}
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06000932 RID: 2354 RVA: 0x000087C3 File Offset: 0x000069C3
		// (set) Token: 0x06000933 RID: 2355 RVA: 0x000087CB File Offset: 0x000069CB
		public int Condition4
		{
			get
			{
				return this._condition4;
			}
			set
			{
				this._condition4 = value;
				this._isDirty = true;
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06000934 RID: 2356 RVA: 0x000087DB File Offset: 0x000069DB
		// (set) Token: 0x06000935 RID: 2357 RVA: 0x000087E3 File Offset: 0x000069E3
		public bool IsComplete
		{
			get
			{
				return this._isComplete;
			}
			set
			{
				this._isComplete = value;
				this._isDirty = true;
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06000936 RID: 2358 RVA: 0x000087F3 File Offset: 0x000069F3
		// (set) Token: 0x06000937 RID: 2359 RVA: 0x000087FB File Offset: 0x000069FB
		public DateTime CompletedDate
		{
			get
			{
				return this._completeDate;
			}
			set
			{
				this._completeDate = value;
				this._isDirty = true;
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06000938 RID: 2360 RVA: 0x0000880B File Offset: 0x00006A0B
		// (set) Token: 0x06000939 RID: 2361 RVA: 0x00008813 File Offset: 0x00006A13
		public bool IsExist
		{
			get
			{
				return this._isExist;
			}
			set
			{
				this._isExist = value;
				this._isDirty = true;
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x0600093A RID: 2362 RVA: 0x00008823 File Offset: 0x00006A23
		// (set) Token: 0x0600093B RID: 2363 RVA: 0x0000882B File Offset: 0x00006A2B
		public int RepeatFinish
		{
			get
			{
				return this._repeatFinish;
			}
			set
			{
				this._repeatFinish = value;
				this._isDirty = true;
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x0600093C RID: 2364 RVA: 0x0000883B File Offset: 0x00006A3B
		public bool ExistInCurrent
		{
			get
			{
				return !this._isComplete;
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x00008846 File Offset: 0x00006A46
		// (set) Token: 0x0600093E RID: 2366 RVA: 0x0000884E File Offset: 0x00006A4E
		public int RandDobule
		{
			get
			{
				return this._randDobule;
			}
			set
			{
				this._randDobule = value;
				this._isDirty = true;
			}
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x00008860 File Offset: 0x00006A60
		public int GetConditionValue(int index)
		{
			int result;
			switch (index)
			{
			case 0:
				result = this.Condition1;
				break;
			case 1:
				result = this.Condition2;
				break;
			case 2:
				result = this.Condition3;
				break;
			case 3:
				result = this.Condition4;
				break;
			default:
				throw new Exception("Quest condition index out of range.");
			}
			return result;
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x000088B8 File Offset: 0x00006AB8
		public void SaveConditionValue(int index, int value)
		{
			switch (index)
			{
			case 0:
				this.Condition1 = value;
				return;
			case 1:
				this.Condition2 = value;
				return;
			case 2:
				this.Condition3 = value;
				return;
			case 3:
				this.Condition4 = value;
				return;
			default:
				throw new Exception("Quest condition index out of range.");
			}
		}

		// Token: 0x040004E9 RID: 1257
		private int _userID;

		// Token: 0x040004EA RID: 1258
		private int _questID;

		// Token: 0x040004EB RID: 1259
		private int _condition1;

		// Token: 0x040004EC RID: 1260
		private int _condition2;

		// Token: 0x040004ED RID: 1261
		private int _condition3;

		// Token: 0x040004EE RID: 1262
		private int _condition4;

		// Token: 0x040004EF RID: 1263
		private bool _isComplete;

		// Token: 0x040004F0 RID: 1264
		private DateTime _completeDate;

		// Token: 0x040004F1 RID: 1265
		private bool _isExist;

		// Token: 0x040004F2 RID: 1266
		private int _repeatFinish;

		// Token: 0x040004F3 RID: 1267
		private int _randDobule;
	}
}
