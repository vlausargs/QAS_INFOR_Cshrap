//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBServiceOtherGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBServiceOtherGroupFactory
	{
		public ICLM_ESBServiceOtherGroup Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBServiceOtherGroup = new BusInterface.CLM_ESBServiceOtherGroup(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBServiceOtherGroupExt = timerfactory.Create<BusInterface.ICLM_ESBServiceOtherGroup>(_CLM_ESBServiceOtherGroup);
			
			return iCLM_ESBServiceOtherGroupExt;
		}
	}
}
