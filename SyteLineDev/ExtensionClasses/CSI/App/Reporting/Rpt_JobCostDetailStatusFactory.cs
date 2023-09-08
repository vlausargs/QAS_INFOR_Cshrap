//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobCostDetailStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JobCostDetailStatusFactory
	{
		public IRpt_JobCostDetailStatus Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JobCostDetailStatus = new Reporting.Rpt_JobCostDetailStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobCostDetailStatusExt = timerfactory.Create<Reporting.IRpt_JobCostDetailStatus>(_Rpt_JobCostDetailStatus);
			
			return iRpt_JobCostDetailStatusExt;
		}
	}
}
