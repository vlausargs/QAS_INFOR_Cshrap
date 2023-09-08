//PROJECT NAME: Material
//CLASS NAME: EcniRevisionFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class EcniRevisionFactory
	{
		public IEcniRevision Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EcniRevision = new Material.EcniRevision(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEcniRevisionExt = timerfactory.Create<Material.IEcniRevision>(_EcniRevision);
			
			return iEcniRevisionExt;
		}
	}
}
