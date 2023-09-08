//PROJECT NAME: Finance
//CLASS NAME: ImportJournalEntries.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class ImportJournalEntries : IImportJournalEntries
	{
		readonly IApplicationDB appDB;
		
		
		public ImportJournalEntries(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ImportJournalEntriesSp(DateTime? PTransactionDate,
		string PAcct,
		decimal? PDomAmount,
		string PRef,
		string JournalID,
		string PControlSite,
		int? PControlYear,
		int? PControlPeriod,
		decimal? PControlNumber,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		string AnalysisAttributeValue01,
		string AnalysisAttributeValue02,
		string AnalysisAttributeValue03,
		string AnalysisAttributeValue04,
		string AnalysisAttributeValue05,
		string AnalysisAttributeValue06,
		string AnalysisAttributeValue07,
		string AnalysisAttributeValue08,
		string AnalysisAttributeValue09,
		string AnalysisAttributeValue10,
		string AnalysisAttributeValue11,
		string AnalysisAttributeValue12,
		string AnalysisAttributeValue13,
		string AnalysisAttributeValue14,
		string AnalysisAttributeValue15)
		{
			DateType _PTransactionDate = PTransactionDate;
			AcctType _PAcct = PAcct;
			AmountType _PDomAmount = PDomAmount;
			ReferenceType _PRef = PRef;
			JournalIdType _JournalID = JournalID;
			SiteType _PControlSite = PControlSite;
			FiscalYearType _PControlYear = PControlYear;
			FinPeriodType _PControlPeriod = PControlPeriod;
			LastTranType _PControlNumber = PControlNumber;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			DimensionValueType _AnalysisAttributeValue01 = AnalysisAttributeValue01;
			DimensionValueType _AnalysisAttributeValue02 = AnalysisAttributeValue02;
			DimensionValueType _AnalysisAttributeValue03 = AnalysisAttributeValue03;
			DimensionValueType _AnalysisAttributeValue04 = AnalysisAttributeValue04;
			DimensionValueType _AnalysisAttributeValue05 = AnalysisAttributeValue05;
			DimensionValueType _AnalysisAttributeValue06 = AnalysisAttributeValue06;
			DimensionValueType _AnalysisAttributeValue07 = AnalysisAttributeValue07;
			DimensionValueType _AnalysisAttributeValue08 = AnalysisAttributeValue08;
			DimensionValueType _AnalysisAttributeValue09 = AnalysisAttributeValue09;
			DimensionValueType _AnalysisAttributeValue10 = AnalysisAttributeValue10;
			DimensionValueType _AnalysisAttributeValue11 = AnalysisAttributeValue11;
			DimensionValueType _AnalysisAttributeValue12 = AnalysisAttributeValue12;
			DimensionValueType _AnalysisAttributeValue13 = AnalysisAttributeValue13;
			DimensionValueType _AnalysisAttributeValue14 = AnalysisAttributeValue14;
			DimensionValueType _AnalysisAttributeValue15 = AnalysisAttributeValue15;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ImportJournalEntriesSp";
				
				appDB.AddCommandParameter(cmd, "PTransactionDate", _PTransactionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomAmount", _PDomAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRef", _PRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalID", _JournalID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PControlSite", _PControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PControlYear", _PControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PControlPeriod", _PControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PControlNumber", _PControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue01", _AnalysisAttributeValue01, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue02", _AnalysisAttributeValue02, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue03", _AnalysisAttributeValue03, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue04", _AnalysisAttributeValue04, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue05", _AnalysisAttributeValue05, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue06", _AnalysisAttributeValue06, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue07", _AnalysisAttributeValue07, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue08", _AnalysisAttributeValue08, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue09", _AnalysisAttributeValue09, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue10", _AnalysisAttributeValue10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue11", _AnalysisAttributeValue11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue12", _AnalysisAttributeValue12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue13", _AnalysisAttributeValue13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue14", _AnalysisAttributeValue14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalysisAttributeValue15", _AnalysisAttributeValue15, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
