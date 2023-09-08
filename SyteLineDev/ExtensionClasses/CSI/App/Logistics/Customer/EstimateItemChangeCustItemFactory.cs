//PROJECT NAME: CSICustomer
//CLASS NAME: EstimateItemChangeCustItemFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EstimateItemChangeCustItemFactory
    {
        public IEstimateItemChangeCustItem Create(IApplicationDB appDB)
        {
            var _EstimateItemChangeCustItem = new EstimateItemChangeCustItem(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEstimateItemChangeCustItemExt = timerfactory.Create<IEstimateItemChangeCustItem>(_EstimateItemChangeCustItem);

            return iEstimateItemChangeCustItemExt;
        }
    }
}
