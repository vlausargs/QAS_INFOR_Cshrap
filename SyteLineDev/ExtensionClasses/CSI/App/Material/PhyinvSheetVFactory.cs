//PROJECT NAME: Material
//CLASS NAME: PhyinvSheetVFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PhyinvSheetVFactory
	{
		public IPhyinvSheetV Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PhyinvSheetV = new Material.PhyinvSheetV(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPhyinvSheetVExt = timerfactory.Create<Material.IPhyinvSheetV>(_PhyinvSheetV);
			
			return iPhyinvSheetVExt;
		}
	}
}
