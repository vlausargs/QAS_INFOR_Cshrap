//PROJECT NAME: CSICustomer
//CLASS NAME: Home_GetTodaysKeyCustomerValuesFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Home_GetTodaysKeyCustomerValuesFactory
    {
        public IHome_GetTodaysKeyCustomerValues Create(IApplicationDB appDB)
        {
            var _Home_GetTodaysKeyCustomerValues = new Home_GetTodaysKeyCustomerValues(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHome_GetTodaysKeyCustomerValuesExt = timerfactory.Create<IHome_GetTodaysKeyCustomerValues>(_Home_GetTodaysKeyCustomerValues);

            return iHome_GetTodaysKeyCustomerValuesExt;
        }
    }
}
