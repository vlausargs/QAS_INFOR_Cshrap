//PROJECT NAME: CSICustomer
//CLASS NAME: GetRmaparmRestockFeePctFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetRmaparmRestockFeePctFactory
	{
		public IGetRmaparmRestockFeePct Create(IApplicationDB appDB)
		{
			var _GetRmaparmRestockFeePct = new Logistics.Customer.GetRmaparmRestockFeePct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetRmaparmRestockFeePctExt = timerfactory.Create<Logistics.Customer.IGetRmaparmRestockFeePct>(_GetRmaparmRestockFeePct);
			
			return iGetRmaparmRestockFeePctExt;
		}
	}
}
