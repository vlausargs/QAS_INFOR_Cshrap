//PROJECT NAME: Material
//CLASS NAME: EcniJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class EcniJobFactory
	{
		public IEcniJob Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EcniJob = new Material.EcniJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEcniJobExt = timerfactory.Create<Material.IEcniJob>(_EcniJob);
			
			return iEcniJobExt;
		}
	}
}
