//PROJECT NAME: Data
//CLASS NAME: IFormatVendorAddress.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IFormatVendorAddress
	{
		string FormatVendorAddressFn(
			string VendNum);

		(int? ReturnCode,
			string VendorAddress,
			string Infobar) FormatVendorAddressSp(
			string VendNum,
			string VendorAddress,
			string Infobar);
	}
}
