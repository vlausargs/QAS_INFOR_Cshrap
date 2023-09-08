//PROJECT NAME: CSICustomer
//CLASS NAME: ResvCoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ResvCoFactory
	{
		public IResvCo Create(IApplicationDB appDB)
		{
			var _ResvCo = new Logistics.Customer.ResvCo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iResvCoExt = timerfactory.Create<Logistics.Customer.IResvCo>(_ResvCo);
			
			return iResvCoExt;
		}
	}
}
