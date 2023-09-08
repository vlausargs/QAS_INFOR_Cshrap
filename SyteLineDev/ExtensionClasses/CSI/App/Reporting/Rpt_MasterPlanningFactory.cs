//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MasterPlanningFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MasterPlanningFactory
	{
		public IRpt_MasterPlanning Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MasterPlanning = new Reporting.Rpt_MasterPlanning(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MasterPlanningExt = timerfactory.Create<Reporting.IRpt_MasterPlanning>(_Rpt_MasterPlanning);
			
			return iRpt_MasterPlanningExt;
		}
	}
}
