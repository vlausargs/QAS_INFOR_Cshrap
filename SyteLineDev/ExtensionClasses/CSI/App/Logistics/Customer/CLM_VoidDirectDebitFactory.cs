//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_VoidDirectDebitFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_VoidDirectDebitFactory
	{
		public ICLM_VoidDirectDebit Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CLM_VoidDirectDebit = new Logistics.Customer.CLM_VoidDirectDebit(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_VoidDirectDebitExt = timerfactory.Create<Logistics.Customer.ICLM_VoidDirectDebit>(_CLM_VoidDirectDebit);
			
			return iCLM_VoidDirectDebitExt;
		}
	}
}
