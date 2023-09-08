//PROJECT NAME: Data
//CLASS NAME: IDisplayVendorAddressWithPhoneSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayVendorAddressWithPhone
	{
		string DisplayVendorAddressWithPhoneSp(
			string VendNum);
	}
}

