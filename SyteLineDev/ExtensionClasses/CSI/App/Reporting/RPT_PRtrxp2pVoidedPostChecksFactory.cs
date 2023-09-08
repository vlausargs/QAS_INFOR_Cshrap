//PROJECT NAME: Reporting
//CLASS NAME: RPT_PRtrxp2pVoidedPostChecksFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RPT_PRtrxp2pVoidedPostChecksFactory
	{
		public IRPT_PRtrxp2pVoidedPostChecks Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RPT_PRtrxp2pVoidedPostChecks = new Reporting.RPT_PRtrxp2pVoidedPostChecks(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRPT_PRtrxp2pVoidedPostChecksExt = timerfactory.Create<Reporting.IRPT_PRtrxp2pVoidedPostChecks>(_RPT_PRtrxp2pVoidedPostChecks);
			
			return iRPT_PRtrxp2pVoidedPostChecksExt;
		}
	}
}
