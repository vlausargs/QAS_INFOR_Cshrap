//PROJECT NAME: Logistics
//CLASS NAME: CLM_MobileDSOFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_MobileDSOFactory
	{
		public ICLM_MobileDSO Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_MobileDSO = new Logistics.Customer.CLM_MobileDSO(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_MobileDSOExt = timerfactory.Create<Logistics.Customer.ICLM_MobileDSO>(_CLM_MobileDSO);
			
			return iCLM_MobileDSOExt;
		}
	}
}
