//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_GetItemVendPriceBrkInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class Homepage_GetItemVendPriceBrkInfoFactory
    {
        public IHomepage_GetItemVendPriceBrkInfo Create(IApplicationDB appDB)
        {
            var _Homepage_GetItemVendPriceBrkInfo = new Logistics.Customer.Homepage_GetItemVendPriceBrkInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_GetItemVendPriceBrkInfoExt = timerfactory.Create<Logistics.Customer.IHomepage_GetItemVendPriceBrkInfo>(_Homepage_GetItemVendPriceBrkInfo);

            return iHomepage_GetItemVendPriceBrkInfoExt;
        }
    }
}
