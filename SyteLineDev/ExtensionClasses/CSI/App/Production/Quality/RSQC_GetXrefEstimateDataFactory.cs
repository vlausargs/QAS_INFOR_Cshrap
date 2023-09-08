//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefEstimateDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefEstimateDataFactory
	{
		public IRSQC_GetXrefEstimateData Create(IApplicationDB appDB)
		{
			var _RSQC_GetXrefEstimateData = new Production.Quality.RSQC_GetXrefEstimateData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetXrefEstimateDataExt = timerfactory.Create<Production.Quality.IRSQC_GetXrefEstimateData>(_RSQC_GetXrefEstimateData);
			
			return iRSQC_GetXrefEstimateDataExt;
		}
	}
}
