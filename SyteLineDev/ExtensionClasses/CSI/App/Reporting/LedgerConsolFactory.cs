//PROJECT NAME: Reporting
//CLASS NAME: LedgerConsolFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class LedgerConsolFactory
	{
		public ILedgerConsol Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _LedgerConsol = new Reporting.LedgerConsol(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLedgerConsolExt = timerfactory.Create<Reporting.ILedgerConsol>(_LedgerConsol);
			
			return iLedgerConsolExt;
		}
	}
}
