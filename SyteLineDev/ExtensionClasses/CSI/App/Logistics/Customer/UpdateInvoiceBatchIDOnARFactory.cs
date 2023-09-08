//PROJECT NAME: Logistics
//CLASS NAME: UpdateInvoiceBatchIDOnARFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdateInvoiceBatchIDOnARFactory
	{
		public IUpdateInvoiceBatchIDOnAR Create(IApplicationDB appDB)
		{
			var _UpdateInvoiceBatchIDOnAR = new Logistics.Customer.UpdateInvoiceBatchIDOnAR(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateInvoiceBatchIDOnARExt = timerfactory.Create<Logistics.Customer.IUpdateInvoiceBatchIDOnAR>(_UpdateInvoiceBatchIDOnAR);
			
			return iUpdateInvoiceBatchIDOnARExt;
		}
	}
}
