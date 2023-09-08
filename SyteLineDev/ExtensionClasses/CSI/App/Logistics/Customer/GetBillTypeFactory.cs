//PROJECT NAME: CSICustomer
//CLASS NAME: GetBillTypeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class GetBillTypeFactory
    {
        public IGetBillType Create(IApplicationDB appDB)
        {
            var _GetBillType = new Customer.GetBillType(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetBillTypeExt = timerfactory.Create<Customer.IGetBillType>(_GetBillType);

            return iGetBillTypeExt;
        }
    }
}
