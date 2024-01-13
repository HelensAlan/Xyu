using System;
using System.Reflection;
using System.Threading;
using log4net;

namespace Game.Base.Packets
{
	// Token: 0x0200001A RID: 26
	public class GSPacketIn : PacketIn
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000DC RID: 220 RVA: 0x0000547D File Offset: 0x0000367D
		// (set) Token: 0x060000DD RID: 221 RVA: 0x00005485 File Offset: 0x00003685
		public int ClientID
		{
			get
			{
				return this.m_cliendId;
			}
			set
			{
				this.m_cliendId = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000DE RID: 222 RVA: 0x0000548E File Offset: 0x0000368E
		// (set) Token: 0x060000DF RID: 223 RVA: 0x00005496 File Offset: 0x00003696
		public short Code
		{
			get
			{
				return this.m_code;
			}
			set
			{
				this.m_code = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x0000549F File Offset: 0x0000369F
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x000054A7 File Offset: 0x000036A7
		public int Parameter1
		{
			get
			{
				return this.m_parameter1;
			}
			set
			{
				this.m_parameter1 = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x000054B0 File Offset: 0x000036B0
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x000054B8 File Offset: 0x000036B8
		public int Parameter2
		{
			get
			{
				return this.m_parameter2;
			}
			set
			{
				this.m_parameter2 = value;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000054C1 File Offset: 0x000036C1
		public void ClearChecksum()
		{
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000054D9 File Offset: 0x000036D9
		public GSPacketIn(short code)
			: this(code, 0, 8192)
		{
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000054E8 File Offset: 0x000036E8
		public GSPacketIn(byte[] buf, int size)
			: base(buf, size)
		{
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000054F2 File Offset: 0x000036F2
		public GSPacketIn(short code, int clientId)
			: this(code, clientId, 8192)
		{
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00005501 File Offset: 0x00003701
		public GSPacketIn(short code, int clientId, int size)
			: base(new byte[size], 20)
		{
			this.m_code = code;
			this.m_cliendId = clientId;
			this.m_offset = 20;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00005528 File Offset: 0x00003728
		public short checkSum()
		{
			short num = 119;
			int num2 = 6;
			while (num2 < this.m_length)
			{
				try
				{
					num += (short)this.m_buffer[num2++];
				}
				catch (Exception e)
				{
					if (GSPacketIn.log.IsErrorEnabled)
					{
						GSPacketIn.log.Error("checkSum", e);
					}
				}
			}
			return num & 32639;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005590 File Offset: 0x00003790
		public void ClearContext()
		{
			this.m_offset = 20;
			this.m_length = 20;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000055A2 File Offset: 0x000037A2
		public GSPacketIn Clone()
		{
			GSPacketIn gspacketIn = new GSPacketIn(this.m_buffer, this.m_length);
			gspacketIn.ReadHeader();
			gspacketIn.Offset = this.m_length;
			return gspacketIn;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000055C8 File Offset: 0x000037C8
		public void Compress()
		{
			byte[] src = Marshal.Compress(this.m_buffer, 20, base.Length - 20);
			this.m_offset = 20;
			this.Write(src);
			this.m_length = src.Length + 20;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00005608 File Offset: 0x00003808
		public void ReadHeader()
		{
			this.ReadShort();
			this.m_length = (int)this.ReadShort();
			this.ReadShort();
			this.m_code = this.ReadShort();
			this.m_cliendId = this.ReadInt();
			this.m_parameter1 = this.ReadInt();
			this.m_parameter2 = this.ReadInt();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000565F File Offset: 0x0000385F
		public GSPacketIn ReadPacket()
		{
			byte[] array = this.ReadBytes();
			GSPacketIn gspacketIn = new GSPacketIn(array, array.Length);
			gspacketIn.ReadHeader();
			return gspacketIn;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00005675 File Offset: 0x00003875
		public void UnCompress()
		{
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00005678 File Offset: 0x00003878
		public void WriteHeader()
		{
			bool flag = false;
			GSPacketIn obj;
			try
			{
				obj = this;
				Monitor.Enter(this, ref flag);
				int offset = this.m_offset;
				this.m_offset = 0;
				this.WriteShort(29099);
				this.WriteShort((short)this.m_length);
				this.WriteShort(this.checkSum());
				this.WriteShort(this.m_code);
				this.WriteInt(this.m_cliendId);
				this.WriteInt(this.m_parameter1);
				this.WriteInt(this.m_parameter2);
				this.m_offset = offset;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(this);
				}
			}
			bool flag2 = false;
			try
			{
				obj = this;
				Monitor.Enter(this, ref flag2);
				int num2 = this.m_offset;
				this.m_offset = 0;
				this.WriteShort(29099);
				this.WriteShort((short)this.m_length);
				this.WriteShort(this.checkSum());
				this.WriteShort(this.m_code);
				this.WriteInt(this.m_cliendId);
				this.WriteInt(this.m_parameter1);
				this.WriteInt(this.m_parameter2);
				this.m_offset = num2;
			}
			finally
			{
				if (flag2)
				{
					Monitor.Exit(obj);
				}
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000057A8 File Offset: 0x000039A8
		public void WriteHeader3()
		{
			lock (this)
			{
				int offset = this.m_offset;
				this.m_offset = 0;
				this.WriteShort(29099);
				this.WriteShort((short)this.m_length);
				this.m_offset = 6;
				this.WriteShort(this.m_code);
				this.WriteInt(this.m_cliendId);
				this.WriteInt(this.m_parameter1);
				this.WriteInt(this.m_parameter2);
				this.m_offset = 4;
				this.WriteShort(this.checkSum());
				this.m_offset = offset;
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00005854 File Offset: 0x00003A54
		public void WritePacket(GSPacketIn pkg)
		{
			pkg.WriteHeader();
			this.Write(pkg.Buffer, 0, pkg.Length);
		}

		// Token: 0x04000059 RID: 89
		public const ushort HDR_SIZE = 20;

		// Token: 0x0400005A RID: 90
		public const short HEADER = 29099;

		// Token: 0x0400005B RID: 91
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x0400005C RID: 92
		protected int m_cliendId;

		// Token: 0x0400005D RID: 93
		protected short m_code;

		// Token: 0x0400005E RID: 94
		protected int m_parameter1;

		// Token: 0x0400005F RID: 95
		protected int m_parameter2;
	}
}
