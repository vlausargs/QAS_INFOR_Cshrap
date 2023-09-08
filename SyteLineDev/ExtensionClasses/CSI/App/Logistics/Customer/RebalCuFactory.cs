//PROJECT NAME: Logistics
//CLASS NAME: RebalCuFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RebalCuFactory
	{
		public IRebalCu Create(IApplicationDB appDB)
		{
			var _RebalCu = new Logistics.Customer.RebalCu(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRebalCuExt = timerfactory.Create<Logistics.Customer.IRebalCu>(_RebalCu);
			
			return iRebalCuExt;
		}
	}
}
