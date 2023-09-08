//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBWorkCenterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBWorkCenterFactory
	{
		public ICLM_ESBWorkCenter Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBWorkCenter = new BusInterface.CLM_ESBWorkCenter(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBWorkCenterExt = timerfactory.Create<BusInterface.ICLM_ESBWorkCenter>(_CLM_ESBWorkCenter);
			
			return iCLM_ESBWorkCenterExt;
		}
	}
}
