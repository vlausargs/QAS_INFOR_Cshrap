//PROJECT NAME: CSIAPS
//CLASS NAME: ApsJobOrderExistsFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsJobOrderExistsFactory
    {
        public IApsJobOrderExists Create(IApplicationDB appDB)
        {
            var _ApsJobOrderExists = new ApsJobOrderExists(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsJobOrderExistsExt = timerfactory.Create<IApsJobOrderExists>(_ApsJobOrderExists);

            return iApsJobOrderExistsExt;
        }
    }
}
