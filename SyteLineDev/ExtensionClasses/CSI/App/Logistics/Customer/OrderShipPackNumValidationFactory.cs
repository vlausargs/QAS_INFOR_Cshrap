//PROJECT NAME: CSICustomer
//CLASS NAME: OrderShipPackNumValidationFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class OrderShipPackNumValidationFactory
    {
        public IOrderShipPackNumValidation Create(IApplicationDB appDB)
        {
            var _OrderShipPackNumValidation = new OrderShipPackNumValidation(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iOrderShipPackNumValidationExt = timerfactory.Create<IOrderShipPackNumValidation>(_OrderShipPackNumValidation);

            return iOrderShipPackNumValidationExt;
        }
    }
}
