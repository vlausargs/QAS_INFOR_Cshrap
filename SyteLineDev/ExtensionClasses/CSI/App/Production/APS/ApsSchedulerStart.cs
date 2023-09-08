//PROJECT NAME: Production
//CLASS NAME: ApsSchedulerStart.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSchedulerStart : IApsSchedulerStart
	{
		readonly IApplicationDB appDB;
		
		public ApsSchedulerStart(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSchedulerStartSp(
			int? AltNo,
			int? ProcessID)
		{
			ShortType _AltNo = AltNo;
			GenericNoType _ProcessID = ProcessID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSchedulerStartSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
