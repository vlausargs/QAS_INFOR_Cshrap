//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RequisitionPOComparison.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RequisitionPOComparison
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RequisitionPOComparisonSP(string ReqNumStarting,
		string ReqNumEnding,
		int? ReqLineStarting,
		int? ReqLineEnding,
		int? ShowCost,
		int? DisplayHeader,
		string BGSessionId = null,
		string pSite = null);
	}
}

