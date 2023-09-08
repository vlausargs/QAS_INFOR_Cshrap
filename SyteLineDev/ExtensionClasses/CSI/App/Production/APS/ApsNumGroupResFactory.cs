//PROJECT NAME: CSIAPS
//CLASS NAME: ApsNumGroupResFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsNumGroupResFactory
    {
        public IApsNumGroupRes Create(IApplicationDB appDB)
        {
            var _ApsNumGroupRes = new ApsNumGroupRes(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsNumGroupResExt = timerfactory.Create<IApsNumGroupRes>(_ApsNumGroupRes);

            return iApsNumGroupResExt;
        }
    }
}
