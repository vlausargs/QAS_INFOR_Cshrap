//PROJECT NAME: Material
//CLASS NAME: PhyinvLotV2Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PhyinvLotV2Factory
	{
		public IPhyinvLotV2 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PhyinvLotV2 = new Material.PhyinvLotV2(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPhyinvLotV2Ext = timerfactory.Create<Material.IPhyinvLotV2>(_PhyinvLotV2);
			
			return iPhyinvLotV2Ext;
		}
	}
}
