//PROJECT NAME: Logistics
//CLASS NAME: Home_VendorAnalysisFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Home_VendorAnalysisFactory
	{
		public IHome_VendorAnalysis Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_VendorAnalysis = new Logistics.Customer.Home_VendorAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_VendorAnalysisExt = timerfactory.Create<Logistics.Customer.IHome_VendorAnalysis>(_Home_VendorAnalysis);
			
			return iHome_VendorAnalysisExt;
		}
	}
}
