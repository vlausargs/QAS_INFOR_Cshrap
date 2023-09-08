//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBGLMovementFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBGLMovementFactory
	{
		public ICLM_ESBGLMovement Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBGLMovement = new BusInterface.CLM_ESBGLMovement(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBGLMovementExt = timerfactory.Create<BusInterface.ICLM_ESBGLMovement>(_CLM_ESBGLMovement);
			
			return iCLM_ESBGLMovementExt;
		}
	}
}
