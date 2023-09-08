//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBBillOfResourcesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBBillOfResourcesFactory
	{
		public ICLM_ESBBillOfResources Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBBillOfResources = new BusInterface.CLM_ESBBillOfResources(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBBillOfResourcesExt = timerfactory.Create<BusInterface.ICLM_ESBBillOfResources>(_CLM_ESBBillOfResources);
			
			return iCLM_ESBBillOfResourcesExt;
		}
	}
}
