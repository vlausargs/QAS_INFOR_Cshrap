//PROJECT NAME: CSICustomer
//CLASS NAME: EstimateLinesValidCustItemFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EstimateLinesValidCustItemFactory
    {
        public IEstimateLinesValidCustItem Create(IApplicationDB appDB)
        {
            var _EstimateLinesValidCustItem = new EstimateLinesValidCustItem(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEstimateLinesValidCustItemExt = timerfactory.Create<IEstimateLinesValidCustItem>(_EstimateLinesValidCustItem);

            return iEstimateLinesValidCustItemExt;
        }
    }
}
