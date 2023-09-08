//PROJECT NAME: Finance
//CLASS NAME: IImportJournalEntries.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IImportJournalEntries
	{
		int? ImportJournalEntriesSp(DateTime? PTransactionDate,
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
		string AnalysisAttributeValue15);
	}
}

