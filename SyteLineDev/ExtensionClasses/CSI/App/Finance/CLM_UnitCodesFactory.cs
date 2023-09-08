//PROJECT NAME: Finance
//CLASS NAME: CLM_UnitCodesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_UnitCodesFactory
	{
		public ICLM_UnitCodes Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_UnitCodes = new Finance.CLM_UnitCodes(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_UnitCodesExt = timerfactory.Create<Finance.ICLM_UnitCodes>(_CLM_UnitCodes);
			
			return iCLM_UnitCodesExt;
		}
	}
}
