//PROJECT NAME: CSICustomer
//CLASS NAME: FormatContactAddressFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class FormatContactAddressFactory
	{
		public IFormatContactAddress Create(IApplicationDB appDB)
		{
			var _FormatContactAddress = new Logistics.Customer.FormatContactAddress(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFormatContactAddressExt = timerfactory.Create<Logistics.Customer.IFormatContactAddress>(_FormatContactAddress);
			
			return iFormatContactAddressExt;
		}
	}
}
