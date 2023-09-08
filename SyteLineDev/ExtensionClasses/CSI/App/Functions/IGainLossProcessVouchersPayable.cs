//PROJECT NAME: Data
//CLASS NAME: IGainLossProcessVouchersPayable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGainLossProcessVouchersPayable
	{
		(int? ReturnCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string rInfobar) GainLossProcessVouchersPayableSp(
			int? pRelGl,
			int? pPostTrx,
			int? pTDomInEuro,
			int? pTCustvendInEuro,
			string pVendorVendNum,
			string pVendorBankCode,
			string pVendorCurrCode,
			string pTId,
			DateTime? pTTransDate,
			string pCurrparmsCurrCode,
			string pTLossAcct = null,
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
			string pTApoffAcct = null,
			string pTApoffAcctUnit1 = null,
			string pTApoffAcctUnit2 = null,
			string pTApoffAcctUnit3 = null,
			string pTApoffAcctUnit4 = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string rInfobar = null);
	}
}

