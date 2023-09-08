//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBFinancialCalendarFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBFinancialCalendarFactory
	{
		public ICLM_ESBFinancialCalendar Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBFinancialCalendar = new BusInterface.CLM_ESBFinancialCalendar(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBFinancialCalendarExt = timerfactory.Create<BusInterface.ICLM_ESBFinancialCalendar>(_CLM_ESBFinancialCalendar);
			
			return iCLM_ESBFinancialCalendarExt;
		}
	}
}
