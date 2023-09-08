//PROJECT NAME: Logistics
//CLASS NAME: SetInteractionEmailSentFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SetInteractionEmailSentFactory
	{
		public ISetInteractionEmailSent Create(IApplicationDB appDB)
		{
			var _SetInteractionEmailSent = new Logistics.Customer.SetInteractionEmailSent(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetInteractionEmailSentExt = timerfactory.Create<Logistics.Customer.ISetInteractionEmailSent>(_SetInteractionEmailSent);
			
			return iSetInteractionEmailSentExt;
		}
	}
}
