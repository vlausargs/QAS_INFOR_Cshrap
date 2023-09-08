//PROJECT NAME: CSICustomer
//CLASS NAME: GetMaxInteractionDetailsSequenceFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetMaxInteractionDetailsSequenceFactory
	{
		public IGetMaxInteractionDetailsSequence Create(IApplicationDB appDB)
		{
			var _GetMaxInteractionDetailsSequence = new Logistics.Customer.GetMaxInteractionDetailsSequence(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetMaxInteractionDetailsSequenceExt = timerfactory.Create<Logistics.Customer.IGetMaxInteractionDetailsSequence>(_GetMaxInteractionDetailsSequence);
			
			return iGetMaxInteractionDetailsSequenceExt;
		}
	}
}
