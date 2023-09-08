//PROJECT NAME: Codes
//CLASS NAME: CLM_DimSubscriptionsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class CLM_DimSubscriptionsFactory
	{
		public ICLM_DimSubscriptions Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_DimSubscriptions = new Codes.CLM_DimSubscriptions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_DimSubscriptionsExt = timerfactory.Create<Codes.ICLM_DimSubscriptions>(_CLM_DimSubscriptions);
			
			return iCLM_DimSubscriptionsExt;
		}
	}
}
