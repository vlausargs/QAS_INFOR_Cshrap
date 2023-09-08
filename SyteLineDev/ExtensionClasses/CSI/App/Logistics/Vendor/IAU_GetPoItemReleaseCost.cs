//PROJECT NAME: Logistics
//CLASS NAME: IAU_GetPoItemReleaseCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAU_GetPoItemReleaseCost
	{
		(int? ReturnCode,
			decimal? UnitMatCostConv,
			string Infobar) AU_GetPoItemReleaseCostSp(
			string PoNum,
			int? PoLine,
			int? PoRelease,
			decimal? UnitMatCostConv,
			string Infobar);
	}
}

