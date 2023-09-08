//PROJECT NAME: CSIVendor
//CLASS NAME: GetDefaultsForSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetDefaultsForSite
	{
		int GetDefaultsForSiteSp(string Site,
		                         ref string CurrCode,
		                         ref decimal? VchrToleranceOver,
		                         ref decimal? VchrToleranceUnder,
		                         ref byte? VchrAuthorize,
		                         ref string EFTBankCode,
		                         ref byte? EcReporting,
		                         ref string EFTFormat);
	}
	
	public class GetDefaultsForSite : IGetDefaultsForSite
	{
		readonly IApplicationDB appDB;
		
		public GetDefaultsForSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetDefaultsForSiteSp(string Site,
		                                ref string CurrCode,
		                                ref decimal? VchrToleranceOver,
		                                ref decimal? VchrToleranceUnder,
		                                ref byte? VchrAuthorize,
		                                ref string EFTBankCode,
		                                ref byte? EcReporting,
		                                ref string EFTFormat)
		{
			SiteType _Site = Site;
			CurrCodeType _CurrCode = CurrCode;
			TolerancePercentType _VchrToleranceOver = VchrToleranceOver;
			TolerancePercentType _VchrToleranceUnder = VchrToleranceUnder;
			ListYesNoType _VchrAuthorize = VchrAuthorize;
			BankCodeType _EFTBankCode = EFTBankCode;
			ListYesNoType _EcReporting = EcReporting;
			EFTFormatType _EFTFormat = EFTFormat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDefaultsForSiteSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VchrToleranceOver", _VchrToleranceOver, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VchrToleranceUnder", _VchrToleranceUnder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VchrAuthorize", _VchrAuthorize, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTBankCode", _EFTBankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcReporting", _EcReporting, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EFTFormat", _EFTFormat, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurrCode = _CurrCode;
				VchrToleranceOver = _VchrToleranceOver;
				VchrToleranceUnder = _VchrToleranceUnder;
				VchrAuthorize = _VchrAuthorize;
				EFTBankCode = _EFTBankCode;
				EcReporting = _EcReporting;
				EFTFormat = _EFTFormat;
				
				return Severity;
			}
		}
	}
}
