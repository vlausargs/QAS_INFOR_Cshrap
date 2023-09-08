//PROJECT NAME: Finance
//CLASS NAME: GetNextCheckNumberFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GetNextCheckNumberFactory
	{
		public IGetNextCheckNumber Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetNextCheckNumber = new Finance.GetNextCheckNumber(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNextCheckNumberExt = timerfactory.Create<Finance.IGetNextCheckNumber>(_GetNextCheckNumber);
			
			return iGetNextCheckNumberExt;
		}
	}
}
