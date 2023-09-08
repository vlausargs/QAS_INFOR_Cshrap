//PROJECT NAME: Production
//CLASS NAME: RSQC_SetItemTestSeqFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SetItemTestSeqFactory
	{
		public IRSQC_SetItemTestSeq Create(IApplicationDB appDB)
		{
			var _RSQC_SetItemTestSeq = new Production.Quality.RSQC_SetItemTestSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_SetItemTestSeqExt = timerfactory.Create<Production.Quality.IRSQC_SetItemTestSeq>(_RSQC_SetItemTestSeq);
			
			return iRSQC_SetItemTestSeqExt;
		}
	}
}
