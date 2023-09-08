//PROJECT NAME: Finance
//CLASS NAME: FaPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class FaPostFactory
	{
		public IFaPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FaPost = new Finance.FaPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFaPostExt = timerfactory.Create<Finance.IFaPost>(_FaPost);
			
			return iFaPostExt;
		}
	}
}
