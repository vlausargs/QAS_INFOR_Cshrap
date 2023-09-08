//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBPoVchFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBPoVchFactory
	{
		public ICLM_ESBPoVch Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBPoVch = new BusInterface.CLM_ESBPoVch(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBPoVchExt = timerfactory.Create<BusInterface.ICLM_ESBPoVch>(_CLM_ESBPoVch);
			
			return iCLM_ESBPoVchExt;
		}
	}
}
