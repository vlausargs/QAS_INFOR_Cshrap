//PROJECT NAME: Logistics
//CLASS NAME: GenerateTmpPackListSerialFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateTmpPackListSerialFactory
	{
		public IGenerateTmpPackListSerial Create(IApplicationDB appDB)
		{
			var _GenerateTmpPackListSerial = new Logistics.Customer.GenerateTmpPackListSerial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateTmpPackListSerialExt = timerfactory.Create<Logistics.Customer.IGenerateTmpPackListSerial>(_GenerateTmpPackListSerial);
			
			return iGenerateTmpPackListSerialExt;
		}
	}
}
