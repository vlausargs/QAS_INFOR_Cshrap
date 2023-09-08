//PROJECT NAME: Logistics
//CLASS NAME: ICLM_ToSiteForManualVoucherBuilder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_ToSiteForManualVoucherBuilder
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ToSiteForManualVoucherBuilderSp(
			string PVendNum);
	}
}

