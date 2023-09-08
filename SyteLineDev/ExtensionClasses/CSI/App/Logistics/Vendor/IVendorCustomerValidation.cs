//PROJECT NAME: Logistics
//CLASS NAME: IVendorCustomerValidation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVendorCustomerValidation
	{
		(int? ReturnCode, string Infobar) VendorCustomerValidationSp(string CustNum,
		string VendNum,
		string Infobar);
	}
}

