//PROJECT NAME: Data
//CLASS NAME: IFRMultiLineAddressSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFRMultiLineAddress
	{
		string FRMultiLineAddressSp(
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
			string FRMessageLanguage = null);
	}
}

