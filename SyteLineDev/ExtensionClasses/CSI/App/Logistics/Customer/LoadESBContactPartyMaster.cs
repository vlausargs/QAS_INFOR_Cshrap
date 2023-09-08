//PROJECT NAME: Logistics
//CLASS NAME: LoadESBContactPartyMaster.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class LoadESBContactPartyMaster : ILoadESBContactPartyMaster
	{
		readonly IApplicationDB appDB;
		
		
		public LoadESBContactPartyMaster(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LoadESBContactPartyMasterSp(string DerBODID,
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
		string Infobar)
		{
			LongListType _DerBODID = DerBODID;
			StringType _ActionExpression = ActionExpression;
			LongListType _ContactID = ContactID;
			SurnameType _LName = LName;
			GivenNameType _FName = FName;
			NameType _MI = MI;
			SuffixNameType _SName = SName;
			JobTitleType _JobTitle = JobTitle;
			NameType _Company = Company;
			AddressType _Addr_1 = Addr_1;
			AddressType _Addr_2 = Addr_2;
			AddressType _Addr_3 = Addr_3;
			AddressType _Addr_4 = Addr_4;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			ISOCountryCodeType _ISOCountryCode = ISOCountryCode;
			PhoneType _OfficePhone = OfficePhone;
			PhoneType _MobilePhone = MobilePhone;
			PhoneType _HomePhone = HomePhone;
			PhoneType _FaxNum = FaxNum;
			EmailType _Email = Email;
			StringType _DerCommunicationPreference = DerCommunicationPreference;
			StringType _DerDoNotCall = DerDoNotCall;
			StringType _DerDoNotSendEmail = DerDoNotSendEmail;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBContactPartyMasterSp";
				
				appDB.AddCommandParameter(cmd, "DerBODID", _DerBODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContactID", _ContactID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LName", _LName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FName", _FName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MI", _MI, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SName", _SName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobTitle", _JobTitle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Company", _Company, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_1", _Addr_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_2", _Addr_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_3", _Addr_3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_4", _Addr_4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISOCountryCode", _ISOCountryCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OfficePhone", _OfficePhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MobilePhone", _MobilePhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HomePhone", _HomePhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerCommunicationPreference", _DerCommunicationPreference, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDoNotCall", _DerDoNotCall, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDoNotSendEmail", _DerDoNotSendEmail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
