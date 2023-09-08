//PROJECT NAME: Finance
//CLASS NAME: ExtFinAddBatchToBGQueueFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.ExtFin
{
	public class ExtFinAddBatchToBGQueueFactory
	{
		public IExtFinAddBatchToBGQueue Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ExtFinAddBatchToBGQueue = new Finance.ExtFin.ExtFinAddBatchToBGQueue(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExtFinAddBatchToBGQueueExt = timerfactory.Create<Finance.ExtFin.IExtFinAddBatchToBGQueue>(_ExtFinAddBatchToBGQueue);
			
			return iExtFinAddBatchToBGQueueExt;
		}
	}
}
