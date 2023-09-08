//PROJECT NAME: Finance
//CLASS NAME: MXDIOTFileGenFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.Mexican
{
	public class MXDIOTFileGenFactory
	{
		public IMXDIOTFileGen Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MXDIOTFileGen = new Finance.Mexican.MXDIOTFileGen(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMXDIOTFileGenExt = timerfactory.Create<Finance.Mexican.IMXDIOTFileGen>(_MXDIOTFileGen);
			
			return iMXDIOTFileGenExt;
		}
	}
}
