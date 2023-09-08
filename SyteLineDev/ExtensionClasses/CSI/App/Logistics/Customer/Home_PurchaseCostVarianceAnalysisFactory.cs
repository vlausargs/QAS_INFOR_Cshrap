//PROJECT NAME: Logistics
//CLASS NAME: Home_PurchaseCostVarianceAnalysisFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Home_PurchaseCostVarianceAnalysisFactory
	{
		public IHome_PurchaseCostVarianceAnalysis Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_PurchaseCostVarianceAnalysis = new Logistics.Customer.Home_PurchaseCostVarianceAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_PurchaseCostVarianceAnalysisExt = timerfactory.Create<Logistics.Customer.IHome_PurchaseCostVarianceAnalysis>(_Home_PurchaseCostVarianceAnalysis);
			
			return iHome_PurchaseCostVarianceAnalysisExt;
		}
	}
}
