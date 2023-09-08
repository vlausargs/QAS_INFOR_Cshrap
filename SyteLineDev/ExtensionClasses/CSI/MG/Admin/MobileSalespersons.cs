//PROJECT NAME: AdminExt
//CLASS NAME: MobileSalespersons.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("MobileSalespersons")]
    public class MobileSalespersons : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_MobileSalespersonSp(int? Position)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_MobileSalespersonExt = new CLM_MobileSalespersonFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iCLM_MobileSalespersonExt.CLM_MobileSalespersonSp(Position);

                return dt;
            }
        }
    }
}
