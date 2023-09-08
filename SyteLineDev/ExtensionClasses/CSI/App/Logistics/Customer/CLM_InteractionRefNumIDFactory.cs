//PROJECT NAME: Logistics
//CLASS NAME: CLM_InteractionRefNumIDFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_InteractionRefNumIDFactory
	{
		public ICLM_InteractionRefNumID Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_InteractionRefNumID = new Logistics.Customer.CLM_InteractionRefNumID(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_InteractionRefNumIDExt = timerfactory.Create<Logistics.Customer.ICLM_InteractionRefNumID>(_CLM_InteractionRefNumID);
			
			return iCLM_InteractionRefNumIDExt;
		}
	}
}
