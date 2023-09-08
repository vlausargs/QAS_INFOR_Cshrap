//PROJECT NAME: Logistics
//CLASS NAME: IVoucherBuilderProcess.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVoucherBuilderProcess
	{
		(int? ReturnCode, int? PoVoucher,
		string PBuilderVoucherNum,
		string Infobar) VoucherBuilderProcessSp(Guid? PProcessID,
		string PVendNum,
		int? PAutoVoucher,
		string CalledFrom = "PurchaseOrderReceiving",
		int? PoVoucher = null,
		string PBuilderVoucherNum = null,
		string Infobar = null);
	}
}

