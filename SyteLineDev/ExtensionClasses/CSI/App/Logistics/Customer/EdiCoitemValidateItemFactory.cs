//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCoitemValidateItemFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EdiCoitemValidateItemFactory
    {
        public IEdiCoitemValidateItem Create(IApplicationDB appDB)
        {
            var _EdiCoitemValidateItem = new Logistics.Customer.EdiCoitemValidateItem(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEdiCoitemValidateItemExt = timerfactory.Create<Logistics.Customer.IEdiCoitemValidateItem>(_EdiCoitemValidateItem);

            return iEdiCoitemValidateItemExt;
        }
    }
}
