//PROJECT NAME: Logistics
//CLASS NAME: IVoucherBuilderSaveDist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVoucherBuilderSaveDist
	{
		int? VoucherBuilderSaveDistSp(Guid? PRowPointer,
		int? PSelected,
		decimal? PQtyVoucher,
		decimal? PUnitMatCostConv,
		decimal? PFreight,
		decimal? PMiscCharges,
		string PTransNat,
		string PTransNat2,
		DateTime? GLDistDate,
		string PVendorInvoice,
		DateTime? PInvoiceDate,
		string PTerms,
		string PAuthorizer,
		Guid? PProcessID,
		string PVendNum,
		int? PVoucher,
		int? PClearSel,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		DateTime? TaxDate);
	}
}

