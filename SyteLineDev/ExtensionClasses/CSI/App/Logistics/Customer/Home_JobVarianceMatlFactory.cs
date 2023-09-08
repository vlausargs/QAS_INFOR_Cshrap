//PROJECT NAME: Logistics
//CLASS NAME: Home_JobVarianceMatlFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Home_JobVarianceMatlFactory
	{
		public IHome_JobVarianceMatl Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_JobVarianceMatl = new Logistics.Customer.Home_JobVarianceMatl(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_JobVarianceMatlExt = timerfactory.Create<Logistics.Customer.IHome_JobVarianceMatl>(_Home_JobVarianceMatl);
			
			return iHome_JobVarianceMatlExt;
		}
	}
}
