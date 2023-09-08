//PROJECT NAME: AdminExt
//CLASS NAME: SLTenantDataCleanup.cs

using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Collections.Generic;
using System.IO;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("SLTenantDataCleanup")]
    public class SLTenantDataCleanup : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CleanupData(string DatasetsJson, ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var Severity = 0;

                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var tenantDataCleanup = new TenantDataCleanupFactory().Create(appDb);

                (Severity, Infobar) = tenantDataCleanup.CleanupDataset(DatasetsJson);

                return Severity;
            }
        }

    }
}
