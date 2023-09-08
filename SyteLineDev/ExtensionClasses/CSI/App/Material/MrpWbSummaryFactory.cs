//PROJECT NAME: Material
//CLASS NAME: MrpWbSummaryFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MrpWbSummaryFactory
	{
		public IMrpWbSummary Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MrpWbSummary = new Material.MrpWbSummary(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMrpWbSummaryExt = timerfactory.Create<Material.IMrpWbSummary>(_MrpWbSummary);
			
			return iMrpWbSummaryExt;
		}
	}
}
