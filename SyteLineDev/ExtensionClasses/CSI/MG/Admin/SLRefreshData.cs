//PROJECT NAME: AdminExt
//CLASS NAME: SLRefreshData.cs

using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;


namespace CSI.MG.Admin
{
    [IDOExtensionClass("SLRefreshData")]
    public class SLRefreshData : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PreRefresh(ref string PreRefreshData, bool isProduction = false, bool isMingleUserSyncActive = false)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var Severity = 0;

                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRefreshWrapperExt = new RefreshWrapperFactory().Create(appDb, isProduction, isMingleUserSyncActive);

                (Severity, PreRefreshData) = iRefreshWrapperExt.PreRefresh();

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PostRefresh(string PreRefreshData, bool isProduction = false, bool isMingleUserSyncActive = false)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRefreshWrapperExt = new RefreshWrapperFactory().Create(appDb, isProduction, isMingleUserSyncActive);

                int Severity = iRefreshWrapperExt.PostRefresh(PreRefreshData);

                return Severity;
            }
        }
    }
}
