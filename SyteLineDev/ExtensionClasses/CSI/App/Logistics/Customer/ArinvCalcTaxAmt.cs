//PROJECT NAME: Logistics
//CLASS NAME: ArinvCalcTaxAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArinvCalcTaxAmt : IArinvCalcTaxAmt
	{
		readonly IApplicationDB appDB;
		
		
		public ArinvCalcTaxAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PSalesTax1,
		decimal? PSalesTax2,
		decimal? PGrossSalesTax1,
		decimal? PGrossSalesTax2,
		decimal? PWithholdingTax1,
		decimal? PWithholdingTax2,
		string Infobar) ArinvCalcTaxAmtSp(DateTime? PInvDate,
		string PTermsCode,
		decimal? PAmount,
		decimal? PFreight,
		decimal? PMisc,
		string PCurrCode,
		decimal? PExchRate,
		int? PUseExchRate,
		int? PPlaces,
		string PTaxCode1,
		string PTaxCode2,
		decimal? PSalesTax1,
		decimal? PSalesTax2,
		string Infobar,
		int? IncludeTaxInPrice,
		int? PCalledFromTrigger = 0,
		Guid? PARInvRowPointer = null,
		decimal? PGrossSalesTax1 = null,
		decimal? PGrossSalesTax2 = null,
		decimal? PWithholdingTax1 = null,
		decimal? PWithholdingTax2 = null
		)
		{
			GenericDate _PInvDate = PInvDate;
			TermsCodeType _PTermsCode = PTermsCode;
			AmountType _PAmount = PAmount;
			AmountType _PFreight = PFreight;
			AmountType _PMisc = PMisc;
			CurrCodeType _PCurrCode = PCurrCode;
			ExchRateType _PExchRate = PExchRate;
			Flag _PUseExchRate = PUseExchRate;
			GenericIntType _PPlaces = PPlaces;
			TaxCodeType _PTaxCode1 = PTaxCode1;
			TaxCodeType _PTaxCode2 = PTaxCode2;
			AmountType _PSalesTax1 = PSalesTax1;
			AmountType _PSalesTax2 = PSalesTax2;
			Infobar _Infobar = Infobar;
			ListYesNoType _IncludeTaxInPrice = IncludeTaxInPrice;
			FlagNyType _PCalledFromTrigger = PCalledFromTrigger;
			RowPointerType _PARInvRowPointer = PARInvRowPointer;
			AmountType _PGrossSalesTax1 = PGrossSalesTax1;
			AmountType _PGrossSalesTax2 = PGrossSalesTax2;
			AmountType _PWithholdingTax1 = PWithholdingTax1;
			AmountType _PWithholdingTax2 = PWithholdingTax2;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArinvCalcTaxAmtSp";
				
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTermsCode", _PTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAmount", _PAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMisc", _PMisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUseExchRate", _PUseExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlaces", _PPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode1", _PTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode2", _PTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax1", _PSalesTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSalesTax2", _PSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IncludeTaxInPrice", _IncludeTaxInPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCalledFromTrigger", _PCalledFromTrigger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PARInvRowPointer", _PARInvRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PGrossSalesTax1", _PGrossSalesTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PGrossSalesTax2", _PGrossSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWithholdingTax1", _PWithholdingTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWithholdingTax2", _PWithholdingTax2, ParameterDirection.InputOutput);
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSalesTax1 = _PSalesTax1;
				PSalesTax2 = _PSalesTax2;
				PGrossSalesTax1 = _PGrossSalesTax1;
				PGrossSalesTax2 = _PGrossSalesTax2;
				PWithholdingTax1 = _PWithholdingTax1;
				PWithholdingTax2 = _PWithholdingTax2;
				Infobar = _Infobar;

				return (Severity, PSalesTax1, PSalesTax2, PGrossSalesTax1, PGrossSalesTax2, PWithholdingTax1, PWithholdingTax2, Infobar);
			}
		}
	}
}
