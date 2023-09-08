//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBPersonFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBPersonFactory
	{
		public ICLM_ESBPerson Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBPerson = new BusInterface.CLM_ESBPerson(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBPersonExt = timerfactory.Create<BusInterface.ICLM_ESBPerson>(_CLM_ESBPerson);
			
			return iCLM_ESBPersonExt;
		}
	}
}
