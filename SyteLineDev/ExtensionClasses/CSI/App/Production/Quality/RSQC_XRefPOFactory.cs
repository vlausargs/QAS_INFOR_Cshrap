//PROJECT NAME: Production
//CLASS NAME: RSQC_XRefPOFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_XRefPOFactory
	{
		public IRSQC_XRefPO Create(IApplicationDB appDB)
		{
			var _RSQC_XRefPO = new Production.Quality.RSQC_XRefPO(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_XRefPOExt = timerfactory.Create<Production.Quality.IRSQC_XRefPO>(_RSQC_XRefPO);
			
			return iRSQC_XRefPOExt;
		}
	}
}
