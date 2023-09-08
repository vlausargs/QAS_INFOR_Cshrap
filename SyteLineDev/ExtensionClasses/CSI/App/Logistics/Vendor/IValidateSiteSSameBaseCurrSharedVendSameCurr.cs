//PROJECT NAME: Logistics
//CLASS NAME: IValidateSiteSSameBaseCurrSharedVendSameCurr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidateSiteSSameBaseCurrSharedVendSameCurr
	{
		(int? ReturnCode, string PSite,
		int? PEnableSalesTax,
		int? PEnableSalesTax2,
		string Infobar) ValidateSiteSSameBaseCurrSharedVendSameCurrSp(string PSite,
		string PVendNum,
		int? PEnableSalesTax,
		int? PEnableSalesTax2,
		string Infobar);
	}
}

