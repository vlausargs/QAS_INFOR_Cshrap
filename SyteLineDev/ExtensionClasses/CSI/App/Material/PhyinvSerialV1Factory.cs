//PROJECT NAME: Material
//CLASS NAME: PhyinvSerialV1Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PhyinvSerialV1Factory
	{
		public IPhyinvSerialV1 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PhyinvSerialV1 = new Material.PhyinvSerialV1(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPhyinvSerialV1Ext = timerfactory.Create<Material.IPhyinvSerialV1>(_PhyinvSerialV1);
			
			return iPhyinvSerialV1Ext;
		}
	}
}
