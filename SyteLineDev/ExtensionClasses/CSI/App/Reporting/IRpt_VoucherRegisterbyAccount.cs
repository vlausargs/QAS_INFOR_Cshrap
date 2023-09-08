//PROJECT NAME: Reporting
//CLASS NAME: IRpt_VoucherRegisterbyAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_VoucherRegisterbyAccount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_VoucherRegisterbyAccountSp(string StartingAccount = null,
		string EndingAccount = null,
		int? StartingVoucher = null,
		int? EndingVoucher = null,
		DateTime? StartingInvoiceDate = null,
		DateTime? EndingInvoiceDate = null,
		string StartingVendor = null,
		string EndingVendor = null,
		string StartingPO = null,
		string EndingPO = null,
		string StartingGrn = null,
		string EndingGrn = null,
		int? TransToDomCurr = null,
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		string pSite = null);
	}
}

