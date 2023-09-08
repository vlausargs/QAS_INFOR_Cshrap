//PROJECT NAME: Data
//CLASS NAME: IGainLossProcessVouchers.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGainLossProcessVouchers
	{
		(int? ReturnCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string rInfobar) GainLossProcessVouchersSp(
			int? pRelGl,
			int? pPostTrx,
			int? pDomInEuro,
			int? pCustVendInEuro,
			string pVendorVendNum,
			string pVendorBankCode,
			string pVendorCurrCode,
			string pTId,
			DateTime? pTransactionDate,
			string pCurrparmsCurrCode,
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
			string pTVchoffAcct = null,
			string pTVchoffAcctUnit1 = null,
			string pTVchoffAcctUnit2 = null,
			string pTVchoffAcctUnit3 = null,
			string pTVchoffAcctUnit4 = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string pAcct = null,
			string pAcctUnit1 = null,
			string pAcctUnit2 = null,
			string pAcctUnit3 = null,
			string pAcctUnit4 = null,
			string rInfobar = null);
	}
}

