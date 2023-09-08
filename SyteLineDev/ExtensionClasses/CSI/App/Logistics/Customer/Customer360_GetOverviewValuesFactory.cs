//PROJECT NAME: CSICustomer
//CLASS NAME: Customer360_GetOverviewValuesFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Customer360_GetOverviewValuesFactory
    {
        public ICustomer360_GetOverviewValues Create(IApplicationDB appDB)
        {
            var _Customer360_GetOverviewValues = new Logistics.Customer.Customer360_GetOverviewValues(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCustomer360_GetOverviewValuesExt = timerfactory.Create<Logistics.Customer.ICustomer360_GetOverviewValues>(_Customer360_GetOverviewValues);

            return iCustomer360_GetOverviewValuesExt;
        }
    }
}
