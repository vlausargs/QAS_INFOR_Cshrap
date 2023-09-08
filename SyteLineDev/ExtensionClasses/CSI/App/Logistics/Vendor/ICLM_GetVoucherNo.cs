//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetVoucherNo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_GetVoucherNo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetVoucherNoSp(string PVendNum,
		int? Cancellation = 0);
	}
}

