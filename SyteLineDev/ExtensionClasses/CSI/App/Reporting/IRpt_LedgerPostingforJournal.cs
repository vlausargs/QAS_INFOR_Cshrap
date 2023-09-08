//PROJECT NAME: Reporting
//CLASS NAME: IRpt_LedgerPostingforJournal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_LedgerPostingforJournal
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_LedgerPostingforJournalSp(string pSessionIDChar = null,
		string pCurId = null,
		int? pSingleDate = null,
		DateTime? pDateForTrans = null,
		DateTime? pPostThroughDate = null,
		string StartingGLVoucher = null,
		string EndingGLVoucher = null,
		string pSite = null);
	}
}

