using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SqlDataProvider.BaseClass
{
	// Token: 0x0200006C RID: 108
	public sealed class Sql_DbObject : IDisposable
	{
		// Token: 0x06000AEC RID: 2796 RVA: 0x000097C0 File Offset: 0x000079C0
		public Sql_DbObject()
		{
			this._SqlConnection = new SqlConnection();
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x000097D4 File Offset: 0x000079D4
		public Sql_DbObject(string Path_Source, string Conn_DB)
		{
			if (Path_Source != null)
			{
				if (Path_Source == "WebConfig")
				{
					this._SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[Conn_DB].ConnectionString);
					return;
				}
				if (Path_Source == "File")
				{
					this._SqlConnection = new SqlConnection(Conn_DB);
					return;
				}
				if (Path_Source == "AppConfig")
				{
					string str = ConfigurationManager.AppSettings[Conn_DB];
					this._SqlConnection = new SqlConnection(str);
					return;
				}
			}
			this._SqlConnection = new SqlConnection(Conn_DB);
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x00009860 File Offset: 0x00007A60
		private static bool OpenConnection(SqlConnection _SqlConnection)
		{
			bool result = false;
			try
			{
				if (_SqlConnection.State != ConnectionState.Open)
				{
					_SqlConnection.Open();
					result = true;
				}
				else
				{
					result = true;
				}
			}
			catch (SqlException ex)
			{
				ApplicationLog.WriteError("打开数据库连接错误:" + ex.Message.Trim());
				result = false;
			}
			return result;
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x000098B8 File Offset: 0x00007AB8
		public bool Exesqlcomm(string Sqlcomm)
		{
			if (Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						CommandType = CommandType.Text,
						Connection = this._SqlConnection,
						CommandText = Sqlcomm
					};
					this._SqlCommand.ExecuteNonQuery();
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行sql语句: " + Sqlcomm + "错误信息为: " + ex.Message.Trim());
					return false;
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00009968 File Offset: 0x00007B68
		public int GetRecordCount(string Sqlcomm)
		{
			int retval = 0;
			if (!Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				retval = 0;
			}
			else
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.Text,
						CommandText = Sqlcomm
					};
					if (this._SqlCommand.ExecuteScalar() == null)
					{
						retval = 0;
					}
					else
					{
						retval = (int)this._SqlCommand.ExecuteScalar();
					}
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行sql语句: " + Sqlcomm + "错误信息为: " + ex.Message.Trim());
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
			}
			return retval;
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x00009A28 File Offset: 0x00007C28
		public DataTable GetDataTableBySqlcomm(string TableName, string Sqlcomm)
		{
			DataTable ResultTable = new DataTable(TableName);
			DataTable result;
			if (!Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				result = ResultTable;
			}
			else
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.Text,
						CommandText = Sqlcomm
					};
					this._SqlDataAdapter = new SqlDataAdapter
					{
						SelectCommand = this._SqlCommand
					};
					this._SqlDataAdapter.Fill(ResultTable);
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行sql语句: " + Sqlcomm + "错误信息为: " + ex.Message.Trim());
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				result = ResultTable;
			}
			return result;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x00009AF4 File Offset: 0x00007CF4
		public DataSet GetDataSetBySqlcomm(string TableName, string Sqlcomm)
		{
			DataSet ResultTable = new DataSet();
			DataSet result;
			if (!Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				result = ResultTable;
			}
			else
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.Text,
						CommandText = Sqlcomm
					};
					this._SqlDataAdapter = new SqlDataAdapter
					{
						SelectCommand = this._SqlCommand
					};
					this._SqlDataAdapter.Fill(ResultTable);
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行Sql语句：" + Sqlcomm + "错误信息为：" + ex.Message.Trim());
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				result = ResultTable;
			}
			return result;
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x00009BBC File Offset: 0x00007DBC
		public bool FillSqlDataReader(ref SqlDataReader Sdr, string SqlComm)
		{
			if (Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.Text,
						CommandText = SqlComm
					};
					Sdr = this._SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
					return true;
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行Sql语句：" + SqlComm + "错误信息为：" + ex.Message.Trim());
				}
				finally
				{
					this.Dispose(true);
				}
				return false;
			}
			return false;
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x00009C64 File Offset: 0x00007E64
		public DataTable GetDataTableBySqlcomm(string TableName, string Sqlcomm, int StartRecordNo, int PageSize)
		{
			DataTable RetTable = new DataTable(TableName);
			DataTable result;
			if (!Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				RetTable.Dispose();
				this.Dispose(true);
				result = RetTable;
			}
			else
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.Text,
						CommandText = Sqlcomm
					};
					this._SqlDataAdapter = new SqlDataAdapter
					{
						SelectCommand = this._SqlCommand
					};
					DataSet ds = new DataSet();
					ds.Tables.Add(RetTable);
					this._SqlDataAdapter.Fill(ds, StartRecordNo, PageSize, TableName);
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行sql语句: " + Sqlcomm + "错误信息为: " + ex.Message.Trim());
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				result = RetTable;
			}
			return result;
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x00009D50 File Offset: 0x00007F50
		public bool RunProcedure(string ProcedureName, SqlParameter[] SqlParameters)
		{
			if (Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					foreach (SqlParameter parameter in SqlParameters)
					{
						this._SqlCommand.Parameters.Add(parameter);
					}
					this._SqlCommand.ExecuteNonQuery();
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程: " + ProcedureName + "错误信息为: " + ex.Message.Trim());
					return false;
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x00009E28 File Offset: 0x00008028
		public bool RunProcedure(string ProcedureName)
		{
			if (Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					this._SqlCommand.ExecuteNonQuery();
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程: " + ProcedureName + "错误信息为: " + ex.Message.Trim());
					return false;
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x00009ED8 File Offset: 0x000080D8
		public bool GetReader(ref SqlDataReader ResultDataReader, string ProcedureName)
		{
			if (Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					ResultDataReader = this._SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程: " + ProcedureName + "错误信息为: " + ex.Message.Trim());
					return false;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x00009F6C File Offset: 0x0000816C
		public bool GetReader(ref SqlDataReader ResultDataReader, string ProcedureName, SqlParameter[] SqlParameters)
		{
			if (Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					foreach (SqlParameter parameter in SqlParameters)
					{
						this._SqlCommand.Parameters.Add(parameter);
					}
					ResultDataReader = this._SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程: " + ProcedureName + "错误信息为: " + ex.Message.Trim());
					return false;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0000A028 File Offset: 0x00008228
		public DataSet GetDataSet(string ProcedureName, SqlParameter[] SqlParameters)
		{
			DataSet FullDataSet = new DataSet();
			DataSet result;
			if (!Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				FullDataSet.Dispose();
				result = FullDataSet;
			}
			else
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					foreach (SqlParameter parameter in SqlParameters)
					{
						this._SqlCommand.Parameters.Add(parameter);
					}
					this._SqlDataAdapter = new SqlDataAdapter
					{
						SelectCommand = this._SqlCommand
					};
					this._SqlDataAdapter.Fill(FullDataSet);
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程：" + ProcedureName + "错信信息为：" + ex.Message.Trim());
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				result = FullDataSet;
			}
			return result;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0000A11C File Offset: 0x0000831C
		public bool GetDataSet(ref DataSet ResultDataSet, ref int row_total, string TableName, string ProcedureName, int StartRecordNo, int PageSize, SqlParameter[] SqlParameters)
		{
			if (Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				try
				{
					row_total = 0;
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					foreach (SqlParameter parameter in SqlParameters)
					{
						this._SqlCommand.Parameters.Add(parameter);
					}
					this._SqlDataAdapter = new SqlDataAdapter
					{
						SelectCommand = this._SqlCommand
					};
					DataSet ds = new DataSet();
					row_total = this._SqlDataAdapter.Fill(ds);
					this._SqlDataAdapter.Fill(ResultDataSet, StartRecordNo, PageSize, TableName);
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程：" + ProcedureName + "错误信息为：" + ex.Message.Trim());
					return false;
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0000A230 File Offset: 0x00008430
		public DataSet GetDateSet(string DatesetName, string ProcedureName, SqlParameter[] SqlParameters)
		{
			DataSet FullDataSet = new DataSet(DatesetName);
			DataSet result;
			if (!Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				FullDataSet.Dispose();
				result = FullDataSet;
			}
			else
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					foreach (SqlParameter parameter in SqlParameters)
					{
						this._SqlCommand.Parameters.Add(parameter);
					}
					this._SqlDataAdapter = new SqlDataAdapter
					{
						SelectCommand = this._SqlCommand
					};
					this._SqlDataAdapter.Fill(FullDataSet);
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程：" + ProcedureName + "错信信息为：" + ex.Message.Trim());
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				result = FullDataSet;
			}
			return result;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0000A328 File Offset: 0x00008528
		public DataTable GetDataTable(string TableName, string ProcedureName, SqlParameter[] SqlParameters)
		{
			return this.GetDataTable(TableName, ProcedureName, SqlParameters, -1);
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x0000A334 File Offset: 0x00008534
		public DataTable GetDataTable(string TableName, string ProcedureName, SqlParameter[] SqlParameters, int commandTimeout)
		{
			DataTable FullTable = new DataTable(TableName);
			DataTable result;
			if (!Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				FullTable.Dispose();
				this.Dispose(true);
				result = FullTable;
			}
			else
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					if (commandTimeout >= 0)
					{
						this._SqlCommand.CommandTimeout = commandTimeout;
					}
					foreach (SqlParameter parameter in SqlParameters)
					{
						this._SqlCommand.Parameters.Add(parameter);
					}
					this._SqlDataAdapter = new SqlDataAdapter
					{
						SelectCommand = this._SqlCommand
					};
					this._SqlDataAdapter.Fill(FullTable);
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程: " + ProcedureName + "错误信息为: " + ex.Message.Trim());
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				result = FullTable;
			}
			return result;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x0000A444 File Offset: 0x00008644
		public DataTable GetDataTable(string TableName, string ProcedureName)
		{
			DataTable FullTable = new DataTable(TableName);
			DataTable result;
			if (!Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				FullTable.Dispose();
				this.Dispose(true);
				result = FullTable;
			}
			else
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					this._SqlDataAdapter = new SqlDataAdapter
					{
						SelectCommand = this._SqlCommand
					};
					this._SqlDataAdapter.Fill(FullTable);
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程: " + ProcedureName + "错误信息为: " + ex.Message.Trim());
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				result = FullTable;
			}
			return result;
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x0000A51C File Offset: 0x0000871C
		public DataTable GetDataTable(string TableName, string ProcedureName, int StartRecordNo, int PageSize)
		{
			DataTable RetTable = new DataTable(TableName);
			DataTable result;
			if (!Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				RetTable.Dispose();
				this.Dispose(true);
				result = RetTable;
			}
			else
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					this._SqlDataAdapter = new SqlDataAdapter
					{
						SelectCommand = this._SqlCommand
					};
					DataSet ds = new DataSet();
					ds.Tables.Add(RetTable);
					this._SqlDataAdapter.Fill(ds, StartRecordNo, PageSize, TableName);
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程: " + ProcedureName + "错误信息为: " + ex.Message.Trim());
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				result = RetTable;
			}
			return result;
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x0000A608 File Offset: 0x00008808
		public DataTable GetDataTable(string TableName, string ProcedureName, SqlParameter[] SqlParameters, int StartRecordNo, int PageSize)
		{
			DataTable RetTable = new DataTable(TableName);
			DataTable result;
			if (!Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				RetTable.Dispose();
				this.Dispose(true);
				result = RetTable;
			}
			else
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					foreach (SqlParameter parameter in SqlParameters)
					{
						this._SqlCommand.Parameters.Add(parameter);
					}
					this._SqlDataAdapter = new SqlDataAdapter
					{
						SelectCommand = this._SqlCommand
					};
					DataSet ds = new DataSet();
					ds.Tables.Add(RetTable);
					this._SqlDataAdapter.Fill(ds, StartRecordNo, PageSize, TableName);
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程: " + ProcedureName + "错误信息为: " + ex.Message.Trim());
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				result = RetTable;
			}
			return result;
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x0000A720 File Offset: 0x00008920
		public bool GetDataTable(ref DataTable ResultTable, string TableName, string ProcedureName, int StartRecordNo, int PageSize)
		{
			ResultTable = null;
			if (Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					this._SqlDataAdapter = new SqlDataAdapter
					{
						SelectCommand = this._SqlCommand
					};
					DataSet ds = new DataSet();
					ds.Tables.Add(ResultTable);
					this._SqlDataAdapter.Fill(ds, StartRecordNo, PageSize, TableName);
					ResultTable = ds.Tables[TableName];
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程: " + ProcedureName + "错误信息为: " + ex.Message.Trim());
					return false;
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x0000A814 File Offset: 0x00008A14
		public bool GetDataTable(ref DataTable ResultTable, string TableName, string ProcedureName, int StartRecordNo, int PageSize, SqlParameter[] SqlParameters)
		{
			if (Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					foreach (SqlParameter parameter in SqlParameters)
					{
						this._SqlCommand.Parameters.Add(parameter);
					}
					this._SqlDataAdapter = new SqlDataAdapter
					{
						SelectCommand = this._SqlCommand
					};
					DataSet ds = new DataSet();
					ds.Tables.Add(ResultTable);
					this._SqlDataAdapter.Fill(ds, StartRecordNo, PageSize, TableName);
					ResultTable = ds.Tables[TableName];
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程: " + ProcedureName + "错误信息为: " + ex.Message.Trim());
					return false;
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x0000A92C File Offset: 0x00008B2C
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(true);
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x0000A940 File Offset: 0x00008B40
		private void Dispose(bool disposing)
		{
			if (disposing && this._SqlDataAdapter != null)
			{
				if (this._SqlDataAdapter.SelectCommand != null)
				{
					if (this._SqlCommand.Connection != null)
					{
						this._SqlDataAdapter.SelectCommand.Connection.Dispose();
					}
					this._SqlDataAdapter.SelectCommand.Dispose();
				}
				this._SqlDataAdapter.Dispose();
				this._SqlDataAdapter = null;
			}
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x0000A9AC File Offset: 0x00008BAC
		public void BeginRunProcedure(string ProcedureName, SqlParameter[] SqlParameters)
		{
			if (Sql_DbObject.OpenConnection(this._SqlConnection))
			{
				try
				{
					this._SqlCommand = new SqlCommand
					{
						Connection = this._SqlConnection,
						CommandType = CommandType.StoredProcedure,
						CommandText = ProcedureName
					};
					foreach (SqlParameter parameter in SqlParameters)
					{
						this._SqlCommand.Parameters.Add(parameter);
					}
					this._SqlCommand.BeginExecuteNonQuery();
				}
				catch (SqlException ex)
				{
					ApplicationLog.WriteError("执行存储过程: " + ProcedureName + "错误信息为: " + ex.Message.Trim());
				}
				finally
				{
					this._SqlConnection.Close();
					this.Dispose(true);
				}
			}
		}

		// Token: 0x040005C0 RID: 1472
		private SqlConnection _SqlConnection;

		// Token: 0x040005C1 RID: 1473
		private SqlCommand _SqlCommand;

		// Token: 0x040005C2 RID: 1474
		private SqlDataAdapter _SqlDataAdapter;
	}
}
