//PROJECT NAME: Reporting
//CLASS NAME: IGLBudgetConsbp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IGLBudgetConsbp
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GLBudgetConsbpSp(DateTime? pCutoffDate,
		int? pPostTrx,
		int? pSummaryOrDetail,
		string pSite = null);
	}
}

