//PROJECT NAME: Data
//CLASS NAME: VendaddrUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class VendaddrUpd : IVendaddrUpd
	{
		readonly IApplicationDB appDB;
		
		public VendaddrUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar) VendaddrUpdSP(
			string Vendnum,
			string Name = null,
			string City = null,
			string State = null,
			string Zip = null,
			string County = null,
			string Country = null,
			string FaxNum = null,
			string TelexNum = null,
			string Addr1 = null,
			string Addr2 = null,
			string Addr3 = null,
			string Addr4 = null,
			int? PayHold = null,
			string PayHoldUser = null,
			DateTime? PayHoldDate = null,
			string PayHoldReason = null,
			string InternetEmailURL = null,
			string InternalEmailAddr = null,
			string ExternalEmailAddr = null,
			int? UseLongName = 0,
			string LongName = null,
			string InfoBar = null)
		{
			VendNumType _Vendnum = Vendnum;
			NameType _Name = Name;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountyType _County = County;
			CountryType _Country = Country;
			PhoneType _FaxNum = FaxNum;
			PhoneType _TelexNum = TelexNum;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			ListYesNoType _PayHold = PayHold;
			UserCodeType _PayHoldUser = PayHoldUser;
			DateType _PayHoldDate = PayHoldDate;
			ReasonCodeType _PayHoldReason = PayHoldReason;
			URLType _InternetEmailURL = InternetEmailURL;
			EmailType _InternalEmailAddr = InternalEmailAddr;
			EmailType _ExternalEmailAddr = ExternalEmailAddr;
			ListYesNoType _UseLongName = UseLongName;
			LongNameType _LongName = LongName;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VendaddrUpdSP";
				
				appDB.AddCommandParameter(cmd, "Vendnum", _Vendnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TelexNum", _TelexNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayHold", _PayHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayHoldUser", _PayHoldUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayHoldDate", _PayHoldDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayHoldReason", _PayHoldReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InternetEmailURL", _InternetEmailURL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InternalEmailAddr", _InternalEmailAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExternalEmailAddr", _ExternalEmailAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseLongName", _UseLongName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LongName", _LongName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
