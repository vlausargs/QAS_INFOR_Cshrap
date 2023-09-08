//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PastDueJobOperationsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PastDueJobOperationsFactory
	{
		public IRpt_PastDueJobOperations Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PastDueJobOperations = new Reporting.Rpt_PastDueJobOperations(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PastDueJobOperationsExt = timerfactory.Create<Reporting.IRpt_PastDueJobOperations>(_Rpt_PastDueJobOperations);
			
			return iRpt_PastDueJobOperationsExt;
		}
	}
}
