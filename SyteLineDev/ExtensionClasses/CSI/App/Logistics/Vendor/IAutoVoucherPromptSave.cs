//PROJECT NAME: Logistics
//CLASS NAME: IAutoVoucherPromptSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAutoVoucherPromptSave
	{
		int? AutoVoucherPromptSaveSp(Guid? PProcessID,
		decimal? PFreight,
		decimal? PMiscCharges,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		DateTime? GLDistDate,
		string PVendorInvoice,
		DateTime? PInvoiceDate,
		string PTerms,
		DateTime? PTaxDate);
	}
}

