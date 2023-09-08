//PROJECT NAME: Logistics
//CLASS NAME: CLM_POsReferencingProjectsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_POsReferencingProjectsFactory
	{
		public ICLM_POsReferencingProjects Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_POsReferencingProjects = new Logistics.Vendor.CLM_POsReferencingProjects(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_POsReferencingProjectsExt = timerfactory.Create<Logistics.Vendor.ICLM_POsReferencingProjects>(_CLM_POsReferencingProjects);
			
			return iCLM_POsReferencingProjectsExt;
		}
	}
}
