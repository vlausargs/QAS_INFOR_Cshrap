//PROJECT NAME: CSICustomer
//CLASS NAME: FormatAddressWhseFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class FormatAddressWhseFactory
	{
		public IFormatAddressWhse Create(IApplicationDB appDB)
		{
			var _FormatAddressWhse = new Logistics.Customer.FormatAddressWhse(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFormatAddressWhseExt = timerfactory.Create<Logistics.Customer.IFormatAddressWhse>(_FormatAddressWhse);
			
			return iFormatAddressWhseExt;
		}
	}
}
