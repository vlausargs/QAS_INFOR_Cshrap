//PROJECT NAME: Logistics
//CLASS NAME: IVendorGetRecurVoucherInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVendorGetRecurVoucherInfo
	{
		(int? ReturnCode, string RTaxCode1,
		string RTaxCode1Desc,
		string RTaxCode2,
		string RTaxCode2Desc,
		string RCurrCode,
		decimal? RExchRate,
		int? RProxCode,
		int? RProxDay,
		decimal? RDiscPct,
		int? RDiscDays,
		DateTime? RDiscDate,
		int? RDueDays,
		DateTime? RDueDate,
		string RApAcct,
		string RApAcctUnit1,
		string RApAcctUnit2,
		string RApAcctUnit3,
		string RApAcctUnit4,
		string RApAcctDesc,
		string RTermsCode,
		string Infobar,
		int? RApAcctIsControl) VendorGetRecurVoucherInfoSp(string PVendNum,
		DateTime? PInvoiceDate,
		string RTaxCode1,
		string RTaxCode1Desc,
		string RTaxCode2,
		string RTaxCode2Desc,
		string RCurrCode,
		decimal? RExchRate,
		int? RProxCode,
		int? RProxDay,
		decimal? RDiscPct,
		int? RDiscDays,
		DateTime? RDiscDate,
		int? RDueDays,
		DateTime? RDueDate,
		string RApAcct,
		string RApAcctUnit1,
		string RApAcctUnit2,
		string RApAcctUnit3,
		string RApAcctUnit4,
		string RApAcctDesc,
		string RTermsCode,
		string Infobar,
		int? RApAcctIsControl);
	}
}

