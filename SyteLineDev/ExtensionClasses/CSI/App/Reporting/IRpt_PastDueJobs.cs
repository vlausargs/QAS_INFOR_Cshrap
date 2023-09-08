//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PastDueJobs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PastDueJobs
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PastDueJobsSp(DateTime? ExOptprPastDueDate = null,
		string JobStarting = null,
		int? JobStartSuffix = null,
		string JobEnding = null,
		int? JobEndSuffix = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string CustStarting = null,
		string CustEnding = null,
		string ExOptgoOrdType = null,
		string OrdNumStarting = null,
		string OrdNumEnding = null,
		DateTime? LstTrxDateStarting = null,
		DateTime? LstTrxDateEnding = null,
		DateTime? JobDateStarting = null,
		DateTime? JobDateEnding = null,
		int? LstTrxDateStartingOffset = null,
		int? LstTrxDateEndingOffset = null,
		int? JobDateStartingOffset = null,
		int? JobDateEndingOffset = null,
		int? ExOptprPastDueDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

