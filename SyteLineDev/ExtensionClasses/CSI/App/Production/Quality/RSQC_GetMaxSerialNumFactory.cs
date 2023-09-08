//PROJECT NAME: Production
//CLASS NAME: RSQC_GetMaxSerialNumFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetMaxSerialNumFactory
	{
		public IRSQC_GetMaxSerialNum Create(IApplicationDB appDB)
		{
			var _RSQC_GetMaxSerialNum = new Production.Quality.RSQC_GetMaxSerialNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetMaxSerialNumExt = timerfactory.Create<Production.Quality.IRSQC_GetMaxSerialNum>(_RSQC_GetMaxSerialNum);
			
			return iRSQC_GetMaxSerialNumExt;
		}
	}
}
