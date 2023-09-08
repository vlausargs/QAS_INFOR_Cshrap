//PROJECT NAME: Data
//CLASS NAME: Parms_mstIupAppTrigger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Parms_mstIupAppTrigger : IParms_mstIupAppTrigger
	{
		readonly IApplicationDB appDB;
		
		public Parms_mstIupAppTrigger(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Parms_mstIupAppTriggerSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Parms_mstIupAppTriggerSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
