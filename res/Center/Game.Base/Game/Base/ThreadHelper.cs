using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Game.Base
{
	// Token: 0x02000016 RID: 22
	public class ThreadHelper
	{
		// Token: 0x060000BE RID: 190 RVA: 0x00004CE2 File Offset: 0x00002EE2
		public static string GetThreadStackTrace(Thread thread)
		{
			return ThreadHelper.FormatStackTrace(ThreadHelper.GetThreadStack(thread));
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004CEF File Offset: 0x00002EEF
		public static StackTrace GetThreadStack(Thread thread)
		{
			thread.Suspend();
			StackTrace result = new StackTrace(thread, true);
			thread.Resume();
			return result;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004D04 File Offset: 0x00002F04
		public static string FormatStackTrace(StackTrace trace)
		{
			StringBuilder str = new StringBuilder(128);
			str.Append("\n");
			if (trace == null)
			{
				str.Append("(null)");
			}
			else
			{
				for (int i = 0; i < trace.FrameCount; i++)
				{
					StackFrame frame = trace.GetFrame(i);
					Type declType = frame.GetMethod().DeclaringType;
					str.Append("   at ").Append((declType == null) ? "(null)" : declType.FullName).Append('.')
						.Append(frame.GetMethod().Name)
						.Append(" in ")
						.Append(frame.GetFileName())
						.Append("  line:")
						.Append(frame.GetFileLineNumber())
						.Append(" col:")
						.Append(frame.GetFileColumnNumber())
						.Append("\n");
				}
			}
			return str.ToString();
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004DF4 File Offset: 0x00002FF4
		public static string FormatTime(long seconds)
		{
			StringBuilder str = new StringBuilder(10);
			long minutes = seconds / 60L;
			if (minutes > 0L)
			{
				str.Append(minutes).Append(":").Append((seconds - minutes * 60L).ToString("D2"))
					.Append(" min");
			}
			else
			{
				str.Append(seconds).Append(" sec");
			}
			return str.ToString();
		}
	}
}
