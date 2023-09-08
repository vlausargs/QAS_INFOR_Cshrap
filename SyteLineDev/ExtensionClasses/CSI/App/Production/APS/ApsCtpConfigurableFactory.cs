//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpConfigurableFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpConfigurableFactory
    {
        public IApsCtpConfigurable Create(IApplicationDB appDB)
        {
            var _ApsCtpConfigurable = new ApsCtpConfigurable(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpConfigurableExt = timerfactory.Create<IApsCtpConfigurable>(_ApsCtpConfigurable);

            return iApsCtpConfigurableExt;
        }
    }
}
