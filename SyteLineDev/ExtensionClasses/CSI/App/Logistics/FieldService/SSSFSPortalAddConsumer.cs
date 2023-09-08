//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalAddConsumer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSPortalAddConsumer
	{
		(int? ReturnCode, string NewUsrNum, string Infobar) SSSFSPortalAddConsumerSp(string Name = null,
		string Addr_1 = null,
		string Addr_2 = null,
		string Addr_3 = null,
		string Addr_4 = null,
		string City = null,
		string State = null,
		string Zip = null,
		string Country = null,
		string Phone = null,
		string Email = null,
		string NewUsrNum = null,
		string Infobar = null);
	}
	
	public class SSSFSPortalAddConsumer : ISSSFSPortalAddConsumer
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPortalAddConsumer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string NewUsrNum, string Infobar) SSSFSPortalAddConsumerSp(string Name = null,
		string Addr_1 = null,
		string Addr_2 = null,
		string Addr_3 = null,
		string Addr_4 = null,
		string City = null,
		string State = null,
		string Zip = null,
		string Country = null,
		string Phone = null,
		string Email = null,
		string NewUsrNum = null,
		string Infobar = null)
		{
			NameType _Name = Name;
			AddressType _Addr_1 = Addr_1;
			AddressType _Addr_2 = Addr_2;
			AddressType _Addr_3 = Addr_3;
			AddressType _Addr_4 = Addr_4;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountryType _Country = Country;
			PhoneType _Phone = Phone;
			EmailType _Email = Email;
			FSUsrNumType _NewUsrNum = NewUsrNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPortalAddConsumerSp";
				
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_1", _Addr_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_2", _Addr_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_3", _Addr_3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_4", _Addr_4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewUsrNum", _NewUsrNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewUsrNum = _NewUsrNum;
				Infobar = _Infobar;
				
				return (Severity, NewUsrNum, Infobar);
			}
		}
	}
}
