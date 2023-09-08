//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_InvVoidSequenceFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_InvVoidSequenceFactory
	{
		public ICLM_InvVoidSequence Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CLM_InvVoidSequence = new Logistics.Customer.CLM_InvVoidSequence(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_InvVoidSequenceExt = timerfactory.Create<Logistics.Customer.ICLM_InvVoidSequence>(_CLM_InvVoidSequence);
			
			return iCLM_InvVoidSequenceExt;
		}
	}
}
