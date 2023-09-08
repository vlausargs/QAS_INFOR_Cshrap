//PROJECT NAME: Data
//CLASS NAME: IEurDom3ConvertJournal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEurDom3ConvertJournal
	{
		(int? ReturnCode,
			string Infobar) EurDom3ConvertJournalSp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string OrigCurrCode,
			string InAcct,
			string InAcctUnit1,
			string InAcctUnit2,
			string InAcctUnit3,
			string InAcctUnit4,
			string AnaInAcct,
			string AnaInAcctUnit1,
			string AnaInAcctUnit2,
			string AnaInAcctUnit3,
			string AnaInAcctUnit4,
			string Infobar);
	}
}

