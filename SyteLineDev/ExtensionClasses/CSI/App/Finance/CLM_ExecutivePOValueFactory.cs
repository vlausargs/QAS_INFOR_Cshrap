//PROJECT NAME: Finance
//CLASS NAME: CLM_ExecutivePOValueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_ExecutivePOValueFactory
	{
		public ICLM_ExecutivePOValue Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ExecutivePOValue = new Finance.CLM_ExecutivePOValue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ExecutivePOValueExt = timerfactory.Create<Finance.ICLM_ExecutivePOValue>(_CLM_ExecutivePOValue);
			
			return iCLM_ExecutivePOValueExt;
		}
	}
}
