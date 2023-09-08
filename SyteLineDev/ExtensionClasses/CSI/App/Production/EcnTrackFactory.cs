//PROJECT NAME: Production
//CLASS NAME: EcnTrackFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class EcnTrackFactory
	{
		public IEcnTrack Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EcnTrack = new Production.EcnTrack(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEcnTrackExt = timerfactory.Create<Production.IEcnTrack>(_EcnTrack);
			
			return iEcnTrackExt;
		}
	}
}
