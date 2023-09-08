//PROJECT NAME: CSIVendor
//CLASS NAME: GetVendAddrInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetVendAddrInfo
	{
		int GetVendAddrInfoSp(string VendNum,
		                      ref string Addr1,
		                      ref string Addr2,
		                      ref string Addr3,
		                      ref string Addr4,
		                      ref string Country,
		                      ref string County,
		                      ref string Name,
		                      ref string Zip,
		                      ref string City,
		                      ref string State,
		                      ref string FaxNum,
		                      ref string TelexNum,
		                      ref byte? PayHold,
		                      ref string PayHoldUser,
		                      ref DateTime? PayHoldDate,
		                      ref string PayHoldReason,
		                      ref string InternetURL,
		                      ref string IntEmailAddr,
		                      ref string ExtEmailAddr,
		                      ref string Infobar);
	}
	
	public class GetVendAddrInfo : IGetVendAddrInfo
	{
		readonly IApplicationDB appDB;
		
		public GetVendAddrInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetVendAddrInfoSp(string VendNum,
		                             ref string Addr1,
		                             ref string Addr2,
		                             ref string Addr3,
		                             ref string Addr4,
		                             ref string Country,
		                             ref string County,
		                             ref string Name,
		                             ref string Zip,
		                             ref string City,
		                             ref string State,
		                             ref string FaxNum,
		                             ref string TelexNum,
		                             ref byte? PayHold,
		                             ref string PayHoldUser,
		                             ref DateTime? PayHoldDate,
		                             ref string PayHoldReason,
		                             ref string InternetURL,
		                             ref string IntEmailAddr,
		                             ref string ExtEmailAddr,
		                             ref string Infobar)
		{
			VendNumType _VendNum = VendNum;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			CountryType _Country = Country;
			CountyType _County = County;
			NameType _Name = Name;
			PostalCodeType _Zip = Zip;
			CityType _City = City;
			StateType _State = State;
			PhoneType _FaxNum = FaxNum;
			PhoneType _TelexNum = TelexNum;
			ListYesNoType _PayHold = PayHold;
			UserCodeType _PayHoldUser = PayHoldUser;
			DateType _PayHoldDate = PayHoldDate;
			ReasonCodeType _PayHoldReason = PayHoldReason;
			URLType _InternetURL = InternetURL;
			EmailType _IntEmailAddr = IntEmailAddr;
			EmailType _ExtEmailAddr = ExtEmailAddr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetVendAddrInfoSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TelexNum", _TelexNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PayHold", _PayHold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PayHoldUser", _PayHoldUser, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PayHoldDate", _PayHoldDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PayHoldReason", _PayHoldReason, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InternetURL", _InternetURL, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IntEmailAddr", _IntEmailAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExtEmailAddr", _ExtEmailAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Addr1 = _Addr1;
				Addr2 = _Addr2;
				Addr3 = _Addr3;
				Addr4 = _Addr4;
				Country = _Country;
				County = _County;
				Name = _Name;
				Zip = _Zip;
				City = _City;
				State = _State;
				FaxNum = _FaxNum;
				TelexNum = _TelexNum;
				PayHold = _PayHold;
				PayHoldUser = _PayHoldUser;
				PayHoldDate = _PayHoldDate;
				PayHoldReason = _PayHoldReason;
				InternetURL = _InternetURL;
				IntEmailAddr = _IntEmailAddr;
				ExtEmailAddr = _ExtEmailAddr;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
