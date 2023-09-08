//PROJECT NAME: Logistics
//CLASS NAME: SSSFSResourceException.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSResourceException : ISSSFSResourceException
	{
		readonly IApplicationDB appDB;
		
		public SSSFSResourceException(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSResourceExceptionSp(
			string SroNum,
			string Action,
			string Infobar,
			int? SchedDownTime = 0,
			string ShiftID = null,
			DateTime? MaintDate = null,
			decimal? MaintDuration = 0,
			int? OldSchedDownTime = 0,
			string OldShiftID = null,
			DateTime? OldMaintDate = null,
			decimal? OldMaintDuration = 0,
			string RESID = null,
			int? SroLine = null)
		{
			FSSRONumType _SroNum = SroNum;
			StringType _Action = Action;
			Infobar _Infobar = Infobar;
			ListYesNoType _SchedDownTime = SchedDownTime;
			ApsShiftType _ShiftID = ShiftID;
			DateTimeType _MaintDate = MaintDate;
			FixedHoursType _MaintDuration = MaintDuration;
			ListYesNoType _OldSchedDownTime = OldSchedDownTime;
			ApsShiftType _OldShiftID = OldShiftID;
			DateTimeType _OldMaintDate = OldMaintDate;
			FixedHoursType _OldMaintDuration = OldMaintDuration;
			ApsResourceType _RESID = RESID;
			FSSROLineType _SroLine = SroLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSResourceExceptionSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SchedDownTime", _SchedDownTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShiftID", _ShiftID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaintDate", _MaintDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaintDuration", _MaintDuration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldSchedDownTime", _OldSchedDownTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldShiftID", _OldShiftID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldMaintDate", _OldMaintDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldMaintDuration", _OldMaintDuration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESID", _RESID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
