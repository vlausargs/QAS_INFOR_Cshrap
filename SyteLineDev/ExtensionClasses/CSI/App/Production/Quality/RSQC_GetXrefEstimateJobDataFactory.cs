//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefEstimateJobDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefEstimateJobDataFactory
	{
		public IRSQC_GetXrefEstimateJobData Create(IApplicationDB appDB)
		{
			var _RSQC_GetXrefEstimateJobData = new Production.Quality.RSQC_GetXrefEstimateJobData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetXrefEstimateJobDataExt = timerfactory.Create<Production.Quality.IRSQC_GetXrefEstimateJobData>(_RSQC_GetXrefEstimateJobData);
			
			return iRSQC_GetXrefEstimateJobDataExt;
		}
	}
}
