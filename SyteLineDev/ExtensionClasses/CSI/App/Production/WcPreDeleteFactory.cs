//PROJECT NAME: CSIProduct
//CLASS NAME: WcPreDeleteFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class WcPreDeleteFactory
    {
        public IWcPreDelete Create(IApplicationDB appDB)
        {
            var _WcPreDelete = new Production.WcPreDelete(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iWcPreDeleteExt = timerfactory.Create<Production.IWcPreDelete>(_WcPreDelete);

            return iWcPreDeleteExt;
        }
    }
}
