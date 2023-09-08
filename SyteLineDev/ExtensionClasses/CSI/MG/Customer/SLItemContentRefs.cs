//PROJECT NAME: MG
//CLASS NAME: SLItemContentRefs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.MG.MGCore;
using CSI.Data.SQL;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLItemContentRefs")]
    public class SLItemContentRefs : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ItemContentRefsSp([Optional] string Item,
            [Optional] string RefType,
            [Optional] string RefNum,
            [Optional, DefaultParameterValue(0)] int? RefLine,
            [Optional, DefaultParameterValue(0)] int? RefRelease,
            [Optional] DateTime? EffectDate,
            [Optional] string FilterString)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                IBuildXMLFilterStringFactory iBuildXMLFilterStringFactory = new BuildXMLFilterStringFactory();
                IExecuteDynamicSQLFactory iExecuteDynamicSQLFactory = new ExecuteDynamicSQLFactory();
                IGetSiteDateFactory iGetSiteDateFactory = new GetSiteDateFactory();

                var iCLM_ItemContentRefsExt = new CLM_ItemContentRefsFactory(iBuildXMLFilterStringFactory, iExecuteDynamicSQLFactory, iGetSiteDateFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iCLM_ItemContentRefsExt.CLM_ItemContentRefsSp(Item,
                    RefType,
                    RefNum,
                    RefLine,
                    RefRelease,
                    EffectDate,
                    FilterString);

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
