//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBReceivableTransactionFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBReceivableTransactionFactory
	{
		public ILoadESBReceivableTransaction Create(IApplicationDB appDB)
		{
			var _LoadESBReceivableTransaction = new BusInterface.LoadESBReceivableTransaction(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBReceivableTransactionExt = timerfactory.Create<BusInterface.ILoadESBReceivableTransaction>(_LoadESBReceivableTransaction);
			
			return iLoadESBReceivableTransactionExt;
		}
	}
}
