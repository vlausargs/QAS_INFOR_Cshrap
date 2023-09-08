//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBProjectMasterHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBProjectMasterHeaderFactory
	{
		public ICLM_ESBProjectMasterHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBProjectMasterHeader = new BusInterface.CLM_ESBProjectMasterHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBProjectMasterHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBProjectMasterHeader>(_CLM_ESBProjectMasterHeader);
			
			return iCLM_ESBProjectMasterHeaderExt;
		}
	}
}
