//PROJECT NAME: ReportExt
//CLASS NAME: SLPurchaseOrderStatusReport.cs

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
    [IDOExtensionClass("SLPurchaseOrderStatusReport")]
    public class SLPurchaseOrderStatusReport : ExtensionClassBase
    {

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_PurchaseOrderStatusSp([Optional] string pPoType,
        [Optional] string pPoitemStat,
        [Optional] string pPoStat,
        [Optional] string pSortBy,
        [Optional] int? pIncludeGrn,
        [Optional] int? pTransDomCurr,
        [Optional] string pStartPoNum,
        [Optional] string pEndPoNum,
        [Optional] string pStartVendor,
        [Optional] string pEndVendor,
        [Optional] DateTime? pStartOrderDate,
        [Optional] DateTime? pEndOrderDate,
        [Optional] string pStartVendOrder,
        [Optional] string pEndVendOrder,
        [Optional] string pStartItem,
        [Optional] string pEndItem,
        [Optional] string pStartVendItem,
        [Optional] string pEndVendItem,
        [Optional] DateTime? pStartDueDate,
        [Optional] DateTime? pEndDueDate,
        [Optional] DateTime? pStartRecvDate,
        [Optional] DateTime? pEndRecvDate,
        [Optional] DateTime? pStartRelDate,
        [Optional] DateTime? pEndRelDate,
        [Optional] string pStartWhse,
        [Optional] string pEndWhse,
        [Optional] int? pStartOrderDateOffset,
        [Optional] int? pEndOrderDateOffset,
        [Optional] int? pStartDueDateOffset,
        [Optional] int? pEndDueDateOffset,
        [Optional] int? pStartRecvDateOffset,
        [Optional] int? pEndRecvDateOffset,
        [Optional] int? pStartRelDateOffset,
        [Optional] int? pEndRelDateOffset,
        [Optional, DefaultParameterValue(0)] int? PrintCost,
        [Optional] int? DisplayHeader,
        [Optional] string BGSessionId,
        [Optional] int? TaskId,
        [Optional] string pSite)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iRpt_PurchaseOrderStatusExt = new Rpt_PurchaseOrderStatusFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iRpt_PurchaseOrderStatusExt.Rpt_PurchaseOrderStatusSp(pPoType,
                pPoitemStat,
                pPoStat,
                pSortBy,
                pIncludeGrn,
                pTransDomCurr,
                pStartPoNum,
                pEndPoNum,
                pStartVendor,
                pEndVendor,
                pStartOrderDate,
                pEndOrderDate,
                pStartVendOrder,
                pEndVendOrder,
                pStartItem,
                pEndItem,
                pStartVendItem,
                pEndVendItem,
                pStartDueDate,
                pEndDueDate,
                pStartRecvDate,
                pEndRecvDate,
                pStartRelDate,
                pEndRelDate,
                pStartWhse,
                pEndWhse,
                pStartOrderDateOffset,
                pEndOrderDateOffset,
                pStartDueDateOffset,
                pEndDueDateOffset,
                pStartRecvDateOffset,
                pEndRecvDateOffset,
                pStartRelDateOffset,
                pEndRelDateOffset,
                PrintCost,
                DisplayHeader,
                BGSessionId,
                TaskId,
                pSite);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }
    }
}