//PROJECT NAME: CSIProduct
//CLASS NAME: WcItemValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class WcItemValidFactory
    {
        public IWcItemValid Create(IApplicationDB appDB)
        {
            var _WcItemValid = new Production.WcItemValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iWcItemValidExt = timerfactory.Create<Production.IWcItemValid>(_WcItemValid);

            return iWcItemValidExt;
        }
    }
}
