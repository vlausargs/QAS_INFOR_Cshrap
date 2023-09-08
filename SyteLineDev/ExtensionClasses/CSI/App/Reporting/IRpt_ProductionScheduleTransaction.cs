//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProductionScheduleTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProductionScheduleTransaction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductionScheduleTransactionSp(string PSNumStarting = null,
		string PSNumEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string WcStarting = null,
		string WcEnding = null,
		string ShiftStarting = null,
		string ShiftEnding = null,
		DateTime? TransDateStarting = null,
		DateTime? TransDateEnding = null,
		int? TransDateStartingOffset = null,
		int? TransDateEndingOffset = null,
		string BackFlushTrans = null,
		int? CompleteStatusReport = null,
		int? DisplayHeader = null,
		string pSite = null,
		string DocumentNumStarting = null,
		string DocumentNumEnding = null);
	}
}

