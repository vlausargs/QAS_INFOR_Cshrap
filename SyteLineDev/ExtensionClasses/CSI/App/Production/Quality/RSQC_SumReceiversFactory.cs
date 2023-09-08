//PROJECT NAME: Production
//CLASS NAME: RSQC_SumReceiversFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SumReceiversFactory
	{
		public IRSQC_SumReceivers Create(IApplicationDB appDB)
		{
			var _RSQC_SumReceivers = new Production.Quality.RSQC_SumReceivers(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_SumReceiversExt = timerfactory.Create<Production.Quality.IRSQC_SumReceivers>(_RSQC_SumReceivers);
			
			return iRSQC_SumReceiversExt;
		}
	}
}
