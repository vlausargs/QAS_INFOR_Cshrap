//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXSetCustTaxCode1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXSetCustTaxCode1
	{
		(int? ReturnCode, string Infobar) SSSVTXSetCustTaxCode1Sp(string Infobar);
	}
}

