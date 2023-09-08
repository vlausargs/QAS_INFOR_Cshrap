//PROJECT NAME: Logistics
//CLASS NAME: AREndFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class AREndFactory
    {
        public IAREnd Create(IApplicationDB appDB)
        {
            var _AREnd = new Finance.AR.AREnd(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAREndExt = timerfactory.Create<Finance.AR.IAREnd>(_AREnd);

            return iAREndExt;
        }
    }
}
