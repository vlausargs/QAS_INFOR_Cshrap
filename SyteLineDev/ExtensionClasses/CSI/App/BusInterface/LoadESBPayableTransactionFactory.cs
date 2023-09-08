//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBPayableTransactionFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadESBPayableTransactionFactory
	{
		public ILoadESBPayableTransaction Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadESBPayableTransaction = new BusInterface.LoadESBPayableTransaction(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBPayableTransactionExt = timerfactory.Create<BusInterface.ILoadESBPayableTransaction>(_LoadESBPayableTransaction);
			
			return iLoadESBPayableTransactionExt;
		}
	}
}
