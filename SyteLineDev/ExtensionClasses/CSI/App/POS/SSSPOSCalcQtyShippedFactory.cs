//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSCalcQtyShippedFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSCalcQtyShippedFactory
    {
        public ISSSPOSCalcQtyShipped Create(IApplicationDB appDB)
        {
            var _SSSPOSCalcQtyShipped = new POS.SSSPOSCalcQtyShipped(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSCalcQtyShippedExt = timerfactory.Create<POS.ISSSPOSCalcQtyShipped>(_SSSPOSCalcQtyShipped);

            return iSSSPOSCalcQtyShippedExt;
        }
    }
}
