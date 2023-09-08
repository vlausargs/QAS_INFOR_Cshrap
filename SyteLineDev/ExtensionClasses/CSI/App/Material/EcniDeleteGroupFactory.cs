//PROJECT NAME: Material
//CLASS NAME: EcniDeleteGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class EcniDeleteGroupFactory
	{
		public IEcniDeleteGroup Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EcniDeleteGroup = new Material.EcniDeleteGroup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEcniDeleteGroupExt = timerfactory.Create<Material.IEcniDeleteGroup>(_EcniDeleteGroup);
			
			return iEcniDeleteGroupExt;
		}
	}
}
