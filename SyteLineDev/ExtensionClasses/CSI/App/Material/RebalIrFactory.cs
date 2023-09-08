//PROJECT NAME: CSIMaterial
//CLASS NAME: RebalIrFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class RebalIrFactory
    {
        public IRebalIr Create(IApplicationDB appDB)
        {
            var _RebalIr = new RebalIr(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRebalIrExt = timerfactory.Create<IRebalIr>(_RebalIr);

            return iRebalIrExt;
        }
    }
}
