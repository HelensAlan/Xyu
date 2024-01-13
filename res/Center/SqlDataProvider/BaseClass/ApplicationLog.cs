using System;
using System.Diagnostics;

namespace SqlDataProvider.BaseClass
{
	// Token: 0x0200006B RID: 107
	public static class ApplicationLog
	{
		// Token: 0x06000AEA RID: 2794 RVA: 0x0000975D File Offset: 0x0000795D
		public static void WriteError(string message)
		{
			ApplicationLog.WriteLog(TraceLevel.Error, message);
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x00009768 File Offset: 0x00007968
		private static void WriteLog(TraceLevel level, string messageText)
		{
			try
			{
				EventLogEntryType LogEntryType;
				if (level != TraceLevel.Error)
				{
					LogEntryType = EventLogEntryType.Error;
				}
				else
				{
					LogEntryType = EventLogEntryType.Error;
				}
				string LogName = "Application";
				if (!EventLog.SourceExists(LogName))
				{
					EventLog.CreateEventSource(LogName, "BIZ");
				}
				new EventLog(LogName, ".", LogName).WriteEntry(messageText, LogEntryType);
			}
			catch
			{
			}
		}
	}
}
