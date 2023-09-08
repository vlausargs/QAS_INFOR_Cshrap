//PROJECT NAME: Production
//CLASS NAME: RSQC_CreatePSReceiverFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreatePSReceiverFactory
	{
		public IRSQC_CreatePSReceiver Create(IApplicationDB appDB)
		{
			var _RSQC_CreatePSReceiver = new Production.Quality.RSQC_CreatePSReceiver(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreatePSReceiverExt = timerfactory.Create<Production.Quality.IRSQC_CreatePSReceiver>(_RSQC_CreatePSReceiver);
			
			return iRSQC_CreatePSReceiverExt;
		}
	}
}
