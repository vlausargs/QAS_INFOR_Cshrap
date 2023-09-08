//PROJECT NAME: Data
//CLASS NAME: IGainLoss1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGainLoss1
	{
		(int? ReturnCode,
			string rInfobar) GainLoss1Sp(
			int? pRelGl,
			int? pPostTrx,
			DateTime? pTTransDate,
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
			string pTUnGainAcct = null,
			string pTUnGainAcctUnit1 = null,
			string pTUnGainAcctUnit2 = null,
			string pTUnGainAcctUnit3 = null,
			string pTUnGainAcctUnit4 = null,
			string pTUnlossAcct = null,
			string pTUnlossAcctUnit1 = null,
			string pTUnlossAcctUnit2 = null,
			string pTUnlossAcctUnit3 = null,
			string pTUnlossAcctUnit4 = null,
			string pTArOffAcct = null,
			string pTArOffAcctUnit1 = null,
			string pTArOffAcctUnit2 = null,
			string pTArOffAcctUnit3 = null,
			string pTArOffAcctUnit4 = null,
			string rInfobar = null);
	}
}

