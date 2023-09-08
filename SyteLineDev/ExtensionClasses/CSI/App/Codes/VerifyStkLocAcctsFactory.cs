//PROJECT NAME: Codes
//CLASS NAME: VerifyStkLocAcctsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class VerifyStkLocAcctsFactory
	{
		public IVerifyStkLocAccts Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _VerifyStkLocAccts = new Codes.VerifyStkLocAccts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVerifyStkLocAcctsExt = timerfactory.Create<Codes.IVerifyStkLocAccts>(_VerifyStkLocAccts);
			
			return iVerifyStkLocAcctsExt;
		}
	}
}
