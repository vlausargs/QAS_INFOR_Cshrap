//PROJECT NAME: CSIFSPlus
//CLASS NAME: FormatMultiLineAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface IFormatMultiLineAddress
	{
		(int? ReturnCode, string Address, string Infobar) FormatMultiLineAddressSp(string Name = null,
		string Addr1 = null,
		string Addr2 = null,
		string Addr3 = null,
		string Addr4 = null,
		string City = null,
		string State = null,
		string Zip = null,
		string Country = null,
		string Address = null,
		string Infobar = null);
	}
	
	public class FormatMultiLineAddress : IFormatMultiLineAddress
	{
		readonly IApplicationDB appDB;
		
		public FormatMultiLineAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Address, string Infobar) FormatMultiLineAddressSp(string Name = null,
		string Addr1 = null,
		string Addr2 = null,
		string Addr3 = null,
		string Addr4 = null,
		string City = null,
		string State = null,
		string Zip = null,
		string Country = null,
		string Address = null,
		string Infobar = null)
		{
			NameType _Name = Name;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountryType _Country = Country;
			LongAddress _Address = Address;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FormatMultiLineAddressSp";
				
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Address", _Address, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Address = _Address;
				Infobar = _Infobar;
				
				return (Severity, Address, Infobar);
			}
		}
	}
}
