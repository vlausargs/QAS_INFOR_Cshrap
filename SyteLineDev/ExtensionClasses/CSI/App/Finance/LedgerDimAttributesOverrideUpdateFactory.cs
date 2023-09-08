//PROJECT NAME: Finance
//CLASS NAME: LedgerDimAttributesOverrideUpdateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class LedgerDimAttributesOverrideUpdateFactory
	{
		public ILedgerDimAttributesOverrideUpdate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LedgerDimAttributesOverrideUpdate = new Finance.LedgerDimAttributesOverrideUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLedgerDimAttributesOverrideUpdateExt = timerfactory.Create<Finance.ILedgerDimAttributesOverrideUpdate>(_LedgerDimAttributesOverrideUpdate);
			
			return iLedgerDimAttributesOverrideUpdateExt;
		}
	}
}
