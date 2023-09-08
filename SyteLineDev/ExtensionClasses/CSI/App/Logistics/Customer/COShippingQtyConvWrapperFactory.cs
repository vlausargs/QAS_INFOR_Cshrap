//PROJECT NAME: CSICustomer
//CLASS NAME: COShippingQtyConvWrapperFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class COShippingQtyConvWrapperFactory
    {
        public ICOShippingQtyConvWrapper Create(IApplicationDB appDB)
        {
            var _COShippingQtyConvWrapper = new COShippingQtyConvWrapper(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCOShippingQtyConvWrapperExt = timerfactory.Create<ICOShippingQtyConvWrapper>(_COShippingQtyConvWrapper);

            return iCOShippingQtyConvWrapperExt;
        }
    }
}
