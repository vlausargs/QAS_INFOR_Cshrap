//PROJECT NAME: Production
//CLASS NAME: ApsSetStopAfterPush.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSetStopAfterPush : IApsSetStopAfterPush
	{
		readonly IApplicationDB appDB;
		
		
		public ApsSetStopAfterPush(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSetStopAfterPushSp(string POrderID,
		int? PCheck)
		{
			ApsOrderType _POrderID = POrderID;
			ListYesNoType _PCheck = PCheck;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSetStopAfterPushSp";
				
				appDB.AddCommandParameter(cmd, "POrderID", _POrderID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheck", _PCheck, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
