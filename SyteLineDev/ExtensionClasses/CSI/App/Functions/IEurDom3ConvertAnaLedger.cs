//PROJECT NAME: Data
//CLASS NAME: IEurDom3ConvertAnaLedger.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEurDom3ConvertAnaLedger
	{
		(int? ReturnCode,
			string Infobar) EurDom3ConvertAnaLedgerSp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string OrigCurrCode,
			string AnaInAcct,
			string AnaInAcctUnit1,
			string AnaInAcctUnit2,
			string AnaInAcctUnit3,
			string AnaInAcctUnit4,
			string Infobar);
	}
}

