//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefCODataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefCODataFactory
	{
		public IRSQC_GetXrefCOData Create(IApplicationDB appDB)
		{
			var _RSQC_GetXrefCOData = new Production.Quality.RSQC_GetXrefCOData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetXrefCODataExt = timerfactory.Create<Production.Quality.IRSQC_GetXrefCOData>(_RSQC_GetXrefCOData);
			
			return iRSQC_GetXrefCODataExt;
		}
	}
}
