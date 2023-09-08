//PROJECT NAME: CSICustomer
//CLASS NAME: AU_GetCustomerParmFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class AU_GetCustomerParmFactory
    {
        public IAU_GetCustomerParm Create(IApplicationDB appDB)
        {
            var _AU_GetCustomerParm = new AU_GetCustomerParm(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAU_GetCustomerParmExt = timerfactory.Create<IAU_GetCustomerParm>(_AU_GetCustomerParm);

            return iAU_GetCustomerParmExt;
        }
    }
}
