//PROJECT NAME: Finance
//CLASS NAME: FinStmtPreviewDefaultsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class FinStmtPreviewDefaultsFactory
	{
		public IFinStmtPreviewDefaults Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FinStmtPreviewDefaults = new Finance.FinStmtPreviewDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFinStmtPreviewDefaultsExt = timerfactory.Create<Finance.IFinStmtPreviewDefaults>(_FinStmtPreviewDefaults);
			
			return iFinStmtPreviewDefaultsExt;
		}
	}
}
