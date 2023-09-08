//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBServiceLaborGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBServiceLaborGroupFactory
	{
		public ICLM_ESBServiceLaborGroup Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBServiceLaborGroup = new BusInterface.CLM_ESBServiceLaborGroup(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBServiceLaborGroupExt = timerfactory.Create<BusInterface.ICLM_ESBServiceLaborGroup>(_CLM_ESBServiceLaborGroup);
			
			return iCLM_ESBServiceLaborGroupExt;
		}
	}
}
