//PROJECT NAME: Data
//CLASS NAME: ActiveBGTasks_mstDelAppTrigger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ActiveBGTasks_mstDelAppTrigger : IActiveBGTasks_mstDelAppTrigger
	{
		readonly IApplicationDB appDB;
		
		public ActiveBGTasks_mstDelAppTrigger(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ActiveBGTasks_mstDelAppTriggerSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ActiveBGTasks_mstDelAppTriggerSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
