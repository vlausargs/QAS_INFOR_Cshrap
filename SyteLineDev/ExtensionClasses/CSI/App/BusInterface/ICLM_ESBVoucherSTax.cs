//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBVoucherSTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBVoucherSTax
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBVoucherSTaxSp(string VendNum,
		int? Voucher);
	}
}

