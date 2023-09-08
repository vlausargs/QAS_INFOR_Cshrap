//PROJECT NAME: Logistics
//CLASS NAME: CLM_TmpCoShipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_TmpCoShipFactory
	{
		public ICLM_TmpCoShip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_TmpCoShip = new Logistics.Customer.CLM_TmpCoShip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_TmpCoShipExt = timerfactory.Create<Logistics.Customer.ICLM_TmpCoShip>(_CLM_TmpCoShip);
			
			return iCLM_TmpCoShipExt;
		}
	}
}
