//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_GetTodaysKeySalespersonValuesFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Homepage_GetTodaysKeySalespersonValuesFactory
    {
        public IHomepage_GetTodaysKeySalespersonValues Create(IApplicationDB appDB)
        {
            var _Homepage_GetTodaysKeySalespersonValues = new Logistics.Customer.Homepage_GetTodaysKeySalespersonValues(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_GetTodaysKeySalespersonValuesExt = timerfactory.Create<Logistics.Customer.IHomepage_GetTodaysKeySalespersonValues>(_Homepage_GetTodaysKeySalespersonValues);

            return iHomepage_GetTodaysKeySalespersonValuesExt;
        }
    }
}
