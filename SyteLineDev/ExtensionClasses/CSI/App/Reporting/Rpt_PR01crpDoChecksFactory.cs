//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PR01crpDoChecksFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PR01crpDoChecksFactory
	{
		public IRpt_PR01crpDoChecks Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PR01crpDoChecks = new Reporting.Rpt_PR01crpDoChecks(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PR01crpDoChecksExt = timerfactory.Create<Reporting.IRpt_PR01crpDoChecks>(_Rpt_PR01crpDoChecks);
			
			return iRpt_PR01crpDoChecksExt;
		}
	}
}
