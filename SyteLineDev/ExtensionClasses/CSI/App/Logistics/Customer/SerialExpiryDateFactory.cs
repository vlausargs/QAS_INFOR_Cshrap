//PROJECT NAME: Logistics
//CLASS NAME: SerialExpiryDateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SerialExpiryDateFactory
	{
		public ISerialExpiryDate Create(IApplicationDB appDB)
		{
			var _SerialExpiryDate = new Logistics.Customer.SerialExpiryDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSerialExpiryDateExt = timerfactory.Create<Logistics.Customer.ISerialExpiryDate>(_SerialExpiryDate);
			
			return iSerialExpiryDateExt;
		}
	}
}
