//PROJECT NAME: Logistics
//CLASS NAME: CLM_InvAdjLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_InvAdjLoadFactory
	{
		public ICLM_InvAdjLoad Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_InvAdjLoad = new Logistics.Customer.CLM_InvAdjLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_InvAdjLoadExt = timerfactory.Create<Logistics.Customer.ICLM_InvAdjLoad>(_CLM_InvAdjLoad);
			
			return iCLM_InvAdjLoadExt;
		}
	}
}
