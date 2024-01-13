using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
	// Token: 0x0200006F RID: 111
	public sealed class SqlHelperParameterCache
	{
		// Token: 0x06000B3D RID: 2877 RVA: 0x0000B3E3 File Offset: 0x000095E3
		private SqlHelperParameterCache()
		{
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x0000B3EC File Offset: 0x000095EC
		private static SqlParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
		{
			SqlParameter[] result;
			using (SqlConnection cn = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(spName, cn))
				{
					cn.Open();
					cmd.CommandType = CommandType.StoredProcedure;
					SqlCommandBuilder.DeriveParameters(cmd);
					if (!includeReturnValueParameter)
					{
						cmd.Parameters.RemoveAt(0);
					}
					SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];
					cmd.Parameters.CopyTo(discoveredParameters, 0);
					result = discoveredParameters;
				}
			}
			return result;
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x0000B480 File Offset: 0x00009680
		private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
		{
			SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];
			int i = 0;
			int j = originalParameters.Length;
			while (i < j)
			{
				clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
				i++;
			}
			return clonedParameters;
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0000B4B8 File Offset: 0x000096B8
		public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
		{
			string hashKey = connectionString + ":" + commandText;
			SqlHelperParameterCache.paramCache[hashKey] = commandParameters;
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0000B4E0 File Offset: 0x000096E0
		public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
		{
			string hashKey = connectionString + ":" + commandText;
			SqlParameter[] cachedParameters = (SqlParameter[])SqlHelperParameterCache.paramCache[hashKey];
			SqlParameter[] result;
			if (cachedParameters == null)
			{
				result = null;
			}
			else
			{
				result = SqlHelperParameterCache.CloneParameters(cachedParameters);
			}
			return result;
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x0000B51A File Offset: 0x0000971A
		public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
		{
			return SqlHelperParameterCache.GetSpParameterSet(connectionString, spName, false);
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x0000B524 File Offset: 0x00009724
		public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
		{
			string hashKey = connectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
			SqlParameter[] cachedParameters = (SqlParameter[])SqlHelperParameterCache.paramCache[hashKey];
			if (cachedParameters == null)
			{
				cachedParameters = (SqlParameter[])(SqlHelperParameterCache.paramCache[hashKey] = SqlHelperParameterCache.DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter));
			}
			return SqlHelperParameterCache.CloneParameters(cachedParameters);
		}

		// Token: 0x040005C3 RID: 1475
		private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());
	}
}
