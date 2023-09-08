//PROJECT NAME: CSIProduct
//CLASS NAME: SchedSetParametersFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class SchedSetParametersFactory
    {
        public ISchedSetParameters Create(IApplicationDB appDB)
        {
            var _SchedSetParameters = new SchedSetParameters(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSchedSetParametersExt = timerfactory.Create<ISchedSetParameters>(_SchedSetParameters);

            return iSchedSetParametersExt;
        }
    }
}
