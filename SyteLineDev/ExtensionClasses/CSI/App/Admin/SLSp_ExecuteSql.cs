//PROJECT NAME: Admin
//CLASS NAME: SLSp_ExecuteSql.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface ISLSp_ExecuteSql
	{
		(int? ReturnCode, string Result,
		string Infobar) SLSp_ExecuteSqlSp(string Result,
		string QueryStr,
		string Infobar = null);
	}
	
	public class SLSp_ExecuteSql : ISLSp_ExecuteSql
	{
		IApplicationDB appDB;
		
		public SLSp_ExecuteSql(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Result,
		string Infobar) SLSp_ExecuteSqlSp(string Result,
		string QueryStr,
		string Infobar = null)
		{
			StringType _Result = Result;
			InfobarType _QueryStr = QueryStr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SLSp_ExecuteSqlSp";
				
				appDB.AddCommandParameter(cmd, "Result", _Result, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QueryStr", _QueryStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Result = _Result;
				Infobar = _Infobar;
				
				return (Severity, Result, Infobar);
			}
		}
	}
}
