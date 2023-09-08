//PROJECT NAME: CSICustomer
//CLASS NAME: GetRmaparmsLocFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetRmaparmsLocFactory
	{
		public IGetRmaparmsLoc Create(IApplicationDB appDB)
		{
			var _GetRmaparmsLoc = new Logistics.Customer.GetRmaparmsLoc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetRmaparmsLocExt = timerfactory.Create<Logistics.Customer.IGetRmaparmsLoc>(_GetRmaparmsLoc);
			
			return iGetRmaparmsLocExt;
		}
	}
}
