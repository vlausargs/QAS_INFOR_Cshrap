//PROJECT NAME: ReportExt
//CLASS NAME: SLToBeShippedValueReport.cs

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
    [IDOExtensionClass("SLToBeShippedValueReport")]
    public class SLToBeShippedValueReport : CSIExtensionClassBase
    {

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_ToBeShippedValueSp([Optional] string pCoType,
            [Optional] string pCoStat,
            [Optional] string pCoitemStat,
            [Optional] int? pTransDomCurr,
            [Optional] int? pSortByCurrency,
            [Optional] string pCreditHold,
            [Optional] int? pDispSubTots,
            [Optional] string pStartCoNum,
            [Optional] string pEndCoNum,
            [Optional] string pStartCustNum,
            [Optional] string pEndCustNum,
            [Optional] DateTime? pStartOrderDate,
            [Optional] DateTime? pEndOrderDate,
            [Optional] string pStartCustPo,
            [Optional] string pEndCustPo,
            [Optional] string pStartItem,
            [Optional] string pEndItem,
            [Optional] string pStartCustItem,
            [Optional] string pEndCustItem,
            [Optional] DateTime? pStartDueDate,
            [Optional] DateTime? pEndDueDate,
            [Optional] DateTime? pStartShipDate,
            [Optional] DateTime? pEndShipDate,
            [Optional] string pStartCurrCode,
            [Optional] string pEndCurrCode,
            [Optional, DefaultParameterValue(0)] int? PrintCost,
            [Optional, DefaultParameterValue(0)] int? PrintPrice,
            [Optional] int? DisplayHeader,
            [Optional] string BGSessionId,
            [Optional] int? TaskId,
            [Optional] string pSite,
            [Optional] string BGUser)
        {
            var iRpt_ToBeShippedValueExt = new Rpt_ToBeShippedValueFactory().Create(this, true);

            var result = iRpt_ToBeShippedValueExt.Rpt_ToBeShippedValueSp(pCoType,
                pCoStat,
                pCoitemStat,
                pTransDomCurr,
                pSortByCurrency,
                pCreditHold,
                pDispSubTots,
                pStartCoNum,
                pEndCoNum,
                pStartCustNum,
                pEndCustNum,
                pStartOrderDate,
                pEndOrderDate,
                pStartCustPo,
                pEndCustPo,
                pStartItem,
                pEndItem,
                pStartCustItem,
                pEndCustItem,
                pStartDueDate,
                pEndDueDate,
                pStartShipDate,
                pEndShipDate,
                pStartCurrCode,
                pEndCurrCode,
                PrintCost,
                PrintPrice,
                DisplayHeader,
                BGSessionId,
                TaskId,
                pSite,
                BGUser);

            if (result.ReturnCode != 0)
            {
                throw new Exception();
            }

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
