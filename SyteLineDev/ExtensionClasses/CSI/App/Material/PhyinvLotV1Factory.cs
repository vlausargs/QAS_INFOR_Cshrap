//PROJECT NAME: Material
//CLASS NAME: PhyinvLotV1Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PhyinvLotV1Factory
	{
		public IPhyinvLotV1 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PhyinvLotV1 = new Material.PhyinvLotV1(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPhyinvLotV1Ext = timerfactory.Create<Material.IPhyinvLotV1>(_PhyinvLotV1);
			
			return iPhyinvLotV1Ext;
		}
	}
}
