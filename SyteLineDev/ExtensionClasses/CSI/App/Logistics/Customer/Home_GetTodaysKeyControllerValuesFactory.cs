//PROJECT NAME: CSICustomer
//CLASS NAME: Home_GetTodaysKeyControllerValuesFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Home_GetTodaysKeyControllerValuesFactory
    {
        public IHome_GetTodaysKeyControllerValues Create(IApplicationDB appDB)
        {
            var _Home_GetTodaysKeyControllerValues = new Customer.Home_GetTodaysKeyControllerValues(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHome_GetTodaysKeyControllerValuesExt = timerfactory.Create<Customer.IHome_GetTodaysKeyControllerValues>(_Home_GetTodaysKeyControllerValues);

            return iHome_GetTodaysKeyControllerValuesExt;
        }
    }
}
