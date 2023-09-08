//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIInvoicesFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PurgeEDIInvoicesFactory
	{
		public IPurgeEDIInvoices Create(IApplicationDB appDB)
		{
			var _PurgeEDIInvoices = new Logistics.Customer.PurgeEDIInvoices(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeEDIInvoicesExt = timerfactory.Create<Logistics.Customer.IPurgeEDIInvoices>(_PurgeEDIInvoices);
			
			return iPurgeEDIInvoicesExt;
		}
	}
}
