//PROJECT NAME: Logistics
//CLASS NAME: CLM_ArPmtpckFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_ArPmtpckFactory
	{
		public ICLM_ArPmtpck Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ArPmtpck = new Logistics.Customer.CLM_ArPmtpck(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ArPmtpckExt = timerfactory.Create<Logistics.Customer.ICLM_ArPmtpck>(_CLM_ArPmtpck);
			
			return iCLM_ArPmtpckExt;
		}
	}
}
