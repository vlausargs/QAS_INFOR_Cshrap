//PROJECT NAME: Production
//CLASS NAME: RSQC_XRefTopicFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_XRefTopicFactory
	{
		public IRSQC_XRefTopic Create(IApplicationDB appDB)
		{
			var _RSQC_XRefTopic = new Production.Quality.RSQC_XRefTopic(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_XRefTopicExt = timerfactory.Create<Production.Quality.IRSQC_XRefTopic>(_RSQC_XRefTopic);
			
			return iRSQC_XRefTopicExt;
		}
	}
}
