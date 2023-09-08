//PROJECT NAME: Material
//CLASS NAME: PhyInvChkEmpItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PhyInvChkEmpItemFactory
	{
		public IPhyInvChkEmpItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PhyInvChkEmpItem = new Material.PhyInvChkEmpItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPhyInvChkEmpItemExt = timerfactory.Create<Material.IPhyInvChkEmpItem>(_PhyInvChkEmpItem);
			
			return iPhyInvChkEmpItemExt;
		}
	}
}
