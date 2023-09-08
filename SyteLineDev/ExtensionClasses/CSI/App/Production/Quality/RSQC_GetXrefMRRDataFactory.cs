//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefMRRDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefMRRDataFactory
	{
		public IRSQC_GetXrefMRRData Create(IApplicationDB appDB)
		{
			var _RSQC_GetXrefMRRData = new Production.Quality.RSQC_GetXrefMRRData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetXrefMRRDataExt = timerfactory.Create<Production.Quality.IRSQC_GetXrefMRRData>(_RSQC_GetXrefMRRData);
			
			return iRSQC_GetXrefMRRDataExt;
		}
	}
}
