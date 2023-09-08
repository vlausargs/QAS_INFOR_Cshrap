//PROJECT NAME: Logistics
//CLASS NAME: ILoadESBContactPartyMaster.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ILoadESBContactPartyMaster
	{
		(int? ReturnCode, string Infobar) LoadESBContactPartyMasterSp(string DerBODID,
		string ActionExpression,
		string ContactID,
		string LName,
		string FName,
		string MI,
		string SName,
		string JobTitle,
		string Company,
		string Addr_1,
		string Addr_2,
		string Addr_3,
		string Addr_4,
		string City,
		string State,
		string Zip,
		string ISOCountryCode,
		string OfficePhone,
		string MobilePhone,
		string HomePhone,
		string FaxNum,
		string Email,
		string DerCommunicationPreference,
		string DerDoNotCall,
		string DerDoNotSendEmail,
		string Infobar);
	}
}

