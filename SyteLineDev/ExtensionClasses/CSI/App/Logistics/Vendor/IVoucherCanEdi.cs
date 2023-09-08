//PROJECT NAME: Logistics
//CLASS NAME: IVoucherCanEdi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVoucherCanEdi
	{
		int? VoucherCanEdiFn(
			string VendNum);
	}
}

