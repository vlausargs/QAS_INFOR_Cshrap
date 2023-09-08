//PROJECT NAME: Finance
//CLASS NAME: GetJournalDefVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GetJournalDefVars : IGetJournalDefVars
	{
		readonly IApplicationDB appDB;
		
		
		public GetJournalDefVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string DefPrefix,
		string DefSite,
		int? DefFiscalYear,
		int? DefPeriod,
		decimal? DefNumber) GetJournalDefVarsSp(DateTime? PDate = null,
		string PId = null,
		string DefPrefix = null,
		string DefSite = null,
		int? DefFiscalYear = null,
		int? DefPeriod = null,
		decimal? DefNumber = null,
		int? GetNewNumber = 0)
		{
			DateType _PDate = PDate;
			JournalIdType _PId = PId;
			JourControlPrefixType _DefPrefix = DefPrefix;
			SiteType _DefSite = DefSite;
			FiscalYearType _DefFiscalYear = DefFiscalYear;
			DuePeriodType _DefPeriod = DefPeriod;
			LastTranType _DefNumber = DefNumber;
			ListYesNoType _GetNewNumber = GetNewNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetJournalDefVarsSp";
				
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PId", _PId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DefPrefix", _DefPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DefSite", _DefSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DefFiscalYear", _DefFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DefPeriod", _DefPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DefNumber", _DefNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GetNewNumber", _GetNewNumber, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DefPrefix = _DefPrefix;
				DefSite = _DefSite;
				DefFiscalYear = _DefFiscalYear;
				DefPeriod = _DefPeriod;
				DefNumber = _DefNumber;
				
				return (Severity, DefPrefix, DefSite, DefFiscalYear, DefPeriod, DefNumber);
			}
		}
	}
}
