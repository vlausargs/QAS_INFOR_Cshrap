//PROJECT NAME: Finance
//CLASS NAME: IExtFinTaxCalc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinTaxCalc
	{
		(int? ReturnCode,
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
			string Infobar);
	}
}

