//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBFactory
	{
		public ICLM_ESB Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESB = new BusInterface.CLM_ESB(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBExt = timerfactory.Create<BusInterface.ICLM_ESB>(_CLM_ESB);
			
			return iCLM_ESBExt;
		}
	}
}
