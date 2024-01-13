using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml;

namespace DAL
{
	// Token: 0x0200006E RID: 110
	public sealed class SqlHelper
	{
		// Token: 0x06000B0A RID: 2826 RVA: 0x0000AA74 File Offset: 0x00008C74
		private SqlHelper()
		{
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x0000AA7C File Offset: 0x00008C7C
		private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
		{
			foreach (SqlParameter p in commandParameters)
			{
				if (p.Direction == ParameterDirection.InputOutput && p.Value == null)
				{
					p.Value = DBNull.Value;
				}
				command.Parameters.Add(p);
			}
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0000AAC4 File Offset: 0x00008CC4
		public static void AssignParameterValues(SqlParameter[] commandParameters, params object[] parameterValues)
		{
			if (commandParameters != null && parameterValues != null)
			{
				if (commandParameters.Length != parameterValues.Length)
				{
					throw new ArgumentException("Parameter count does not match Parameter Value count.");
				}
				int i = 0;
				int j = commandParameters.Length;
				while (i < j)
				{
					if (parameterValues[i] != null && (commandParameters[i].Direction == ParameterDirection.Input || commandParameters[i].Direction == ParameterDirection.InputOutput))
					{
						commandParameters[i].Value = parameterValues[i];
					}
					i++;
				}
			}
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x0000AB20 File Offset: 0x00008D20
		public static void AssignParameterValues(SqlParameter[] commandParameters, Hashtable parameterValues)
		{
			if (commandParameters != null && parameterValues != null)
			{
				if (commandParameters.Length != parameterValues.Count)
				{
					throw new ArgumentException("Parameter count does not match Parameter Value count.");
				}
				int i = 0;
				int j = commandParameters.Length;
				while (i < j)
				{
					if (parameterValues[commandParameters[i].ParameterName] != null && (commandParameters[i].Direction == ParameterDirection.Input || commandParameters[i].Direction == ParameterDirection.InputOutput))
					{
						commandParameters[i].Value = parameterValues[commandParameters[i].ParameterName];
					}
					i++;
				}
			}
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x0000AB95 File Offset: 0x00008D95
		private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
		{
			if (connection.State != ConnectionState.Open)
			{
				connection.Open();
			}
			command.Connection = connection;
			command.CommandText = commandText;
			if (transaction != null)
			{
				command.Transaction = transaction;
			}
			command.CommandType = commandType;
			if (commandParameters != null)
			{
				SqlHelper.AttachParameters(command, commandParameters);
			}
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x0000ABD2 File Offset: 0x00008DD2
		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
		{
			return SqlHelper.ExecuteNonQuery(connectionString, commandType, commandText, null);
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0000ABE0 File Offset: 0x00008DE0
		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			int result;
			using (SqlConnection cn = new SqlConnection(connectionString))
			{
				cn.Open();
				result = SqlHelper.ExecuteNonQuery(cn, commandType, commandText, commandParameters);
			}
			return result;
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x0000AC24 File Offset: 0x00008E24
		public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
		{
			int result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0000AC60 File Offset: 0x00008E60
		public static int ExecuteNonQuery(string connectionString, string spName, Hashtable parameterValues)
		{
			int result;
			if (parameterValues != null && parameterValues.Count > 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x0000AC9E File Offset: 0x00008E9E
		public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText)
		{
			return SqlHelper.ExecuteNonQuery(connection, commandType, commandText, null);
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x0000ACAC File Offset: 0x00008EAC
		public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			SqlCommand sqlCommand = new SqlCommand();
			SqlHelper.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters);
			int retval = sqlCommand.ExecuteNonQuery();
			sqlCommand.Parameters.Clear();
			return retval;
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x0000ACDC File Offset: 0x00008EDC
		public static int ExecuteNonQuery(SqlConnection connection, string spName, params object[] parameterValues)
		{
			int result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x0000AD1C File Offset: 0x00008F1C
		public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			SqlCommand sqlCommand = new SqlCommand();
			SqlHelper.PrepareCommand(sqlCommand, transaction.Connection, transaction, commandType, commandText, commandParameters);
			int retval = sqlCommand.ExecuteNonQuery();
			sqlCommand.Parameters.Clear();
			return retval;
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0000AD50 File Offset: 0x00008F50
		public static int ExecuteNonQuery(SqlTransaction transaction, string spName, params object[] parameterValues)
		{
			int result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, new SqlParameter[0]);
			}
			return result;
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x0000AD99 File Offset: 0x00008F99
		public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
		{
			return SqlHelper.ExecuteDataset(connectionString, commandType, commandText, null);
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x0000ADA4 File Offset: 0x00008FA4
		public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			DataSet result;
			using (SqlConnection cn = new SqlConnection(connectionString))
			{
				cn.Open();
				result = SqlHelper.ExecuteDataset(cn, commandType, commandText, commandParameters);
			}
			return result;
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x0000ADE8 File Offset: 0x00008FE8
		public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
		{
			DataSet result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x0000AE21 File Offset: 0x00009021
		public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText)
		{
			return SqlHelper.ExecuteDataset(connection, commandType, commandText, null);
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x0000AE2C File Offset: 0x0000902C
		public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			SqlCommand sqlCommand = new SqlCommand();
			SqlHelper.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters);
			DataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
			DataSet ds = new DataSet();
			dataAdapter.Fill(ds);
			sqlCommand.Parameters.Clear();
			return ds;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0000AE68 File Offset: 0x00009068
		public static DataSet ExecuteDataset(SqlConnection connection, string spName, params object[] parameterValues)
		{
			DataSet result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0000AEA6 File Offset: 0x000090A6
		public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText)
		{
			return SqlHelper.ExecuteDataset(transaction, commandType, commandText, null);
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0000AEB4 File Offset: 0x000090B4
		public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			SqlCommand sqlCommand = new SqlCommand();
			SqlHelper.PrepareCommand(sqlCommand, transaction.Connection, transaction, commandType, commandText, commandParameters);
			DataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
			DataSet ds = new DataSet();
			dataAdapter.Fill(ds);
			sqlCommand.Parameters.Clear();
			return ds;
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0000AEF4 File Offset: 0x000090F4
		public static DataSet ExecuteDataset(SqlTransaction transaction, string spName, params object[] parameterValues)
		{
			DataSet result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x0000AF38 File Offset: 0x00009138
		private static SqlDataReader ExecuteReader(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, SqlHelper.SqlConnectionOwnership connectionOwnership)
		{
			SqlCommand cmd = new SqlCommand();
			SqlHelper.PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters);
			SqlDataReader dr;
			if (connectionOwnership == SqlHelper.SqlConnectionOwnership.External)
			{
				dr = cmd.ExecuteReader();
			}
			else
			{
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
			cmd.Parameters.Clear();
			return dr;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x0000AF7A File Offset: 0x0000917A
		public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
		{
			return SqlHelper.ExecuteReader(connectionString, commandType, commandText, null);
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x0000AF88 File Offset: 0x00009188
		public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			SqlConnection cn = new SqlConnection(connectionString);
			cn.Open();
			SqlDataReader result;
			try
			{
				result = SqlHelper.ExecuteReader(cn, null, commandType, commandText, commandParameters, SqlHelper.SqlConnectionOwnership.Internal);
			}
			catch
			{
				cn.Close();
				throw;
			}
			return result;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x0000AFCC File Offset: 0x000091CC
		public static SqlDataReader ExecuteReader(string connectionString, string spName, params object[] parameterValues)
		{
			SqlDataReader result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0000B005 File Offset: 0x00009205
		public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText)
		{
			return SqlHelper.ExecuteReader(connection, commandType, commandText, null);
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0000B010 File Offset: 0x00009210
		public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			return SqlHelper.ExecuteReader(connection, null, commandType, commandText, commandParameters, SqlHelper.SqlConnectionOwnership.External);
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0000B020 File Offset: 0x00009220
		public static SqlDataReader ExecuteReader(SqlConnection connection, string spName, params object[] parameterValues)
		{
			SqlDataReader result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0000B05E File Offset: 0x0000925E
		public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText)
		{
			return SqlHelper.ExecuteReader(transaction, commandType, commandText, null);
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0000B069 File Offset: 0x00009269
		public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			return SqlHelper.ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, SqlHelper.SqlConnectionOwnership.External);
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0000B07C File Offset: 0x0000927C
		public static SqlDataReader ExecuteReader(SqlTransaction transaction, string spName, params object[] parameterValues)
		{
			SqlDataReader result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteReader(transaction, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0000B0BF File Offset: 0x000092BF
		public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
		{
			return SqlHelper.ExecuteScalar(connectionString, commandType, commandText, null);
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0000B0CC File Offset: 0x000092CC
		public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			object result;
			using (SqlConnection cn = new SqlConnection(connectionString))
			{
				cn.Open();
				result = SqlHelper.ExecuteScalar(cn, commandType, commandText, commandParameters);
			}
			return result;
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x0000B110 File Offset: 0x00009310
		public static object ExecuteScalar(string connectionString, string spName, params object[] parameterValues)
		{
			object result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x0000B149 File Offset: 0x00009349
		public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText)
		{
			return SqlHelper.ExecuteScalar(connection, commandType, commandText, null);
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0000B154 File Offset: 0x00009354
		public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			SqlCommand sqlCommand = new SqlCommand();
			SqlHelper.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters);
			object retval = sqlCommand.ExecuteScalar();
			sqlCommand.Parameters.Clear();
			return retval;
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x0000B184 File Offset: 0x00009384
		public static object ExecuteScalar(SqlConnection connection, string spName, params object[] parameterValues)
		{
			object result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0000B1C2 File Offset: 0x000093C2
		public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText)
		{
			return SqlHelper.ExecuteScalar(transaction, commandType, commandText, null);
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0000B1D0 File Offset: 0x000093D0
		public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			SqlCommand sqlCommand = new SqlCommand();
			SqlHelper.PrepareCommand(sqlCommand, transaction.Connection, transaction, commandType, commandText, commandParameters);
			object retval = sqlCommand.ExecuteScalar();
			sqlCommand.Parameters.Clear();
			return retval;
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0000B204 File Offset: 0x00009404
		public static object ExecuteScalar(SqlTransaction transaction, string spName, params object[] parameterValues)
		{
			object result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0000B247 File Offset: 0x00009447
		public static XmlReader ExecuteXmlReader(SqlConnection connection, CommandType commandType, string commandText)
		{
			return SqlHelper.ExecuteXmlReader(connection, commandType, commandText, null);
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0000B254 File Offset: 0x00009454
		public static XmlReader ExecuteXmlReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			SqlCommand sqlCommand = new SqlCommand();
			SqlHelper.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters);
			XmlReader retval = sqlCommand.ExecuteXmlReader();
			sqlCommand.Parameters.Clear();
			return retval;
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x0000B284 File Offset: 0x00009484
		public static XmlReader ExecuteXmlReader(SqlConnection connection, string spName, params object[] parameterValues)
		{
			XmlReader result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0000B2C2 File Offset: 0x000094C2
		public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText)
		{
			return SqlHelper.ExecuteXmlReader(transaction, commandType, commandText, null);
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0000B2D0 File Offset: 0x000094D0
		public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			SqlCommand sqlCommand = new SqlCommand();
			SqlHelper.PrepareCommand(sqlCommand, transaction.Connection, transaction, commandType, commandText, commandParameters);
			XmlReader retval = sqlCommand.ExecuteXmlReader();
			sqlCommand.Parameters.Clear();
			return retval;
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x0000B304 File Offset: 0x00009504
		public static XmlReader ExecuteXmlReader(SqlTransaction transaction, string spName, params object[] parameterValues)
		{
			XmlReader result;
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				result = SqlHelper.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				result = SqlHelper.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName);
			}
			return result;
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0000B347 File Offset: 0x00009547
		public static void BeginExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			SqlCommand sqlCommand = new SqlCommand();
			SqlHelper.PrepareCommand(sqlCommand, connection, null, commandType, commandText, commandParameters);
			sqlCommand.BeginExecuteNonQuery();
			sqlCommand.Parameters.Clear();
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x0000B36C File Offset: 0x0000956C
		public static void BeginExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
		{
			using (SqlConnection cn = new SqlConnection(connectionString))
			{
				cn.Open();
				SqlHelper.ExecuteNonQuery(cn, commandType, commandText, commandParameters);
			}
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0000B3AC File Offset: 0x000095AC
		public static void BeginExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
		{
			if (parameterValues != null && parameterValues.Length != 0)
			{
				SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				SqlHelper.AssignParameterValues(commandParameters, parameterValues);
				SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
				return;
			}
			SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
		}

		// Token: 0x02000071 RID: 113
		private enum SqlConnectionOwnership
		{
			// Token: 0x040005C9 RID: 1481
			Internal,
			// Token: 0x040005CA RID: 1482
			External
		}
	}
}
