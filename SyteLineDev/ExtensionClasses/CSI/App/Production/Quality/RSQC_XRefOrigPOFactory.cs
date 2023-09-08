//PROJECT NAME: Production
//CLASS NAME: RSQC_XRefOrigPOFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_XRefOrigPOFactory
	{
		public IRSQC_XRefOrigPO Create(IApplicationDB appDB)
		{
			var _RSQC_XRefOrigPO = new Production.Quality.RSQC_XRefOrigPO(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_XRefOrigPOExt = timerfactory.Create<Production.Quality.IRSQC_XRefOrigPO>(_RSQC_XRefOrigPO);
			
			return iRSQC_XRefOrigPOExt;
		}
	}
}
