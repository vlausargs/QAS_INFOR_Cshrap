//PROJECT NAME: MG
//CLASS NAME: SLResourceSummaryReport.cs

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
    [IDOExtensionClass("SLResourceSummaryReport")]
    public class SLResourceSummaryReport : CSIExtensionClassBase
    {

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_ResourceSummarySp([Optional] string ResourceStarting,
            [Optional] string ResourceEnding,
            [Optional] string ResourceGroupStarting,
            [Optional] string ResourceGroupEnding,
            [Optional] string ResourceTypeStarting,
            [Optional] string ResourceTypeEnding,
            [Optional] decimal? PercentLoadStarting,
            [Optional] decimal? PercentLoadEnding,
            [Optional] int? DisplayHeader,
            [Optional] int? ALTNO,
            [Optional] string pSite)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                ICloseSessionContextFactory CloseSessionContextFactory = new CloseSessionContextFactory();
                IInitSessionContextFactory InitSessionContextFactory = new InitSessionContextFactory();
                IGetIsolationLevelFactory GetIsolationLevelFactory = new GetIsolationLevelFactory();

                var iRpt_ResourceSummaryExt = new Rpt_ResourceSummaryFactory(CloseSessionContextFactory, InitSessionContextFactory, GetIsolationLevelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iRpt_ResourceSummaryExt.Rpt_ResourceSummarySp(ResourceStarting,
                    ResourceEnding,
                    ResourceGroupStarting,
                    ResourceGroupEnding,
                    ResourceTypeStarting,
                    ResourceTypeEnding,
                    PercentLoadStarting,
                    PercentLoadEnding,
                    DisplayHeader,
                    ALTNO,
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
