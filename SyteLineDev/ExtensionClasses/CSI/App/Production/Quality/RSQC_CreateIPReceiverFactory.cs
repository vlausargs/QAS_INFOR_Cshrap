//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateIPReceiverFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateIPReceiverFactory
	{
		public IRSQC_CreateIPReceiver Create(IApplicationDB appDB)
		{
			var _RSQC_CreateIPReceiver = new Production.Quality.RSQC_CreateIPReceiver(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateIPReceiverExt = timerfactory.Create<Production.Quality.IRSQC_CreateIPReceiver>(_RSQC_CreateIPReceiver);
			
			return iRSQC_CreateIPReceiverExt;
		}
	}
}
