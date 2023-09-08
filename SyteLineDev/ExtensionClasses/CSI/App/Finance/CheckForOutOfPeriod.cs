//PROJECT NAME: Finance
//CLASS NAME: CheckForOutOfPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class CheckForOutOfPeriod : ICheckForOutOfPeriod
	{
		readonly IApplicationDB appDB;
		
		
		public CheckForOutOfPeriod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? OutOfPeriod,
		int? Closed,
		int? FiscalYear,
		string Infobar,
		int? TransPeriod) CheckForOutOfPeriodSp(string PJournalId,
		Guid? PSessionID,
		int? OutOfPeriod,
		int? Closed,
		int? FiscalYear,
		string Infobar,
		int? PSingleDateForTnx = 0,
		DateTime? PSingleDateToUse = null,
		int? TransPeriod = null)
		{
			JournalIdType _PJournalId = PJournalId;
			RowPointerType _PSessionID = PSessionID;
			ListYesNoType _OutOfPeriod = OutOfPeriod;
			ListYesNoType _Closed = Closed;
			FiscalYearType _FiscalYear = FiscalYear;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PSingleDateForTnx = PSingleDateForTnx;
			DateType _PSingleDateToUse = PSingleDateToUse;
			FinPeriodType _TransPeriod = TransPeriod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckForOutOfPeriodSp";
				
				appDB.AddCommandParameter(cmd, "PJournalId", _PJournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutOfPeriod", _OutOfPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Closed", _Closed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSingleDateForTnx", _PSingleDateForTnx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSingleDateToUse", _PSingleDateToUse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransPeriod", _TransPeriod, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutOfPeriod = _OutOfPeriod;
				Closed = _Closed;
				FiscalYear = _FiscalYear;
				Infobar = _Infobar;
				TransPeriod = _TransPeriod;
				
				return (Severity, OutOfPeriod, Closed, FiscalYear, Infobar, TransPeriod);
			}
		}
	}
}
