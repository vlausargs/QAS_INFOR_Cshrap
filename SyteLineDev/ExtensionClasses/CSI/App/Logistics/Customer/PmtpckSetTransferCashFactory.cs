//PROJECT NAME: CSICustomer
//CLASS NAME: PmtpckSetTransferCashFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PmtpckSetTransferCashFactory
	{
		public IPmtpckSetTransferCash Create(IApplicationDB appDB)
		{
			var _PmtpckSetTransferCash = new Logistics.Customer.PmtpckSetTransferCash(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmtpckSetTransferCashExt = timerfactory.Create<Logistics.Customer.IPmtpckSetTransferCash>(_PmtpckSetTransferCash);
			
			return iPmtpckSetTransferCashExt;
		}
	}
}
