//PROJECT NAME: CSIProduct
//CLASS NAME: ApsSyncDeferSetVarsFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class ApsSyncDeferSetVarsFactory
    {
        public IApsSyncDeferSetVars Create(IApplicationDB appDB)
        {
            var _ApsSyncDeferSetVars = new ApsSyncDeferSetVars(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsSyncDeferSetVarsExt = timerfactory.Create<IApsSyncDeferSetVars>(_ApsSyncDeferSetVars);

            return iApsSyncDeferSetVarsExt;
        }
    }
}
