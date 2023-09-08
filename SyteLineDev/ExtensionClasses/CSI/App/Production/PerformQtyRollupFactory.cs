//PROJECT NAME: CSIProduct
//CLASS NAME: PerformQtyRollupFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class PerformQtyRollupFactory
    {
        public IPerformQtyRollup Create(IApplicationDB appDB)
        {
            var _PerformQtyRollup = new PerformQtyRollup(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPerformQtyRollupExt = timerfactory.Create<IPerformQtyRollup>(_PerformQtyRollup);

            return iPerformQtyRollupExt;
        }
    }
}
