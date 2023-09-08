//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RequisitionPOComparisonFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RequisitionPOComparisonFactory
	{
		public IRpt_RequisitionPOComparison Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RequisitionPOComparison = new Reporting.Rpt_RequisitionPOComparison(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RequisitionPOComparisonExt = timerfactory.Create<Reporting.IRpt_RequisitionPOComparison>(_Rpt_RequisitionPOComparison);
			
			return iRpt_RequisitionPOComparisonExt;
		}
	}
}
