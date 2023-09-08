//PROJECT NAME: Logistics
//CLASS NAME: ICLM_CreatePendingVoucher.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_CreatePendingVoucher
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_CreatePendingVoucherSp(Guid? PProcessID,
		string PVendNum,
		string PVoucherType,
		string PSite,
		int? PVoucher,
		string FilterString = null,
		string PoCurrCode = null);
	}
}

