//PROJECT NAME: Logistics
//CLASS NAME: ICreateContactCommunication.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICreateContactCommunication
	{
		int? CreateContactCommunicationSp(string Topic,
		string Type,
		string Note,
		string ShowContent,
		string Input,
		string ContactId,
		string LName,
		string FName,
		string Mi,
		string SName,
		string Company,
		string JobTitle,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string City,
		string State,
		string Zip,
		string Country,
		string OfficePhone,
		string MobilePhone,
		string Email,
		string Fax);
	}
}

