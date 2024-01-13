using System;
using System.Runtime.Serialization;

namespace Center.GMService.DataContracts
{
	// Token: 0x0200000D RID: 13
	[DataContract]
	public class ConsortiumUserData
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00004281 File Offset: 0x00002481
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00004289 File Offset: 0x00002489
		[DataMember]
		public int ID { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00004292 File Offset: 0x00002492
		// (set) Token: 0x06000098 RID: 152 RVA: 0x0000429A File Offset: 0x0000249A
		[DataMember]
		public int ConsortiaID { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000099 RID: 153 RVA: 0x000042A3 File Offset: 0x000024A3
		// (set) Token: 0x0600009A RID: 154 RVA: 0x000042AB File Offset: 0x000024AB
		[DataMember]
		public string ConsortiaName { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600009B RID: 155 RVA: 0x000042B4 File Offset: 0x000024B4
		// (set) Token: 0x0600009C RID: 156 RVA: 0x000042BC File Offset: 0x000024BC
		[DataMember]
		public int UserID { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600009D RID: 157 RVA: 0x000042C5 File Offset: 0x000024C5
		// (set) Token: 0x0600009E RID: 158 RVA: 0x000042CD File Offset: 0x000024CD
		[DataMember]
		public string UserName { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600009F RID: 159 RVA: 0x000042D6 File Offset: 0x000024D6
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x000042DE File Offset: 0x000024DE
		[DataMember]
		public string LoginName { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x000042E7 File Offset: 0x000024E7
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x000042EF File Offset: 0x000024EF
		[DataMember]
		public int RatifierID { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x000042F8 File Offset: 0x000024F8
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x00004300 File Offset: 0x00002500
		[DataMember]
		public string RatifierName { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00004309 File Offset: 0x00002509
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00004311 File Offset: 0x00002511
		[DataMember]
		public int DutyID { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x0000431A File Offset: 0x0000251A
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x00004322 File Offset: 0x00002522
		[DataMember]
		public bool IsBanChat { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x0000432B File Offset: 0x0000252B
		// (set) Token: 0x060000AA RID: 170 RVA: 0x00004333 File Offset: 0x00002533
		[DataMember]
		public string Remark { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000AB RID: 171 RVA: 0x0000433C File Offset: 0x0000253C
		// (set) Token: 0x060000AC RID: 172 RVA: 0x00004344 File Offset: 0x00002544
		[DataMember]
		public int Grade { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000AD RID: 173 RVA: 0x0000434D File Offset: 0x0000254D
		// (set) Token: 0x060000AE RID: 174 RVA: 0x00004355 File Offset: 0x00002555
		[DataMember]
		public int GP { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000AF RID: 175 RVA: 0x0000435E File Offset: 0x0000255E
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x00004366 File Offset: 0x00002566
		[DataMember]
		public int Repute { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x0000436F File Offset: 0x0000256F
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x00004377 File Offset: 0x00002577
		[DataMember]
		public int State { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00004380 File Offset: 0x00002580
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x00004388 File Offset: 0x00002588
		[DataMember]
		public int Offer { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00004391 File Offset: 0x00002591
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x00004399 File Offset: 0x00002599
		[DataMember]
		public string Colors { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000043A2 File Offset: 0x000025A2
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x000043AA File Offset: 0x000025AA
		[DataMember]
		public string Style { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x000043B3 File Offset: 0x000025B3
		// (set) Token: 0x060000BA RID: 186 RVA: 0x000043BB File Offset: 0x000025BB
		[DataMember]
		public int Hide { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000BB RID: 187 RVA: 0x000043C4 File Offset: 0x000025C4
		// (set) Token: 0x060000BC RID: 188 RVA: 0x000043CC File Offset: 0x000025CC
		[DataMember]
		public string Skin { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000BD RID: 189 RVA: 0x000043D5 File Offset: 0x000025D5
		// (set) Token: 0x060000BE RID: 190 RVA: 0x000043DD File Offset: 0x000025DD
		[DataMember]
		public int Level { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000BF RID: 191 RVA: 0x000043E6 File Offset: 0x000025E6
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x000043EE File Offset: 0x000025EE
		[DataMember]
		public string DutyName { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x000043F7 File Offset: 0x000025F7
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x000043FF File Offset: 0x000025FF
		[DataMember]
		public int Right { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00004408 File Offset: 0x00002608
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00004410 File Offset: 0x00002610
		[DataMember]
		public bool IsExist { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00004419 File Offset: 0x00002619
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00004421 File Offset: 0x00002621
		[DataMember]
		public DateTime LastDate { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x0000442A File Offset: 0x0000262A
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00004432 File Offset: 0x00002632
		[DataMember]
		public bool Sex { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x0000443B File Offset: 0x0000263B
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00004443 File Offset: 0x00002643
		[DataMember]
		public int Win { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000CB RID: 203 RVA: 0x0000444C File Offset: 0x0000264C
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00004454 File Offset: 0x00002654
		[DataMember]
		public int Total { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000CD RID: 205 RVA: 0x0000445D File Offset: 0x0000265D
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00004465 File Offset: 0x00002665
		[DataMember]
		public int Escape { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000CF RID: 207 RVA: 0x0000446E File Offset: 0x0000266E
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00004476 File Offset: 0x00002676
		[DataMember]
		public int RichesOffer { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x0000447F File Offset: 0x0000267F
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x00004487 File Offset: 0x00002687
		[DataMember]
		public int RichesRob { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00004490 File Offset: 0x00002690
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x00004498 File Offset: 0x00002698
		[DataMember]
		public int Nimbus { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x000044A1 File Offset: 0x000026A1
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x000044A9 File Offset: 0x000026A9
		[DataMember]
		public int FightPower { get; set; }
	}
}
