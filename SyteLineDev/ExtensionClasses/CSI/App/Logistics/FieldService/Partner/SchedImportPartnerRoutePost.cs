//PROJECT NAME: Logistics
//CLASS NAME: SchedImportPartnerRoutePost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SchedImportPartnerRoutePost : ISchedImportPartnerRoutePost
	{
		readonly IApplicationDB appDB;
		
		
		public SchedImportPartnerRoutePost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SchedImportPartnerRoutePostSp(Guid? SessionID,
		string ProfileUsername,
		string ScheduleID,
		string PartnerID,
		DateTime? NextApptDate,
		string Durations,
		string Infobar)
		{
			RowPointerType _SessionID = SessionID;
			StringType _ProfileUsername = ProfileUsername;
			StringType _ScheduleID = ScheduleID;
			FSPartnerType _PartnerID = PartnerID;
			DateType _NextApptDate = NextApptDate;
			LongListType _Durations = Durations;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SchedImportPartnerRoutePostSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProfileUsername", _ProfileUsername, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleID", _ScheduleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextApptDate", _NextApptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Durations", _Durations, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
