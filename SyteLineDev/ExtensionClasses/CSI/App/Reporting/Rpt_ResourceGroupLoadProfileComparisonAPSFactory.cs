//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceGroupLoadProfileComparisonAPSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ResourceGroupLoadProfileComparisonAPSFactory
	{
		public IRpt_ResourceGroupLoadProfileComparisonAPS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ResourceGroupLoadProfileComparisonAPS = new Reporting.Rpt_ResourceGroupLoadProfileComparisonAPS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ResourceGroupLoadProfileComparisonAPSExt = timerfactory.Create<Reporting.IRpt_ResourceGroupLoadProfileComparisonAPS>(_Rpt_ResourceGroupLoadProfileComparisonAPS);
			
			return iRpt_ResourceGroupLoadProfileComparisonAPSExt;
		}
	}
}
