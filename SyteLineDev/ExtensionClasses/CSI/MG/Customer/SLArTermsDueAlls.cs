//PROJECT NAME: CustomerExt
//CLASS NAME: SLArTermsDueAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLArTermsDueAlls")]
    public class SLArTermsDueAlls : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ArTermsDueSp(string PSite_ref,
                                          string PCustNum,
                                          string PInvNum,
                                          int? PInvSeq)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_ArTermsDueExt = new CLM_ArTermsDueFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iCLM_ArTermsDueExt.CLM_ArTermsDueSp(PSite_ref,
                                                                   PCustNum,
                                                                   PInvNum,
                                                                   PInvSeq);

                return dt;
            }
        }
    }
}
