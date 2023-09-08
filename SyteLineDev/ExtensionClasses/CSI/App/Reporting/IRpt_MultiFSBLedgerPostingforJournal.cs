//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MultiFSBLedgerPostingforJournal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MultiFSBLedgerPostingforJournal
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MultiFSBLedgerPostingforJournalSp(string pSessionIDChar = null,
		string pCurId = null,
		int? pSingleDate = null,
		DateTime? pDateForTrans = null,
		DateTime? pPostThroughDate = null,
		string FSBName = null,
		string pSite = null);
	}
}

