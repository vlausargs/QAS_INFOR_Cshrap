//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ChangeOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IRpt_ChangeOrder
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) Rpt_ChangeOrderSp(
            string pPoType = null,
            string pPoStat = null,
            string pPoitemStat = null,
            int? pRoundPlaces = null,
            string pPrintItemIV = null,
            int? pPrPoTxt = null,
            int? pPrPoBlnTxt = null,
            int? pPrPoLineTxt = null,
            string pPRPoChg = null,
            string pChgStat = null,
            int? pTransDomCurr = null,
            int? pPrintEuro = null,
            string pStartPoNum = null,
            string pEndPoNum = null,
            int? pStartPoLine = null,
            int? pEndPoLine = null,
            int? pStartPoRElease = null,
            int? pEndPoRelease = null,
            string pStartvendor = null,
            string pEndVendor = null,
            int? pShowExternal1 = null,
            int? pShowInternal1 = null,
            int? pPrintPOTable = null,
            int? pPrintpoitem = null,
            int? pPrintpo_bln = null,
            int? pPrintpochange = null,
            int? TaskId = null,
            int? pPrintManufacturerItem = 0,
            string ReviewPrint = null,
            string pSite = null,
            int? pPrintItemOverview = null,
            int? PrintDrawingNumber = 0,
            int? PrintDeliveryIncoTerms = 0,
            int? PrintEUCode = 0,
            int? PrintOriginCode = 0,
            int? PrintCommodityCode = 0,
            int? PrintHeaderOnAllPages = 0,
            int? PrintAuthorizationSignatures = 0);
    }
}

