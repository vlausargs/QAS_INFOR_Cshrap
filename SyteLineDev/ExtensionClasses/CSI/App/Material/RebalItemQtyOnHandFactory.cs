//PROJECT NAME: CSIMaterial
//CLASS NAME: RebalItemQtyOnHandFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class RebalItemQtyOnHandFactory
    {
        public IRebalItemQtyOnHand Create(IApplicationDB appDB)
        {
            var _RebalItemQtyOnHand = new RebalItemQtyOnHand(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRebalItemQtyOnHandExt = timerfactory.Create<IRebalItemQtyOnHand>(_RebalItemQtyOnHand);

            return iRebalItemQtyOnHandExt;
        }
    }
}
