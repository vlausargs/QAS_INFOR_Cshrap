//PROJECT NAME: Material
//CLASS NAME: Home_MRPOrderActionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class Home_MRPOrderActionFactory
	{
		public IHome_MRPOrderAction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_MRPOrderAction = new Material.Home_MRPOrderAction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_MRPOrderActionExt = timerfactory.Create<Material.IHome_MRPOrderAction>(_Home_MRPOrderAction);
			
			return iHome_MRPOrderActionExt;
		}
	}
}
