//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSupplierBalanceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSupplierBalanceFactory
	{
		public ICLM_ESBSupplierBalance Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSupplierBalance = new BusInterface.CLM_ESBSupplierBalance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSupplierBalanceExt = timerfactory.Create<BusInterface.ICLM_ESBSupplierBalance>(_CLM_ESBSupplierBalance);
			
			return iCLM_ESBSupplierBalanceExt;
		}
	}
}
