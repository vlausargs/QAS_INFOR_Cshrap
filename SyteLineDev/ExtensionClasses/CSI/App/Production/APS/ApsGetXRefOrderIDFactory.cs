//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetXRefOrderIDFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsGetXRefOrderIDFactory
    {
        public IApsGetXRefOrderID Create(IApplicationDB appDB)
        {
            var _ApsGetXRefOrderID = new ApsGetXRefOrderID(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsGetXRefOrderIDExt = timerfactory.Create<IApsGetXRefOrderID>(_ApsGetXRefOrderID);

            return iApsGetXRefOrderIDExt;
        }
    }
}
