using System;

namespace SqlDataProvider.Data
{
	// Token: 0x0200000D RID: 13
	public class BallInfo
	{
		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x000026FA File Offset: 0x000008FA
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00002702 File Offset: 0x00000902
		public int ID { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x0000270B File Offset: 0x0000090B
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00002713 File Offset: 0x00000913
		public string Name { get; set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000CB RID: 203 RVA: 0x0000271C File Offset: 0x0000091C
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00002724 File Offset: 0x00000924
		public double Power { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000CD RID: 205 RVA: 0x0000272D File Offset: 0x0000092D
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00002735 File Offset: 0x00000935
		public int Radii { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060000CF RID: 207 RVA: 0x0000273E File Offset: 0x0000093E
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00002746 File Offset: 0x00000946
		public int Amount { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x0000274F File Offset: 0x0000094F
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x00002757 File Offset: 0x00000957
		public string FlyingPartical { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00002760 File Offset: 0x00000960
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x00002768 File Offset: 0x00000968
		public string BombPartical { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00002771 File Offset: 0x00000971
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x00002779 File Offset: 0x00000979
		public string Crater { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00002782 File Offset: 0x00000982
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x0000278A File Offset: 0x0000098A
		public int AttackResponse { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00002793 File Offset: 0x00000993
		// (set) Token: 0x060000DA RID: 218 RVA: 0x0000279B File Offset: 0x0000099B
		public bool IsSpin { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060000DB RID: 219 RVA: 0x000027A4 File Offset: 0x000009A4
		// (set) Token: 0x060000DC RID: 220 RVA: 0x000027AC File Offset: 0x000009AC
		public int Mass { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060000DD RID: 221 RVA: 0x000027B5 File Offset: 0x000009B5
		// (set) Token: 0x060000DE RID: 222 RVA: 0x000027BD File Offset: 0x000009BD
		public double SpinVA { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060000DF RID: 223 RVA: 0x000027C6 File Offset: 0x000009C6
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x000027CE File Offset: 0x000009CE
		public int SpinV { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x000027D7 File Offset: 0x000009D7
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x000027DF File Offset: 0x000009DF
		public int Wind { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x000027E8 File Offset: 0x000009E8
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x000027F0 File Offset: 0x000009F0
		public int DragIndex { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x000027F9 File Offset: 0x000009F9
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00002801 File Offset: 0x00000A01
		public int Weight { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x0000280A File Offset: 0x00000A0A
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00002812 File Offset: 0x00000A12
		public bool Shake { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x0000281B File Offset: 0x00000A1B
		// (set) Token: 0x060000EA RID: 234 RVA: 0x00002823 File Offset: 0x00000A23
		public int Delay { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060000EB RID: 235 RVA: 0x0000282C File Offset: 0x00000A2C
		// (set) Token: 0x060000EC RID: 236 RVA: 0x00002834 File Offset: 0x00000A34
		public string ShootSound { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060000ED RID: 237 RVA: 0x0000283D File Offset: 0x00000A3D
		// (set) Token: 0x060000EE RID: 238 RVA: 0x00002845 File Offset: 0x00000A45
		public string BombSound { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060000EF RID: 239 RVA: 0x0000284E File Offset: 0x00000A4E
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x00002856 File Offset: 0x00000A56
		public int ActionType { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x0000285F File Offset: 0x00000A5F
		// (set) Token: 0x060000F2 RID: 242 RVA: 0x00002867 File Offset: 0x00000A67
		public bool HasTunnel { get; set; }
	}
}
