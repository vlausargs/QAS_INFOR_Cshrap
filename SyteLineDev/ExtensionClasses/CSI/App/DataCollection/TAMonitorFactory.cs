//PROJECT NAME: DataCollection
//CLASS NAME: TAMonitorFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.DataCollection
{
	public class TAMonitorFactory
	{
		public ITAMonitor Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _TAMonitor = new DataCollection.TAMonitor(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTAMonitorExt = timerfactory.Create<DataCollection.ITAMonitor>(_TAMonitor);
			
			return iTAMonitorExt;
		}
	}
}
