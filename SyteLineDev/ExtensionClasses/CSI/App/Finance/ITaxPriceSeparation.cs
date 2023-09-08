//PROJECT NAME: Finance
//CLASS NAME: ITaxPriceSeparation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITaxPriceSeparation
	{
		(int? ReturnCode,
			decimal? AmountWithoutTax,
			decimal? UndiscAmountWithoutTax,
			decimal? Tax1OnAmount,
			decimal? Tax2OnAmount,
			decimal? Tax1OnUndiscAmount,
			decimal? Tax2OnUndiscAmount,
			string Infobar) TaxPriceSeparationSp(
			string InvType = "R",
			string Type = "I",
			string TaxCode1 = null,
			string TaxCode2 = null,
			string HdrTaxCode1 = null,
			string HdrTaxCode2 = null,
			decimal? Amount = null,
			decimal? UndiscAmount = null,
			string CurrCode = null,
			decimal? ExchRate = null,
			int? UseExchRate = null,
			int? Places = 2,
			DateTime? InvDate = null,
			string TermsCode = null,
			decimal? AmountWithoutTax = null,
			decimal? UndiscAmountWithoutTax = null,
			decimal? Tax1OnAmount = null,
			decimal? Tax2OnAmount = null,
			decimal? Tax1OnUndiscAmount = null,
			decimal? Tax2OnUndiscAmount = null,
			string Infobar = null,
			decimal? WholesalePrice = null,
			string Site = null,
			string DomCurrCode = null,
			int? IsTaxInterfaceAvailable = null,
			int? vrtx_parm_Exists = null,
			int? IsJapanInterfaceAvailable = null);
	}
}