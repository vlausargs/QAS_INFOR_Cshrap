//PROJECT NAME: Data
//CLASS NAME: PRtrxp1fpPostChecks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PRtrxp1fpPostChecks : IPRtrxp1fpPostChecks
	{
		readonly IApplicationDB appDB;
		
		public PRtrxp1fpPostChecks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PRtrxp1fpPostChecksSp(
			Guid? pPrtrxRowPointer,
			string pTId,
			string pTRef,
			string pCurrparmsCurrCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string Infobar)
		{
			RowPointerType _pPrtrxRowPointer = pPrtrxRowPointer;
			JournalIdType _pTId = pTId;
			LongListType _pTRef = pTRef;
			CurrCodeType _pCurrparmsCurrCode = pCurrparmsCurrCode;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PRtrxp1fpPostChecksSp";
				
				appDB.AddCommandParameter(cmd, "pPrtrxRowPointer", _pPrtrxRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTId", _pTId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTRef", _pTRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrparmsCurrCode", _pCurrparmsCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
