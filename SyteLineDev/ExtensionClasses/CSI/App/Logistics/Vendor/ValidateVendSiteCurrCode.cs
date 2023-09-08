//PROJECT NAME: Logistics
//CLASS NAME: ValidateVendSiteCurrCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateVendSiteCurrCode : IValidateVendSiteCurrCode
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateVendSiteCurrCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ToSite,
		string Infobar) ValidateVendSiteCurrCodeSp(string CurrSite,
		string ToSite,
		string VendNum,
		string Infobar)
		{
			SiteType _CurrSite = CurrSite;
			SiteType _ToSite = ToSite;
			VendNumType _VendNum = VendNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateVendSiteCurrCodeSp";
				
				appDB.AddCommandParameter(cmd, "CurrSite", _CurrSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ToSite = _ToSite;
				Infobar = _Infobar;
				
				return (Severity, ToSite, Infobar);
			}
		}
	}
}
