//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PurchaseRequirementsTimePhaseDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PurchaseRequirementsTimePhaseDetail
	{
		int? Rpt_PurchaseRequirementsTimePhaseDetailSp(
			string Item,
			decimal? QtyOnHand,
			string WhseStarting,
			string WhseEnding,
			int? ShowDepl,
			int? ShowRepl,
			string COStatus,
			string POStatus,
			string PSStatus,
			string JobStatus,
			int? UseJob);
	}
}

