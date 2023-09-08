//PROJECT NAME: Logistics
//CLASS NAME: PurgeInvoiceHistoryFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PurgeInvoiceHistoryFactory
	{
		public IPurgeInvoiceHistory Create(IApplicationDB appDB)
		{
			var _PurgeInvoiceHistory = new Logistics.Customer.PurgeInvoiceHistory(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeInvoiceHistoryExt = timerfactory.Create<Logistics.Customer.IPurgeInvoiceHistory>(_PurgeInvoiceHistory);
			
			return iPurgeInvoiceHistoryExt;
		}
	}
}
