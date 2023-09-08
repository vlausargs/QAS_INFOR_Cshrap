//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_ChangeConsolidatedInvoicingFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_ChangeConsolidatedInvoicingFactory
	{
		public ICLM_ChangeConsolidatedInvoicing Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CLM_ChangeConsolidatedInvoicing = new Logistics.Customer.CLM_ChangeConsolidatedInvoicing(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ChangeConsolidatedInvoicingExt = timerfactory.Create<Logistics.Customer.ICLM_ChangeConsolidatedInvoicing>(_CLM_ChangeConsolidatedInvoicing);
			
			return iCLM_ChangeConsolidatedInvoicingExt;
		}
	}
}
