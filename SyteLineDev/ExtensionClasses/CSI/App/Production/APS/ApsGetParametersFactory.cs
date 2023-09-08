//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetParametersFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsGetParametersFactory
    {
        public IApsGetParameters Create(IApplicationDB appDB)
        {
            var _ApsGetParameters = new ApsGetParameters(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsGetParametersExt = timerfactory.Create<IApsGetParameters>(_ApsGetParameters);

            return iApsGetParametersExt;
        }
    }
}
