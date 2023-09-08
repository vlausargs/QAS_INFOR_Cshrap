//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBFinancialCalendarDetailFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBFinancialCalendarDetailFactory
	{
		public ICLM_ESBFinancialCalendarDetail Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBFinancialCalendarDetail = new BusInterface.CLM_ESBFinancialCalendarDetail(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBFinancialCalendarDetailExt = timerfactory.Create<BusInterface.ICLM_ESBFinancialCalendarDetail>(_CLM_ESBFinancialCalendarDetail);
			
			return iCLM_ESBFinancialCalendarDetailExt;
		}
	}
}
