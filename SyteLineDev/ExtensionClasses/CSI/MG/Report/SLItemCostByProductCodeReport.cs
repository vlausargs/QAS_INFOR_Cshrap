//PROJECT NAME: ReportExt
//CLASS NAME: SLItemCostByProductCodeReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.MG.MGCore;
using CSI.Data.Functions;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLItemCostByProductCodeReport")]
    public class SLItemCostByProductCodeReport : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_ItemCostbyProductCodeSp([Optional] string StartProdCode,
            [Optional] string EndProdCode,
            [Optional] string StartItem,
            [Optional] string EndItem,
            [Optional] string FromWarehouse,
            [Optional] string ToWarehouse,
            [Optional] string MatlStat,
            [Optional] string MatlType,
            [Optional] string Source,
            [Optional] string Stocked,
            [Optional] string ABCCode,
            [Optional] int? PrintZeroQty,
            [Optional] int? PrintCostDet,
            [Optional] int? DisplayHeader,
            [Optional] int? CostItemAtWhse,
            [Optional] string pSite)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                ICloseSessionContextFactory closeSessionContextFactory = new CloseSessionContextFactory();
                IInitSessionContextFactory initSessionContextFactory = new InitSessionContextFactory();
                IGetIsolationLevelFactory getIsolationLevelFactory = new GetIsolationLevelFactory();
                IGetSiteDateFactory getSiteDateFactory = new GetSiteDateFactory();
                var iRpt_ItemCostbyProductCodeExt = new Rpt_ItemCostbyProductCodeFactory(
                    closeSessionContextFactory,
                    initSessionContextFactory,
                    getIsolationLevelFactory,
                    getSiteDateFactory).Create(appDb,
                        bunchedLoadCollection,
                        mgInvoker,
                        new CSI.Data.SQL.SQLParameterProvider(),
                        true, this);

                var result = iRpt_ItemCostbyProductCodeExt.Rpt_ItemCostbyProductCodeSp(StartProdCode,
                    EndProdCode,
                    StartItem,
                    EndItem,
                    FromWarehouse,
                    ToWarehouse,
                    MatlStat,
                    MatlType,
                    Source,
                    Stocked,
                    ABCCode,
                    PrintZeroQty,
                    PrintCostDet,
                    DisplayHeader,
                    CostItemAtWhse,
                    pSite);

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
}
