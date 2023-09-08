//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefJobDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefJobDataFactory
	{
		public IRSQC_GetXrefJobData Create(IApplicationDB appDB)
		{
			var _RSQC_GetXrefJobData = new Production.Quality.RSQC_GetXrefJobData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetXrefJobDataExt = timerfactory.Create<Production.Quality.IRSQC_GetXrefJobData>(_RSQC_GetXrefJobData);
			
			return iRSQC_GetXrefJobDataExt;
		}
	}
}
