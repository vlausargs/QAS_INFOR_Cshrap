//PROJECT NAME: Finance
//CLASS NAME: PreDeleteCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class PreDeleteCheckFactory
	{
		public IPreDeleteCheck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PreDeleteCheck = new Finance.PreDeleteCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreDeleteCheckExt = timerfactory.Create<Finance.IPreDeleteCheck>(_PreDeleteCheck);
			
			return iPreDeleteCheckExt;
		}
	}
}
