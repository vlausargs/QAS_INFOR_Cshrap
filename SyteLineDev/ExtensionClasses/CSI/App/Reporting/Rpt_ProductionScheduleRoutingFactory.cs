//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionScheduleRoutingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProductionScheduleRoutingFactory
	{
		public IRpt_ProductionScheduleRouting Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProductionScheduleRouting = new Reporting.Rpt_ProductionScheduleRouting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProductionScheduleRoutingExt = timerfactory.Create<Reporting.IRpt_ProductionScheduleRouting>(_Rpt_ProductionScheduleRouting);
			
			return iRpt_ProductionScheduleRoutingExt;
		}
	}
}
