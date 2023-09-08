//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedHasConflicts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedHasConflicts
	{
		(int? ReturnCode, byte? Conflict) SSSFSSchedHasConflictsSp(string PartnerID,
		DateTime? SchedDate,
		decimal? Hrs,
		byte? Conflict);
	}
	
	public class SSSFSSchedHasConflicts : ISSSFSSchedHasConflicts
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSchedHasConflicts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? Conflict) SSSFSSchedHasConflictsSp(string PartnerID,
		DateTime? SchedDate,
		decimal? Hrs,
		byte? Conflict)
		{
			FSPartnerType _PartnerID = PartnerID;
			DateTimeType _SchedDate = SchedDate;
			HoursOffType _Hrs = Hrs;
			ListYesNoType _Conflict = Conflict;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSchedHasConflictsSp";
				
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchedDate", _SchedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Hrs", _Hrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Conflict", _Conflict, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Conflict = _Conflict;
				
				return (Severity, Conflict);
			}
		}
	}
}
