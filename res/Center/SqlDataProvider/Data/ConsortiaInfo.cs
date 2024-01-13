using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200001E RID: 30
	public class ConsortiaInfo : DataObject
	{
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000224 RID: 548 RVA: 0x000032E1 File Offset: 0x000014E1
		// (set) Token: 0x06000225 RID: 549 RVA: 0x000032E9 File Offset: 0x000014E9
		public string AreaName
		{
			get
			{
				return this._areaName;
			}
			set
			{
				this._areaName = value;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000226 RID: 550 RVA: 0x000032F2 File Offset: 0x000014F2
		// (set) Token: 0x06000227 RID: 551 RVA: 0x000032FA File Offset: 0x000014FA
		public int ConsortiaID
		{
			get
			{
				return this._consortiaID;
			}
			set
			{
				this._consortiaID = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000228 RID: 552 RVA: 0x0000330A File Offset: 0x0000150A
		// (set) Token: 0x06000229 RID: 553 RVA: 0x00003312 File Offset: 0x00001512
		public string ConsortiaName
		{
			get
			{
				return this._consortiaName;
			}
			set
			{
				this._consortiaName = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600022A RID: 554 RVA: 0x00003322 File Offset: 0x00001522
		// (set) Token: 0x0600022B RID: 555 RVA: 0x0000332A File Offset: 0x0000152A
		public int Honor
		{
			get
			{
				return this._honor;
			}
			set
			{
				this._honor = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600022C RID: 556 RVA: 0x0000333A File Offset: 0x0000153A
		// (set) Token: 0x0600022D RID: 557 RVA: 0x00003342 File Offset: 0x00001542
		public int CreatorID
		{
			get
			{
				return this._creatorID;
			}
			set
			{
				this._creatorID = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600022E RID: 558 RVA: 0x00003352 File Offset: 0x00001552
		// (set) Token: 0x0600022F RID: 559 RVA: 0x0000335A File Offset: 0x0000155A
		public string CreatorName
		{
			get
			{
				return this._creatorName;
			}
			set
			{
				this._creatorName = value;
				this._isDirty = true;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000230 RID: 560 RVA: 0x0000336A File Offset: 0x0000156A
		// (set) Token: 0x06000231 RID: 561 RVA: 0x00003372 File Offset: 0x00001572
		public int ChairmanID
		{
			get
			{
				return this._chairmanID;
			}
			set
			{
				this._chairmanID = value;
				this._isDirty = true;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000232 RID: 562 RVA: 0x00003382 File Offset: 0x00001582
		// (set) Token: 0x06000233 RID: 563 RVA: 0x0000338A File Offset: 0x0000158A
		public string ChairmanName
		{
			get
			{
				return this._chairmanName;
			}
			set
			{
				this._chairmanName = value;
				this._isDirty = true;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000234 RID: 564 RVA: 0x0000339A File Offset: 0x0000159A
		// (set) Token: 0x06000235 RID: 565 RVA: 0x000033A2 File Offset: 0x000015A2
		public string Description
		{
			get
			{
				return this._description;
			}
			set
			{
				this._description = value;
				this._isDirty = true;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000236 RID: 566 RVA: 0x000033B2 File Offset: 0x000015B2
		// (set) Token: 0x06000237 RID: 567 RVA: 0x000033BA File Offset: 0x000015BA
		public string Placard
		{
			get
			{
				return this._placard;
			}
			set
			{
				this._placard = value;
				this._isDirty = true;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000238 RID: 568 RVA: 0x000033CA File Offset: 0x000015CA
		// (set) Token: 0x06000239 RID: 569 RVA: 0x000033D2 File Offset: 0x000015D2
		public int Level
		{
			get
			{
				return this._level;
			}
			set
			{
				this._level = value;
				this._isDirty = true;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x0600023A RID: 570 RVA: 0x000033E2 File Offset: 0x000015E2
		// (set) Token: 0x0600023B RID: 571 RVA: 0x000033EA File Offset: 0x000015EA
		public int MaxCount
		{
			get
			{
				return this._maxCount;
			}
			set
			{
				this._maxCount = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x0600023C RID: 572 RVA: 0x000033FA File Offset: 0x000015FA
		// (set) Token: 0x0600023D RID: 573 RVA: 0x00003402 File Offset: 0x00001602
		public int CelebCount
		{
			get
			{
				return this._celebCount;
			}
			set
			{
				this._celebCount = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x0600023E RID: 574 RVA: 0x00003412 File Offset: 0x00001612
		// (set) Token: 0x0600023F RID: 575 RVA: 0x0000341A File Offset: 0x0000161A
		public DateTime BuildDate
		{
			get
			{
				return this._buildDate;
			}
			set
			{
				this._buildDate = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000240 RID: 576 RVA: 0x0000342A File Offset: 0x0000162A
		// (set) Token: 0x06000241 RID: 577 RVA: 0x00003432 File Offset: 0x00001632
		public int Repute
		{
			get
			{
				return this._repute;
			}
			set
			{
				this._repute = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000242 RID: 578 RVA: 0x00003442 File Offset: 0x00001642
		// (set) Token: 0x06000243 RID: 579 RVA: 0x0000344A File Offset: 0x0000164A
		public int Count
		{
			get
			{
				return this._count;
			}
			set
			{
				this._count = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000244 RID: 580 RVA: 0x0000345A File Offset: 0x0000165A
		// (set) Token: 0x06000245 RID: 581 RVA: 0x00003462 File Offset: 0x00001662
		public string IP
		{
			get
			{
				return this._ip;
			}
			set
			{
				this._ip = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000246 RID: 582 RVA: 0x00003472 File Offset: 0x00001672
		// (set) Token: 0x06000247 RID: 583 RVA: 0x0000347A File Offset: 0x0000167A
		public int Port
		{
			get
			{
				return this._port;
			}
			set
			{
				this._port = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000248 RID: 584 RVA: 0x0000348A File Offset: 0x0000168A
		// (set) Token: 0x06000249 RID: 585 RVA: 0x00003492 File Offset: 0x00001692
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

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600024A RID: 586 RVA: 0x000034A2 File Offset: 0x000016A2
		// (set) Token: 0x0600024B RID: 587 RVA: 0x000034AA File Offset: 0x000016AA
		public int Riches
		{
			get
			{
				return this._riches;
			}
			set
			{
				this._riches = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600024C RID: 588 RVA: 0x000034BA File Offset: 0x000016BA
		// (set) Token: 0x0600024D RID: 589 RVA: 0x000034C2 File Offset: 0x000016C2
		public DateTime DeductDate
		{
			get
			{
				return this._deductDate;
			}
			set
			{
				this._deductDate = value;
				this._isDirty = true;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600024E RID: 590 RVA: 0x000034D2 File Offset: 0x000016D2
		// (set) Token: 0x0600024F RID: 591 RVA: 0x000034DA File Offset: 0x000016DA
		public int AddDayRiches { get; set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000250 RID: 592 RVA: 0x000034E3 File Offset: 0x000016E3
		// (set) Token: 0x06000251 RID: 593 RVA: 0x000034EB File Offset: 0x000016EB
		public int AddWeekRiches { get; set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000252 RID: 594 RVA: 0x000034F4 File Offset: 0x000016F4
		// (set) Token: 0x06000253 RID: 595 RVA: 0x000034FC File Offset: 0x000016FC
		public int AddDayHonor { get; set; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000254 RID: 596 RVA: 0x00003505 File Offset: 0x00001705
		// (set) Token: 0x06000255 RID: 597 RVA: 0x0000350D File Offset: 0x0000170D
		public int AddWeekHonor { get; set; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000256 RID: 598 RVA: 0x00003516 File Offset: 0x00001716
		// (set) Token: 0x06000257 RID: 599 RVA: 0x0000351E File Offset: 0x0000171E
		public int LastDayRiches { get; set; }

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000258 RID: 600 RVA: 0x00003527 File Offset: 0x00001727
		// (set) Token: 0x06000259 RID: 601 RVA: 0x0000352F File Offset: 0x0000172F
		public bool OpenApply { get; set; }

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600025A RID: 602 RVA: 0x00003538 File Offset: 0x00001738
		// (set) Token: 0x0600025B RID: 603 RVA: 0x00003540 File Offset: 0x00001740
		public int BufferLevel { get; set; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x0600025C RID: 604 RVA: 0x00003549 File Offset: 0x00001749
		// (set) Token: 0x0600025D RID: 605 RVA: 0x00003551 File Offset: 0x00001751
		public int ShopLevel { get; set; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600025E RID: 606 RVA: 0x0000355A File Offset: 0x0000175A
		// (set) Token: 0x0600025F RID: 607 RVA: 0x00003562 File Offset: 0x00001762
		public int SmithLevel { get; set; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000260 RID: 608 RVA: 0x0000356B File Offset: 0x0000176B
		// (set) Token: 0x06000261 RID: 609 RVA: 0x00003573 File Offset: 0x00001773
		public int StoreLevel { get; set; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000262 RID: 610 RVA: 0x0000357C File Offset: 0x0000177C
		// (set) Token: 0x06000263 RID: 611 RVA: 0x00003584 File Offset: 0x00001784
		public int FightPower { get; set; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000264 RID: 612 RVA: 0x0000358D File Offset: 0x0000178D
		// (set) Token: 0x06000265 RID: 613 RVA: 0x00003595 File Offset: 0x00001795
		public bool IsSystemCreate { get; set; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000266 RID: 614 RVA: 0x0000359E File Offset: 0x0000179E
		// (set) Token: 0x06000267 RID: 615 RVA: 0x000035A6 File Offset: 0x000017A6
		public bool IsActive { get; set; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000268 RID: 616 RVA: 0x000035AF File Offset: 0x000017AF
		// (set) Token: 0x06000269 RID: 617 RVA: 0x000035B7 File Offset: 0x000017B7
		public int BadgeID { get; set; }

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600026A RID: 618 RVA: 0x000035C0 File Offset: 0x000017C0
		// (set) Token: 0x0600026B RID: 619 RVA: 0x000035C8 File Offset: 0x000017C8
		public DateTime BadgeBuyTime
		{
			get
			{
				return this._badgeBuyTime;
			}
			set
			{
				this._badgeBuyTime = value;
				if (this._badgeBuyTime.AddDays((double)this.ValidDate) < DateTime.Now)
				{
					this.BadgeID = 0;
				}
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600026C RID: 620 RVA: 0x000035F6 File Offset: 0x000017F6
		// (set) Token: 0x0600026D RID: 621 RVA: 0x000035FE File Offset: 0x000017FE
		public int ValidDate { get; set; }

		// Token: 0x04000188 RID: 392
		private string _areaName;

		// Token: 0x04000189 RID: 393
		private int _consortiaID;

		// Token: 0x0400018A RID: 394
		private string _consortiaName;

		// Token: 0x0400018B RID: 395
		private int _honor;

		// Token: 0x0400018C RID: 396
		private int _creatorID;

		// Token: 0x0400018D RID: 397
		private string _creatorName;

		// Token: 0x0400018E RID: 398
		private int _chairmanID;

		// Token: 0x0400018F RID: 399
		private string _chairmanName;

		// Token: 0x04000190 RID: 400
		private string _description;

		// Token: 0x04000191 RID: 401
		private string _placard;

		// Token: 0x04000192 RID: 402
		private int _level;

		// Token: 0x04000193 RID: 403
		private int _maxCount;

		// Token: 0x04000194 RID: 404
		private int _celebCount;

		// Token: 0x04000195 RID: 405
		private DateTime _buildDate;

		// Token: 0x04000196 RID: 406
		private int _repute;

		// Token: 0x04000197 RID: 407
		private int _count;

		// Token: 0x04000198 RID: 408
		private string _ip;

		// Token: 0x04000199 RID: 409
		private int _port;

		// Token: 0x0400019A RID: 410
		private bool _isExist;

		// Token: 0x0400019B RID: 411
		private int _riches;

		// Token: 0x0400019C RID: 412
		private DateTime _deductDate;

		// Token: 0x040001AB RID: 427
		private DateTime _badgeBuyTime;
	}
}
