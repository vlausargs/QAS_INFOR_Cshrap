//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ConsolidatedInvoicingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ConsolidatedInvoicingFactory
	{
		public IRpt_ConsolidatedInvoicing Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ConsolidatedInvoicing = new Reporting.Rpt_ConsolidatedInvoicing(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ConsolidatedInvoicingExt = timerfactory.Create<Reporting.IRpt_ConsolidatedInvoicing>(_Rpt_ConsolidatedInvoicing);
			
			return iRpt_ConsolidatedInvoicingExt;
		}
	}
}
