//PROJECT NAME: Production
//CLASS NAME: RSQC_ValidateVendorFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ValidateVendorFactory
	{
		public IRSQC_ValidateVendor Create(IApplicationDB appDB)
		{
			var _RSQC_ValidateVendor = new Production.Quality.RSQC_ValidateVendor(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ValidateVendorExt = timerfactory.Create<Production.Quality.IRSQC_ValidateVendor>(_RSQC_ValidateVendor);
			
			return iRSQC_ValidateVendorExt;
		}
	}
}
