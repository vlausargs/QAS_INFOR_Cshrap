//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobCostbyItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JobCostbyItemFactory
	{
		public IRpt_JobCostbyItem Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JobCostbyItem = new Reporting.Rpt_JobCostbyItem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobCostbyItemExt = timerfactory.Create<Reporting.IRpt_JobCostbyItem>(_Rpt_JobCostbyItem);
			
			return iRpt_JobCostbyItemExt;
		}
	}
}
