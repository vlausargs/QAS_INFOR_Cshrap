//PROJECT NAME: Production
//CLASS NAME: MO_SHIFTEXDIMaintIDQuery.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class MO_SHIFTEXDIMaintIDQuery : IMO_SHIFTEXDIMaintIDQuery
	{
		readonly IApplicationDB appDB;
		
		
		public MO_SHIFTEXDIMaintIDQuery(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string MaintenanceID,
		DateTime? StartDate,
		DateTime? EndDate,
		string SHIFTID) MO_SHIFTEXDIMaintIDQuerySp(string SHIFTEXID,
		string MaintenanceID,
		DateTime? StartDate,
		DateTime? EndDate,
		string SHIFTID)
		{
			ApsShiftexType _SHIFTEXID = SHIFTEXID;
			MO_MaintenanceIDType _MaintenanceID = MaintenanceID;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			ApsShiftType _SHIFTID = SHIFTID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_SHIFTEXDIMaintIDQuerySp";
				
				appDB.AddCommandParameter(cmd, "SHIFTEXID", _SHIFTEXID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaintenanceID", _MaintenanceID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SHIFTID", _SHIFTID, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MaintenanceID = _MaintenanceID;
				StartDate = _StartDate;
				EndDate = _EndDate;
				SHIFTID = _SHIFTID;
				
				return (Severity, MaintenanceID, StartDate, EndDate, SHIFTID);
			}
		}
	}
}
