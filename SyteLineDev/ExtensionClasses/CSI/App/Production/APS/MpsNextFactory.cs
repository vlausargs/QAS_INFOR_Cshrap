//PROJECT NAME: Production
//CLASS NAME: MpsNextFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class MpsNextFactory
	{
		public IMpsNext Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MpsNext = new Production.APS.MpsNext(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMpsNextExt = timerfactory.Create<Production.APS.IMpsNext>(_MpsNext);
			
			return iMpsNextExt;
		}
	}
}
