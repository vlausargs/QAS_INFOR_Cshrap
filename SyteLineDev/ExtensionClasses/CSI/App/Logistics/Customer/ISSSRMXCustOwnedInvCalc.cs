//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXCustOwnedInvCalc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXCustOwnedInvCalc
	{
		(int? ReturnCode,
			decimal? oCOIMatlCost,
			decimal? oCOILbrCost,
			decimal? oCOIFovCost,
			decimal? oCOIVovCost,
			decimal? oCOIOutCost,
			string Infobar) SSSRMXCustOwnedInvCalcSp(
			string RmaNum,
			int? RmaLine,
			decimal? QtyToPost,
			decimal? oCOIMatlCost,
			decimal? oCOILbrCost,
			decimal? oCOIFovCost,
			decimal? oCOIVovCost,
			decimal? oCOIOutCost,
			string Infobar);
	}
}

