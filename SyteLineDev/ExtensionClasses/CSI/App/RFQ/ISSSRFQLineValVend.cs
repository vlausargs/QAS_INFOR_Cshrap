//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQLineValVend.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQLineValVend
	{
		(int? ReturnCode, string Name,
		string Contact,
		string Phone,
		string FaxNum,
		string Email,
		string CurrCode,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string City,
		string State,
		string Zip,
		string Country,
		string County,
		string VendItem,
		string Infobar) SSSRFQLineValVendSp(string VendNum,
		string Item,
		string Name,
		string Contact,
		string Phone,
		string FaxNum,
		string Email,
		string CurrCode,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string City,
		string State,
		string Zip,
		string Country,
		string County,
		string VendItem,
		string Infobar);
	}
}

