using System;
using System.Text;
using System.Threading;

namespace Game.Base
{
	// Token: 0x02000013 RID: 19
	public class PacketIn
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00004070 File Offset: 0x00002270
		public byte[] Buffer
		{
			get
			{
				return this.m_buffer;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00004078 File Offset: 0x00002278
		public int DataLeft
		{
			get
			{
				return this.m_length - this.m_offset;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00004087 File Offset: 0x00002287
		public int Length
		{
			get
			{
				return this.m_length;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000090 RID: 144 RVA: 0x0000408F File Offset: 0x0000228F
		// (set) Token: 0x06000091 RID: 145 RVA: 0x00004097 File Offset: 0x00002297
		public int Offset
		{
			get
			{
				return this.m_offset;
			}
			set
			{
				this.m_offset = value;
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000040A0 File Offset: 0x000022A0
		public PacketIn(byte[] buf, int len)
		{
			this.isSended = true;
			this.m_buffer = buf;
			this.m_length = len;
			this.m_offset = 0;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000040C8 File Offset: 0x000022C8
		public virtual int CopyFrom(byte[] src, int srcOffset, int offset, int count)
		{
			int result;
			if (count < this.m_buffer.Length && count - srcOffset < src.Length)
			{
				System.Buffer.BlockCopy(src, srcOffset, this.m_buffer, offset, count);
				result = count;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004104 File Offset: 0x00002304
		public virtual int CopyFrom(byte[] src, int srcOffset, int offset, int count, int key)
		{
			int result;
			if (count >= this.m_buffer.Length || count - srcOffset >= src.Length)
			{
				result = -1;
			}
			else
			{
				key = (key & 16711680) >> 16;
				for (int i = 0; i < count; i++)
				{
					this.m_buffer[offset + i] = (byte)((int)src[srcOffset + i] ^ key);
				}
				result = count;
			}
			return result;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000415C File Offset: 0x0000235C
		public virtual int[] CopyFrom3(byte[] src, int srcOffset, int offset, int count, byte[] key)
		{
			int[] numArray = new int[count];
			for (int i = 0; i < count; i++)
			{
				this.m_buffer[i] = src[i];
			}
			if (count < this.m_buffer.Length && count - srcOffset < src.Length)
			{
				this.m_buffer[0] = src[srcOffset] ^ key[0];
				for (int j = 1; j < count; j++)
				{
					key[j % 8] = (byte)((int)(key[j % 8] + src[srcOffset + j - 1]) ^ j);
					this.m_buffer[j] = (src[srcOffset + j] - src[srcOffset + j - 1]) ^ key[j % 8];
				}
			}
			return numArray;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000041F4 File Offset: 0x000023F4
		public virtual int CopyTo(byte[] dst, int dstOffset, int offset)
		{
			int count = ((this.m_length - offset < dst.Length - dstOffset) ? (this.m_length - offset) : (dst.Length - dstOffset));
			if (count > 0)
			{
				System.Buffer.BlockCopy(this.m_buffer, offset, dst, dstOffset, count);
			}
			return count;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004234 File Offset: 0x00002434
		public virtual int CopyTo(byte[] dst, int dstOffset, int offset, byte[] key)
		{
			int num = ((this.m_length - offset < dst.Length - dstOffset) ? (this.m_length - offset) : (dst.Length - dstOffset));
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					if (offset + i == 0)
					{
						dst[dstOffset] = this.m_buffer[offset + i] ^ key[(offset + i) % 8];
					}
					else if (i == 0 && dstOffset == 0)
					{
						key[(offset + i) % 8] = (byte)((int)(key[(offset + i) % 8] + this.lastbits) ^ (offset + i));
						dst[dstOffset + i] = (this.m_buffer[offset + i] ^ key[(offset + i) % 8]) + this.lastbits;
					}
					else
					{
						key[(offset + i) % 8] = (byte)((int)(key[(offset + i) % 8] + dst[dstOffset + i - 1]) ^ (offset + i));
						dst[dstOffset + i] = (this.m_buffer[offset + i] ^ key[(offset + i) % 8]) + dst[dstOffset + i - 1];
						if (i == num - 1)
						{
							this.lastbits = dst[dstOffset + i];
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00004330 File Offset: 0x00002530
		public virtual int CopyTo3(byte[] dst, int dstOffset, int offset, byte[] key, ref int packetArrangeSend)
		{
			int num = ((this.m_length - offset < dst.Length - dstOffset) ? (this.m_length - offset) : (dst.Length - dstOffset));
			int result;
			lock (this)
			{
				if (num > 0)
				{
					int num2;
					if (this.isSended)
					{
						this.packetNum = Interlocked.Increment(ref packetArrangeSend);
						packetArrangeSend = this.packetNum;
						this.m_sended = 0;
						this.isSended = false;
						num2 = this.m_sended + dstOffset;
					}
					else
					{
						num2 = 8192;
					}
					if (this.packetNum != packetArrangeSend)
					{
						result = 0;
						return result;
					}
					for (int i = 0; i < num; i++)
					{
						int index = offset + i;
						while (num2 > 8192)
						{
							num2 -= 8192;
						}
						if (this.m_sended == 0)
						{
							dst[dstOffset] = this.m_buffer[index] ^ key[this.m_sended % 8];
						}
						else
						{
							if (num2 == 0)
							{
								result = 0;
								return result;
							}
							key[this.m_sended % 8] = (byte)((int)(key[this.m_sended % 8] + dst[num2 - 1]) ^ this.m_sended);
							dst[dstOffset + i] = (this.m_buffer[index] ^ key[this.m_sended % 8]) + dst[num2 - 1];
						}
						this.m_sended++;
						num2++;
					}
				}
				result = num;
			}
			return result;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000044C4 File Offset: 0x000026C4
		public virtual void Fill(byte val, int num)
		{
			for (int i = 0; i < num; i++)
			{
				this.WriteByte(val);
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000044E4 File Offset: 0x000026E4
		public virtual bool ReadBoolean()
		{
			byte[] buffer = this.m_buffer;
			int offset = this.m_offset;
			this.m_offset = offset + 1;
			return buffer[offset] > 0;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000450C File Offset: 0x0000270C
		public virtual byte ReadByte()
		{
			byte[] buffer = this.m_buffer;
			int offset = this.m_offset;
			this.m_offset = offset + 1;
			return buffer[offset];
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004531 File Offset: 0x00002731
		public virtual byte[] ReadBytes()
		{
			return this.ReadBytes(this.m_length - this.m_offset);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004548 File Offset: 0x00002748
		public virtual byte[] ReadBytes(int maxLen)
		{
			byte[] destinationArray = new byte[maxLen];
			Array.Copy(this.m_buffer, this.m_offset, destinationArray, 0, maxLen);
			this.m_offset += maxLen;
			return destinationArray;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000457F File Offset: 0x0000277F
		public DateTime ReadDateTime()
		{
			return new DateTime((int)this.ReadShort(), (int)this.ReadByte(), (int)this.ReadByte(), (int)this.ReadByte(), (int)this.ReadByte(), (int)this.ReadByte());
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000045AC File Offset: 0x000027AC
		public virtual double ReadDouble()
		{
			byte[] buffer = new byte[8];
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = this.ReadByte();
			}
			return BitConverter.ToDouble(buffer, 0);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000045E0 File Offset: 0x000027E0
		public virtual float ReadFloat()
		{
			byte[] buffer = new byte[4];
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = this.ReadByte();
			}
			return BitConverter.ToSingle(buffer, 0);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00004614 File Offset: 0x00002814
		public virtual int ReadInt()
		{
			byte v = this.ReadByte();
			byte num2 = this.ReadByte();
			byte num3 = this.ReadByte();
			byte num4 = this.ReadByte();
			return Marshal.ConvertToInt32(v, num2, num3, num4);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00004644 File Offset: 0x00002844
		public virtual long ReadLong()
		{
			int num = this.ReadInt();
			long num2 = this.readUnsignedInt();
			int num3 = 1;
			if (num < 0)
			{
				num3 = -1;
			}
			return (long)((double)num3 * (Math.Abs((double)num * Math.Pow(2.0, 32.0)) + (double)num2));
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004690 File Offset: 0x00002890
		public virtual short ReadShort()
		{
			byte v = this.ReadByte();
			byte num2 = this.ReadByte();
			return Marshal.ConvertToInt16(v, num2);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000046B0 File Offset: 0x000028B0
		public virtual short ReadShortLowEndian()
		{
			byte num = this.ReadByte();
			return Marshal.ConvertToInt16(this.ReadByte(), num);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000046D0 File Offset: 0x000028D0
		public virtual string ReadString()
		{
			short count = this.ReadShort();
			string @string = Encoding.UTF8.GetString(this.m_buffer, this.m_offset, (int)count);
			this.m_offset += (int)count;
			return @string.Replace("\0", "");
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00004718 File Offset: 0x00002918
		public virtual uint ReadUInt()
		{
			byte v = this.ReadByte();
			byte num2 = this.ReadByte();
			byte num3 = this.ReadByte();
			byte num4 = this.ReadByte();
			return Marshal.ConvertToUInt32(v, num2, num3, num4);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00004748 File Offset: 0x00002948
		public virtual long readUnsignedInt()
		{
			return (long)this.ReadInt() & -1L;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00004754 File Offset: 0x00002954
		public void Skip(int num)
		{
			this.m_offset += num;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00004764 File Offset: 0x00002964
		public virtual void WriteUnsignedInt(uint val)
		{
			this.WriteByte((byte)(val >> 24));
			this.WriteByte((byte)((val >> 16) & 255U));
			this.WriteByte((byte)((val & 65535U) >> 8));
			this.WriteByte((byte)(val & 65535U & 255U));
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000047B1 File Offset: 0x000029B1
		public virtual void Write(byte[] src)
		{
			this.Write(src, 0, src.Length);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000047C0 File Offset: 0x000029C0
		public virtual void Write(byte[] src, int offset, int len)
		{
			if (this.m_offset + len >= this.m_buffer.Length)
			{
				byte[] sourceArray = this.m_buffer;
				this.m_buffer = new byte[this.m_buffer.Length * 2];
				Array.Copy(sourceArray, this.m_buffer, sourceArray.Length);
				this.Write(src, offset, len);
				return;
			}
			Array.Copy(src, offset, this.m_buffer, this.m_offset, len);
			this.m_offset += len;
			this.m_length = ((this.m_offset > this.m_length) ? this.m_offset : this.m_length);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00004858 File Offset: 0x00002A58
		public virtual void Write3(byte[] src, int offset, int len)
		{
			Array.Copy(src, offset, this.m_buffer, this.m_offset, len);
			this.m_offset += len;
			this.m_length = ((this.m_offset > this.m_length) ? this.m_offset : this.m_length);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000048AC File Offset: 0x00002AAC
		public virtual void WriteBoolean(bool val)
		{
			if (this.m_offset == this.m_buffer.Length)
			{
				byte[] sourceArray = this.m_buffer;
				this.m_buffer = new byte[this.m_buffer.Length * 2];
				Array.Copy(sourceArray, this.m_buffer, sourceArray.Length);
			}
			byte[] buffer = this.m_buffer;
			int offset = this.m_offset;
			this.m_offset = offset + 1;
			buffer[offset] = (val ? 1 : 0);
			this.m_length = ((this.m_offset > this.m_length) ? this.m_offset : this.m_length);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00004938 File Offset: 0x00002B38
		public virtual void WriteByte(byte val)
		{
			if (this.m_offset == this.m_buffer.Length)
			{
				byte[] sourceArray = this.m_buffer;
				this.m_buffer = new byte[this.m_buffer.Length * 2];
				Array.Copy(sourceArray, this.m_buffer, sourceArray.Length);
			}
			byte[] buffer = this.m_buffer;
			int offset = this.m_offset;
			this.m_offset = offset + 1;
			buffer[offset] = val;
			this.m_length = ((this.m_offset > this.m_length) ? this.m_offset : this.m_length);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000049BC File Offset: 0x00002BBC
		public void WriteDateTime(DateTime date)
		{
			this.WriteShort((short)date.Year);
			this.WriteByte((byte)date.Month);
			this.WriteByte((byte)date.Day);
			this.WriteByte((byte)date.Hour);
			this.WriteByte((byte)date.Minute);
			this.WriteByte((byte)date.Second);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00004A20 File Offset: 0x00002C20
		public virtual void WriteDouble(double val)
		{
			byte[] bytes = BitConverter.GetBytes(val);
			this.Write(bytes);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00004A3C File Offset: 0x00002C3C
		public virtual void WriteFloat(float val)
		{
			byte[] bytes = BitConverter.GetBytes(val);
			this.Write(bytes);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004A58 File Offset: 0x00002C58
		public virtual void WriteInt(int val)
		{
			this.WriteByte((byte)(val >> 24));
			this.WriteByte((byte)((val >> 16) & 255));
			this.WriteByte((byte)((val & 65535) >> 8));
			this.WriteByte((byte)(val & 65535 & 255));
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004AA8 File Offset: 0x00002CA8
		public virtual void WriteLong(long val)
		{
			int num2 = (int)val;
			string str = Convert.ToString(val, 2);
			string str2 = ((str.Length <= 32) ? "" : str.Substring(0, str.Length - 32));
			int num3 = 0;
			for (int i = 0; i < str2.Length; i++)
			{
				string str3 = str2.Substring(str2.Length - (i + 1));
				if (!(str3 == "0"))
				{
					if (!(str3 == "1"))
					{
						break;
					}
					num3 += 1 << i;
				}
			}
			this.WriteInt(num3);
			this.WriteInt(num2);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004B40 File Offset: 0x00002D40
		public virtual void WriteShort(short val)
		{
			this.WriteByte((byte)(val >> 8));
			this.WriteByte((byte)(val & 255));
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004B5A File Offset: 0x00002D5A
		public virtual void WriteShortLowEndian(short val)
		{
			this.WriteByte((byte)(val & 255));
			this.WriteByte((byte)(val >> 8));
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004B74 File Offset: 0x00002D74
		public virtual void WriteString(string str)
		{
			if (!string.IsNullOrEmpty(str))
			{
				byte[] bytes = Encoding.UTF8.GetBytes(str);
				this.WriteShort((short)(bytes.Length + 1));
				this.Write(bytes, 0, bytes.Length);
				this.WriteByte(0);
				return;
			}
			this.WriteShort(1);
			this.WriteByte(0);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00004BC4 File Offset: 0x00002DC4
		public virtual void WriteString(string str, int maxlen)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			int len = ((bytes.Length < maxlen) ? bytes.Length : maxlen);
			this.WriteShort((short)len);
			this.Write(bytes, 0, len);
		}

		// Token: 0x0400003F RID: 63
		public volatile bool isSended;

		// Token: 0x04000040 RID: 64
		private byte lastbits;

		// Token: 0x04000041 RID: 65
		protected byte[] m_buffer;

		// Token: 0x04000042 RID: 66
		protected byte[] m_buffer2;

		// Token: 0x04000043 RID: 67
		protected int m_length;

		// Token: 0x04000044 RID: 68
		public volatile int m_loop;

		// Token: 0x04000045 RID: 69
		protected int m_offset;

		// Token: 0x04000046 RID: 70
		public volatile int m_sended;

		// Token: 0x04000047 RID: 71
		public volatile int packetNum;
	}
}
