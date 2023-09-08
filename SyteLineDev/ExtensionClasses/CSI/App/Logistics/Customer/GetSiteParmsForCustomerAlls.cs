//PROJECT NAME: CSICustomer
//CLASS NAME: GetSiteParmsForCustomerAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetSiteParmsForCustomerAlls
	{
		(int? ReturnCode, string CurrCode, byte? EcReporting, string Country) GetSiteParmsForCustomerAllsSP(string Site,
		string CurrCode,
		byte? EcReporting,
		string Country);
	}
	
	public class GetSiteParmsForCustomerAlls : IGetSiteParmsForCustomerAlls
	{
		readonly IApplicationDB appDB;
		
		public GetSiteParmsForCustomerAlls(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CurrCode, byte? EcReporting, string Country) GetSiteParmsForCustomerAllsSP(string Site,
		string CurrCode,
		byte? EcReporting,
		string Country)
		{
			SiteType _Site = Site;
			CurrCodeType _CurrCode = CurrCode;
			ListYesNoType _EcReporting = EcReporting;
			CountryType _Country = Country;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSiteParmsForCustomerAllsSP";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcReporting", _EcReporting, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurrCode = _CurrCode;
				EcReporting = _EcReporting;
				Country = _Country;
				
				return (Severity, CurrCode, EcReporting, Country);
			}
		}
	}
}
