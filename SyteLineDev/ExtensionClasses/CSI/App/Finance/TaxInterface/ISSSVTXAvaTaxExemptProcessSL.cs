//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXAvaTaxExemptProcessSL.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXAvaTaxExemptProcessSL
	{
		(int? ReturnCode,
			string oCMInvNum,
			string Infobar) SSSVTXAvaTaxExemptProcessSLSp(
			string pInvNum,
			decimal? pAvalaraTax,
			decimal? pAvalaraTax2,
			string oCMInvNum,
			string Infobar);
	}
}

