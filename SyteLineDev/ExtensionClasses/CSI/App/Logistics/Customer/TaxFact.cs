//PROJECT NAME: Logistics
//CLASS NAME: TaxFact.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TaxFact : ITaxFact
	{
		readonly IApplicationDB appDB;
		
		
		public TaxFact(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PFactor,
		string Infobar) TaxFactSp(string PTermsCode,
		int? PUseExchRate,
		decimal? PExchRate,
		DateTime? PInvDate,
		string PCurrCode,
		decimal? PFactor,
		string Infobar,
		int? EXTGEN_TaxFactSp_Exists = null,
		string Site = null,
		string DomCurrCode = null)
		{
			TermsCodeType _PTermsCode = PTermsCode;
			Flag _PUseExchRate = PUseExchRate;
			ExchRateType _PExchRate = PExchRate;
			GenericDate _PInvDate = PInvDate;
			CurrCodeType _PCurrCode = PCurrCode;
			ExchRateType _PFactor = PFactor;
			Infobar _Infobar = Infobar;
			ListYesNoType _EXTGEN_TaxFactSp_Exists = EXTGEN_TaxFactSp_Exists;
			SiteType _Site = Site;
			CurrCodeType _DomCurrCode = DomCurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TaxFactSp";
				
				appDB.AddCommandParameter(cmd, "PTermsCode", _PTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUseExchRate", _PUseExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFactor", _PFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EXTGEN_TaxFactSp_Exists", _EXTGEN_TaxFactSp_Exists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrCode", _DomCurrCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PFactor = _PFactor;
				Infobar = _Infobar;
				
				return (Severity, PFactor, Infobar);
			}
		}
	}
}
