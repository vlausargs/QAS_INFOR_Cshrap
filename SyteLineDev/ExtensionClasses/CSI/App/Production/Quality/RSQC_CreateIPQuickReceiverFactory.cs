//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateIPQuickReceiverFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateIPQuickReceiverFactory
	{
		public IRSQC_CreateIPQuickReceiver Create(IApplicationDB appDB)
		{
			var _RSQC_CreateIPQuickReceiver = new Production.Quality.RSQC_CreateIPQuickReceiver(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateIPQuickReceiverExt = timerfactory.Create<Production.Quality.IRSQC_CreateIPQuickReceiver>(_RSQC_CreateIPQuickReceiver);
			
			return iRSQC_CreateIPQuickReceiverExt;
		}
	}
}
