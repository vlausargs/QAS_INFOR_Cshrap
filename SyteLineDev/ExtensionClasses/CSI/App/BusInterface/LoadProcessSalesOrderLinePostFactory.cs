//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadProcessSalesOrderLinePostFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadProcessSalesOrderLinePostFactory
	{
		public ILoadProcessSalesOrderLinePost Create(IApplicationDB appDB)
		{
			var _LoadProcessSalesOrderLinePost = new BusInterface.LoadProcessSalesOrderLinePost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadProcessSalesOrderLinePostExt = timerfactory.Create<BusInterface.ILoadProcessSalesOrderLinePost>(_LoadProcessSalesOrderLinePost);
			
			return iLoadProcessSalesOrderLinePostExt;
		}
	}
}
