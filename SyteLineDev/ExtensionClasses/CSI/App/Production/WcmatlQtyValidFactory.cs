//PROJECT NAME: CSIProduct
//CLASS NAME: WcmatlQtyValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class WcmatlQtyValidFactory
    {
        public IWcmatlQtyValid Create(IApplicationDB appDB)
        {
            var _WcmatlQtyValid = new Production.WcmatlQtyValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iWcmatlQtyValidExt = timerfactory.Create<Production.IWcmatlQtyValid>(_WcmatlQtyValid);

            return iWcmatlQtyValidExt;
        }
    }
}
