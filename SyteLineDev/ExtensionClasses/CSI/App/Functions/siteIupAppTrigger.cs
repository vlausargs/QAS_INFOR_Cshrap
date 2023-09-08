//PROJECT NAME: Data
//CLASS NAME: siteIupAppTrigger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class siteIupAppTrigger : IsiteIupAppTrigger
	{
		readonly IApplicationDB appDB;
		
		public siteIupAppTrigger(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? siteIupAppTriggerSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "siteIupAppTriggerSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
