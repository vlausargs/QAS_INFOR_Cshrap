//PROJECT NAME: Logistics
//CLASS NAME: GenerateTmpShipSeqSerialFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GenerateTmpShipSeqSerialFactory
	{
		public IGenerateTmpShipSeqSerial Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GenerateTmpShipSeqSerial = new Logistics.Customer.GenerateTmpShipSeqSerial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateTmpShipSeqSerialExt = timerfactory.Create<Logistics.Customer.IGenerateTmpShipSeqSerial>(_GenerateTmpShipSeqSerial);
			
			return iGenerateTmpShipSeqSerialExt;
		}
	}
}
