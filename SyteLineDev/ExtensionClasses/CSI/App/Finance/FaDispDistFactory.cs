//PROJECT NAME: Finance
//CLASS NAME: FaDispDistFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class FaDispDistFactory
	{
		public IFaDispDist Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FaDispDist = new Finance.FaDispDist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFaDispDistExt = timerfactory.Create<Finance.IFaDispDist>(_FaDispDist);
			
			return iFaDispDistExt;
		}
	}
}
