//PROJECT NAME: Logistics
//CLASS NAME: ICheckOPMVendortoShipQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICheckOPMVendortoShipQty
	{
		(int? ReturnCode,
		string Infobar) CheckOPMVendortoShipQtySp(
			string PoNum,
			int? PoLine,
			int? PoRelease = 0,
			decimal? PoOrderedQtyConv = 0,
			string Infobar = null);
	}
}

