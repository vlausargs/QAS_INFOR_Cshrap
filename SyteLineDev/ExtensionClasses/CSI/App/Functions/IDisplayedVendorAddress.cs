//PROJECT NAME: Data
//CLASS NAME: IDisplayedVendorAddressSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayedVendorAddress
	{
		string DisplayedVendorAddressSp(
			string VendNum);
	}
}

