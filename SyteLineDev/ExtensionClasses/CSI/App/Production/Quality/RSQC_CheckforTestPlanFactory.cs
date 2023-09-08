//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckforTestPlanFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckforTestPlanFactory
	{
		public IRSQC_CheckforTestPlan Create(IApplicationDB appDB)
		{
			var _RSQC_CheckforTestPlan = new Production.Quality.RSQC_CheckforTestPlan(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CheckforTestPlanExt = timerfactory.Create<Production.Quality.IRSQC_CheckforTestPlan>(_RSQC_CheckforTestPlan);
			
			return iRSQC_CheckforTestPlanExt;
		}
	}
}
