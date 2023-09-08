//PROJECT NAME: Production
//CLASS NAME: RSQC_CanCloseProcessFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CanCloseProcessFactory
	{
		public IRSQC_CanCloseProcess Create(IApplicationDB appDB)
		{
			var _RSQC_CanCloseProcess = new Production.Quality.RSQC_CanCloseProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CanCloseProcessExt = timerfactory.Create<Production.Quality.IRSQC_CanCloseProcess>(_RSQC_CanCloseProcess);
			
			return iRSQC_CanCloseProcessExt;
		}
	}
}
