//PROJECT NAME: CSIAPS
//CLASS NAME: ApsSetParametersFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsSetParametersFactory
    {
        public IApsSetParameters Create(IApplicationDB appDB)
        {
            var _ApsSetParameters = new ApsSetParameters(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsSetParametersExt = timerfactory.Create<IApsSetParameters>(_ApsSetParameters);

            return iApsSetParametersExt;
        }
    }
}
