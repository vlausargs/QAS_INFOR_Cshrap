//PROJECT NAME: Material
//CLASS NAME: PhyinvSerialV2Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PhyinvSerialV2Factory
	{
		public IPhyinvSerialV2 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PhyinvSerialV2 = new Material.PhyinvSerialV2(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPhyinvSerialV2Ext = timerfactory.Create<Material.IPhyinvSerialV2>(_PhyinvSerialV2);
			
			return iPhyinvSerialV2Ext;
		}
	}
}
