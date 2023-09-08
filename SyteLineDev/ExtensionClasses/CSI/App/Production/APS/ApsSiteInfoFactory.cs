//PROJECT NAME: Production
//CLASS NAME: ApsSiteInFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsSiteInFactory
    {
        public IApsSiteIn Create(IApplicationDB appDB)
        {
            var _ApsSiteIn = new Production.APS.ApsSiteIn(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsSiteInExt = timerfactory.Create<Production.APS.IApsSiteIn>(_ApsSiteIn);

            return iApsSiteInExt;
        }
    }
}
