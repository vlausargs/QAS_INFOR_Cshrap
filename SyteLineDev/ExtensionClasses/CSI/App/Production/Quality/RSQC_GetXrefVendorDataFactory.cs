//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefVendorDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefVendorDataFactory
	{
		public IRSQC_GetXrefVendorData Create(IApplicationDB appDB)
		{
			var _RSQC_GetXrefVendorData = new Production.Quality.RSQC_GetXrefVendorData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetXrefVendorDataExt = timerfactory.Create<Production.Quality.IRSQC_GetXrefVendorData>(_RSQC_GetXrefVendorData);
			
			return iRSQC_GetXrefVendorDataExt;
		}
	}
}
