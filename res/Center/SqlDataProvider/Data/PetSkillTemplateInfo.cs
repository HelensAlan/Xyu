using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200004D RID: 77
	public class PetSkillTemplateInfo
	{
		// Token: 0x0600077E RID: 1918 RVA: 0x0000756F File Offset: 0x0000576F
		public PetSkillTemplateInfo()
		{
			this._PetTemplateID = -1;
			this._KindID = -1;
			this._Type = -1;
			this._SkillID = -1;
			this._SkillBookID = -1;
			this._MinLevel = -1;
			this._DeleteSkillIDs = "";
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x000075AC File Offset: 0x000057AC
		// (set) Token: 0x06000780 RID: 1920 RVA: 0x000075B4 File Offset: 0x000057B4
		public int PetTemplateID
		{
			get
			{
				return this._PetTemplateID;
			}
			set
			{
				this._PetTemplateID = value;
			}
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000781 RID: 1921 RVA: 0x000075BD File Offset: 0x000057BD
		// (set) Token: 0x06000782 RID: 1922 RVA: 0x000075C5 File Offset: 0x000057C5
		public int KindID
		{
			get
			{
				return this._KindID;
			}
			set
			{
				this._KindID = value;
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000783 RID: 1923 RVA: 0x000075CE File Offset: 0x000057CE
		// (set) Token: 0x06000784 RID: 1924 RVA: 0x000075D6 File Offset: 0x000057D6
		public int Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000785 RID: 1925 RVA: 0x000075DF File Offset: 0x000057DF
		// (set) Token: 0x06000786 RID: 1926 RVA: 0x000075E7 File Offset: 0x000057E7
		public int SkillID
		{
			get
			{
				return this._SkillID;
			}
			set
			{
				this._SkillID = value;
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000787 RID: 1927 RVA: 0x000075F0 File Offset: 0x000057F0
		// (set) Token: 0x06000788 RID: 1928 RVA: 0x000075F8 File Offset: 0x000057F8
		public int SkillBookID
		{
			get
			{
				return this._SkillBookID;
			}
			set
			{
				this._SkillBookID = value;
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000789 RID: 1929 RVA: 0x00007601 File Offset: 0x00005801
		// (set) Token: 0x0600078A RID: 1930 RVA: 0x00007609 File Offset: 0x00005809
		public int MinLevel
		{
			get
			{
				return this._MinLevel;
			}
			set
			{
				this._MinLevel = value;
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x0600078B RID: 1931 RVA: 0x00007612 File Offset: 0x00005812
		// (set) Token: 0x0600078C RID: 1932 RVA: 0x0000761A File Offset: 0x0000581A
		public string DeleteSkillIDs
		{
			get
			{
				return this._DeleteSkillIDs;
			}
			set
			{
				this._DeleteSkillIDs = value;
			}
		}

		// Token: 0x0400041A RID: 1050
		private int _PetTemplateID;

		// Token: 0x0400041B RID: 1051
		private int _KindID;

		// Token: 0x0400041C RID: 1052
		private int _Type;

		// Token: 0x0400041D RID: 1053
		private int _SkillID;

		// Token: 0x0400041E RID: 1054
		private int _SkillBookID;

		// Token: 0x0400041F RID: 1055
		private int _MinLevel;

		// Token: 0x04000420 RID: 1056
		private string _DeleteSkillIDs;
	}
}
