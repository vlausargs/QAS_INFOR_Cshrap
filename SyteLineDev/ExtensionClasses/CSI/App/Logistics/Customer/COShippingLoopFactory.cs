//PROJECT NAME: CSICustomer
//CLASS NAME: COShippingLoopFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class COShippingLoopFactory
	{
		public ICOShippingLoop Create(IApplicationDB appDB)
		{
			var _COShippingLoop = new Logistics.Customer.COShippingLoop(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCOShippingLoopExt = timerfactory.Create<Logistics.Customer.ICOShippingLoop>(_COShippingLoop);
			
			return iCOShippingLoopExt;
		}
	}
}
