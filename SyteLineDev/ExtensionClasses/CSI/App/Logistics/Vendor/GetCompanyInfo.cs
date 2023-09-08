//PROJECT NAME: CSIVendor
//CLASS NAME: GetCompanyInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetCompanyInfo
	{
		int GetCompanyInfoSP(ref string ReturnCompanyName,
		                     ref string MailingAddress,
		                     ref string City,
		                     ref string State,
		                     ref string Zip);
	}
	
	public class GetCompanyInfo : IGetCompanyInfo
	{
		readonly IApplicationDB appDB;
		
		public GetCompanyInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetCompanyInfoSP(ref string ReturnCompanyName,
		                            ref string MailingAddress,
		                            ref string City,
		                            ref string State,
		                            ref string Zip)
		{
			NameType _ReturnCompanyName = ReturnCompanyName;
			AddressType _MailingAddress = MailingAddress;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCompanyInfoSP";
				
				appDB.AddCommandParameter(cmd, "ReturnCompanyName", _ReturnCompanyName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MailingAddress", _MailingAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReturnCompanyName = _ReturnCompanyName;
				MailingAddress = _MailingAddress;
				City = _City;
				State = _State;
				Zip = _Zip;
				
				return Severity;
			}
		}
	}
}
