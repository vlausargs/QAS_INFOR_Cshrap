//PROJECT NAME: CSICustomer
//CLASS NAME: FormatProspectAddressFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class FormatProspectAddressFactory
	{
		public IFormatProspectAddress Create(IApplicationDB appDB)
		{
			var _FormatProspectAddress = new Logistics.Customer.FormatProspectAddress(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFormatProspectAddressExt = timerfactory.Create<Logistics.Customer.IFormatProspectAddress>(_FormatProspectAddress);
			
			return iFormatProspectAddressExt;
		}
	}
}
