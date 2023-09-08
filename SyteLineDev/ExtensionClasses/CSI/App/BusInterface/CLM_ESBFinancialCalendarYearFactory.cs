//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBFinancialCalendarYearFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBFinancialCalendarYearFactory
	{
		public ICLM_ESBFinancialCalendarYear Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBFinancialCalendarYear = new BusInterface.CLM_ESBFinancialCalendarYear(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBFinancialCalendarYearExt = timerfactory.Create<BusInterface.ICLM_ESBFinancialCalendarYear>(_CLM_ESBFinancialCalendarYear);
			
			return iCLM_ESBFinancialCalendarYearExt;
		}
	}
}
