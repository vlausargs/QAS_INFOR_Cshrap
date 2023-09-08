//PROJECT NAME: Finance
//CLASS NAME: IArFilpckOpenInvoices.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArFilpckOpenInvoices
	{
		(int? ReturnCode,
			DateTime? TInvDate,
			DateTime? TDueDate,
			decimal? TOrig,
			decimal? TDisc,
			decimal? TBal,
			string Infobar) ArFilpckOpenInvoicesSp(
			string PCurrCode,
			string PParmsAllCurrCode,
			int? PSameCurr,
			int? PDomCust,
			int? PDomOfEuro,
			string ArparmsAllDiscAcct,
			string ArparmsAllDiscAcctUnit1,
			string ArparmsAllDiscAcctUnit2,
			string ArparmsAllDiscAcctUnit3,
			string ArparmsAllDiscAcctUnit4,
			DateTime? ArpmtRecptDate,
			int? ArpmtCheckNum,
			string ArpmtType,
			string ArpmtBankCode,
			string ArpmtCustNum,
			decimal? ArpmtExchRate,
			decimal? ArpmtPaymentExchRate,
			string TransactionCurrCode,
			Guid? PArtranAllRowPointer,
			int? PFirstOfArtran,
			int? PLastOfArtran,
			string InvoiceSite,
			string BaseSite,
			DateTime? TInvDate,
			DateTime? TDueDate,
			decimal? TOrig,
			decimal? TDisc,
			decimal? TBal,
			string Infobar,
			Guid? PProcessId,
			decimal? OpenPaymentAmount = 0);
	}
}

