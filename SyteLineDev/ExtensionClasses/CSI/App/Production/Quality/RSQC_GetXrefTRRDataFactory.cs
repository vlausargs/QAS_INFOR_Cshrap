//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefTRRDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefTRRDataFactory
	{
		public IRSQC_GetXrefTRRData Create(IApplicationDB appDB)
		{
			var _RSQC_GetXrefTRRData = new Production.Quality.RSQC_GetXrefTRRData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetXrefTRRDataExt = timerfactory.Create<Production.Quality.IRSQC_GetXrefTRRData>(_RSQC_GetXrefTRRData);
			
			return iRSQC_GetXrefTRRDataExt;
		}
	}
}
