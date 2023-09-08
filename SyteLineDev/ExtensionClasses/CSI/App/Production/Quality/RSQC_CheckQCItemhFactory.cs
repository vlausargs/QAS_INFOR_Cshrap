//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckQCItemhFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckQCItemhFactory
	{
		public IRSQC_CheckQCItemh Create(IApplicationDB appDB)
		{
			var _RSQC_CheckQCItemh = new Production.Quality.RSQC_CheckQCItemh(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CheckQCItemhExt = timerfactory.Create<Production.Quality.IRSQC_CheckQCItemh>(_RSQC_CheckQCItemh);
			
			return iRSQC_CheckQCItemhExt;
		}
	}
}
