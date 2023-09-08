//PROJECT NAME: BusInterface
//CLASS NAME: SerialSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class SerialSaveFactory
	{
		public ISerialSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SerialSave = new BusInterface.SerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSerialSaveExt = timerfactory.Create<BusInterface.ISerialSave>(_SerialSave);
			
			return iSerialSaveExt;
		}
	}
}
