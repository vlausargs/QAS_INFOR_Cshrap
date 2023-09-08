//PROJECT NAME: Material
//CLASS NAME: PhyinvLocVFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PhyinvLocVFactory
	{
		public IPhyinvLocV Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PhyinvLocV = new Material.PhyinvLocV(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPhyinvLocVExt = timerfactory.Create<Material.IPhyinvLocV>(_PhyinvLocV);
			
			return iPhyinvLocVExt;
		}
	}
}
