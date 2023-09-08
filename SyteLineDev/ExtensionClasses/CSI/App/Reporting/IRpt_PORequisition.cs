//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PORequisition.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PORequisition
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PORequisitionSp(string ReqStat = null,
		string ReqitemStat = null,
		string QuotedTp = null,
		string SortBy = null,
		string StartReqNum = null,
		string EndReqNum = null,
		int? StartReqLine = null,
		int? EndReqLine = null,
		string StartVendor = null,
		string EndVendor = null,
		string StartBuyer = null,
		string EndBuyer = null,
		string StartApprover = null,
		string EndApprover = null,
		string StartRequester = null,
		string EndRequester = null,
		string StartReqCode = null,
		string EndReqCode = null,
		DateTime? StartDueDate = null,
		DateTime? EndDueDate = null,
		DateTime? StartRelDate = null,
		DateTime? EndRelDate = null,
		int? StartDueDateOffset = null,
		int? EndDueDateOffset = null,
		int? StartRelDateOffset = null,
		int? EndRelDateOffset = null,
		int? PrintCost = 0,
		int? DisplayHeader = null,
		string PMessageLanguage = null,
		int? TransDomCurr = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null);
	}
}

