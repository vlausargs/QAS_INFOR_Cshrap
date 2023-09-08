//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBInvLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBInvLineFactory
	{
		public ICLM_ESBInvLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBInvLine = new BusInterface.CLM_ESBInvLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBInvLineExt = timerfactory.Create<BusInterface.ICLM_ESBInvLine>(_CLM_ESBInvLine);
			
			return iCLM_ESBInvLineExt;
		}
	}
}
