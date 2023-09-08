//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBServiceOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBServiceOrderFactory
	{
		public ICLM_ESBServiceOrder Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBServiceOrder = new BusInterface.CLM_ESBServiceOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBServiceOrderExt = timerfactory.Create<BusInterface.ICLM_ESBServiceOrder>(_CLM_ESBServiceOrder);
			
			return iCLM_ESBServiceOrderExt;
		}
	}
}
