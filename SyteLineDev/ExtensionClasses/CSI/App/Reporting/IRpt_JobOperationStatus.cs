//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobOperationStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobOperationStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobOperationStatusSp(string JobStarting = null,
		string JobEnding = null,
		int? SuffixStarting = null,
		int? SuffixEnding = null,
		string JobStatus = null,
		string LbrMatlBoth = null,
		string CustNum = null,
		string CustPo = null,
		string CustItem = null,
		int? ControlPoint = null,
		string ItemStarting = null,
		string ItemEnding = null,
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
		string BGSessionId = null,
		string pSite = null);
	}
}

