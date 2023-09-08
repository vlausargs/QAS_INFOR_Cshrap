//PROJECT NAME: Data
//CLASS NAME: IUseInventoryConsignedFromVendor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUseInventoryConsignedFromVendor
	{
		(int? ReturnCode,
			string Infobar) UseInventoryConsignedFromVendorSp(
			string CurrentWhse,
			string JobmatlItem = null,
			decimal? ConsignQtyRequired = null,
			string UM = null,
			string BackFlushLoc = null,
			string Infobar = null);
	}
}

