//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXCalcCoTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXCalcCoTax
	{
		(int? ReturnCode,
		string Infobar) SSSVTXCalcCoTaxSp(
			string pCoNum,
			string Infobar);
	}
}

