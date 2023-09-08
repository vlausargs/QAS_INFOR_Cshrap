//PROJECT NAME: Production
//CLASS NAME: CLM_ContainerItemsForCompareToProjResFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class CLM_ContainerItemsForCompareToProjResFactory
	{
		public ICLM_ContainerItemsForCompareToProjRes Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ContainerItemsForCompareToProjRes = new Production.Projects.CLM_ContainerItemsForCompareToProjRes(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ContainerItemsForCompareToProjResExt = timerfactory.Create<Production.Projects.ICLM_ContainerItemsForCompareToProjRes>(_CLM_ContainerItemsForCompareToProjRes);
			
			return iCLM_ContainerItemsForCompareToProjResExt;
		}
	}
}
