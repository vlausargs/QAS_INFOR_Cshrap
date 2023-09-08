//PROJECT NAME: CSIMaterial
//CLASS NAME: ASNRecalcFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ASNRecalcFactory
    {
        public IASNRecalc Create(IApplicationDB appDB)
        {
            var _ASNRecalc = new ASNRecalc(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iASNRecalcExt = timerfactory.Create<IASNRecalc>(_ASNRecalc);

            return iASNRecalcExt;
        }
    }
}
