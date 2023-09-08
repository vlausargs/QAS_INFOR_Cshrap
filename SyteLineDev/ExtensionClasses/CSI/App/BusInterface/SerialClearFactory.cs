//PROJECT NAME: BusInterface
//CLASS NAME: SerialClearFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class SerialClearFactory
	{
		public ISerialClear Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SerialClear = new BusInterface.SerialClear(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSerialClearExt = timerfactory.Create<BusInterface.ISerialClear>(_SerialClear);
			
			return iSerialClearExt;
		}
	}
}
