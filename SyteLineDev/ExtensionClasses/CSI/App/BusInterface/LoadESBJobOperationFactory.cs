//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBJobOperationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadESBJobOperationFactory
	{
		public ILoadESBJobOperation Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadESBJobOperation = new BusInterface.LoadESBJobOperation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBJobOperationExt = timerfactory.Create<BusInterface.ILoadESBJobOperation>(_LoadESBJobOperation);
			
			return iLoadESBJobOperationExt;
		}
	}
}
