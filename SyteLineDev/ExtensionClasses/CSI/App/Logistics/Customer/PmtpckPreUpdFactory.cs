//PROJECT NAME: CSICustomer
//CLASS NAME: PmtpckPreUpdFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PmtpckPreUpdFactory
	{
		public IPmtpckPreUpd Create(IApplicationDB appDB)
		{
			var _PmtpckPreUpd = new Logistics.Customer.PmtpckPreUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmtpckPreUpdExt = timerfactory.Create<Logistics.Customer.IPmtpckPreUpd>(_PmtpckPreUpd);
			
			return iPmtpckPreUpdExt;
		}
	}
}
