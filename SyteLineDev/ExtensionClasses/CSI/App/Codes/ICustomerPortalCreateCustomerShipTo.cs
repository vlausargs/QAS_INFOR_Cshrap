//PROJECT NAME: Codes
//CLASS NAME: ICustomerPortalCreateCustomerShipTo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICustomerPortalCreateCustomerShipTo
	{
		(int? ReturnCode, string CustSeq,
		string Infobar) CustomerPortalCreateCustomerShipToSp(string CustNum,
		string CustSeq,
		string Name,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string City,
		string County,
		string State,
		string PostalCode,
		string Country,
		string ResellerSlsman,
		string ShipToContactName,
		string ShipToContactPhone,
		string ShipToContactFax,
		string ShipToContactEmail,
		int? PrimarySiteFlag,
		int? BillToFlag,
		int? AddressChanged,
		string Infobar);
	}
}

