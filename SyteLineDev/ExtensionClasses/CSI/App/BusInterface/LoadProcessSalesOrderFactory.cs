//PROJECT NAME: BusInterface
//CLASS NAME: LoadProcessSalesOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadProcessSalesOrderFactory
	{
		public ILoadProcessSalesOrder Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadProcessSalesOrder = new BusInterface.LoadProcessSalesOrder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadProcessSalesOrderExt = timerfactory.Create<BusInterface.ILoadProcessSalesOrder>(_LoadProcessSalesOrder);
			
			return iLoadProcessSalesOrderExt;
		}
	}
}
