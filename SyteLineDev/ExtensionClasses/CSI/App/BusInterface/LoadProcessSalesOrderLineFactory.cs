//PROJECT NAME: BusInterface
//CLASS NAME: LoadProcessSalesOrderLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadProcessSalesOrderLineFactory
	{
		public ILoadProcessSalesOrderLine Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadProcessSalesOrderLine = new BusInterface.LoadProcessSalesOrderLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadProcessSalesOrderLineExt = timerfactory.Create<BusInterface.ILoadProcessSalesOrderLine>(_LoadProcessSalesOrderLine);
			
			return iLoadProcessSalesOrderLineExt;
		}
	}
}
