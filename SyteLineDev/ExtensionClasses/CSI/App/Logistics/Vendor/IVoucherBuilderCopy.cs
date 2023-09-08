//PROJECT NAME: Logistics
//CLASS NAME: IVoucherBuilderCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVoucherBuilderCopy
	{
		(int? ReturnCode,
			string Infobar) VoucherBuilderCopySp(
			Guid? PProcessId,
			string PToSite,
			string PVBOrigSite = null,
			string PBuilderVoucher = null,
			int? PSelected = null,
			string PVendNum = null,
			string PCurrCode = null,
			string PType = null,
			string PSite = null,
			int? PVoucher = null,
			DateTime? PDistDate = null,
			string PInvNum = null,
			DateTime? PInvDate = null,
			string PTermsCode = null,
			string PAuthorizer = null,
			int? PFixedRate = null,
			decimal? PExchRate = null,
			int? PITaxInCost = null,
			string PBPoOrigSite = null,
			string PBPoNum = null,
			string PPoNum = null,
			int? PPoLine = null,
			int? PPoRelease = null,
			string PItem = null,
			string PItemDesc = null,
			string PVendItem = null,
			decimal? PQtyRcvd = null,
			decimal? PQtyVoucher = null,
			decimal? POrigQtyVoucher = null,
			string PUm = null,
			decimal? PUnitMatCostConv = null,
			decimal? PPlanCostConv = null,
			decimal? PFreight = null,
			decimal? PMiscCharges = null,
			string PTransNat = null,
			string PTransNat2 = null,
			string PPoTaxCode1 = null,
			string PPoTaxCode2 = null,
			string PPoITaxCode1 = null,
			string PPoITaxCode2 = null,
			string PFrtTaxCode1 = null,
			string PFrtTaxCode2 = null,
			string PMscTaxCode1 = null,
			string PMscTaxCode2 = null,
			DateTime? PPoRecDate = null,
			int? PReadOnly = null,
			decimal? PSalesTax = null,
			decimal? PSalesTax2 = null,
			int? TaxSystem1Enabled = null,
			int? TaxSystem2Enabled = null,
			int? ActiveForPurch1 = null,
			int? ActiveForPurch2 = null,
			string Infobar = null);
	}
}

