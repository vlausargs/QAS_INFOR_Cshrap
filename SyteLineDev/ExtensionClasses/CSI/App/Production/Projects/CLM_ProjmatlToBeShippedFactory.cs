//PROJECT NAME: Production
//CLASS NAME: CLM_ProjmatlToBeShippedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class CLM_ProjmatlToBeShippedFactory
	{
		public ICLM_ProjmatlToBeShipped Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ProjmatlToBeShipped = new Production.Projects.CLM_ProjmatlToBeShipped(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ProjmatlToBeShippedExt = timerfactory.Create<Production.Projects.ICLM_ProjmatlToBeShipped>(_CLM_ProjmatlToBeShipped);
			
			return iCLM_ProjmatlToBeShippedExt;
		}
	}
}
