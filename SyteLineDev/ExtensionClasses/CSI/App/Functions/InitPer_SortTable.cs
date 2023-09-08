//PROJECT NAME: Data
//CLASS NAME: InitPer_SortTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitPer_SortTable : IInitPer_SortTable
	{
		readonly IApplicationDB appDB;
		
		public InitPer_SortTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitPer_SortTableSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitPer_SortTableSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
