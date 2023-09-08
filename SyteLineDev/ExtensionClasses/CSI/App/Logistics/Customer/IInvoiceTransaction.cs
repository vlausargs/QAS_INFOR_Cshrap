//PROJECT NAME: Logistics
//CLASS NAME: IInvoiceTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvoiceTransaction
	{
		(int? ReturnCode, string Infobar) InvoiceTransactionSp(string pSessionIDChar = null,
		int? pCallingProgram = null,
		string pStartingCustNum = null,
		string pEndingCustNum = null,
		string pStartingInvNumber = null,
		string pEndingInvNumber = null,
		DateTime? pStartingInvDate = null,
		DateTime? pEndingInvDate = null,
		DateTime? pStartingDueDate = null,
		DateTime? pEndingDueDate = null,
		string pInvoice = null,
		string pDebitMemo = null,
		string pCreditMemo = null,
		int? pDisplayTotals = null,
		int? pSortByInvoice = null,
		int? pDisplayHeader = null,
		string pSite = null,
		string pToSite = null,
		string pStartBuilderInvNum = null,
		string pEndBuilderInvNum = null,
		int? pSeperateDRandCRtot = null,
		string Infobar = null);
	}
}

