//PROJECT NAME: Data
//CLASS NAME: IDisplayedVendorAddressWithContactSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayedVendorAddressWithContact
	{
		string DisplayedVendorAddressWithContactSp(
			string VendNum,
			string Contact = null);
	}
}

