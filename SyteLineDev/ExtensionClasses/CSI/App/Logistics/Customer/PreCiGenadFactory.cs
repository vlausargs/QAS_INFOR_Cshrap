//PROJECT NAME: CSICustomer
//CLASS NAME: PreCiGenadFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class PreCiGenadFactory
    {
        public IPreCiGenad Create(IApplicationDB appDB)
        {
            var _PreCiGenad = new Customer.PreCiGenad(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPreCiGenadExt = timerfactory.Create<Customer.IPreCiGenad>(_PreCiGenad);

            return iPreCiGenadExt;
        }
    }
}
