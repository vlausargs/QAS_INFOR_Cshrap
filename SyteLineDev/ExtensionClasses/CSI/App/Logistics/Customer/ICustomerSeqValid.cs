//PROJECT NAME: Logistics
//CLASS NAME: ICustomerSeqValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustomerSeqValid
	{
		(int? ReturnCode, string Name,
		string City,
		string State,
		string Zip,
		string County,
		string Country,
		string FaxNum,
		string TelexNum,
		string Addr_1,
		string Addr_2,
		string Addr_3,
		string Addr_4,
		string CurrCode,
		string ShipToEmail,
		string BillToEmail,
		Guid? RowPointer,
		string Infobar) CustomerSeqValidSp(string CustNum,
		int? CustSeq,
		string Name,
		string City,
		string State,
		string Zip,
		string County,
		string Country,
		string FaxNum,
		string TelexNum,
		string Addr_1,
		string Addr_2,
		string Addr_3,
		string Addr_4,
		string CurrCode,
		string ShipToEmail,
		string BillToEmail,
		Guid? RowPointer,
		string Infobar,
		string PSite = null);
	}
}

