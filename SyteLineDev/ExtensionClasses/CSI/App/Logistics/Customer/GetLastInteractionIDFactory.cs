//PROJECT NAME: CSICustomer
//CLASS NAME: GetLastInteractionIDFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetLastInteractionIDFactory
	{
		public IGetLastInteractionID Create(IApplicationDB appDB)
		{
			var _GetLastInteractionID = new Logistics.Customer.GetLastInteractionID(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetLastInteractionIDExt = timerfactory.Create<Logistics.Customer.IGetLastInteractionID>(_GetLastInteractionID);
			
			return iGetLastInteractionIDExt;
		}
	}
}
