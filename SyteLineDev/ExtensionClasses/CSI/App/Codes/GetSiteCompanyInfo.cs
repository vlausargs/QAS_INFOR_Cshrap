//PROJECT NAME: CSICodes
//CLASS NAME: GetSiteCompanyInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IGetSiteCompanyInfo
	{
		int GetSiteCompanyInfoSp(string Site,
		                         ref string ReturnCompanyName,
		                         ref string MailingAddress,
		                         ref string City,
		                         ref string State,
		                         ref string Zip,
		                         ref string Country,
		                         ref string CountryCode,
		                         ref string EmailAddr,
		                         ref string Phone);
	}
	
	public class GetSiteCompanyInfo : IGetSiteCompanyInfo
	{
		readonly IApplicationDB appDB;
		
		public GetSiteCompanyInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetSiteCompanyInfoSp(string Site,
		                                ref string ReturnCompanyName,
		                                ref string MailingAddress,
		                                ref string City,
		                                ref string State,
		                                ref string Zip,
		                                ref string Country,
		                                ref string CountryCode,
		                                ref string EmailAddr,
		                                ref string Phone)
		{
			SiteType _Site = Site;
			NameType _ReturnCompanyName = ReturnCompanyName;
			AddressType _MailingAddress = MailingAddress;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountryType _Country = Country;
			ISOCountryCodeType _CountryCode = CountryCode;
			EmailType _EmailAddr = EmailAddr;
			PhoneType _Phone = Phone;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSiteCompanyInfoSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReturnCompanyName", _ReturnCompanyName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MailingAddress", _MailingAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CountryCode", _CountryCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EmailAddr", _EmailAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReturnCompanyName = _ReturnCompanyName;
				MailingAddress = _MailingAddress;
				City = _City;
				State = _State;
				Zip = _Zip;
				Country = _Country;
				CountryCode = _CountryCode;
				EmailAddr = _EmailAddr;
				Phone = _Phone;
				
				return Severity;
			}
		}
	}
}
