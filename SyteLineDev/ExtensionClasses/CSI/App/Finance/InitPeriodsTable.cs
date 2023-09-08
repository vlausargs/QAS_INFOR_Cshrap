//PROJECT NAME: Finance
//CLASS NAME: InitPeriodsTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class InitPeriodsTable : IInitPeriodsTable
	{
		readonly IApplicationDB appDB;
		
		
		public InitPeriodsTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? pAllowInsertForSite) InitPeriodsTableSp(int? pAllowInsertForSite)
		{
			IntType _pAllowInsertForSite = pAllowInsertForSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitPeriodsTableSp";
				
				appDB.AddCommandParameter(cmd, "pAllowInsertForSite", _pAllowInsertForSite, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pAllowInsertForSite = _pAllowInsertForSite;
				
				return (Severity, pAllowInsertForSite);
			}
		}
	}
}
