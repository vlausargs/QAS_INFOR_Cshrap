//PROJECT NAME: CSIAdmin
//CLASS NAME: UnlockUserFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class UnlockUserFactory
    {
        public IUnlockUser Create(IApplicationDB appDB)
        {
            var _UnlockUser = new UnlockUser(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iUnlockUserExt = timerfactory.Create<IUnlockUser>(_UnlockUser);

            return iUnlockUserExt;
        }
    }
}