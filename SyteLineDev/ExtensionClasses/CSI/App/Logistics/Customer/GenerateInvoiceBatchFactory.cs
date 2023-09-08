//PROJECT NAME: CSICustomer
//CLASS NAME: GenerateInvoiceBatchFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateInvoiceBatchFactory
	{
		public IGenerateInvoiceBatch Create(IApplicationDB appDB)
		{
			var _GenerateInvoiceBatch = new Logistics.Customer.GenerateInvoiceBatch(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateInvoiceBatchExt = timerfactory.Create<Logistics.Customer.IGenerateInvoiceBatch>(_GenerateInvoiceBatch);
			
			return iGenerateInvoiceBatchExt;
		}
	}
}
