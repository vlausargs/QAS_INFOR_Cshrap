//PROJECT NAME: CSICustomer
//CLASS NAME: EstimateLinesCheckForRecalcFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EstimateLinesCheckForRecalcFactory
    {
        public IEstimateLinesCheckForRecalc Create(IApplicationDB appDB)
        {
            var _EstimateLinesCheckForRecalc = new EstimateLinesCheckForRecalc(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEstimateLinesCheckForRecalcExt = timerfactory.Create<IEstimateLinesCheckForRecalc>(_EstimateLinesCheckForRecalc);

            return iEstimateLinesCheckForRecalcExt;
        }
    }
}
