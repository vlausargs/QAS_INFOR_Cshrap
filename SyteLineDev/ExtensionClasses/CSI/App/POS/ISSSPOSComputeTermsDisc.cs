//PROJECT NAME: POS
//CLASS NAME: ISSSPOSComputeTermsDisc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSComputeTermsDisc
	{
		(int? ReturnCode,
			decimal? DiscAmt,
			string Infobar) SSSPOSComputeTermsDiscSp(
			string POSMNum,
			decimal? Amount,
			int? CurrencyPlaces,
			decimal? DiscAmt,
			string Infobar);
	}
}

