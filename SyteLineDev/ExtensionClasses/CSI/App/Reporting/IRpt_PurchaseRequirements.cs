//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PurchaseRequirements.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PurchaseRequirements
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchaseRequirementsSp(string WhseStarting = null,
		string WhseEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string PlanCodeStarting = null,
		string PlanCodeEnding = null,
		string MatlType = null,
		string Source = null,
		string Stocked = null,
		string ABCCode = null,
		int? ShowDepl = null,
		int? ShowRepl = null,
		int? TimePhaseDetail = null,
		string COStatus = null,
		string POStatus = null,
		string PSStatus = null,
		string JobStatus = null,
		int? DisplayHeader = null,
		string SROStatus = null,
		int? IncOrderMinMult = null,
		string pSite = null);
	}
}

