//PROJECT NAME: CSICustomer
//CLASS NAME: EstimateLinesItemForCustItemFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EstimateLinesItemForCustItemFactory
	{
		public IEstimateLinesItemForCustItem Create(IApplicationDB appDB)
		{
			var _EstimateLinesItemForCustItem = new Logistics.Customer.EstimateLinesItemForCustItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstimateLinesItemForCustItemExt = timerfactory.Create<Logistics.Customer.IEstimateLinesItemForCustItem>(_EstimateLinesItemForCustItem);
			
			return iEstimateLinesItemForCustItemExt;
		}
	}
}
