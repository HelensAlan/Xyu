using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000006 RID: 6
	public class AchievementDataInfo : DataObject
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002145 File Offset: 0x00000345
		// (set) Token: 0x0600001F RID: 31 RVA: 0x0000214D File Offset: 0x0000034D
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

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000020 RID: 32 RVA: 0x0000215D File Offset: 0x0000035D
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002165 File Offset: 0x00000365
		public int AchievementID
		{
			get
			{
				return this._achievementID;
			}
			set
			{
				this._achievementID = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002175 File Offset: 0x00000375
		// (set) Token: 0x06000023 RID: 35 RVA: 0x0000217D File Offset: 0x0000037D
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

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000024 RID: 36 RVA: 0x0000218D File Offset: 0x0000038D
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00002195 File Offset: 0x00000395
		public DateTime CompletedDate
		{
			get
			{
				return this._completedDate;
			}
			set
			{
				this._completedDate = value;
				this._isDirty = true;
			}
		}

		// Token: 0x04000092 RID: 146
		private int _userID;

		// Token: 0x04000093 RID: 147
		private int _achievementID;

		// Token: 0x04000094 RID: 148
		private bool _isComplete;

		// Token: 0x04000095 RID: 149
		private DateTime _completedDate;
	}
}
