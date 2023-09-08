//PROJECT NAME: Finance
//CLASS NAME: JournalBuilderProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class JournalBuilderProcess : IJournalBuilderProcess
	{
		readonly IApplicationDB appDB;
		
		
		public JournalBuilderProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? JournalBuilderProcessSp(DateTime? PTransactionDate,
		string PToSite,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		decimal? PDomAmount,
		string PRef,
		string PControlPrefix,
		string PControlSite,
		int? PControlYear,
		int? PControlPeriod,
		decimal? PControlNumber)
		{
			DateType _PTransactionDate = PTransactionDate;
			SiteType _PToSite = PToSite;
			AcctType _PAcct = PAcct;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			AmountType _PDomAmount = PDomAmount;
			ReferenceType _PRef = PRef;
			JourControlPrefixType _PControlPrefix = PControlPrefix;
			SiteType _PControlSite = PControlSite;
			FiscalYearType _PControlYear = PControlYear;
			FinPeriodType _PControlPeriod = PControlPeriod;
			LastTranType _PControlNumber = PControlNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JournalBuilderProcessSp";
				
				appDB.AddCommandParameter(cmd, "PTransactionDate", _PTransactionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToSite", _PToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomAmount", _PDomAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRef", _PRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PControlPrefix", _PControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PControlSite", _PControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PControlYear", _PControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PControlPeriod", _PControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PControlNumber", _PControlNumber, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
