//PROJECT NAME: Reporting
//CLASS NAME: IRpt_OrderInvoicingCreditMemo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_OrderInvoicingCreditMemo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderInvoicingCreditMemoSp(string pSessionIDChar = null,
		string InvType = "RBP",
		string Mode = "REPRINT",
		string StartInvNum = null,
		string EndInvNum = null,
		string StartOrderNum = null,
		string EndOrderNum = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string StartCustNum = null,
		string EndCustNum = null,
		string PrintItemCustomerItem = "CI",
		int? TransToDomCurr = 0,
		string InvCred = "I",
		int? PrintSerialNumbers = 1,
		int? PrintPlanItemMaterial = 0,
		string PrintConfigurationDetail = "N",
		int? PrintEuro = 0,
		int? PrintCustomerNotes = 1,
		int? PrintOrderNotes = 1,
		int? PrintOrderLineNotes = 1,
		int? PrintOrderBlanketLineNotes = 1,
		int? PrintProgressiveBillingNotes = 0,
		int? PrintInternalNotes = 1,
		int? PrintExternalNotes = 1,
		int? PrintItemOverview = 0,
		int? DisplayHeader = 1,
		int? PrintLineReleaseDescription = 1,
		int? PrintStandardOrderText = 1,
		int? PrintBillToNotes = 1,
		string LangCode = null,
		string BGSessionId = null,
		int? PrintDiscountAmt = 0,
		int? PrintLotNumbers = 1,
		string pSite = null,
		string CalledFrom = null,
		Guid? InvoicBuilderProcessID = null,
		string StartBuilderInvNum = null,
		string EndBuilderInvNum = null,
		int? pPrintDrawingNumber = 0,
		int? pPrintDeliveryIncoTerms = 0,
		int? pPrintTax = 0,
		int? pPrintEUDetails = 0,
		int? pPrintCurrCode = 0,
		int? pPrintHeaderOnAllPages = 0);
	}
}

