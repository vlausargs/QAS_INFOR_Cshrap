//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBProjectMasterLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBProjectMasterLineFactory
	{
		public ICLM_ESBProjectMasterLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBProjectMasterLine = new BusInterface.CLM_ESBProjectMasterLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBProjectMasterLineExt = timerfactory.Create<BusInterface.ICLM_ESBProjectMasterLine>(_CLM_ESBProjectMasterLine);
			
			return iCLM_ESBProjectMasterLineExt;
		}
	}
}
