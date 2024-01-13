using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using log4net;
using SqlDataProvider.BaseClass;

namespace Bussiness
{
	// Token: 0x02000006 RID: 6
	public class BaseBussiness : IDisposable
	{
		// Token: 0x0600002E RID: 46 RVA: 0x0000391F File Offset: 0x00001B1F
		public BaseBussiness()
		{
			this.db = new Sql_DbObject("AppConfig", "conString");
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000393C File Offset: 0x00001B3C
		public DataTable GetPage(string queryStr, string queryWhere, int pageCurrent, int pageSize, string fdShow, string fdOreder, string fdKey, ref int total)
		{
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@QueryStr", queryStr),
					new SqlParameter("@QueryWhere", queryWhere),
					new SqlParameter("@PageSize", pageSize),
					new SqlParameter("@PageCurrent", pageCurrent),
					new SqlParameter("@FdShow", fdShow),
					new SqlParameter("@FdOrder", fdOreder),
					new SqlParameter("@FdKey", fdKey),
					new SqlParameter("@TotalRow", total)
				};
				para[7].Direction = ParameterDirection.Output;
				DataTable dataTable = this.db.GetDataTable(queryStr, "SP_CustomPage", para, 120);
				total = (int)para[7].Value;
				return dataTable;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error(string.Format("Custome Page queryStr@{0},queryWhere@{1},pageCurrent@{2},pageSize@{3},fdShow@{4},fdOrder@{5},fdKey@{6}", new object[] { queryStr, queryWhere, pageCurrent, pageSize, fdShow, fdOreder, fdKey }), e);
				}
			}
			return new DataTable(queryStr);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003A74 File Offset: 0x00001C74
		public DataTable GetFetch_List(int page, int size, string sOrder, string sWhere, string tableName, ref int total)
		{
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@page_num", page),
					new SqlParameter("@row_in_page", size),
					new SqlParameter("@order_column", sOrder),
					new SqlParameter("@row_total", total)
					{
						Direction = ParameterDirection.Output
					},
					new SqlParameter("@comb_condition", sWhere),
					new SqlParameter("@tablename", tableName)
				};
				DataTable dataTable = this.db.GetDataTable("table1", "Sp_Fetch_List", para);
				total = (int)para[3].Value;
				return dataTable;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error(string.Format("Sp_Fetch_List  page@{0},sOrder@{1},sWhere{2},tableName{3}", new object[] { page, size, sOrder, sWhere, tableName }), e);
				}
			}
			return new DataTable(tableName);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003B84 File Offset: 0x00001D84
		protected T InitValue<T>(SqlDataReader reader, List<string> ignoreFields = null)
		{
			Type typeFromHandle = typeof(T);
			object obj = Activator.CreateInstance(typeFromHandle);
			foreach (PropertyInfo p in typeFromHandle.GetProperties())
			{
				if (ignoreFields == null || (ignoreFields != null && !ignoreFields.Contains(p.Name)))
				{
					p.SetValue(obj, reader[p.Name]);
				}
			}
			return (T)((object)obj);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003BE8 File Offset: 0x00001DE8
		protected string GetInsertCommand<T>(T t, string tableName, List<string> ignoreFields = null)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("insert into " + tableName + " ");
			Type type = t.GetType();
			List<string> columnList = new List<string>();
			List<string> valueList = new List<string>();
			foreach (PropertyInfo p in type.GetProperties())
			{
				if (ignoreFields == null || (ignoreFields != null && !ignoreFields.Contains(p.Name)))
				{
					columnList.Add("[" + p.Name + "]");
					valueList.Add(string.Format("'{0}'", p.GetValue(t)));
				}
			}
			sb.Append("(");
			sb.Append(string.Join(", ", columnList));
			sb.Append(") values (");
			sb.Append(string.Join(", ", valueList));
			sb.Append(")");
			return sb.ToString();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003CE8 File Offset: 0x00001EE8
		protected string GetUpdateCommand<T>(T t, string tableName, string condiction, List<string> ignoreFields = null)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("update " + tableName + " set ");
			Type type = t.GetType();
			List<string> paraList = new List<string>();
			foreach (PropertyInfo p in type.GetProperties())
			{
				if (ignoreFields == null || (ignoreFields != null && !ignoreFields.Contains(p.Name)))
				{
					paraList.Add(string.Format("{0} = '{1}'", p.Name, p.GetValue(t)));
				}
			}
			sb.Append(string.Join(", ", paraList));
			sb.Append(condiction);
			return sb.ToString();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003D9A File Offset: 0x00001F9A
		public void Dispose()
		{
			this.db.Dispose();
			GC.SuppressFinalize(this);
		}

		// Token: 0x04000012 RID: 18
		protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x04000013 RID: 19
		protected Sql_DbObject db;
	}
}
