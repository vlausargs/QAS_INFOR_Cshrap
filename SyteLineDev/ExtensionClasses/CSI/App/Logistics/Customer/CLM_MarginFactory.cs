//PROJECT NAME: Logistics
//CLASS NAME: CLM_MarginFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_MarginFactory
	{
		public ICLM_Margin Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_Margin = new Logistics.Customer.CLM_Margin(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_MarginExt = timerfactory.Create<Logistics.Customer.ICLM_Margin>(_CLM_Margin);
			
			return iCLM_MarginExt;
		}
	}
}
