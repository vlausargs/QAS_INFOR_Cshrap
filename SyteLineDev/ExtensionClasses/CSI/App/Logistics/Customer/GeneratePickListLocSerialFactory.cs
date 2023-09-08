//PROJECT NAME: CSICustomer
//CLASS NAME: GeneratePickListLocSerialFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GeneratePickListLocSerialFactory
	{
		public IGeneratePickListLocSerial Create(IApplicationDB appDB)
		{
			var _GeneratePickListLocSerial = new Logistics.Customer.GeneratePickListLocSerial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGeneratePickListLocSerialExt = timerfactory.Create<Logistics.Customer.IGeneratePickListLocSerial>(_GeneratePickListLocSerial);
			
			return iGeneratePickListLocSerialExt;
		}
	}
}
