using System;

namespace SqlDataProvider.Data
{
	// Token: 0x02000035 RID: 53
	public class ItemInfo : DataObject
	{
		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000454 RID: 1108 RVA: 0x0000463C File Offset: 0x0000283C
		// (set) Token: 0x06000455 RID: 1109 RVA: 0x00004644 File Offset: 0x00002844
		public bool IsOpenHole { get; private set; }

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x0000464D File Offset: 0x0000284D
		public ItemTemplateInfo Template
		{
			get
			{
				return this._template;
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x00004655 File Offset: 0x00002855
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x0000465D File Offset: 0x0000285D
		public ItemTemplateInfo GoldTemplate { get; set; }

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x00004666 File Offset: 0x00002866
		// (set) Token: 0x0600045A RID: 1114 RVA: 0x0000466E File Offset: 0x0000286E
		public int ItemID
		{
			get
			{
				return this._itemID;
			}
			set
			{
				this._itemID = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x0000467E File Offset: 0x0000287E
		// (set) Token: 0x0600045C RID: 1116 RVA: 0x00004686 File Offset: 0x00002886
		public int UserID
		{
			get
			{
				return this._userID;
			}
			set
			{
				if (this._userID != value)
				{
					this._userID = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x0000469F File Offset: 0x0000289F
		// (set) Token: 0x0600045E RID: 1118 RVA: 0x000046A7 File Offset: 0x000028A7
		public int BagType
		{
			get
			{
				return this._bagType;
			}
			set
			{
				if (this._bagType != value)
				{
					this._bagType = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x000046C0 File Offset: 0x000028C0
		// (set) Token: 0x06000460 RID: 1120 RVA: 0x000046C8 File Offset: 0x000028C8
		public int TemplateID
		{
			get
			{
				return this._templateId;
			}
			set
			{
				if (this._templateId != value)
				{
					this._templateId = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000461 RID: 1121 RVA: 0x000046E1 File Offset: 0x000028E1
		// (set) Token: 0x06000462 RID: 1122 RVA: 0x000046E9 File Offset: 0x000028E9
		public int Place
		{
			get
			{
				return this._place;
			}
			set
			{
				if (this._place != value)
				{
					this._place = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x00004702 File Offset: 0x00002902
		// (set) Token: 0x06000464 RID: 1124 RVA: 0x0000470A File Offset: 0x0000290A
		public int Count
		{
			get
			{
				return this._count;
			}
			set
			{
				if (this._count != value)
				{
					this._count = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x00004723 File Offset: 0x00002923
		// (set) Token: 0x06000466 RID: 1126 RVA: 0x0000472B File Offset: 0x0000292B
		public bool IsJudge
		{
			get
			{
				return this._isJudage;
			}
			set
			{
				if (this._isJudage != value)
				{
					this._isJudage = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x00004744 File Offset: 0x00002944
		// (set) Token: 0x06000468 RID: 1128 RVA: 0x0000474C File Offset: 0x0000294C
		public string Color
		{
			get
			{
				return this._color;
			}
			set
			{
				if (!(this._color == value))
				{
					this._color = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x0000476A File Offset: 0x0000296A
		// (set) Token: 0x0600046A RID: 1130 RVA: 0x00004772 File Offset: 0x00002972
		public bool IsExist
		{
			get
			{
				return this._isExist;
			}
			set
			{
				if (this._isExist != value)
				{
					this._isExist = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x0000478B File Offset: 0x0000298B
		// (set) Token: 0x0600046C RID: 1132 RVA: 0x00004793 File Offset: 0x00002993
		public int StrengthenLevel
		{
			get
			{
				return this._strengthenLevel;
			}
			set
			{
				if (this._strengthenLevel != value)
				{
					this._strengthenLevel = value;
					this._isDirty = true;
				}
				ItemInfo.OpenHole(this);
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x0600046D RID: 1133 RVA: 0x000047B2 File Offset: 0x000029B2
		// (set) Token: 0x0600046E RID: 1134 RVA: 0x000047BA File Offset: 0x000029BA
		public int AttackCompose
		{
			get
			{
				return this._attackCompose;
			}
			set
			{
				if (this._attackCompose != value)
				{
					this._attackCompose = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x0600046F RID: 1135 RVA: 0x000047D3 File Offset: 0x000029D3
		// (set) Token: 0x06000470 RID: 1136 RVA: 0x000047DB File Offset: 0x000029DB
		public int DefendCompose
		{
			get
			{
				return this._defendCompose;
			}
			set
			{
				if (this._defendCompose != value)
				{
					this._defendCompose = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000471 RID: 1137 RVA: 0x000047F4 File Offset: 0x000029F4
		// (set) Token: 0x06000472 RID: 1138 RVA: 0x000047FC File Offset: 0x000029FC
		public int LuckCompose
		{
			get
			{
				return this._luckCompose;
			}
			set
			{
				if (this._luckCompose != value)
				{
					this._luckCompose = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x00004815 File Offset: 0x00002A15
		// (set) Token: 0x06000474 RID: 1140 RVA: 0x0000481D File Offset: 0x00002A1D
		public int AgilityCompose
		{
			get
			{
				return this._agilityCompose;
			}
			set
			{
				if (this._agilityCompose != value)
				{
					this._agilityCompose = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x00004836 File Offset: 0x00002A36
		// (set) Token: 0x06000476 RID: 1142 RVA: 0x0000483E File Offset: 0x00002A3E
		public bool IsBinds
		{
			get
			{
				return this._isBinds;
			}
			set
			{
				if (this._isBinds != value)
				{
					this._isBinds = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000477 RID: 1143 RVA: 0x00004857 File Offset: 0x00002A57
		// (set) Token: 0x06000478 RID: 1144 RVA: 0x0000485F File Offset: 0x00002A5F
		public bool IsUsed
		{
			get
			{
				return this._isUsed;
			}
			set
			{
				if (this._isUsed != value)
				{
					this._isUsed = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000479 RID: 1145 RVA: 0x00004878 File Offset: 0x00002A78
		// (set) Token: 0x0600047A RID: 1146 RVA: 0x00004880 File Offset: 0x00002A80
		public string Skin
		{
			get
			{
				return this._skin;
			}
			set
			{
				this._skin = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x00004890 File Offset: 0x00002A90
		// (set) Token: 0x0600047C RID: 1148 RVA: 0x00004898 File Offset: 0x00002A98
		public DateTime BeginDate
		{
			get
			{
				return this._beginDate;
			}
			set
			{
				if (!(this._beginDate == value))
				{
					this._beginDate = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x0600047D RID: 1149 RVA: 0x000048B6 File Offset: 0x00002AB6
		// (set) Token: 0x0600047E RID: 1150 RVA: 0x000048BE File Offset: 0x00002ABE
		public int ValidDate
		{
			get
			{
				return this._validDate;
			}
			set
			{
				if (this._validDate != value)
				{
					this._validDate = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x000048D7 File Offset: 0x00002AD7
		// (set) Token: 0x06000480 RID: 1152 RVA: 0x000048DF File Offset: 0x00002ADF
		public DateTime RemoveDate
		{
			get
			{
				return this._removeDate;
			}
			set
			{
				if (!(this._removeDate == value))
				{
					this._removeDate = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x000048FD File Offset: 0x00002AFD
		// (set) Token: 0x06000482 RID: 1154 RVA: 0x00004905 File Offset: 0x00002B05
		public int RemoveType
		{
			get
			{
				return this._removeType;
			}
			set
			{
				if (this._removeType != value)
				{
					this._removeType = value;
					this._removeDate = DateTime.Now;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x00004929 File Offset: 0x00002B29
		// (set) Token: 0x06000484 RID: 1156 RVA: 0x00004931 File Offset: 0x00002B31
		public int Hole1
		{
			get
			{
				return this._hole1;
			}
			set
			{
				if (this.Hole1 != value)
				{
					this._hole1 = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x0000494A File Offset: 0x00002B4A
		// (set) Token: 0x06000486 RID: 1158 RVA: 0x00004952 File Offset: 0x00002B52
		public int Hole2
		{
			get
			{
				return this._hole2;
			}
			set
			{
				if (this.Hole2 != value)
				{
					this._hole2 = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x0000496B File Offset: 0x00002B6B
		// (set) Token: 0x06000488 RID: 1160 RVA: 0x00004973 File Offset: 0x00002B73
		public int Hole3
		{
			get
			{
				return this._hole3;
			}
			set
			{
				if (this.Hole3 != value)
				{
					this._hole3 = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x0000498C File Offset: 0x00002B8C
		// (set) Token: 0x0600048A RID: 1162 RVA: 0x00004994 File Offset: 0x00002B94
		public int Hole4
		{
			get
			{
				return this._hole4;
			}
			set
			{
				if (this.Hole4 != value)
				{
					this._hole4 = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x000049AD File Offset: 0x00002BAD
		// (set) Token: 0x0600048C RID: 1164 RVA: 0x000049B5 File Offset: 0x00002BB5
		public int Hole5
		{
			get
			{
				return this._hole5;
			}
			set
			{
				if (this.Hole5 != value)
				{
					this._hole5 = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x000049CE File Offset: 0x00002BCE
		// (set) Token: 0x0600048E RID: 1166 RVA: 0x000049D6 File Offset: 0x00002BD6
		public int Hole6
		{
			get
			{
				return this._hole6;
			}
			set
			{
				if (this.Hole6 != value)
				{
					this._hole6 = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x000049EF File Offset: 0x00002BEF
		public int Attack
		{
			get
			{
				return this._attackCompose + this._template.Attack;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000490 RID: 1168 RVA: 0x00004A03 File Offset: 0x00002C03
		public int Defence
		{
			get
			{
				return this._defendCompose + this._template.Defence;
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x00004A17 File Offset: 0x00002C17
		public int Agility
		{
			get
			{
				return this._agilityCompose + this._template.Agility;
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000492 RID: 1170 RVA: 0x00004A2B File Offset: 0x00002C2B
		public int Luck
		{
			get
			{
				return this._luckCompose + this._template.Luck;
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x00004A3F File Offset: 0x00002C3F
		// (set) Token: 0x06000494 RID: 1172 RVA: 0x00004A47 File Offset: 0x00002C47
		public bool IsTips
		{
			get
			{
				return this._isTips;
			}
			set
			{
				this._isTips = value;
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x00004A50 File Offset: 0x00002C50
		// (set) Token: 0x06000496 RID: 1174 RVA: 0x00004A58 File Offset: 0x00002C58
		public bool IsLogs
		{
			get
			{
				return this._isLogs;
			}
			set
			{
				this._isLogs = value;
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x00004A61 File Offset: 0x00002C61
		// (set) Token: 0x06000498 RID: 1176 RVA: 0x00004A69 File Offset: 0x00002C69
		public int Hole5Level
		{
			get
			{
				return this._hole5Level;
			}
			set
			{
				this._hole5Level = value;
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x00004A72 File Offset: 0x00002C72
		// (set) Token: 0x0600049A RID: 1178 RVA: 0x00004A7A File Offset: 0x00002C7A
		public int Hole5Exp
		{
			get
			{
				return this._hole5Exp;
			}
			set
			{
				this._hole5Exp = value;
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x00004A83 File Offset: 0x00002C83
		// (set) Token: 0x0600049C RID: 1180 RVA: 0x00004A8B File Offset: 0x00002C8B
		public int Hole6Level
		{
			get
			{
				return this._hole6Level;
			}
			set
			{
				this._hole6Level = value;
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x00004A94 File Offset: 0x00002C94
		// (set) Token: 0x0600049E RID: 1182 RVA: 0x00004A9C File Offset: 0x00002C9C
		public int Hole6Exp
		{
			get
			{
				return this._hole6Exp;
			}
			set
			{
				this._hole6Exp = value;
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x00004AA5 File Offset: 0x00002CA5
		public string Pic
		{
			get
			{
				if (this.IsGold && this.GoldTemplate != null)
				{
					return this.GoldTemplate.Pic;
				}
				return this._template.Pic ?? "";
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x060004A0 RID: 1184 RVA: 0x00004AD8 File Offset: 0x00002CD8
		// (set) Token: 0x060004A1 RID: 1185 RVA: 0x00004B31 File Offset: 0x00002D31
		public bool IsGold
		{
			get
			{
				if (this._isGold && this._goldBeginTime.AddDays((double)this._goldValidDate) < DateTime.Now)
				{
					if (this._strengthenLevel > 12)
					{
						this._strengthenLevel = 12;
					}
					this._isGold = false;
					this._isDirty = true;
				}
				return this._isGold;
			}
			set
			{
				if (this._isGold != value)
				{
					this._isGold = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x00004B4A File Offset: 0x00002D4A
		// (set) Token: 0x060004A3 RID: 1187 RVA: 0x00004B52 File Offset: 0x00002D52
		public int GoldValidDate
		{
			get
			{
				return this._goldValidDate;
			}
			set
			{
				if (this._goldValidDate != value)
				{
					this._goldValidDate = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x00004B6B File Offset: 0x00002D6B
		// (set) Token: 0x060004A5 RID: 1189 RVA: 0x00004B73 File Offset: 0x00002D73
		public DateTime GoldBeginTime
		{
			get
			{
				return this._goldBeginTime;
			}
			set
			{
				if (this._goldBeginTime != value)
				{
					this._goldBeginTime = value;
					this._isDirty = true;
				}
			}
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x00004B91 File Offset: 0x00002D91
		internal ItemInfo(ItemTemplateInfo template)
		{
			this._template = template;
			if (this._template != null)
			{
				this._templateId = this._template.TemplateID;
			}
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x00004BBC File Offset: 0x00002DBC
		public ItemInfo Clone()
		{
			return new ItemInfo(this._template)
			{
				_userID = this._userID,
				_validDate = this._validDate,
				_templateId = this._templateId,
				_strengthenLevel = this._strengthenLevel,
				_luckCompose = this._luckCompose,
				_itemID = 0,
				_isJudage = this._isJudage,
				_isExist = this._isExist,
				_isBinds = this._isBinds,
				_isUsed = this._isUsed,
				_defendCompose = this._defendCompose,
				_count = this._count,
				_color = this._color,
				_skin = this._skin,
				_beginDate = this._beginDate,
				_attackCompose = this._attackCompose,
				_agilityCompose = this._agilityCompose,
				_hole1 = this._hole1,
				_hole2 = this._hole2,
				_hole3 = this._hole3,
				_hole4 = this._hole4,
				_hole5 = this._hole5,
				_hole6 = this._hole6,
				_removeDate = this._removeDate,
				_removeType = this._removeType,
				_itemID = 0,
				_bagType = -1,
				_place = -1,
				_hole5Level = this._hole5Level,
				_hole5Exp = this._hole5Exp,
				_hole6Level = this._hole6Level,
				_hole6Exp = this._hole6Exp,
				_isGold = this._isGold,
				_goldValidDate = this._goldValidDate,
				_goldBeginTime = this._goldBeginTime,
				_isDirty = true
			};
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00004D6B File Offset: 0x00002F6B
		public bool IsValidItem()
		{
			return this._validDate == 0 || !this._isUsed || DateTime.Compare(this._beginDate.AddDays((double)this._validDate), DateTime.Now) > 0;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00004DA0 File Offset: 0x00002FA0
		public bool CanStackedTo(ItemInfo to)
		{
			return this._templateId == to.TemplateID && this.Template.MaxCount > 1 && this._isBinds == to.IsBinds && this._isUsed == to._isUsed && (this.ValidDate == 0 || (this.BeginDate == to.BeginDate && this.ValidDate == this.ValidDate));
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00004E14 File Offset: 0x00003014
		public int GetBagType()
		{
			int categoryID = this._template.CategoryID;
			int result;
			if (categoryID - 10 > 1)
			{
				if (categoryID != 12)
				{
					result = 0;
				}
				else
				{
					result = 2;
				}
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00004E46 File Offset: 0x00003046
		public bool CanEquip()
		{
			return this._template.CategoryID < 10 || (this._template.CategoryID >= 13 && this._template.CategoryID <= 16);
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00004E7C File Offset: 0x0000307C
		public string GetBagName()
		{
			int categoryID = this._template.CategoryID;
			string result;
			if (categoryID - 10 > 1)
			{
				if (categoryID != 12)
				{
					result = "Game.Server.GameObjects.Equip";
				}
				else
				{
					result = "Game.Server.GameObjects.Task";
				}
			}
			else
			{
				result = "Game.Server.GameObjects.Prop";
			}
			return result;
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00004EBC File Offset: 0x000030BC
		public string GetPropertyString()
		{
			return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", new object[] { this.StrengthenLevel, this.Attack, this.Defence, this.Agility, this.Luck, this.AttackCompose, this.DefendCompose, this.AgilityCompose, this.LuckCompose });
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00004F58 File Offset: 0x00003158
		public string ToShortString()
		{
			return string.Format("{0}:{1}", this.ItemID, this.Template.Name);
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00004F7A File Offset: 0x0000317A
		public static ItemInfo CreateWithoutInit(ItemTemplateInfo template)
		{
			return new ItemInfo(template);
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00004F84 File Offset: 0x00003184
		public static ItemInfo CreateFromTemplate(ItemTemplateInfo template, int count, int type)
		{
			if (template == null)
			{
				throw new ArgumentNullException("template");
			}
			return new ItemInfo(template)
			{
				TemplateID = template.TemplateID,
				AgilityCompose = 0,
				AttackCompose = 0,
				BeginDate = DateTime.Now,
				Color = "",
				Skin = "",
				DefendCompose = 0,
				IsBinds = false,
				IsUsed = false,
				IsDirty = false,
				IsExist = true,
				IsJudge = true,
				LuckCompose = 0,
				StrengthenLevel = 0,
				ValidDate = 0,
				Count = count,
				GoldBeginTime = DateTime.Now,
				IsBinds = (template.BindType == 1),
				_removeDate = DateTime.Now,
				_removeType = type,
				Hole1 = -1,
				Hole2 = -1,
				Hole3 = -1,
				Hole4 = -1,
				Hole5 = -1,
				Hole6 = -1,
				IsTips = false,
				IsLogs = false
			};
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x0000508C File Offset: 0x0000328C
		public static ItemInfo FindSpecialItemInfo(ItemInfo info, ref int gold, ref int money, ref int giftToken)
		{
			int gp = 0;
			return ItemInfo.FindSpecialItemInfo(info, ref gold, ref money, ref giftToken, ref gp);
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x000050A8 File Offset: 0x000032A8
		public static ItemInfo FindSpecialItemInfo(ItemInfo info, ref int gold, ref int money, ref int giftToken, ref int gp)
		{
			int templateID = info.TemplateID;
			if (templateID <= -200)
			{
				if (templateID != -300)
				{
					if (templateID == -200)
					{
						money += info.Count;
						info = null;
					}
				}
				else
				{
					giftToken += info.Count;
					info = null;
				}
			}
			else if (templateID != -100)
			{
				if (templateID == 11107)
				{
					gp += info.Count;
					info = null;
				}
			}
			else
			{
				gold += info.Count;
				info = null;
			}
			return info;
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00005124 File Offset: 0x00003324
		public static void OpenHole(ItemInfo item)
		{
			if (item.Template != null)
			{
				item.IsOpenHole = false;
				for (int i = 0; i < 6; i++)
				{
					ValueTuple<int, int> holeInfo = item.Template.GetHoleInfo(i + 1);
					int level = holeInfo.Item1;
					int type = holeInfo.Item2;
					if (item.StrengthenLevel >= level && type != -1)
					{
						switch (i)
						{
						case 0:
							if (item.Hole1 < 0)
							{
								item.Hole1 = 0;
								item.IsOpenHole = true;
							}
							break;
						case 1:
							if (item.Hole2 < 0)
							{
								item.Hole2 = 0;
								item.IsOpenHole = true;
							}
							break;
						case 2:
							if (item.Hole3 < 0)
							{
								item.Hole3 = 0;
								item.IsOpenHole = true;
							}
							break;
						case 3:
							if (item.Hole4 < 0)
							{
								item.Hole4 = 0;
								item.IsOpenHole = true;
							}
							break;
						case 4:
							if (item.Hole5 < 0)
							{
								item.Hole5 = 0;
								item.IsOpenHole = true;
							}
							break;
						case 5:
							if (item.Hole6 < 0)
							{
								item.Hole6 = 0;
								item.IsOpenHole = true;
							}
							break;
						}
					}
				}
			}
		}

		// Token: 0x0400029F RID: 671
		private ItemTemplateInfo _template;

		// Token: 0x040002A0 RID: 672
		private int _itemID;

		// Token: 0x040002A1 RID: 673
		private int _userID;

		// Token: 0x040002A2 RID: 674
		private int _bagType;

		// Token: 0x040002A3 RID: 675
		private int _templateId;

		// Token: 0x040002A4 RID: 676
		private int _place;

		// Token: 0x040002A5 RID: 677
		private int _count;

		// Token: 0x040002A6 RID: 678
		private bool _isJudage;

		// Token: 0x040002A7 RID: 679
		private string _color;

		// Token: 0x040002A8 RID: 680
		private bool _isExist;

		// Token: 0x040002A9 RID: 681
		private int _strengthenLevel;

		// Token: 0x040002AA RID: 682
		private int _attackCompose;

		// Token: 0x040002AB RID: 683
		private int _defendCompose;

		// Token: 0x040002AC RID: 684
		private int _luckCompose;

		// Token: 0x040002AD RID: 685
		private int _agilityCompose;

		// Token: 0x040002AE RID: 686
		private bool _isBinds;

		// Token: 0x040002AF RID: 687
		private bool _isUsed;

		// Token: 0x040002B0 RID: 688
		private string _skin;

		// Token: 0x040002B1 RID: 689
		private DateTime _beginDate;

		// Token: 0x040002B2 RID: 690
		private int _validDate;

		// Token: 0x040002B3 RID: 691
		private DateTime _removeDate;

		// Token: 0x040002B4 RID: 692
		private int _removeType;

		// Token: 0x040002B5 RID: 693
		private int _hole1;

		// Token: 0x040002B6 RID: 694
		private int _hole2;

		// Token: 0x040002B7 RID: 695
		private int _hole3;

		// Token: 0x040002B8 RID: 696
		private int _hole4;

		// Token: 0x040002B9 RID: 697
		private int _hole5;

		// Token: 0x040002BA RID: 698
		private int _hole6;

		// Token: 0x040002BB RID: 699
		private bool _isTips;

		// Token: 0x040002BC RID: 700
		private bool _isLogs;

		// Token: 0x040002BF RID: 703
		private int _hole5Level;

		// Token: 0x040002C0 RID: 704
		private int _hole5Exp;

		// Token: 0x040002C1 RID: 705
		private int _hole6Level;

		// Token: 0x040002C2 RID: 706
		private int _hole6Exp;

		// Token: 0x040002C3 RID: 707
		private bool _isGold;

		// Token: 0x040002C4 RID: 708
		private int _goldValidDate;

		// Token: 0x040002C5 RID: 709
		private DateTime _goldBeginTime;
	}
}
