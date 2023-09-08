//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobCostVarianceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JobCostVarianceFactory
	{
		public IRpt_JobCostVariance Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JobCostVariance = new Reporting.Rpt_JobCostVariance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobCostVarianceExt = timerfactory.Create<Reporting.IRpt_JobCostVariance>(_Rpt_JobCostVariance);
			
			return iRpt_JobCostVarianceExt;
		}
	}
}
