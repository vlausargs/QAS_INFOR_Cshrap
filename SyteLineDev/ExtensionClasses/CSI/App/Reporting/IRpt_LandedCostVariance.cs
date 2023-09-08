//PROJECT NAME: Reporting
//CLASS NAME: IRpt_LandedCostVariance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_LandedCostVariance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_LandedCostVarianceSp(string StartingPoNum = null,
		string EndingPoNum = null,
		string PoType = null,
		string PoStat = null,
		string PoitemStat = null,
		int? TransDomCurr = null,
		string StartingVendor = null,
		string EndingVendor = null,
		DateTime? StartingOrderDate = null,
		DateTime? EndingOrderDate = null,
		int? StartingOrderDateOffset = null,
		int? EndingOrderDateOffset = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
}

