//PROJECT NAME: Reporting
//CLASS NAME: IRpt_VoucherRegister.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_VoucherRegister
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_VoucherRegisterSp(string Sortby = "P",
		int? PrintPoLineRel = null,
		int? PrintGRN = null,
		int? DisplayVoucherTotals = null,
		int? StartingVoucher = null,
		int? EndingVoucher = null,
		DateTime? StartingInvoiceDate = null,
		DateTime? EndingInvoiceDate = null,
		string StartingVendor = null,
		string EndingVendor = null,
		string StartingName = null,
		string EndingName = null,
		string StartingPO = null,
		string EndingPO = null,
		string StartingGrn = null,
		string EndingGrn = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		int? StartingInvDateOffSet = null,
		int? EndingInvDateOffSet = null,
		string pSite = null);
	}
}

