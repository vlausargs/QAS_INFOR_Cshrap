//PROJECT NAME: CSIMaterial
//CLASS NAME: ProdMixCompareRoutingFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ProdMixCompareRoutingFactory
    {
        public IProdMixCompareRouting Create(IApplicationDB appDB)
        {
            var _ProdMixCompareRouting = new ProdMixCompareRouting(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iProdMixCompareRoutingExt = timerfactory.Create<IProdMixCompareRouting>(_ProdMixCompareRouting);

            return iProdMixCompareRoutingExt;
        }
    }
}
