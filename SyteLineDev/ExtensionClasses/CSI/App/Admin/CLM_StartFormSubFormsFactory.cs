//PROJECT NAME: Admin
//CLASS NAME: CLM_StartFormSubFormsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CLM_StartFormSubFormsFactory
	{
		public ICLM_StartFormSubForms Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_StartFormSubForms = new Admin.CLM_StartFormSubForms(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_StartFormSubFormsExt = timerfactory.Create<Admin.ICLM_StartFormSubForms>(_CLM_StartFormSubForms);
			
			return iCLM_StartFormSubFormsExt;
		}
	}
}
