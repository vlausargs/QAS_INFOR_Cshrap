//PROJECT NAME: Production
//CLASS NAME: CLM_JobsReferencingProjectsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class CLM_JobsReferencingProjectsFactory
	{
		public ICLM_JobsReferencingProjects Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_JobsReferencingProjects = new Production.CLM_JobsReferencingProjects(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_JobsReferencingProjectsExt = timerfactory.Create<Production.ICLM_JobsReferencingProjects>(_CLM_JobsReferencingProjects);
			
			return iCLM_JobsReferencingProjectsExt;
		}
	}
}
