//PROJECT NAME: CSIProduct
//CLASS NAME: WcUMValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class WcUMValidFactory
    {
        public IWcUMValid Create(IApplicationDB appDB)
        {
            var _WcUMValid = new Production.WcUMValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iWcUMValidExt = timerfactory.Create<Production.IWcUMValid>(_WcUMValid);

            return iWcUMValidExt;
        }
    }
}
