//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PurchaseOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PurchaseOrder
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchaseOrderSp(string pPoType = null,
		string pPoStat = null,
		string pPoitemStat = null,
		int? pPostFlag = null,
		DateTime? pPODate = null,
		int? pRoundPlaces = null,
		string pPrintItemVI = null,
		int? pPrPoTxt = null,
		int? pPrPoBlnNote = null,
		int? pPrPoLineNote = null,
		int? pPrPoBlnDesc = null,
		int? pPrPoLineDesc = null,
		int? pPrPONote = null,
		int? pTransDomCurr = null,
		int? pPrintEuro = null,
		string pStartPoNum = null,
		string pEndPoNum = null,
		int? pStartPoLine = null,
		int? pEndPoLine = null,
		int? pStartPoRElease = null,
		int? pEndPoRelease = null,
		DateTime? pStartDueDate = null,
		DateTime? pEndDueDate = null,
		string pStartvendor = null,
		string pEndVendor = null,
		DateTime? pStartorderDate = null,
		DateTime? pEndOrderDate = null,
		string pReviewPrint = null,
		int? pPODateOffset = null,
		int? pStartDueDateOffset = null,
		int? pEndDueDateOffset = null,
		int? pStartOrderDateOffset = null,
		int? pEndOrderDateOffset = null,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? IncludeBlnsWOReleases = 0,
		string FmSessionId = null,
		int? pPrintManufacturerItem = 0,
		decimal? UserID = null,
		int? TaskID = null,
		string BGSessionId = null,
		string pSite = null,
		int? pPrintDrawingNumber = 0,
		int? pPrintDeliveryIncoTerms = 0,
		int? pPrintEUCode = 0,
		int? pPrintOriginCode = 0,
		int? pPrintCommodityCode = 0,
		int? pPrintHeaderOnAllPages = 0,
		int? pPrintAuthorizationSignatures = 0,
		int? pPrintItemOverview = 0,
		int? ProfileExists = null,
		int? UseProfile = null,
		string Method = null,
		string Destination = null);
	}
}

