//PROJECT NAME: Data
//CLASS NAME: IEurDom3ConvertLedger.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEurDom3ConvertLedger
	{
		(int? ReturnCode,
			string Infobar) EurDom3ConvertLedgerSp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string OrigCurrCode,
			string InAcct,
			string InAcctUnit1,
			string InAcctUnit2,
			string InAcctUnit3,
			string InAcctUnit4,
			string Infobar);
	}
}

