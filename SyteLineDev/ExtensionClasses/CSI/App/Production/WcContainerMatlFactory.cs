//PROJECT NAME: CSIProduct
//CLASS NAME: WcContainerMatlFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class WcContainerMatlFactory
    {
        public IWcContainerMatl Create(IApplicationDB appDB)
        {
            var _WcContainerMatl = new Production.WcContainerMatl(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iWcContainerMatlExt = timerfactory.Create<Production.IWcContainerMatl>(_WcContainerMatl);

            return iWcContainerMatlExt;
        }
    }
}
