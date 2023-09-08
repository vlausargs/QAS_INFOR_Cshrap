//PROJECT NAME: Production
//CLASS NAME: CLM_LoadProjectResourceChangeDetailFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class CLM_LoadProjectResourceChangeDetailFactory
	{
		public ICLM_LoadProjectResourceChangeDetail Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_LoadProjectResourceChangeDetail = new Production.Projects.CLM_LoadProjectResourceChangeDetail(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_LoadProjectResourceChangeDetailExt = timerfactory.Create<Production.Projects.ICLM_LoadProjectResourceChangeDetail>(_CLM_LoadProjectResourceChangeDetail);
			
			return iCLM_LoadProjectResourceChangeDetailExt;
		}
	}
}
