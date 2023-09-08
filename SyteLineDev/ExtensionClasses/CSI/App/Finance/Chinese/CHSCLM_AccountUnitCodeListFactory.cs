//PROJECT NAME: Finance
//CLASS NAME: CHSCLM_AccountUnitCodeListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance.Chinese
{
	public class CHSCLM_AccountUnitCodeListFactory
	{
		public ICHSCLM_AccountUnitCodeList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSCLM_AccountUnitCodeList = new Finance.Chinese.CHSCLM_AccountUnitCodeList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSCLM_AccountUnitCodeListExt = timerfactory.Create<Finance.Chinese.ICHSCLM_AccountUnitCodeList>(_CHSCLM_AccountUnitCodeList);
			
			return iCHSCLM_AccountUnitCodeListExt;
		}
	}
}
