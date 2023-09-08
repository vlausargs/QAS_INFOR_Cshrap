//PROJECT NAME: Logistics
//CLASS NAME: ProfilesDunningReportFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfilesDunningReportFactory
	{
		public IProfilesDunningReport Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfilesDunningReport = new Logistics.Customer.ProfilesDunningReport(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfilesDunningReportExt = timerfactory.Create<Logistics.Customer.IProfilesDunningReport>(_ProfilesDunningReport);
			
			return iProfilesDunningReportExt;
		}
	}
}
