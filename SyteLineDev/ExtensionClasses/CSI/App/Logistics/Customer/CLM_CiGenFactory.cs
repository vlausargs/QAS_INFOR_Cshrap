//PROJECT NAME: Logistics
//CLASS NAME: CLM_CiGenFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_CiGenFactory
	{
		public ICLM_CiGen Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CiGen = new Logistics.Customer.CLM_CiGen(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CiGenExt = timerfactory.Create<Logistics.Customer.ICLM_CiGen>(_CLM_CiGen);
			
			return iCLM_CiGenExt;
		}
	}
}
