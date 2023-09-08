//PROJECT NAME: Production
//CLASS NAME: RSQC_GetJobDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetJobDataFactory
	{
		public IRSQC_GetJobData Create(IApplicationDB appDB)
		{
			var _RSQC_GetJobData = new Production.Quality.RSQC_GetJobData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetJobDataExt = timerfactory.Create<Production.Quality.IRSQC_GetJobData>(_RSQC_GetJobData);
			
			return iRSQC_GetJobDataExt;
		}
	}
}
