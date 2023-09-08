//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobCostbyItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobCostbyItem
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobCostbyItemSp(string ItemStarting = null,
		string ItemEnding = null,
		string JobStatus = null,
		int? SubTotal = null,
		string JobStarting = null,
		string JobEnding = null,
		int? SuffixStarting = null,
		int? SuffixEnding = null,
		string CustNumStarting = null,
		string CustNumEnding = null,
		string OrdType = null,
		string OrdNumStarting = null,
		string OrdNumEnding = null,
		DateTime? LastTrxDateStarting = null,
		DateTime? LastTrxDateEnding = null,
		int? LastTrxDateStartingOffset = null,
		int? LastTrxDateEndingOffset = null,
		DateTime? JobDateStarting = null,
		DateTime? JobDateEnding = null,
		int? JobDateStartingOffset = null,
		int? JobDateEndingOffset = null,
		int? DisplayHeader = 1,
		string pSite = null);
	}
}

