//PROJECT NAME: CSICustomer
//CLASS NAME: AddSingleByPOFilterFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class AddSingleByPOFilterFactory
    {
        public IAddSingleByPOFilter Create(IApplicationDB appDB)
        {
            var _AddSingleByPOFilter = new Logistics.Customer.AddSingleByPOFilter(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAddSingleByPOFilterExt = timerfactory.Create<Logistics.Customer.IAddSingleByPOFilter>(_AddSingleByPOFilter);

            return iAddSingleByPOFilterExt;
        }
    }
}
