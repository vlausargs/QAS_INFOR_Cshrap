//PROJECT NAME: Logistics
//CLASS NAME: IValidateVendSiteCurrCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidateVendSiteCurrCode
	{
		(int? ReturnCode, string ToSite,
		string Infobar) ValidateVendSiteCurrCodeSp(string CurrSite,
		string ToSite,
		string VendNum,
		string Infobar);
	}
}

