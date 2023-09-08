//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQLineValVend.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQLineValVend : ISSSRFQLineValVend
	{
		readonly IApplicationDB appDB;
		
		
		public SSSRFQLineValVend(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Name,
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
		string Infobar)
		{
			VendNumType _VendNum = VendNum;
			ItemType _Item = Item;
			NameType _Name = Name;
			ContactType _Contact = Contact;
			PhoneType _Phone = Phone;
			PhoneType _FaxNum = FaxNum;
			EmailType _Email = Email;
			CurrCodeType _CurrCode = CurrCode;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountryType _Country = Country;
			CountyType _County = County;
			VendItemType _VendItem = VendItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQLineValVendSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendItem", _VendItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Name = _Name;
				Contact = _Contact;
				Phone = _Phone;
				FaxNum = _FaxNum;
				Email = _Email;
				CurrCode = _CurrCode;
				Addr1 = _Addr1;
				Addr2 = _Addr2;
				Addr3 = _Addr3;
				Addr4 = _Addr4;
				City = _City;
				State = _State;
				Zip = _Zip;
				Country = _Country;
				County = _County;
				VendItem = _VendItem;
				Infobar = _Infobar;
				
				return (Severity, Name, Contact, Phone, FaxNum, Email, CurrCode, Addr1, Addr2, Addr3, Addr4, City, State, Zip, Country, County, VendItem, Infobar);
			}
		}
	}
}
