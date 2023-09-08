//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MassJournalPosting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MassJournalPosting
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_MassJournalPostingSp(
			string pSessionIDChar = null,
			int? pSingleDate = null,
			DateTime? pDateForTrans = null,
			DateTime? pTransDateStart = null,
			DateTime? pTransDateEnd = null,
			int? pPostInBackgroundQueue = null,
			int? pCompJour = null,
			string pCompressionLevel = null,
			int? pDeleteTransactionsAfterPost = null,
			DateTime? pReversingTransactionDate = null,
			string pSite = null);
	}
}