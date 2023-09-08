//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjectPurchaseOrderCommitments2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjectPurchaseOrderCommitments2
	{
		int? Rpt_ProjectPurchaseOrderCommitments2Sp(
			string Job,
			int? Suffix,
			decimal? Qty,
			string ProjNum,
			int? TaskNum,
			string TPoitemStat,
			int? PrintCost);
	}
}

