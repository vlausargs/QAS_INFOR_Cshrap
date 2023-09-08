//PROJECT NAME: ReportExt
//CLASS NAME: SLGetItemContentReport.cs

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

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLGetItemContentReport")]
    public class SLGetItemContentReport : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_GetItemContentSp([Optional] string Item,
            [Optional] string RefType,
            [Optional] string RefNum,
            [Optional] int? RefLine,
            [Optional] int? RefRelease,
            [Optional] string pSite,
            [Optional] string InvNum,
            [Optional] int? InvLine,
            [Optional] int? InvSeq)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                ICloseSessionContextFactory iCloseSessionContextFactory = new CloseSessionContextFactory();
                IInitSessionContextFactory iInitSessionContextFactory = new InitSessionContextFactory();

                var iRpt_GetItemContentExt = new Rpt_GetItemContentFactory(iCloseSessionContextFactory, iInitSessionContextFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true, this);

                var result = iRpt_GetItemContentExt.Rpt_GetItemContentSp(Item,
                    RefType,
                    RefNum,
                    RefLine,
                    RefRelease,
                    pSite,
                    InvNum,
                    InvLine,
                    InvSeq);

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
