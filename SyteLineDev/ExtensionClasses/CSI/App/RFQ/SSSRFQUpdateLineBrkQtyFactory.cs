//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQUpdateLineBrkQtyFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
    public class SSSRFQUpdateLineBrkQtyFactory
    {
        public ISSSRFQUpdateLineBrkQty Create(IApplicationDB appDB)
        {
            var _SSSRFQUpdateLineBrkQty = new RFQ.SSSRFQUpdateLineBrkQty(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRFQUpdateLineBrkQtyExt = timerfactory.Create<RFQ.ISSSRFQUpdateLineBrkQty>(_SSSRFQUpdateLineBrkQty);

            return iSSSRFQUpdateLineBrkQtyExt;
        }
    }
}
