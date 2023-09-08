//PROJECT NAME: Production
//CLASS NAME: WBSPercCompleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class WBSPercCompleteFactory
	{
		public IWBSPercComplete Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _WBSPercComplete = new Production.Projects.WBSPercComplete(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWBSPercCompleteExt = timerfactory.Create<Production.Projects.IWBSPercComplete>(_WBSPercComplete);
			
			return iWBSPercCompleteExt;
		}
	}
}
