//PROJECT NAME: Logistics
//CLASS NAME: CLM_ApsCustIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_ApsCustIdFactory
	{
		public ICLM_ApsCustId Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsCustId = new Logistics.Customer.CLM_ApsCustId(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsCustIdExt = timerfactory.Create<Logistics.Customer.ICLM_ApsCustId>(_CLM_ApsCustId);
			
			return iCLM_ApsCustIdExt;
		}
	}
}
