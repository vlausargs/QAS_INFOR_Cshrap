//PROJECT NAME: Production
//CLASS NAME: JobP4.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobP4 : IJobP4
	{
		readonly IApplicationDB appDB;
		
		public JobP4(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string Infobar) JobP4Sp(
			Guid? JobtranRP,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string Infobar,
			string DocumentNum = null,
			string JournalId = null)
		{
			RowPointerType _JobtranRP = JobtranRP;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			InfobarType _Infobar = Infobar;
			DocumentNumType _DocumentNum = DocumentNum;
			JournalIdType _JournalId = JournalId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobP4Sp";
				
				appDB.AddCommandParameter(cmd, "JobtranRP", _JobtranRP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalId", _JournalId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ControlPrefix = _ControlPrefix;
				ControlSite = _ControlSite;
				ControlYear = _ControlYear;
				ControlPeriod = _ControlPeriod;
				ControlNumber = _ControlNumber;
				Infobar = _Infobar;
				
				return (Severity, ControlPrefix, ControlSite, ControlYear, ControlPeriod, ControlNumber, Infobar);
			}
		}
	}
}
