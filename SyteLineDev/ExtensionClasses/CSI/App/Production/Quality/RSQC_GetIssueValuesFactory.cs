//PROJECT NAME: Production
//CLASS NAME: RSQC_GetIssueValuesFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetIssueValuesFactory
	{
		public IRSQC_GetIssueValues Create(IApplicationDB appDB)
		{
			var _RSQC_GetIssueValues = new Production.Quality.RSQC_GetIssueValues(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetIssueValuesExt = timerfactory.Create<Production.Quality.IRSQC_GetIssueValues>(_RSQC_GetIssueValues);
			
			return iRSQC_GetIssueValuesExt;
		}
	}
}
