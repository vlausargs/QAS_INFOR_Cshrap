//PROJECT NAME: CSICustomer
//CLASS NAME: PmtpckApplyCompStatusFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PmtpckApplyCompStatusFactory
	{
		public IPmtpckApplyCompStatus Create(IApplicationDB appDB)
		{
			var _PmtpckApplyCompStatus = new Logistics.Customer.PmtpckApplyCompStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmtpckApplyCompStatusExt = timerfactory.Create<Logistics.Customer.IPmtpckApplyCompStatus>(_PmtpckApplyCompStatus);
			
			return iPmtpckApplyCompStatusExt;
		}
	}
}
