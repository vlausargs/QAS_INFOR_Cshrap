//PROJECT NAME: Logistics
//CLASS NAME: IValidateVoucher.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidateVoucher
	{
		(int? ReturnCode, string Infobar) ValidateVoucherSp(string PVendNum,
		int? PVoucher,
		string SiteRef = null,
		string Infobar = null);
	}
}

