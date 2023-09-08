//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobCostDetailBreakoutFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JobCostDetailBreakoutFactory
	{
		public IRpt_JobCostDetailBreakout Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JobCostDetailBreakout = new Reporting.Rpt_JobCostDetailBreakout(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobCostDetailBreakoutExt = timerfactory.Create<Reporting.IRpt_JobCostDetailBreakout>(_Rpt_JobCostDetailBreakout);
			
			return iRpt_JobCostDetailBreakoutExt;
		}
	}
}
