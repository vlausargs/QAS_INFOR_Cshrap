//PROJECT NAME: APSExt
//CLASS NAME: SLInvProfiles.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLInvProfiles")]
    public class SLInvProfiles : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ApsGetInvProfileSp(short? PAltNo,
                                                string PItem,
                                                DateTime? PStartDate,
                                                DateTime? PEndDate,
                                                byte? PFcstAsRqmtFg,
                                                string FilterString)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_ApsGetInvProfileExt = new CLM_ApsGetInvProfileFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iCLM_ApsGetInvProfileExt.CLM_ApsGetInvProfileSp(PAltNo,
                                                                               PItem,
                                                                               PStartDate,
                                                                               PEndDate,
                                                                               PFcstAsRqmtFg,
                                                                               FilterString);

                return dt;
            }
        }
    }
}
