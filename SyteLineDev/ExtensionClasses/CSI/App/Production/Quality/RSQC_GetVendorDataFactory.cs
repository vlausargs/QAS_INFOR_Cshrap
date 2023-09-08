//PROJECT NAME: Production
//CLASS NAME: RSQC_GetVendorDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetVendorDataFactory
	{
		public IRSQC_GetVendorData Create(IApplicationDB appDB)
		{
			var _RSQC_GetVendorData = new Production.Quality.RSQC_GetVendorData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetVendorDataExt = timerfactory.Create<Production.Quality.IRSQC_GetVendorData>(_RSQC_GetVendorData);
			
			return iRSQC_GetVendorDataExt;
		}
	}
}
