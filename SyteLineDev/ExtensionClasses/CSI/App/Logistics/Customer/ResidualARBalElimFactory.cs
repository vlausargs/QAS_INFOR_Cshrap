//PROJECT NAME: Logistics
//CLASS NAME: ResidualARBalElimFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ResidualARBalElimFactory
	{
		public IResidualARBalElim Create(IApplicationDB appDB)
		{
			var _ResidualARBalElim = new Logistics.Customer.ResidualARBalElim(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iResidualARBalElimExt = timerfactory.Create<Logistics.Customer.IResidualARBalElim>(_ResidualARBalElim);
			
			return iResidualARBalElimExt;
		}
	}
}
