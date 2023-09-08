//PROJECT NAME: Finance
//CLASS NAME: ExtFinTaxCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinTaxCalc : IExtFinTaxCalc
	{
		readonly IApplicationDB appDB;
		
		public ExtFinTaxCalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar) ExtFinTaxCalcSp(
			string PInvType,
			string PTaxCode1,
			string PTaxCode2,
			decimal? PFreight,
			string PFrtTaxCode1,
			string PFrtTaxCode2,
			decimal? PMisc,
			string PMiscTaxCode1,
			string PMiscTaxCode2,
			DateTime? PInvDate,
			string PTermsCode,
			int? PUseExchRate,
			string PCurrCode,
			int? PPlaces,
			decimal? PExchRate,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar)
		{
			DefaultCharType _PInvType = PInvType;
			TaxCodeType _PTaxCode1 = PTaxCode1;
			TaxCodeType _PTaxCode2 = PTaxCode2;
			AmountType _PFreight = PFreight;
			TaxCodeType _PFrtTaxCode1 = PFrtTaxCode1;
			TaxCodeType _PFrtTaxCode2 = PFrtTaxCode2;
			AmountType _PMisc = PMisc;
			TaxCodeType _PMiscTaxCode1 = PMiscTaxCode1;
			TaxCodeType _PMiscTaxCode2 = PMiscTaxCode2;
			GenericDate _PInvDate = PInvDate;
			TermsCodeType _PTermsCode = PTermsCode;
			Flag _PUseExchRate = PUseExchRate;
			CurrCodeType _PCurrCode = PCurrCode;
			GenericIntType _PPlaces = PPlaces;
			ExchRateType _PExchRate = PExchRate;
			AmountType _PSalesTax1 = PSalesTax1;
			AmountType _PSalesTax2 = PSalesTax2;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinTaxCalcSp";
				
				appDB.AddCommandParameter(cmd, "PInvType", _PInvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode1", _PTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode2", _PTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFrtTaxCode1", _PFrtTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFrtTaxCode2", _PFrtTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMisc", _PMisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscTaxCode1", _PMiscTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscTaxCode2", _PMiscTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTermsCode", _PTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUseExchRate", _PUseExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlaces", _PPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax1", _PSalesTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSalesTax2", _PSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSalesTax1 = _PSalesTax1;
				PSalesTax2 = _PSalesTax2;
				Infobar = _Infobar;
				
				return (Severity, PSalesTax1, PSalesTax2, Infobar);
			}
		}
	}
}
