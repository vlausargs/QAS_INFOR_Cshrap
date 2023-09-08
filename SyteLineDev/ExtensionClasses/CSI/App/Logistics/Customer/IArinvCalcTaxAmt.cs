//PROJECT NAME: Logistics
//CLASS NAME: IArinvCalcTaxAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArinvCalcTaxAmt
	{
		(int? ReturnCode, decimal? PSalesTax1,
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
		);
	}
}

