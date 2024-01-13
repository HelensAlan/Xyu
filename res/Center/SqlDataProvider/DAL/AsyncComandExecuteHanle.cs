using System;
using System.Data.SqlClient;

namespace DAL
{
	// Token: 0x0200006D RID: 109
	// (Invoke) Token: 0x06000B07 RID: 2823
	public delegate void AsyncComandExecuteHanle(SqlCommand cmd, IAsyncResult result, object state);
}
