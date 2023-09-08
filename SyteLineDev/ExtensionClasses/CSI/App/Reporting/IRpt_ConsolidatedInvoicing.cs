//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ConsolidatedInvoicing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ConsolidatedInvoicing
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ConsolidatedInvoicingSp(string pSessionIdChar = null,
		string pMode = "REPRINT",
		string pBegCustNum = null,
		string pEndCustNum = null,
		string pBegDoNum = null,
		string pEndDoNum = null,
		string pBegCustPo = null,
		string pEndCustPo = null,
		string pBegInvNum = null,
		string pEndInvNum = null,
		DateTime? pBegInvoiceDate = null,
		DateTime? pEndInvoiceDate = null,
		string pItemType = "CI",
		string pInvoiceOrCreditMemo = "I",
		string pConfigurationDetails = "E",
		string pInvoiceType = "RB",
		int? pEuroTotal = 0,
		int? pTranslateToDomestic = 0,
		int? PrintSerialNumbers = 1,
		int? pPlanningItemMaterials = 0,
		int? pLCR = 1,
		int? pOrderNumbers = 0,
		int? PrintOrderLineNotes = 0,
		int? PrintLineReleaseDescription = 0,
		int? PrintStandardOrderText = 0,
		int? PrintBillToNotes = 0,
		int? PrintInternalNotes = 1,
		int? PrintExternalNotes = 1,
		int? PrintItemOverview = 0,
		int? PrintDiscountAmt = 0,
		int? PrintLotNumbers = 1,
		decimal? pBegShipment = null,
		decimal? pEndShipment = null,
		string pSite = null,
		string BGUser = null);
	}
}

