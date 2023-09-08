//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PRtrxpPostChecksFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PRtrxpPostChecksFactory
	{
		public IRpt_PRtrxpPostChecks Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PRtrxpPostChecks = new Reporting.Rpt_PRtrxpPostChecks(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PRtrxpPostChecksExt = timerfactory.Create<Reporting.IRpt_PRtrxpPostChecks>(_Rpt_PRtrxpPostChecks);
			
			return iRpt_PRtrxpPostChecksExt;
		}
	}
}
