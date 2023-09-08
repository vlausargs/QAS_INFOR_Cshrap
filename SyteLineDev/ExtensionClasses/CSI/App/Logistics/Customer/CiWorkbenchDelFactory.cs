//PROJECT NAME: CSICustomer
//CLASS NAME: CiWorkbenchDelFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CiWorkbenchDelFactory
    {
        public ICiWorkbenchDel Create(IApplicationDB appDB)
        {
            var _CiWorkbenchDel = new Customer.CiWorkbenchDel(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCiWorkbenchDelExt = timerfactory.Create<Customer.ICiWorkbenchDel>(_CiWorkbenchDel);

            return iCiWorkbenchDelExt;
        }
    }
}
