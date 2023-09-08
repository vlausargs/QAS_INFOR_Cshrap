//PROJECT NAME: Data
//CLASS NAME: IMultiLineAddressSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IMultiLineAddress
	{
		string MultiLineAddressSp(
			string Name = null,
			string Addr1 = null,
			string Addr2 = null,
			string Addr3 = null,
			string Addr4 = null,
			string City = null,
			string StateCode = null,
			string Zip = null,
			string Country = null,
			string Contact = null);
	}
}

