//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefCMRDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefCMRDataFactory
	{
		public IRSQC_GetXrefCMRData Create(IApplicationDB appDB)
		{
			var _RSQC_GetXrefCMRData = new Production.Quality.RSQC_GetXrefCMRData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetXrefCMRDataExt = timerfactory.Create<Production.Quality.IRSQC_GetXrefCMRData>(_RSQC_GetXrefCMRData);
			
			return iRSQC_GetXrefCMRDataExt;
		}
	}
}
