//PROJECT NAME: Logistics
//CLASS NAME: IAU_RecalculatePOBlanketReleaseCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAU_RecalculatePOBlanketReleaseCost
	{
		(int? ReturnCode,
			string Infobar) AU_RecalculatePOBlanketReleaseCostSp(
			string PoNum,
			int? PoLine,
			decimal? UnitCost,
			string Infobar,
			string Site = null);
	}
}

