//PROJECT NAME: Finance
//CLASS NAME: IMultiLineAddressWithAltCountry.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiLineAddressWithAltCountry
	{
		string MultiLineAddressWithAltCountryFn(
			string Name = null,
			string Addr1 = null,
			string Addr2 = null,
			string Addr3 = null,
			string Addr4 = null,
			string City = null,
			string StateCode = null,
			string Zip = null,
			string Country = null,
			string Contact = null,
			string AlternateAddrFormatCountry = null);
	}
}

