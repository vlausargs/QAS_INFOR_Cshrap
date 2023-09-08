//PROJECT NAME: Data
//CLASS NAME: JobMach.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobMach : IJobMach
	{
		readonly IApplicationDB appDB;
		
		public JobMach(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			Guid? TMatltranRecid,
			string Infobar) JobMachSp(
			string TKeyValue1,
			Guid? SJobtranRowPointer,
			Guid? SJobRowPointer,
			Guid? SWcRowPointer,
			Guid? SJobrouteRowPointer,
			Guid? SJrtSchRowPointer,
			Guid? SProdvarRowPointer,
			Guid? SItemRowPointer,
			int? TCoby,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			Guid? TMatltranRecid,
			string Infobar,
			string JournalId = null)
		{
			LongListType _TKeyValue1 = TKeyValue1;
			RowPointerType _SJobtranRowPointer = SJobtranRowPointer;
			RowPointerType _SJobRowPointer = SJobRowPointer;
			RowPointerType _SWcRowPointer = SWcRowPointer;
			RowPointerType _SJobrouteRowPointer = SJobrouteRowPointer;
			RowPointerType _SJrtSchRowPointer = SJrtSchRowPointer;
			RowPointerType _SProdvarRowPointer = SProdvarRowPointer;
			RowPointerType _SItemRowPointer = SItemRowPointer;
			FlagNyType _TCoby = TCoby;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			RowPointerType _TMatltranRecid = TMatltranRecid;
			InfobarType _Infobar = Infobar;
			JournalIdType _JournalId = JournalId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobMachSp";
				
				appDB.AddCommandParameter(cmd, "TKeyValue1", _TKeyValue1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobtranRowPointer", _SJobtranRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobRowPointer", _SJobRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SWcRowPointer", _SWcRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobrouteRowPointer", _SJobrouteRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJrtSchRowPointer", _SJrtSchRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SProdvarRowPointer", _SProdvarRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SItemRowPointer", _SItemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCoby", _TCoby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TMatltranRecid", _TMatltranRecid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JournalId", _JournalId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ControlPrefix = _ControlPrefix;
				ControlSite = _ControlSite;
				ControlYear = _ControlYear;
				ControlPeriod = _ControlPeriod;
				ControlNumber = _ControlNumber;
				TMatltranRecid = _TMatltranRecid;
				Infobar = _Infobar;
				
				return (Severity, ControlPrefix, ControlSite, ControlYear, ControlPeriod, ControlNumber, TMatltranRecid, Infobar);
			}
		}
	}
}
