//PROJECT NAME: Data
//CLASS NAME: IGainLoss2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGainLoss2
	{
		(int? ReturnCode,
			string rInfobar) GainLoss2Sp(
			int? pRelGl,
			int? pPostTrx,
			DateTime? pTTransDate,
			string pCurrparmsCurrCode,
			int? pTDomInEuro,
			int? pParmsAnalyticalLedger,
			string pCurrencyCurrCode,
			int? pCurrencyPlaces,
			string pTLossAcct,
			string pTLossAcctUnit1 = null,
			string pTLossAcctUnit2 = null,
			string pTLossAcctUnit3 = null,
			string pTLossAcctUnit4 = null,
			string pTGainAcct = null,
			string pTGainAcctUnit1 = null,
			string pTGainAcctUnit2 = null,
			string pTGainAcctUnit3 = null,
			string pTGainAcctUnit4 = null,
			string pTUngainAcct = null,
			string pTUngainAcctUnit1 = null,
			string pTUngainAcctUnit2 = null,
			string pTUngainAcctUnit3 = null,
			string pTUngainAcctUnit4 = null,
			string pTUnlossAcct = null,
			string pTUnlossAcctUnit1 = null,
			string pTUnlossAcctUnit2 = null,
			string pTUnlossAcctUnit3 = null,
			string pTUnlossAcctUnit4 = null,
			string pTVoucherAcct = null,
			string pTVoucherAcctUnit1 = null,
			string pTVoucherAcctUnit2 = null,
			string pTVoucherAcctUnit3 = null,
			string pTVoucherAcctUnit4 = null,
			string pTVchoffAcct = null,
			string pTVchoffAcctUnit1 = null,
			string pTVchoffAcctUnit2 = null,
			string pTVchoffAcctUnit3 = null,
			string pTVchoffAcctUnit4 = null,
			string rInfobar = null);
	}
}

