//PROJECT NAME: BusInterface
//CLASS NAME: SupplyWEBInPoAckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class SupplyWEBInPoAckFactory
	{
		public ISupplyWEBInPoAck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SupplyWEBInPoAck = new BusInterface.SupplyWEBInPoAck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSupplyWEBInPoAckExt = timerfactory.Create<BusInterface.ISupplyWEBInPoAck>(_SupplyWEBInPoAck);
			
			return iSupplyWEBInPoAckExt;
		}
	}
}
