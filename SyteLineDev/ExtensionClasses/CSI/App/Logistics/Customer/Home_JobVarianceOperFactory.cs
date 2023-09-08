//PROJECT NAME: Logistics
//CLASS NAME: Home_JobVarianceOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Home_JobVarianceOperFactory
	{
		public IHome_JobVarianceOper Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_JobVarianceOper = new Logistics.Customer.Home_JobVarianceOper(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_JobVarianceOperExt = timerfactory.Create<Logistics.Customer.IHome_JobVarianceOper>(_Home_JobVarianceOper);
			
			return iHome_JobVarianceOperExt;
		}
	}
}
