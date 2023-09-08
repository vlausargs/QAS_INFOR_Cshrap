//PROJECT NAME: Production
//CLASS NAME: IRpt_NominatedInvoiceMilestones.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRpt_NominatedInvoiceMilestones
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_NominatedInvoiceMilestonesSp(string PProjectStarting,
		string PProjectEnding,
		string PInvoiceMilestoneStarting,
		string PInvoiceMilestoneEnding,
		int? PPeriod,
		int? PNonPostedMSOnly,
		int? PYear,
		int? PPrintCost,
		string PSite = null);
	}
}

