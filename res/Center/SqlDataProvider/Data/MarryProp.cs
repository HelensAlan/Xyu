using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000043 RID: 67
	public class MarryProp
	{
		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x0600063A RID: 1594 RVA: 0x000060E7 File Offset: 0x000042E7
		// (set) Token: 0x0600063B RID: 1595 RVA: 0x000060EF File Offset: 0x000042EF
		public bool IsMarried
		{
			get
			{
				return this._isMarried;
			}
			set
			{
				this._isMarried = value;
			}
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x0600063C RID: 1596 RVA: 0x000060F8 File Offset: 0x000042F8
		// (set) Token: 0x0600063D RID: 1597 RVA: 0x00006100 File Offset: 0x00004300
		public int SpouseID
		{
			get
			{
				return this._spouseID;
			}
			set
			{
				this._spouseID = value;
			}
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x00006109 File Offset: 0x00004309
		// (set) Token: 0x0600063F RID: 1599 RVA: 0x00006111 File Offset: 0x00004311
		public string SpouseName
		{
			get
			{
				return this._spouseName;
			}
			set
			{
				this._spouseName = value;
			}
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x0000611A File Offset: 0x0000431A
		// (set) Token: 0x06000641 RID: 1601 RVA: 0x00006122 File Offset: 0x00004322
		public bool IsCreatedMarryRoom
		{
			get
			{
				return this._isCreatedMarryRoom;
			}
			set
			{
				this._isCreatedMarryRoom = value;
			}
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000642 RID: 1602 RVA: 0x0000612B File Offset: 0x0000432B
		// (set) Token: 0x06000643 RID: 1603 RVA: 0x00006133 File Offset: 0x00004333
		public int SelfMarryRoomID
		{
			get
			{
				return this._selfMarryRoomID;
			}
			set
			{
				this._selfMarryRoomID = value;
			}
		}

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000644 RID: 1604 RVA: 0x0000613C File Offset: 0x0000433C
		// (set) Token: 0x06000645 RID: 1605 RVA: 0x00006144 File Offset: 0x00004344
		public bool IsGotRing
		{
			get
			{
				return this._isGotRing;
			}
			set
			{
				this._isGotRing = value;
			}
		}

		// Token: 0x04000381 RID: 897
		private bool _isMarried;

		// Token: 0x04000382 RID: 898
		private int _spouseID;

		// Token: 0x04000383 RID: 899
		private string _spouseName;

		// Token: 0x04000384 RID: 900
		private bool _isCreatedMarryRoom;

		// Token: 0x04000385 RID: 901
		private int _selfMarryRoomID;

		// Token: 0x04000386 RID: 902
		private bool _isGotRing;
	}
}
