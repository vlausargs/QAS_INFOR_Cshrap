//PROJECT NAME: Finance
//CLASS NAME: FinRptLinRmtSiteTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptLinRmtSiteTrans : IFinRptLinRmtSiteTrans
	{
		readonly IApplicationDB appDB;
		
		public FinRptLinRmtSiteTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FinRptLinRmtSiteTransSp(
			string FullTextSql)
		{
			VeryLongListType _FullTextSql = FullTextSql;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinRptLinRmtSiteTransSp";
				
				appDB.AddCommandParameter(cmd, "FullTextSql", _FullTextSql, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
