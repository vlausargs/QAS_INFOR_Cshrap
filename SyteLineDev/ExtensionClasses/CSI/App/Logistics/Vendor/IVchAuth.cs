//PROJECT NAME: Logistics
//CLASS NAME: IVchAuth.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVchAuth
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) VchAuthSp(string PText,
		string PStartingAuthorizer,
		string PEndingAuthorizer,
		int? PStartingVoucher,
		int? PEndingVoucher,
		DateTime? PStartingInvoiceDate,
		DateTime? PEndingInvoiceDate,
		string PStartingVendor,
		string PEndingVendor,
		string PAuthStatus,
		string Infobar);
	}
}

