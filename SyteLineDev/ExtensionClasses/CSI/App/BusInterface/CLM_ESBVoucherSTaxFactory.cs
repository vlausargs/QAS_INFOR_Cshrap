//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBVoucherSTaxFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBVoucherSTaxFactory
	{
		public ICLM_ESBVoucherSTax Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBVoucherSTax = new BusInterface.CLM_ESBVoucherSTax(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBVoucherSTaxExt = timerfactory.Create<BusInterface.ICLM_ESBVoucherSTax>(_CLM_ESBVoucherSTax);
			
			return iCLM_ESBVoucherSTaxExt;
		}
	}
}
