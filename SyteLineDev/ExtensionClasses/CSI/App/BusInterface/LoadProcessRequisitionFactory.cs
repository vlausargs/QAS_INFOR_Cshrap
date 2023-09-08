//PROJECT NAME: BusInterface
//CLASS NAME: LoadProcessRequisitionFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadProcessRequisitionFactory
	{
		public ILoadProcessRequisition Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadProcessRequisition = new BusInterface.LoadProcessRequisition(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadProcessRequisitionExt = timerfactory.Create<BusInterface.ILoadProcessRequisition>(_LoadProcessRequisition);
			
			return iLoadProcessRequisitionExt;
		}
	}
}
