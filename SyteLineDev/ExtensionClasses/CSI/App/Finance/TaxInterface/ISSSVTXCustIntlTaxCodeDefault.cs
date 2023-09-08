//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXCustIntlTaxCodeDefault.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXCustIntlTaxCodeDefault
	{
		(int? ReturnCode, string TaxCode1) SSSVTXCustIntlTaxCodeDefaultSp(string Country,
		string TaxCode1);
	}
}

