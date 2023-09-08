//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSPortalValidateUnitReg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSPortalValidateUnitReg
	{
		int SSSFSPortalValidateUnitRegSp(string SerNum,
		                                 string Item,
		                                 string Name,
		                                 string Addr1,
		                                 string City,
		                                 string State,
		                                 string Zip,
		                                 string Country,
		                                 string Phone,
		                                 string Email,
		                                 ref string Infobar);
	}
	
	public class SSSFSPortalValidateUnitReg : ISSSFSPortalValidateUnitReg
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPortalValidateUnitReg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSPortalValidateUnitRegSp(string SerNum,
		                                        string Item,
		                                        string Name,
		                                        string Addr1,
		                                        string City,
		                                        string State,
		                                        string Zip,
		                                        string Country,
		                                        string Phone,
		                                        string Email,
		                                        ref string Infobar)
		{
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			NameType _Name = Name;
			AddressType _Addr1 = Addr1;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountryType _Country = Country;
			PhoneType _Phone = Phone;
			EmailType _Email = Email;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPortalValidateUnitRegSp";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
