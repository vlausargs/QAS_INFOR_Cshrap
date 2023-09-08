//PROJECT NAME: MaterialExt
//CLASS NAME: Homepage_ProjItemExceptions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLHomepageItemExceptionsViews")]
    public class SLHomepageItemExceptionsViews : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_ProjItemExceptionsSp(string ProjMgr)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_ProjItemExceptionsExt = new Homepage_ProjItemExceptionsFactory().Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_ProjItemExceptionsExt.Homepage_ProjItemExceptionsSp(ProjMgr);

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