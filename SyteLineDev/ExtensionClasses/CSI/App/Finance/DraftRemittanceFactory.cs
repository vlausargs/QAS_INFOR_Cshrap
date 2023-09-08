//PROJECT NAME: Finance
//CLASS NAME: DraftRemittanceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class DraftRemittanceFactory
	{
		public IDraftRemittance Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DraftRemittance = new Finance.DraftRemittance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDraftRemittanceExt = timerfactory.Create<Finance.IDraftRemittance>(_DraftRemittance);
			
			return iDraftRemittanceExt;
		}
	}
}
