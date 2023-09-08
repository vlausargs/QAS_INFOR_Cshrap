//PROJECT NAME: Data
//CLASS NAME: TH_SaveForReprintTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TH_SaveForReprintTables : ITH_SaveForReprintTables
	{
		readonly IApplicationDB appDB;
		
		public TH_SaveForReprintTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TH_SaveForReprintTablesSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TH_SaveForReprintTables";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
