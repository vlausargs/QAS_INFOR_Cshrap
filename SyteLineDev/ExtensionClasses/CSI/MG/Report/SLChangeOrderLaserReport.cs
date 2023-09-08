//PROJECT NAME: ReportExt
//CLASS NAME: SLChangeOrderLaserReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLChangeOrderLaserReport")]
    public class SLChangeOrderLaserReport : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ChangeOrderSp([Optional] string pPoType,
			[Optional] string pPoStat,
			[Optional] string pPoitemStat,
			[Optional] int? pRoundPlaces,
			[Optional] string pPrintItemIV,
			[Optional] int? pPrPoTxt,
			[Optional] int? pPrPoBlnTxt,
			[Optional] int? pPrPoLineTxt,
			[Optional] string pPRPoChg,
			[Optional] string pChgStat,
			[Optional] int? pTransDomCurr,
			[Optional] int? pPrintEuro,
			[Optional] string pStartPoNum,
			[Optional] string pEndPoNum,
			[Optional] int? pStartPoLine,
			[Optional] int? pEndPoLine,
			[Optional] int? pStartPoRElease,
			[Optional] int? pEndPoRelease,
			[Optional] string pStartvendor,
			[Optional] string pEndVendor,
			[Optional] int? pShowExternal1,
			[Optional] int? pShowInternal1,
			[Optional] int? pPrintPOTable,
			[Optional] int? pPrintpoitem,
			[Optional] int? pPrintpo_bln,
			[Optional] int? pPrintpochange,
			[Optional] int? TaskId,
			[Optional, DefaultParameterValue(0)] int? pPrintManufacturerItem,
			[Optional] string ReviewPrint,
			[Optional] string pSite,
			[Optional] int? pPrintItemOverview,
			[Optional, DefaultParameterValue(0)] int? PrintDrawingNumber,
			[Optional, DefaultParameterValue(0)] int? PrintDeliveryIncoTerms,
			[Optional, DefaultParameterValue(0)] int? PrintEUCode,
			[Optional, DefaultParameterValue(0)] int? PrintOriginCode,
			[Optional, DefaultParameterValue(0)] int? PrintCommodityCode,
			[Optional, DefaultParameterValue(0)] int? PrintHeaderOnAllPages,
			[Optional, DefaultParameterValue(0)] int? PrintAuthorizationSignatures)
		{
			var iRpt_ChangeOrderExt = new Rpt_ChangeOrderFactory().Create(this, true);
			
			var result = iRpt_ChangeOrderExt.Rpt_ChangeOrderSp(pPoType,
				pPoStat,
				pPoitemStat,
				pRoundPlaces,
				pPrintItemIV,
				pPrPoTxt,
				pPrPoBlnTxt,
				pPrPoLineTxt,
				pPRPoChg,
				pChgStat,
				pTransDomCurr,
				pPrintEuro,
				pStartPoNum,
				pEndPoNum,
				pStartPoLine,
				pEndPoLine,
				pStartPoRElease,
				pEndPoRelease,
				pStartvendor,
				pEndVendor,
				pShowExternal1,
				pShowInternal1,
				pPrintPOTable,
				pPrintpoitem,
				pPrintpo_bln,
				pPrintpochange,
				TaskId,
				pPrintManufacturerItem,
				ReviewPrint,
				pSite,
				pPrintItemOverview,
				PrintDrawingNumber,
				PrintDeliveryIncoTerms,
				PrintEUCode,
				PrintOriginCode,
				PrintCommodityCode,
				PrintHeaderOnAllPages,
				PrintAuthorizationSignatures);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

    }
}
