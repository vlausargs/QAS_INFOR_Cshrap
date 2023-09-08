//PROJECT NAME: Data
//CLASS NAME: Site_groupDelAppTrigger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Site_groupDelAppTrigger : ISite_groupDelAppTrigger
	{
		readonly IApplicationDB appDB;
		
		public Site_groupDelAppTrigger(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Site_groupDelAppTriggerSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Site_groupDelAppTriggerSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
