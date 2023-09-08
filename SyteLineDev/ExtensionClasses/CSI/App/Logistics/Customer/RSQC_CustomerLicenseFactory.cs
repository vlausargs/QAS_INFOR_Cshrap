//PROJECT NAME: Logistics
//CLASS NAME: RSQC_CustomerLicenseFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RSQC_CustomerLicenseFactory
	{
		public IRSQC_CustomerLicense Create(IApplicationDB appDB)
		{
			var _RSQC_CustomerLicense = new Logistics.Customer.RSQC_CustomerLicense(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CustomerLicenseExt = timerfactory.Create<Logistics.Customer.IRSQC_CustomerLicense>(_RSQC_CustomerLicense);
			
			return iRSQC_CustomerLicenseExt;
		}
	}
}
