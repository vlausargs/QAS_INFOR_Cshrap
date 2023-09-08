//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBCalendarFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBCalendarFactory
	{
		public ICLM_ESBCalendar Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBCalendar = new BusInterface.CLM_ESBCalendar(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBCalendarExt = timerfactory.Create<BusInterface.ICLM_ESBCalendar>(_CLM_ESBCalendar);
			
			return iCLM_ESBCalendarExt;
		}
	}
}
