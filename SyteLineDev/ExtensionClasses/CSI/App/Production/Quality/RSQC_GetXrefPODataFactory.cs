//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefPODataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefPODataFactory
	{
		public IRSQC_GetXrefPOData Create(IApplicationDB appDB)
		{
			var _RSQC_GetXrefPOData = new Production.Quality.RSQC_GetXrefPOData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetXrefPODataExt = timerfactory.Create<Production.Quality.IRSQC_GetXrefPOData>(_RSQC_GetXrefPOData);
			
			return iRSQC_GetXrefPODataExt;
		}
	}
}
