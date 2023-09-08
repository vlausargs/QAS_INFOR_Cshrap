//PROJECT NAME: CSICustomer
//CLASS NAME: CoPackingSlipQtyConvFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CoPackingSlipQtyConvFactory
    {
        public ICoPackingSlipQtyConv Create(IApplicationDB appDB)
        {
            var _CoPackingSlipQtyConv = new CoPackingSlipQtyConv(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoPackingSlipQtyConvExt = timerfactory.Create<ICoPackingSlipQtyConv>(_CoPackingSlipQtyConv);

            return iCoPackingSlipQtyConvExt;
        }
    }
}
