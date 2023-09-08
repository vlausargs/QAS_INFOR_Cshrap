//PROJECT NAME: Admin
//CLASS NAME: CLM_ExtMsgEntitiesWbkpiEffectiveFormsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CLM_ExtMsgEntitiesWbkpiEffectiveFormsFactory
	{
		public ICLM_ExtMsgEntitiesWbkpiEffectiveForms Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ExtMsgEntitiesWbkpiEffectiveForms = new Admin.CLM_ExtMsgEntitiesWbkpiEffectiveForms(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ExtMsgEntitiesWbkpiEffectiveFormsExt = timerfactory.Create<Admin.ICLM_ExtMsgEntitiesWbkpiEffectiveForms>(_CLM_ExtMsgEntitiesWbkpiEffectiveForms);
			
			return iCLM_ExtMsgEntitiesWbkpiEffectiveFormsExt;
		}
	}
}
