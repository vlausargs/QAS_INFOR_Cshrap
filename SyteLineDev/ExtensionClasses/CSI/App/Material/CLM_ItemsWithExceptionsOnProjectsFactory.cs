//PROJECT NAME: Material
//CLASS NAME: CLM_ItemsWithExceptionsOnProjectsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_ItemsWithExceptionsOnProjectsFactory
	{
		public ICLM_ItemsWithExceptionsOnProjects Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ItemsWithExceptionsOnProjects = new Material.CLM_ItemsWithExceptionsOnProjects(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ItemsWithExceptionsOnProjectsExt = timerfactory.Create<Material.ICLM_ItemsWithExceptionsOnProjects>(_CLM_ItemsWithExceptionsOnProjects);
			
			return iCLM_ItemsWithExceptionsOnProjectsExt;
		}
	}
}
