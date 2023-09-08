//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JournalTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JournalTransaction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JournalTransactionSp(string CurId = null,
		string SiteGroup = null,
		int? StartingSeq = null,
		int? EndingSeq = null,
		DateTime? StartingTransDate = null,
		DateTime? EndingTransDate = null,
		int? StartingTransDateOffset = null,
		int? EndingTransDateOffset = null,
		DateTime? StartingPeriod = null,
		DateTime? EndingPeriod = null,
		int? StartingPeriodOffset = null,
		int? EndingPeriodOffset = null,
		string StartingAcct = null,
		string EndingAcct = null,
		string StartingAcctUnit1 = null,
		string EndingAcctUnit1 = null,
		string StartingAcctUnit2 = null,
		string EndingAcctUnit2 = null,
		string StartingAcctUnit3 = null,
		string EndingAcctUnit3 = null,
		string StartingAcctUnit4 = null,
		string EndingAcctUnit4 = null,
		string StartingRef = null,
		string EndingRef = null,
		string SortBy = null,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? ShowDetail = null,
		int? GroupBy = 0,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

