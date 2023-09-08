//PROJECT NAME: Reporting
//CLASS NAME: RPT_PRtrxp2pPostChecksFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RPT_PRtrxp2pPostChecksFactory
	{
		public IRPT_PRtrxp2pPostChecks Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RPT_PRtrxp2pPostChecks = new Reporting.RPT_PRtrxp2pPostChecks(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRPT_PRtrxp2pPostChecksExt = timerfactory.Create<Reporting.IRPT_PRtrxp2pPostChecks>(_RPT_PRtrxp2pPostChecks);
			
			return iRPT_PRtrxp2pPostChecksExt;
		}
	}
}
