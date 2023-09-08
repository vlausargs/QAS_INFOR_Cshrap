//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetCOLinesmobiFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetCOLinesmobiFactory
	{
		public ICLM_GetCOLinesmobi Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetCOLinesmobi = new Logistics.Customer.CLM_GetCOLinesmobi(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetCOLinesmobiExt = timerfactory.Create<Logistics.Customer.ICLM_GetCOLinesmobi>(_CLM_GetCOLinesmobi);
			
			return iCLM_GetCOLinesmobiExt;
		}
	}
}
