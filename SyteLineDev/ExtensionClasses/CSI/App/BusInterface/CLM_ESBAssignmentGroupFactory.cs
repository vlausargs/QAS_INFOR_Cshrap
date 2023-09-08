//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBAssignmentGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBAssignmentGroupFactory
	{
		public ICLM_ESBAssignmentGroup Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBAssignmentGroup = new BusInterface.CLM_ESBAssignmentGroup(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBAssignmentGroupExt = timerfactory.Create<BusInterface.ICLM_ESBAssignmentGroup>(_CLM_ESBAssignmentGroup);
			
			return iCLM_ESBAssignmentGroupExt;
		}
	}
}
