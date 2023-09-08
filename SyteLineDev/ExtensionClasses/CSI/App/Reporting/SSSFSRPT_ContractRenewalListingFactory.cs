//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRPT_ContractRenewalListingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRPT_ContractRenewalListingFactory
	{
		public ISSSFSRPT_ContractRenewalListing Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRPT_ContractRenewalListing = new Reporting.SSSFSRPT_ContractRenewalListing(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRPT_ContractRenewalListingExt = timerfactory.Create<Reporting.ISSSFSRPT_ContractRenewalListing>(_SSSFSRPT_ContractRenewalListing);
			
			return iSSSFSRPT_ContractRenewalListingExt;
		}
	}
}
