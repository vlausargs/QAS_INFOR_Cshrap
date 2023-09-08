//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TransactionSummary.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_TransactionSummary
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TransactionSummarySp(string TransactionCodeStarting = null,
		string TransactionCodeEnding = null,
		DateTime? DateStarting = null,
		DateTime? DateEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? DateStartingOffset = null,
		int? DateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

