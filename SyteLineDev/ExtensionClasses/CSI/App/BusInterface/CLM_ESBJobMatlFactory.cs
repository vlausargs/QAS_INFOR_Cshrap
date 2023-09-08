//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBJobMatlFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBJobMatlFactory
	{
		public ICLM_ESBJobMatl Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBJobMatl = new BusInterface.CLM_ESBJobMatl(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBJobMatlExt = timerfactory.Create<BusInterface.ICLM_ESBJobMatl>(_CLM_ESBJobMatl);
			
			return iCLM_ESBJobMatlExt;
		}
	}
}
