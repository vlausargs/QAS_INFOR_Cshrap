//PROJECT NAME: CSIMaterial
//CLASS NAME: RebalItemQtyTrnFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class RebalItemQtyTrnFactory
    {
        public IRebalItemQtyTrn Create(IApplicationDB appDB)
        {
            var _RebalItemQtyTrn = new RebalItemQtyTrn(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRebalItemQtyTrnExt = timerfactory.Create<IRebalItemQtyTrn>(_RebalItemQtyTrn);

            return iRebalItemQtyTrnExt;
        }
    }
}
