//PROJECT NAME: Logistics
//CLASS NAME: CLM_MobileDPOFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_MobileDPOFactory
	{
		public ICLM_MobileDPO Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_MobileDPO = new Logistics.Customer.CLM_MobileDPO(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_MobileDPOExt = timerfactory.Create<Logistics.Customer.ICLM_MobileDPO>(_CLM_MobileDPO);
			
			return iCLM_MobileDPOExt;
		}
	}
}
