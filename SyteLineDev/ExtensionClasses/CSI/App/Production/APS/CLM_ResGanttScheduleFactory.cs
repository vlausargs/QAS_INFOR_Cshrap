//PROJECT NAME: Production
//CLASS NAME: CLM_ResGanttScheduleFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ResGanttScheduleFactory
	{
		public ICLM_ResGanttSchedule Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ResGanttSchedule = new Production.APS.CLM_ResGanttSchedule(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ResGanttScheduleExt = timerfactory.Create<Production.APS.ICLM_ResGanttSchedule>(_CLM_ResGanttSchedule);
			
			return iCLM_ResGanttScheduleExt;
		}
	}
}
