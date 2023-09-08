//PROJECT NAME: Production
//CLASS NAME: ApsGetStringsByListID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetStringsByListID : IApsGetStringsByListID
	{
		readonly IApplicationDB appDB;
		
		public ApsGetStringsByListID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGetStringsByListIDSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsGetStringsByListIDSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
