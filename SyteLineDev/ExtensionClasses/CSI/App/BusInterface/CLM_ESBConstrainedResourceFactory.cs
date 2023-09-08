//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBConstrainedResourceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBConstrainedResourceFactory
	{
		public ICLM_ESBConstrainedResource Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBConstrainedResource = new BusInterface.CLM_ESBConstrainedResource(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBConstrainedResourceExt = timerfactory.Create<BusInterface.ICLM_ESBConstrainedResource>(_CLM_ESBConstrainedResource);
			
			return iCLM_ESBConstrainedResourceExt;
		}
	}
}
