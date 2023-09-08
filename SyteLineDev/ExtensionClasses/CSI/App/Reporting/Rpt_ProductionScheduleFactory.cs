//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionScheduleFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProductionScheduleFactory
	{
		public IRpt_ProductionSchedule Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProductionSchedule = new Reporting.Rpt_ProductionSchedule(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProductionScheduleExt = timerfactory.Create<Reporting.IRpt_ProductionSchedule>(_Rpt_ProductionSchedule);
			
			return iRpt_ProductionScheduleExt;
		}
	}
}
