//PROJECT NAME: Logistics
//CLASS NAME: RmaItemCompareQtyFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaItemCompareQtyFactory
	{
		public IRmaItemCompareQty Create(IApplicationDB appDB)
		{
			var _RmaItemCompareQty = new Logistics.Customer.RmaItemCompareQty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaItemCompareQtyExt = timerfactory.Create<Logistics.Customer.IRmaItemCompareQty>(_RmaItemCompareQty);
			
			return iRmaItemCompareQtyExt;
		}
	}
}
