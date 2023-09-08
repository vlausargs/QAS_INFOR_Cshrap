//PROJECT NAME: Material
//CLASS NAME: PhyinvValEmployeeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PhyinvValEmployeeFactory
	{
		public IPhyinvValEmployee Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PhyinvValEmployee = new Material.PhyinvValEmployee(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPhyinvValEmployeeExt = timerfactory.Create<Material.IPhyinvValEmployee>(_PhyinvValEmployee);
			
			return iPhyinvValEmployeeExt;
		}
	}
}
