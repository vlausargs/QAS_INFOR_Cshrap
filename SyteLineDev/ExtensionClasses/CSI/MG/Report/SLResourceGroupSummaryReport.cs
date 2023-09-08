//PROJECT NAME: ReportExt
//CLASS NAME: SLResourceGroupSummaryReport.cs

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
    [IDOExtensionClass("SLResourceGroupSummaryReport")]
    public class SLResourceGroupSummaryReport : CSIExtensionClassBase
    {

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_ResourceGroupSummarySp([Optional] string ResourceStarting,
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

                ICloseSessionContextFactory iCloseSessionContextFactory = new CloseSessionContextFactory();
                IInitSessionContextFactory iInitSessionContextFactory = new InitSessionContextFactory();
                IGetIsolationLevelFactory iGetIsolationLevelFactory = new GetIsolationLevelFactory();

                var iRpt_ResourceGroupSummaryExt = new Rpt_ResourceGroupSummaryFactory(iCloseSessionContextFactory,
                    iInitSessionContextFactory, iGetIsolationLevelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iRpt_ResourceGroupSummaryExt.Rpt_ResourceGroupSummarySp(ResourceStarting,
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

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }
    }
}
