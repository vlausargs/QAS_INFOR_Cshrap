//PROJECT NAME: Logistics
//CLASS NAME: PurgeTmpPickListLocSerialFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class PurgeTmpPickListLocSerialFactory
	{
		public IPurgeTmpPickListLocSerial Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PurgeTmpPickListLocSerial = new Logistics.Customer.PurgeTmpPickListLocSerial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeTmpPickListLocSerialExt = timerfactory.Create<Logistics.Customer.IPurgeTmpPickListLocSerial>(_PurgeTmpPickListLocSerial);
			
			return iPurgeTmpPickListLocSerialExt;
		}
	}
}
