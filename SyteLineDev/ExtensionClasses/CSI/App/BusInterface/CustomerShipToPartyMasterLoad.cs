//PROJECT NAME: CSIBusInterface
//CLASS NAME: CustomerShipToPartyMasterLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ICustomerShipToPartyMasterLoad
	{
		int CustomerShipToPartyMasterLoadSp(ref string DerBODID,
		                                    string ActionExpression,
		                                    string Name,
		                                    ref string Addr1,
		                                    ref string Addr2,
		                                    ref string Addr3,
		                                    ref string Addr4,
		                                    string City,
		                                    string State,
		                                    ref string Zip,
		                                    string ISOCountryCode,
		                                    string RequesterContactFax,
		                                    string RequesterContactPhone,
		                                    string CustomerPartyReceivingContact,
		                                    string ExternalEmailAddr,
		                                    string URL,
		                                    string CustomerPartyPartyId,
		                                    ref string Infobar);
	}
	
	public class CustomerShipToPartyMasterLoad : ICustomerShipToPartyMasterLoad
	{
		readonly IApplicationDB appDB;
		
		public CustomerShipToPartyMasterLoad(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CustomerShipToPartyMasterLoadSp(ref string DerBODID,
		                                           string ActionExpression,
		                                           string Name,
		                                           ref string Addr1,
		                                           ref string Addr2,
		                                           ref string Addr3,
		                                           ref string Addr4,
		                                           string City,
		                                           string State,
		                                           ref string Zip,
		                                           string ISOCountryCode,
		                                           string RequesterContactFax,
		                                           string RequesterContactPhone,
		                                           string CustomerPartyReceivingContact,
		                                           string ExternalEmailAddr,
		                                           string URL,
		                                           string CustomerPartyPartyId,
		                                           ref string Infobar)
		{
			LongListType _DerBODID = DerBODID;
			StringType _ActionExpression = ActionExpression;
			NameType _Name = Name;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			ISOCountryCodeType _ISOCountryCode = ISOCountryCode;
			PhoneType _RequesterContactFax = RequesterContactFax;
			PhoneType _RequesterContactPhone = RequesterContactPhone;
			ContactType _CustomerPartyReceivingContact = CustomerPartyReceivingContact;
			EmailType _ExternalEmailAddr = ExternalEmailAddr;
			URLType _URL = URL;
			CustNumType _CustomerPartyPartyId = CustomerPartyPartyId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustomerShipToPartyMasterLoadSp";
				
				appDB.AddCommandParameter(cmd, "DerBODID", _DerBODID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ISOCountryCode", _ISOCountryCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RequesterContactFax", _RequesterContactFax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RequesterContactPhone", _RequesterContactPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerPartyReceivingContact", _CustomerPartyReceivingContact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExternalEmailAddr", _ExternalEmailAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "URL", _URL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerPartyPartyId", _CustomerPartyPartyId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DerBODID = _DerBODID;
				Addr1 = _Addr1;
				Addr2 = _Addr2;
				Addr3 = _Addr3;
				Addr4 = _Addr4;
				Zip = _Zip;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
