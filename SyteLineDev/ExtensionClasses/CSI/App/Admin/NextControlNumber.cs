//PROJECT NAME: Admin
//CLASS NAME: NextControlNumber.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class NextControlNumber : INextControlNumber
	{
		IApplicationDB appDB;
		
		
		public NextControlNumber(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ControlPrefix,
		string ControlSite,
		int? ControlYear,
		int? ControlPeriod,
		decimal? ControlNumber,
		string Infobar,
		decimal? OldControlNumber) NextControlNumberSp(string SubKey = null,
		string JournalId = null,
		int? UpdatePeriodsSeqOnly = 0,
		string ControlPrefix = null,
		string ControlSite = null,
		DateTime? TransDate = null,
		int? ControlYear = null,
		int? ControlPeriod = null,
		string SequenceBy = null,
		decimal? ControlNumber = null,
		string Infobar = null,
		decimal? OldControlNumber = null)
		{
			GenericKeyType _SubKey = SubKey;
			JournalIdType _JournalId = JournalId;
			ListYesNoType _UpdatePeriodsSeqOnly = UpdatePeriodsSeqOnly;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			DateType _TransDate = TransDate;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			ListYearPeriodType _SequenceBy = SequenceBy;
			LastTranType _ControlNumber = ControlNumber;
			InfobarType _Infobar = Infobar;
			LastTranType _OldControlNumber = OldControlNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextControlNumberSp";
				
				appDB.AddCommandParameter(cmd, "SubKey", _SubKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalId", _JournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdatePeriodsSeqOnly", _UpdatePeriodsSeqOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SequenceBy", _SequenceBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OldControlNumber", _OldControlNumber, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ControlPrefix = _ControlPrefix;
				ControlSite = _ControlSite;
				ControlYear = _ControlYear;
				ControlPeriod = _ControlPeriod;
				ControlNumber = _ControlNumber;
				Infobar = _Infobar;
				OldControlNumber = _OldControlNumber;
				
				return (Severity, ControlPrefix, ControlSite, ControlYear, ControlPeriod, ControlNumber, Infobar, OldControlNumber);
			}
		}
	}
}
