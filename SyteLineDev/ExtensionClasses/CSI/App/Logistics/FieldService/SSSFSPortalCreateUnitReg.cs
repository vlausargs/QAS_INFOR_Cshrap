//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalCreateUnitReg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSPortalCreateUnitReg
	{
		(int? ReturnCode, string TransNum, string Infobar) SSSFSPortalCreateUnitRegSp(string SerNum,
		string Item,
		string Name,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string City,
		string State,
		string Zip,
		string Country,
		string Phone,
		string Email,
		string RegNotes,
		byte? Validate = (byte)0,
		string TransNum = null,
		string Infobar = null);
	}
	
	public class SSSFSPortalCreateUnitReg : ISSSFSPortalCreateUnitReg
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPortalCreateUnitReg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TransNum, string Infobar) SSSFSPortalCreateUnitRegSp(string SerNum,
		string Item,
		string Name,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string City,
		string State,
		string Zip,
		string Country,
		string Phone,
		string Email,
		string RegNotes,
		byte? Validate = (byte)0,
		string TransNum = null,
		string Infobar = null)
		{
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			NameType _Name = Name;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountryType _Country = Country;
			PhoneType _Phone = Phone;
			EmailType _Email = Email;
			StringType _RegNotes = RegNotes;
			ListYesNoType _Validate = Validate;
			FSIncNumType _TransNum = TransNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPortalCreateUnitRegSp";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RegNotes", _RegNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Validate", _Validate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TransNum = _TransNum;
				Infobar = _Infobar;
				
				return (Severity, TransNum, Infobar);
			}
		}
	}
}
