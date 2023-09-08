//PROJECT NAME: Logistics
//CLASS NAME: CreateContactCommunication.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CreateContactCommunication : ICreateContactCommunication
	{
		readonly IApplicationDB appDB;
		
		
		public CreateContactCommunication(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateContactCommunicationSp(string Topic,
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
		string Fax)
		{
			CommLogTopicType _Topic = Topic;
			CommLogTypeType _Type = Type;
			CommLogNotesType _Note = Note;
			StringType _ShowContent = ShowContent;
			CommLogNotesType _Input = Input;
			ContactIDType _ContactId = ContactId;
			SurnameType _LName = LName;
			GivenNameType _FName = FName;
			InitialType _Mi = Mi;
			SuffixNameType _SName = SName;
			NameType _Company = Company;
			JobTitleType _JobTitle = JobTitle;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountryType _Country = Country;
			PhoneType _OfficePhone = OfficePhone;
			PhoneType _MobilePhone = MobilePhone;
			EmailType _Email = Email;
			PhoneType _Fax = Fax;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateContactCommunicationSp";
				
				appDB.AddCommandParameter(cmd, "Topic", _Topic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Note", _Note, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowContent", _ShowContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Input", _Input, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContactId", _ContactId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LName", _LName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FName", _FName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mi", _Mi, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SName", _SName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Company", _Company, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobTitle", _JobTitle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OfficePhone", _OfficePhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MobilePhone", _MobilePhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Fax", _Fax, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
